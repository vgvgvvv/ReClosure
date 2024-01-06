namespace ReClosure
{
    // Memory friendly multi-cast-delegate implementation
// It could eliminate unnecessary GC-allocation for delegate cloning( add, remove )
// Usage:
// class Test {
//    BetterEvent<int> callback;
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

    public struct BetterEvent
    {
        private List<Action> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static implicit operator bool(BetterEvent exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public static BetterEvent operator +(BetterEvent lhs, Action rhs)
        {
            lhs.Slot += rhs;
            return lhs;
        }

        public static BetterEvent operator -(BetterEvent lhs, Action rhs)
        {
            lhs.Slot -= rhs;
            return lhs;
        }

        public event Action Slot
        {
            add
            {
                if (value != null)
                {
                    _calleeList = _calleeList ?? new List<Action>(1);
                    _calleeList.Add(value);
                }
            }
            remove
            {
                if (value != null)
                {
                    var list = _calleeList;
                    if (list != null)
                    {
                        if (_depth != 0)
                        {
                            for (int i = 0, count = list.Count; i < count; ++i)
                                if (list[i] != null && list[i].Equals(value))
                                {
                                    list[i] = null;
                                    if (i <= _sparseIndex) _sparseIndex = i + 1;
                                }
                        }
                        else
                        {
                            list.Remove(value);
                        }
                    }
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
                    if (callback != null)
                        callback();
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                        if (list[i] == null)
                        {
                            var newCount = i++;
                            for (; i < count; ++i)
                                if (list[i] != null)
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

    public struct BetterEvent<T>
    {
        private List<Action<T>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static BetterEvent<T> operator +(BetterEvent<T> lhs, Action<T> rhs)
        {
            lhs.Slot += rhs;
            return lhs;
        }

        public static BetterEvent<T> operator -(BetterEvent<T> lhs, Action<T> rhs)
        {
            lhs.Slot -= rhs;
            return lhs;
        }

        public static implicit operator bool(BetterEvent<T> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0 ;
        }

        public event Action<T> Slot
        {
            add
            {
                if (value != null)
                {
                    _calleeList = _calleeList ?? new List<Action<T>>(1);
                    _calleeList.Add(value);
                }
            }
            remove
            {
                if (value != null)
                {
                    var list = _calleeList;
                    if (list != null)
                    {
                        if (_depth != 0)
                        {
                            for (int i = 0, count = list.Count; i < count; ++i)
                            {
                                if (list[i] == null || !list[i].Equals(value)) continue;
                                list[i] = null;
                                if (i <= _sparseIndex) _sparseIndex = i + 1;
                            }
                        }
                        else
                        {
                            list.Remove(value);
                        }
                    }
                }
            }
        }

        public void Invoke(T arg)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback?.Invoke(arg);
                }
            }
            finally
            {
                --_depth;
                if (_sparseIndex > 0 && _depth == 0 && list.Count > 0)
                {
                    var count = list.Count;
                    for (var i = _sparseIndex - 1; i < count; ++i)
                        if (list[i] == null)
                        {
                            var newCount = i++;
                            for (; i < count; ++i)
                                if (list[i] != null)
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

    public struct BetterEvent<T1, T2>
    {
        private List<Action<T1, T2>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static BetterEvent<T1, T2> operator +(BetterEvent<T1, T2> lhs, Action<T1, T2> rhs)
        {
            lhs.Slot += rhs;
            return lhs;
        }

        public static BetterEvent<T1, T2> operator -(BetterEvent<T1, T2> lhs, Action<T1, T2> rhs)
        {
            lhs.Slot -= rhs;
            return lhs;
        }

        public static implicit operator bool(BetterEvent<T1, T2> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public event Action<T1, T2> Slot
        {
            add
            {
                if (value != null)
                {
                    _calleeList = _calleeList ?? new List<Action<T1, T2>>(1);
                    _calleeList.Add(value);
                }
            }
            remove
            {
                if (value != null)
                {
                    var list = _calleeList;
                    if (list == null) return;
                    if (_depth != 0)
                    {
                        for (int i = 0, count = list.Count; i < count; ++i)
                        {
                            if (list[i] == null || !list[i].Equals(value)) continue;
                            list[i] = null;
                            if (i <= _sparseIndex) _sparseIndex = i + 1;
                        }
                    }
                    else
                    {
                        list.Remove(value);
                    }
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback?.Invoke(arg1, arg2);
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
                        if (list[i] == null)
                        {
                            var newCount = i++;
                            for (; i < count; ++i)
                                if (list[i] != null)
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

    public struct BetterEvent<T1, T2, T3>
    {
        private List<Action<T1, T2, T3>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static BetterEvent<T1, T2, T3> operator +(BetterEvent<T1, T2, T3> lhs, Action<T1, T2, T3> rhs)
        {
            lhs.Slot += rhs;
            return lhs;
        }

        public static BetterEvent<T1, T2, T3> operator -(BetterEvent<T1, T2, T3> lhs, Action<T1, T2, T3> rhs)
        {
            lhs.Slot -= rhs;
            return lhs;
        }

        public static implicit operator bool(BetterEvent<T1, T2, T3> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public event Action<T1, T2, T3> Slot
        {
            add
            {
                if (value == null) return;
                _calleeList = _calleeList ?? new List<Action<T1, T2, T3>>(1);
                _calleeList.Add(value);
            }
            remove
            {
                if (value == null) return;
                var list = _calleeList;
                if (list != null)
                {
                    if (_depth != 0)
                    {
                        for (int i = 0, count = list.Count; i < count; ++i)
                            if (list[i] != null && list[i].Equals(value))
                            {
                                list[i] = null;
                                if (i <= _sparseIndex) _sparseIndex = i + 1;
                            }
                    }
                    else
                    {
                        list.Remove(value);
                    }
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback?.Invoke(arg1, arg2, arg3);
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
                        if (list[i] != null) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                            if (list[i] != null)
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

    public struct BetterEvent<T1, T2, T3, T4>
    {
        private List<Action<T1, T2, T3, T4>> _calleeList;
        private int _depth;
        private int _sparseIndex;

        public static BetterEvent<T1, T2, T3, T4> operator +(BetterEvent<T1, T2, T3, T4> lhs, Action<T1, T2, T3, T4> rhs)
        {
            lhs.Slot += rhs;
            return lhs;
        }

        public static BetterEvent<T1, T2, T3, T4> operator -(BetterEvent<T1, T2, T3, T4> lhs, Action<T1, T2, T3, T4> rhs)
        {
            lhs.Slot -= rhs;
            return lhs;
        }

        public static implicit operator bool(BetterEvent<T1, T2, T3, T4> exists)
        {
            return exists._calleeList != null && exists._calleeList.Count > 0;
        }

        public event Action<T1, T2, T3, T4> Slot
        {
            add
            {
                if (value != null)
                {
                    _calleeList = _calleeList ?? new List<Action<T1, T2, T3, T4>>(1);
                    _calleeList.Add(value);
                }
            }
            remove
            {
                if (value != null)
                {
                    var list = _calleeList;
                    if (list == null) return;
                    if (_depth != 0)
                    {
                        for (int i = 0, count = list.Count; i < count; ++i)
                        {
                            if (list[i] == null || !list[i].Equals(value)) continue;
                            list[i] = null;
                            if (i <= _sparseIndex) _sparseIndex = i + 1;
                        }
                    }
                    else
                    {
                        list.Remove(value);
                    }
                }
            }
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var list = _calleeList;
            if (list == null) return;
            try
            {
                ++_depth;
                foreach (var callback in list)
                {
                    callback?.Invoke(arg1, arg2, arg3, arg4);
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
                        if (list[i] != null) continue;
                        var newCount = i++;
                        for (; i < count; ++i)
                            if (list[i] != null)
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