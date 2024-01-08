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
            _calleeList = _calleeList ?? new List<ActionClosure>(1);
            _calleeList.Add(closure);
        }

        void Remove(ActionClosure closure)
        {
            var list = _calleeList;
            if (list != null)
            {
                if (_depth != 0)
                {
                    for (int i = 0, count = list.Count; i < count; ++i)
                        if (list[i].Equals(closure))
                        {
                            list[i].Reset();
                            if (i <= _sparseIndex) _sparseIndex = i + 1;
                        }
                }
                else
                {
                    list.Remove(closure);
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
                    if (callback.IsValid())
                        callback.Invoke();
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
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

                    _sparseIndex = 0;
                }
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
            _calleeList = _calleeList ?? new List<ActionClosure<T>>(1);
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
                }
            }
        }

        public void Invoke(T arg)
        {
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

                    _sparseIndex = 0;
                }
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
            _calleeList = _calleeList ?? new List<ActionClosure<T1, T2>>(1);
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
            }
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            Invoke(ref arg1, ref arg2);
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

                    _sparseIndex = 0;
                }
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
            _calleeList = _calleeList ?? new List<ActionClosure<T1, T2, T3>>(1);
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
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            Invoke(ref arg1, ref arg2, ref arg3);
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

                    _sparseIndex = 0;
                }
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
            _calleeList = _calleeList ?? new List<ActionClosure<T1, T2, T3, T4>>(1);
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
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Invoke(ref arg1, ref arg2, ref arg3, ref arg4);
        }

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

                    _sparseIndex = 0;
                }
            }
        }
    }
}
//EOF