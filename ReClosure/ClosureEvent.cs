using System;
using System.Collections.Generic;

namespace ReClosure
{
    // Memory friendly multi-cast-delegate implementation
    // It could eliminate unnecessary GC-allocation for delegate cloning( add, remove )
    // Usage:
    // class Test {
    //    ClosureEvent<int> callback;
    //    Test() {
    //        callback += Func;
    //        if ( callback ) {
    //            callback.Invoke( 0 );
    //        }
    //    }
    //    void Func( int a ) {
    //        // no problem at all
    //        callback -= Func;
    //    }
    //}

    internal class ObjectPool<T> where T : class, new()
    {
        private static Queue<T> objects = new Queue<T>();
        public static void Recycle(T obj)
        {
            if (obj == null)
            {
                return;
            }
            lock (objects)
            {
                objects.Enqueue(obj);
            }
        }
        public static T Get()
        {
            if (objects.Count <= 0)
            {
                return new T();
            }
            lock (objects)
            {
                return objects.Dequeue();
            }
        }
    }

    public struct ClosureEvent
    {
        private List<ActionClosure> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static implicit operator bool(ClosureEvent exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public static ClosureEvent operator +(ClosureEvent lhs, ActionClosure rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent operator -(ClosureEvent lhs, ActionClosure rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent operator +(ClosureEvent lhs, Action rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent operator -(ClosureEvent lhs, Action rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }

        void Add(ActionClosure closure)
        {
            _calleeList = _calleeList ?? ObjectPool<List<ActionClosure>>.Get();
            _calleeList.Add(closure);
        }

        void Remove(ActionClosure closure)
        {
            var list = _calleeList;
            if (list == null) return;
            if (_depth != 0)
            {
                for (int i = 0, count = list.Count; i < count; ++i)
                {
                    if (!list[i].Equals(closure)) continue;
                    list[i].Reset();
                    if (i <= _sparseIndex) _sparseIndex = i + 1;
                }
            }
            else
            {
                list.Remove(closure);
                if (_calleeList.Count == 0)
                {
                    ObjectPool<List<ActionClosure>>.Recycle(_calleeList);
                    _calleeList = null;
                }
            }
        }

        public void Invoke()
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    if (callback.IsValid())
                        callback.Invoke();
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                    {
                        if (!list[i].IsValid()) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                        {
                            if (!list[i].IsValid()) continue;
                            list[newCount++] = list[i];
                        }

                        var removeCount = count - newCount;
                        list.RemoveRange(newCount, removeCount);
                        break;
                    }
                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure>>.Recycle(_calleeList);
                        _calleeList = null;
                    }
                    _sparseIndex = 0;
                }
            }
        }

        public bool IsEmpty()
        {
            return _calleeList == null || _calleeList.Count == 0;
        }

        public void Reset()
        {
            if (_calleeList != null)
            {
                _calleeList.Clear();
                ObjectPool<List<ActionClosure>>.Recycle(_calleeList);
                _calleeList = null;
            }
        }
    }

    public struct ClosureEvent<T>
    {
        private List<ActionClosure<T>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static ClosureEvent<T> operator +(ClosureEvent<T> lhs, ActionClosure<T> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T> operator -(ClosureEvent<T> lhs, ActionClosure<T> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T> operator +(ClosureEvent<T> lhs, Action<T> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T> operator -(ClosureEvent<T> lhs, Action<T> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T> operator +(ClosureEvent<T> lhs, ActionByRef<T> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T> operator -(ClosureEvent<T> lhs, ActionByRef<T> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }

        public static implicit operator bool(ClosureEvent<T> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0 ;
        }

        public void Add(ActionClosure<T> closure)
        {
            _calleeList = _calleeList ?? ObjectPool<List<ActionClosure<T>>>.Get();
            _calleeList.Add(closure);
        }

        public void Remove(ActionClosure<T> closure)
        {
            var list = _calleeList;
            if (list != null)
            {
                if (_depth != 0)
                {
                    for (int i = 0, count = list.Count; i < count; ++i)
                    {
                        if (list[i].IsValid() || !list[i].Equals(closure)) continue;
                        list[i].Reset();
                        if (i <= _sparseIndex) _sparseIndex = i + 1;
                    }
                }
                else
                {
                    list.Remove(closure);
                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }
                }
            }
        }

        public void Invoke(T arg)
        {
            Invoke(ref arg);
        }

        public void InvokeOut(out T arg)
        {
            arg = default;
            Invoke(ref arg);
        }

        public void Invoke(ref T arg)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback.Invoke(ref arg);
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                    {
                        if (!list[i].IsValid()) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                            if (list[i].IsValid())
                                list[newCount++] = list[i];
                        var removeCount = count - newCount;
                        list.RemoveRange(newCount, removeCount);
                        break;
                    }

                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }
                    _sparseIndex = 0;
                }
            }
        }

        public bool IsEmpty()
        {
            return _calleeList == null || _calleeList.Count == 0;
        }

        public void Reset()
        {
            if (_calleeList != null)
            {
                _calleeList.Clear();
                ObjectPool<List<ActionClosure<T>>>.Recycle(_calleeList);
                _calleeList = null;
            }
        }
    }

    public struct ClosureEvent<T1, T2>
    {
        private List<ActionClosure<T1, T2>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static ClosureEvent<T1, T2> operator +(ClosureEvent<T1, T2> lhs, ActionClosure<T1, T2> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2> operator -(ClosureEvent<T1, T2> lhs, ActionClosure<T1, T2> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2> operator +(ClosureEvent<T1, T2> lhs, Action<T1, T2> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2> operator -(ClosureEvent<T1, T2> lhs, Action<T1, T2> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2> operator +(ClosureEvent<T1, T2> lhs, ActionByRef<T1, T2> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2> operator -(ClosureEvent<T1, T2> lhs, ActionByRef<T1, T2> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        

        public static implicit operator bool(ClosureEvent<T1, T2> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public void Add(ActionClosure<T1, T2> closure)
        {
            _calleeList = _calleeList ?? ObjectPool<List<ActionClosure<T1, T2>>>.Get();
            _calleeList.Add(closure);
        }

        public void Remove(ActionClosure<T1, T2> closure)
        {
            var list = _calleeList;
            if (list == null) return;
            if (_depth != 0)
            {
                for (int i = 0, count = list.Count; i < count; ++i)
                {
                    if (list[i].IsValid() || !list[i].Equals(closure)) continue;
                    list[i].Reset();
                    if (i <= _sparseIndex) _sparseIndex = i + 1;
                }
            }
            else
            {
                list.Remove(closure);
                if (_calleeList.Count == 0)
                {
                    ObjectPool<List<ActionClosure<T1, T2>>>.Recycle(_calleeList);
                    _calleeList = null;
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            Invoke(ref arg1, ref arg2);
        }
        
        public void Invoke(ref T1 arg0, T2 arg1)
        {
            Invoke(ref arg0, ref arg1);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1)
        {
            arg0 = default;
            Invoke(ref arg0, ref arg1);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1)
        {
            Invoke(ref arg0, ref arg1);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1)
        {
            arg1 = default;
            Invoke(ref arg0, ref arg1);
        }
        
        public void Invoke(ref T1 arg1, ref T2 arg2)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback.Invoke(ref arg1, ref arg2);
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                    {
                        if (list[i].IsValid())
                        {
                            var newCount = i++;
                            for (; i < count; ++i)
                                if (list[i].IsValid())
                                    list[newCount++] = list[i];
                            var removeCount = count - newCount;
                            list.RemoveRange(newCount, removeCount);
                            break;
                        }
                    }

                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T1, T2>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }
                    _sparseIndex = 0;
                }
            }
        }
        
        public void InvokeOut(out T1 arg1, out T2 arg2)
        {
            arg1 = default;
            arg2 = default;
            Invoke(ref arg1, ref arg2);
        }

        public bool IsEmpty()
        {
            return _calleeList == null || _calleeList.Count == 0;
        }

        public void Reset()
        {
            if (_calleeList != null)
            {
                _calleeList.Clear();
                ObjectPool<List<ActionClosure<T1, T2>>>.Recycle(_calleeList);
                _calleeList = null;
            }
        }
    }

    public struct ClosureEvent<T1, T2, T3>
    {
        private List<ActionClosure<T1, T2, T3>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static ClosureEvent<T1, T2, T3> operator +(ClosureEvent<T1, T2, T3> lhs, ActionClosure<T1, T2, T3> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3> operator -(ClosureEvent<T1, T2, T3> lhs, ActionClosure<T1, T2, T3> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2, T3> operator +(ClosureEvent<T1, T2, T3> lhs, Action<T1, T2, T3> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3> operator -(ClosureEvent<T1, T2, T3> lhs, Action<T1, T2, T3> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2, T3> operator +(ClosureEvent<T1, T2, T3> lhs, ActionByRef<T1, T2, T3> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3> operator -(ClosureEvent<T1, T2, T3> lhs, ActionByRef<T1, T2, T3> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }

        public static implicit operator bool(ClosureEvent<T1, T2, T3> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public void Add(ActionClosure<T1, T2, T3> closure)
        {
            _calleeList = _calleeList ?? ObjectPool<List<ActionClosure<T1, T2, T3>>>.Get();
            _calleeList.Add(closure);
        }

        public void Remove(ActionClosure<T1, T2, T3> closure)
        {
            var list = _calleeList;
            if (list != null)
            {
                if (_depth != 0)
                {
                    for (int i = 0, count = list.Count; i < count; ++i)
                        if (list[i].IsValid() && list[i].Equals(closure))
                        {
                            list[i].Reset();
                            if (i <= _sparseIndex) _sparseIndex = i + 1;
                        }
                }
                else
                {
                    list.Remove(closure);
                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T1, T2, T3>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            Invoke(ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref T1 arg0, T2 arg1, T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, T3 arg2)
        {
            arg0 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1, T3 arg2)
        {
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(T1 arg0, T2 arg1, ref T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(T1 arg0, T2 arg1, out T3 arg2)
        {
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(ref T1 arg0, ref T2 arg1, T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(out T1 arg0, out T2 arg1, T3 arg2)
        {
            arg0 = default;
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(ref T1 arg0,  T2 arg1, ref T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, out T3 arg2)
        {
            arg0 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, ref T3 arg2)
        {
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1, out T3 arg2)
        {
            arg1 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2);
        }
        
        public void Invoke(ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback.Invoke(ref arg1, ref arg2, ref arg3);
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                    {
                        if (list[i].IsValid()) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                            if (list[i].IsValid())
                                list[newCount++] = list[i];
                        var removeCount = count - newCount;
                        list.RemoveRange(newCount, removeCount);
                        break;
                    }

                    if (_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T1, T2, T3>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }

                    _sparseIndex = 0;
                }
            }
        }
        
        public void InvokeOut(out T1 arg1, out T2 arg2, out T3 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg1, ref arg2, ref arg3);
        }

        public bool IsEmpty()
        {
            return _calleeList == null || _calleeList.Count == 0;
        }

        public void Reset()
        {
            if (_calleeList != null)
            {
                _calleeList.Clear();
                ObjectPool<List<ActionClosure<T1, T2, T3>>>.Recycle(_calleeList);
                _calleeList = null;
            }
        }
    }

    public struct ClosureEvent<T1, T2, T3, T4>
    {
        private List<ActionClosure<T1, T2, T3, T4>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static ClosureEvent<T1, T2, T3, T4> operator +(ClosureEvent<T1, T2, T3, T4> lhs, ActionClosure<T1, T2, T3, T4> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3, T4> operator -(ClosureEvent<T1, T2, T3, T4> lhs, ActionClosure<T1, T2, T3, T4> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2, T3, T4> operator +(ClosureEvent<T1, T2, T3, T4> lhs, Action<T1, T2, T3, T4> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3, T4> operator -(ClosureEvent<T1, T2, T3, T4> lhs, Action<T1, T2, T3, T4> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }
        
        public static ClosureEvent<T1, T2, T3, T4> operator +(ClosureEvent<T1, T2, T3, T4> lhs, ActionByRef<T1, T2, T3, T4> rhs)
        {
            lhs.Add(rhs);
            return lhs;
        }

        public static ClosureEvent<T1, T2, T3, T4> operator -(ClosureEvent<T1, T2, T3, T4> lhs, ActionByRef<T1, T2, T3, T4> rhs)
        {
            lhs.Remove(rhs);
            return lhs;
        }

        public static implicit operator bool(ClosureEvent<T1, T2, T3, T4> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public void Add(ActionClosure<T1, T2, T3, T4> closure)
        {
            _calleeList = _calleeList ?? ObjectPool<List<ActionClosure<T1, T2, T3, T4>>>.Get();
            _calleeList.Add(closure);
        }

        public void Remove(ActionClosure<T1, T2, T3, T4> closure)
        {
            var list = _calleeList;
            if (list == null) return;
            if (_depth != 0)
            {
                for (int i = 0, count = list.Count; i < count; ++i)
                {
                    if (list[i].IsValid() || !list[i].Equals(closure)) continue;
                    list[i].Reset();
                    if (i <= _sparseIndex) _sparseIndex = i + 1;
                }
            }
            else
            {
                list.Remove(closure);
                if (_calleeList.Count == 0)
                {
                    ObjectPool<List<ActionClosure<T1, T2, T3, T4>>>.Recycle(_calleeList);
                    _calleeList = null;
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Invoke(ref arg1, ref arg2, ref arg3, ref arg4);
        }
        
        #region Ref1
        public void Invoke(ref T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, T3 arg2, T4 arg3)
        {
            arg0 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1, T3 arg2, T4 arg3)
        {
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, T2 arg1, ref T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, T2 arg1, out T3 arg2, T4 arg3)
        {
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, T2 arg1, T3 arg2, out T4 arg3)
        {
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        #endregion
        
        #region Ref2
        public void Invoke(ref T1 arg0, ref T2 arg1, T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, out T2 arg1, T3 arg2, T4 arg3)
        {
            arg0 = default;
            arg1 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref T1 arg0,  T2 arg1, ref T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, out T3 arg2, T4 arg3)
        {
            arg0 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref T1 arg0,  T2 arg1,  T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, T3 arg2, out T4 arg3)
        {
            arg0 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, ref T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1, out T3 arg2, T4 arg3)
        {
            arg1 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0,  T2 arg1, ref T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, T2 arg1, out T3 arg2, out T4 arg3)
        {
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion
        
        #region Ref3
        
        public void Invoke(ref T1 arg0, ref T2 arg1, ref T3 arg2, T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, out T2 arg1, out T3 arg2, T4 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg2 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref T1 arg0, ref T2 arg1, T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, out T2 arg1, T3 arg2, out T4 arg3)
        {
            arg0 = default;
            arg1 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(ref T1 arg0, T2 arg1, ref T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(out T1 arg0, T2 arg1, out T3 arg2, out T4 arg3)
        {
            arg0 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void Invoke(T1 arg0, ref T2 arg1, ref T3 arg2, ref T4 arg3)
        {
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        public void InvokeOut(T1 arg0, out T2 arg1, out T3 arg2, out T4 arg3)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            Invoke(ref arg0, ref arg1, ref arg2, ref arg3);
        }
        
        #endregion

        public void Invoke(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback.Invoke(ref arg1, ref arg2, ref arg3, ref arg4);
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                    {
                        if (list[i].IsValid()) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                            if (list[i].IsValid())
                                list[newCount++] = list[i];
                        var removeCount = count - newCount;
                        list.RemoveRange(newCount, removeCount);
                        break;
                    }

                    if(_calleeList.Count == 0)
                    {
                        ObjectPool<List<ActionClosure<T1, T2, T3, T4>>>.Recycle(_calleeList);
                        _calleeList = null;
                    }

                    _sparseIndex = 0;
                }
            }
        }

        public void InvokeOut(out T1 arg1, out T2 arg2, out T3 arg3, out T4 arg4)
        {
            arg1 = default;
            arg2 = default;
            arg3 = default;
            arg4 = default;
            Invoke(ref arg1, ref arg2, ref arg3, ref arg4);
        }

        public bool IsEmpty()
        {
            return _calleeList == null || _calleeList.Count == 0;
        }

        public void Reset()
        {
            if (_calleeList != null)
            {
                _calleeList.Clear();
                ObjectPool<List<ActionClosure<T1, T2, T3, T4>>>.Recycle(_calleeList);
                _calleeList = null;
            }
        }
    }
}
//EOF