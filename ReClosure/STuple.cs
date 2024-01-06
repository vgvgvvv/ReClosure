using System.Text;

namespace ReClosure;

internal interface ISTuple
{
    public SValue this[int index] { get; }
    int Size { get; }
    string ToString(StringBuilder sb);
}

public static class STuple
{
    public static STuple<T1> Create<T1>(T1 item1)
    {
        return new STuple<T1>(item1);
    }

    public static STuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
    {
        return new STuple<T1, T2>(item1, item2);
    }

    public static STuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    {
        return new STuple<T1, T2, T3>(item1, item2, item3);
    }

    public static STuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
    {
        return new STuple<T1, T2, T3, T4>(item1, item2, item3, item4);
    }

    public static STuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4,
        T5 item5)
    {
        return new STuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
    }

    public static STuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4,
        T5 item5, T6 item6)
    {
        return new STuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
    }

    public static STuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3,
        T4 item4, T5 item5, T6 item6, T7 item7)
    {
        return new STuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
    }

    public static STuple<T1, T2, T3, T4, T5, T6, T7, STuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1,
        T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
    {
        return new STuple<T1, T2, T3, T4, T5, T6, T7, STuple<T8>>(item1, item2, item3, item4, item5, item6, item7,
            new STuple<T8>(item8));
    }
}

public struct STuple<T1> : ISTuple
{
    public T1 Item1 { get; }

    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            throw new IndexOutOfRangeException();
        }
    }
    
    public STuple(T1 item1)
    {
        Item1 = item1;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 1;
}

public struct STuple<T1, T2> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 2;
}

public struct STuple<T1, T2, T3> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 3;
}

public struct STuple<T1, T2, T3, T4> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public T4 Item4 { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            else if (index == 3)
            {
                return SValue.Writer<T4>.Invoke(Item4);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3, T4 item4)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 4;
}

public struct STuple<T1, T2, T3, T4, T5> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public T4 Item4 { get; }

    public T5 Item5 { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            else if (index == 3)
            {
                return SValue.Writer<T4>.Invoke(Item4);
            }
            else if (index == 4)
            {
                return SValue.Writer<T5>.Invoke(Item5);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 5;
}

public struct STuple<T1, T2, T3, T4, T5, T6> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public T4 Item4 { get; }

    public T5 Item5 { get; }

    public T6 Item6 { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            else if (index == 3)
            {
                return SValue.Writer<T4>.Invoke(Item4);
            }
            else if (index == 4)
            {
                return SValue.Writer<T5>.Invoke(Item5);
            }
            else if (index == 5)
            {
                return SValue.Writer<T6>.Invoke(Item6);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 6;
}

public struct STuple<T1, T2, T3, T4, T5, T6, T7> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public T4 Item4 { get; }

    public T5 Item5 { get; }

    public T6 Item6 { get; }

    public T7 Item7 { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            else if (index == 3)
            {
                return SValue.Writer<T4>.Invoke(Item4);
            }
            else if (index == 4)
            {
                return SValue.Writer<T5>.Invoke(Item5);
            }
            else if (index == 5)
            {
                return SValue.Writer<T6>.Invoke(Item6);
            }
            else if (index == 6)
            {
                return SValue.Writer<T7>.Invoke(Item7);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(")");
        return sb.ToString();
    }

    int ISTuple.Size => 7;
}

public struct STuple<T1, T2, T3, T4, T5, T6, T7, TRest> : ISTuple
{
    public T1 Item1 { get; }

    public T2 Item2 { get; }

    public T3 Item3 { get; }

    public T4 Item4 { get; }

    public T5 Item5 { get; }

    public T6 Item6 { get; }

    public T7 Item7 { get; }

    public TRest Rest { get; }
    
    public SValue this[int index]
    {
        get
        {
            if (index == 0)
            {
                return SValue.Writer<T1>.Invoke(Item1);
            }
            else if (index == 1)
            {
                return SValue.Writer<T2>.Invoke(Item2);
            }
            else if (index == 2)
            {
                return SValue.Writer<T3>.Invoke(Item3);
            }
            else if (index == 3)
            {
                return SValue.Writer<T4>.Invoke(Item4);
            }
            else if (index == 4)
            {
                return SValue.Writer<T5>.Invoke(Item5);
            }
            else if (index == 5)
            {
                return SValue.Writer<T6>.Invoke(Item6);
            }
            else if (index == 6)
            {
                return SValue.Writer<T7>.Invoke(Item7);
            }
            else if (index == 7)
            {
                return SValue.Writer<TRest>.Invoke(Rest);
            }
            throw new IndexOutOfRangeException();
        }
    }

    public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
        Item5 = item5;
        Item6 = item6;
        Item7 = item7;
        Rest = rest;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("(");
        return ((ISTuple)this).ToString(sb);
    }

    string ISTuple.ToString(StringBuilder sb)
    {
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(", ");
        return ((ISTuple)Rest).ToString(sb);
    }

    int ISTuple.Size => 7 + ((ISTuple)Rest).Size;
}