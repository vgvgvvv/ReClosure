using System.Globalization;
using System.Runtime.InteropServices;
#if RE_CLOSURE_FOR_UNITY
using UnityEngine;
#endif

namespace ReClosure
{
    public struct SValue
    {
        static SValue()
        {
            _nil.ValueType = Type.Nil;
#if RE_CLOSURE_FOR_UNITY
            _nil._val._vec4 = Vector4.zero;
#endif
            _nil._obj = null;
        }

        private static readonly SValue _nil;

        public static SValue nil => _nil;

        public enum Type
        {
            Nil,
            Boolean,
            Int8,
            UInt8,
            Char,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Single,
            Double,
            String,
            Object,
#if RE_CLOSURE_FOR_UNITY
        Vector2,
        Vector3,
        Vector4,
        Vector4i,
        Quaternion,
        Color4f,
        Color32
#endif
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InternalValue
        {
            [FieldOffset(0)] internal Boolean _bool;

            [FieldOffset(0)] internal SByte _int8;

            [FieldOffset(0)] internal Byte _uint8;

            [FieldOffset(0)] internal Char _char;

            [FieldOffset(0)] internal Int16 _int16;

            [FieldOffset(0)] internal UInt16 _uint16;

            [FieldOffset(0)] internal Int32 _int32;

            [FieldOffset(0)] internal UInt32 _uint32;

            [FieldOffset(0)] internal Int64 _int64;

            [FieldOffset(0)] internal UInt64 _uint64;

            [FieldOffset(0)] internal Single _single;

            [FieldOffset(0)] internal Double _double;
#if RE_CLOSURE_FOR_UNITY
            [FieldOffset( 0 )]
            internal Vector2 _vec2;

            [FieldOffset( 0 )]
            internal Vector3 _vec3;

            [FieldOffset( 0 )]
            internal Vector4 _vec4;

            [FieldOffset( 0 )]
            internal Quaternion _quat;

            [FieldOffset( 0 )]
            internal Color _color4f;

            [FieldOffset( 0 )]
            internal Color32 _color32;
#endif
        }

        private InternalValue _val;
        private object _obj;

        public Type ValueType { get; private set; }

        public override string ToString()
        {
            switch (ValueType)
            {
                case Type.String:
                {
                    var s = _obj as string;
                    return s != null ? s : "null";
                }
                case Type.Object:
                {
                    var s = _obj;
                    return s?.ToString() ?? "null";
                }
                case Type.Double:
                    return _val._double.ToString(CultureInfo.CurrentCulture);
                case Type.Single:
                    return _val._single.ToString(CultureInfo.CurrentCulture);
                case Type.UInt64:
                    return _val._uint64.ToString();
                case Type.Int64:
                    return _val._int64.ToString();
                case Type.Int32:
                    return _val._int32.ToString();
                case Type.UInt32:
                    return _val._uint32.ToString();
                case Type.UInt16:
                    return _val._uint16.ToString();
                case Type.Int16:
                    return _val._int16.ToString();
                case Type.Char:
                    return _val._char.ToString();
                case Type.UInt8:
                    return _val._uint8.ToString();
                case Type.Int8:
                    return _val._int8.ToString();
                case Type.Boolean:
                    return _val._bool.ToString();
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return _val._vec2.ToString();
            case Type.Vector3:
                return _val._vec3.ToString();
            case Type.Vector4:
                return _val._vec4.ToString();
            case Type.Vector4i:
                return _val._vec4i.ToString();
            case Type.Quaternion:
                return _val._quat.ToString();
            case Type.Color32:
                return _val._color32.ToString();
            case Type.Color4f:
                return _val._color4f.ToString();
#endif
                case Type.Nil:
                    return "nil";
            }

            return string.Empty;
        }

        public bool ToBoolean()
        {
            switch (ValueType)
            {
                case Type.Boolean:
                    return _val._bool;
                case Type.Int8:
                case Type.UInt8:
                    return _val._int8 != 0;
                case Type.Char:
                case Type.Int16:
                case Type.UInt16:
                    return _val._int16 != 0;
                case Type.Int32:
                case Type.UInt32:
                    return _val._int32 != 0;
                case Type.Int64:
                case Type.UInt64:
                    return _val._int64 != 0;
                case Type.Single:
                    return _val._single != 0;
                case Type.Double:
                    return _val._double != 0;
                case Type.Nil:
                    return false;
                case Type.Object:
                    return true.Equals(_obj);
                case Type.String:
                    return string.IsNullOrEmpty(_obj as string);
            }

            return false;
        }

        public sbyte ToSByte()
        {
            switch (ValueType)
            {
                case Type.Int8:
                    return _val._int8;
                case Type.UInt8:
                    return (sbyte)_val._uint8;
                case Type.Boolean:
                    return (sbyte)(_val._bool ? 1 : 0);
                case Type.Char:
                    return (sbyte)_val._char;
                case Type.Int16:
                    return (sbyte)_val._int16;
                case Type.UInt16:
                    return (sbyte)_val._uint16;
                case Type.Int32:
                    return (sbyte)_val._int32;
                case Type.UInt32:
                    return (sbyte)_val._uint32;
                case Type.Int64:
                    return (sbyte)_val._int64;
                case Type.UInt64:
                    return (sbyte)_val._uint64;
                case Type.Single:
                    return (sbyte)_val._single;
                case Type.Double:
                    return (sbyte)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( SByte )_val._vec2.x;
            case Type.Vector3:
                return ( SByte )_val._vec3.x;
            case Type.Vector4:
                return ( SByte )_val._vec4.x;
            case Type.Quaternion:
                return ( SByte )_val._quat.x;
            case Type.Color32:
                return ( SByte )_val._color32.r;
            case Type.Color4f:
                return ( SByte )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public byte ToByte()
        {
            switch (ValueType)
            {
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return (byte)_val._int8;
                case Type.Boolean:
                    return (byte)(_val._bool ? 1 : 0);
                case Type.Char:
                    return (byte)_val._char;
                case Type.Int16:
                    return (byte)_val._int16;
                case Type.UInt16:
                    return (byte)_val._uint16;
                case Type.Int32:
                    return (byte)_val._int32;
                case Type.UInt32:
                    return (byte)_val._uint32;
                case Type.Int64:
                    return (byte)_val._int64;
                case Type.UInt64:
                    return (byte)_val._uint64;
                case Type.Single:
                    return (byte)_val._single;
                case Type.Double:
                    return (byte)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Byte )_val._vec2.x;
            case Type.Vector3:
                return ( Byte )_val._vec3.x;
            case Type.Vector4:
                return ( Byte )_val._vec4.x;
            case Type.Quaternion:
                return ( Byte )_val._quat.x;
            case Type.Color32:
                return ( Byte )_val._color32.r;
            case Type.Color4f:
                return ( Byte )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public char ToChar()
        {
            switch (ValueType)
            {
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return (char)_val._uint8;
                case Type.Int8:
                    return (char)_val._int8;
                case Type.Boolean:
                    return (char)(_val._bool ? 1 : 0);
                case Type.Int16:
                    return (char)_val._int16;
                case Type.UInt16:
                    return (char)_val._uint16;
                case Type.Int32:
                    return (char)_val._int32;
                case Type.UInt32:
                    return (char)_val._uint32;
                case Type.Int64:
                    return (char)_val._int64;
                case Type.UInt64:
                    return (char)_val._uint64;
                case Type.Single:
                    return (char)_val._single;
                case Type.Double:
                    return (char)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Char )_val._vec2.x;
            case Type.Vector3:
                return ( Char )_val._vec3.x;
            case Type.Vector4:
                return ( Char )_val._vec4.x;
            case Type.Quaternion:
                return ( Char )_val._quat.x;
            case Type.Color32:
                return ( Char )_val._color32.r;
            case Type.Color4f:
                return ( Char )( _val._color4f.r * 255.0f );
#endif
            }

            return '\0';
        }

        public short ToInt16()
        {
            switch (ValueType)
            {
                case Type.Int16:
                    return _val._int16;
                case Type.Char:
                    return (short)_val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return _val._int8;
                case Type.Boolean:
                    return (short)(_val._bool ? 1 : 0);
                case Type.UInt16:
                    return (short)_val._uint16;
                case Type.Int32:
                    return (short)_val._int32;
                case Type.UInt32:
                    return (short)_val._uint32;
                case Type.Int64:
                    return (short)_val._int64;
                case Type.UInt64:
                    return (short)_val._uint64;
                case Type.Single:
                    return (short)_val._single;
                case Type.Double:
                    return (short)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Int16 )_val._vec2.x;
            case Type.Vector3:
                return ( Int16 )_val._vec3.x;
            case Type.Vector4:
                return ( Int16 )_val._vec4.x;
            case Type.Quaternion:
                return ( Int16 )_val._quat.x;
            case Type.Color32:
                return ( Int16 )_val._color32.r;
            case Type.Color4f:
                return ( Int16 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public ushort ToUInt16()
        {
            switch (ValueType)
            {
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return (ushort)_val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return (ushort)_val._int8;
                case Type.Boolean:
                    return (ushort)(_val._bool ? 1 : 0);
                case Type.Int32:
                    return (ushort)_val._int32;
                case Type.UInt32:
                    return (ushort)_val._uint32;
                case Type.Int64:
                    return (ushort)_val._int64;
                case Type.UInt64:
                    return (ushort)_val._uint64;
                case Type.Single:
                    return (ushort)_val._single;
                case Type.Double:
                    return (ushort)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( UInt16 )_val._vec2.x;
            case Type.Vector3:
                return ( UInt16 )_val._vec3.x;
            case Type.Vector4:
                return ( UInt16 )_val._vec4.x;
            case Type.Quaternion:
                return ( UInt16 )_val._quat.x;
            case Type.Color32:
                return ( UInt16 )_val._color32.r;
            case Type.Color4f:
                return ( UInt16 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public int ToInt32()
        {
            switch (ValueType)
            {
                case Type.Int32:
                    return _val._int32;
                case Type.UInt32:
                    return (int)_val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return _val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return _val._int8;
                case Type.Boolean:
                    return _val._bool ? 1 : 0;
                case Type.Int64:
                    return (int)_val._int64;
                case Type.UInt64:
                    return (int)_val._uint64;
                case Type.Single:
                    return (int)_val._single;
                case Type.Double:
                    return (int)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Int32 )_val._vec2.x;
            case Type.Vector3:
                return ( Int32 )_val._vec3.x;
            case Type.Vector4:
                return ( Int32 )_val._vec4.x;
            case Type.Quaternion:
                return ( Int32 )_val._quat.x;
            case Type.Color32:
                return ( Int32 )_val._color32.r;
            case Type.Color4f:
                return ( Int32 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public uint ToUInt32()
        {
            switch (ValueType)
            {
                case Type.UInt32:
                    return _val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return (uint)_val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return (uint)_val._int8;
                case Type.Boolean:
                    return (uint)(_val._bool ? 1 : 0);
                case Type.Int32:
                    return (uint)_val._int32;
                case Type.Int64:
                    return (uint)_val._int64;
                case Type.UInt64:
                    return (uint)_val._uint64;
                case Type.Single:
                    return (uint)_val._single;
                case Type.Double:
                    return (uint)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( UInt32 )_val._vec2.x;
            case Type.Vector3:
                return ( UInt32 )_val._vec3.x;
            case Type.Vector4:
                return ( UInt32 )_val._vec4.x;
            case Type.Quaternion:
                return ( UInt32 )_val._quat.x;
            case Type.Color32:
                return ( UInt32 )_val._color32.r;
            case Type.Color4f:
                return ( UInt32 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public long ToInt64()
        {
            switch (ValueType)
            {
                case Type.Int64:
                    return _val._int64;
                case Type.Int32:
                    return _val._int32;
                case Type.UInt32:
                    return _val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return _val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return _val._int8;
                case Type.Boolean:
                    return _val._bool ? 1 : 0;
                case Type.UInt64:
                    return (long)_val._uint64;
                case Type.Single:
                    return (long)_val._single;
                case Type.Double:
                    return (long)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Int64 )_val._vec2.x;
            case Type.Vector3:
                return ( Int64 )_val._vec3.x;
            case Type.Vector4:
                return ( Int64 )_val._vec4.x;
            case Type.Quaternion:
                return ( Int64 )_val._quat.x;
            case Type.Color32:
                return ( Int64 )_val._color32.r;
            case Type.Color4f:
                return ( Int64 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public ulong ToUInt64()
        {
            switch (ValueType)
            {
                case Type.UInt64:
                    return _val._uint64;
                case Type.Int64:
                    return (ulong)_val._int64;
                case Type.Int32:
                    return (ulong)_val._int32;
                case Type.UInt32:
                    return _val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return (ulong)_val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return (ulong)_val._int8;
                case Type.Boolean:
                    return (ulong)(_val._bool ? 1 : 0);
                case Type.Single:
                    return (ulong)_val._single;
                case Type.Double:
                    return (ulong)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( UInt64 )_val._vec2.x;
            case Type.Vector3:
                return ( UInt64 )_val._vec3.x;
            case Type.Vector4:
                return ( UInt64 )_val._vec4.x;
            case Type.Quaternion:
                return ( UInt64 )_val._quat.x;
            case Type.Color32:
                return ( UInt64 )_val._color32.r;
            case Type.Color4f:
                return ( UInt64 )( _val._color4f.r * 255.0f );
#endif
            }

            return 0;
        }

        public float ToSingle()
        {
            switch (ValueType)
            {
                case Type.Single:
                    return _val._single;
                case Type.UInt64:
                    return _val._uint64;
                case Type.Int64:
                    return _val._int64;
                case Type.Int32:
                    return _val._int32;
                case Type.UInt32:
                    return _val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return _val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return _val._int8;
                case Type.Boolean:
                    return _val._bool ? 1 : 0;
                case Type.Double:
                    return (float)_val._double;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return _val._vec2.x;
            case Type.Vector3:
                return _val._vec3.x;
            case Type.Vector4:
                return _val._vec4.x;
            case Type.Quaternion:
                return _val._quat.x;
            case Type.Color32:
                return ( _val._color32.r / 255.0f );
            case Type.Color4f:
                return _val._color4f.r;
#endif
            }

            return 0;
        }

        public double ToDouble()
        {
            switch (ValueType)
            {
                case Type.Double:
                    return _val._double;
                case Type.Single:
                    return _val._single;
                case Type.UInt64:
                    return _val._uint64;
                case Type.Int64:
                    return _val._int64;
                case Type.Int32:
                    return _val._int32;
                case Type.UInt32:
                    return _val._uint32;
                case Type.UInt16:
                    return _val._uint16;
                case Type.Int16:
                    return _val._int16;
                case Type.Char:
                    return _val._char;
                case Type.UInt8:
                    return _val._uint8;
                case Type.Int8:
                    return _val._int8;
                case Type.Boolean:
                    return _val._bool ? 1 : 0;
#if RE_CLOSURE_FOR_UNITY
            case Type.Vector2:
                return ( Double )_val._vec2.x;
            case Type.Vector3:
                return ( Double )_val._vec3.x;
            case Type.Vector4:
                return ( Double )_val._vec4.x;
            case Type.Quaternion:
                return ( Double )_val._quat.x;
            case Type.Color32:
                return ( Double )( _val._color32.r / 255.0 );
            case Type.Color4f:
                return ( Double )_val._color4f.r;
#endif
            }

            return 0;
        }
#if RE_CLOSURE_FOR_UNITY
        public Vector2 ToVector2() {
            switch ( type ) {
            case Type.Vector2:
                return _val._vec2;
            case Type.Vector3:
                return new Vector2( _val._vec3.x, _val._vec3.y );
            case Type.Vector4:
                return new Vector2( _val._vec4.x, _val._vec4.y );
            case Type.Double:
                return new Vector2( ( float )_val._double, 0 );
            case Type.Single:
                return new Vector2( ( float )_val._single, 0 );
            case Type.UInt64:
                return new Vector2( ( float )_val._uint64, 0 );
            case Type.Int64:
                return new Vector2( ( float )_val._int64, 0 );
            case Type.Int32:
                return new Vector2( ( float )_val._int32, 0 );
            case Type.UInt32:
                return new Vector2( ( float )_val._uint32, 0 );
            case Type.UInt16:
                return new Vector2( ( float )_val._uint16, 0 );
            case Type.Int16:
                return new Vector2( ( float )_val._int16, 0 );
            case Type.Char:
                return new Vector2( ( float )_val._char, 0 );
            case Type.UInt8:
                return new Vector2( ( float )_val._uint8, 0 );
            case Type.Int8:
                return new Vector2( ( float )_val._int8, 0 );
            case Type.Boolean:
                return new Vector2( ( _val._bool ? 1.0f : 0 ), 0 );
            case Type.Color4f:
                return new Vector2( _val._color4f.r, _val._color4f.g );
            case Type.Color32:
                return new Vector2( _val._color32.r / 255.0f, _val._color4f.g / 255.0f );
            case Type.Quaternion:
                return new Vector2( _val._quat.x, _val._quat.y );
            case Type.Vector4i:
                return new Vector2( _val._vec4i.x, _val._vec4i.y );
            }
            return Vector2.zero;
        }

        public Vector3 ToVector3() {
            switch ( type ) {
            case Type.Vector3:
                return _val._vec3;
            case Type.Vector2:
                return new Vector3( _val._vec2.x, _val._vec2.y, 0 );
            case Type.Vector4:
                return new Vector3( _val._vec4.x, _val._vec4.y, _val._vec4.z );
            case Type.Double:
                return new Vector3( ( float )_val._double, 0, 0 );
            case Type.Single:
                return new Vector3( ( float )_val._single, 0, 0 );
            case Type.UInt64:
                return new Vector3( ( float )_val._uint64, 0, 0 );
            case Type.Int64:
                return new Vector3( ( float )_val._int64, 0, 0 );
            case Type.Int32:
                return new Vector3( ( float )_val._int32, 0, 0 );
            case Type.UInt32:
                return new Vector3( ( float )_val._uint32, 0, 0 );
            case Type.UInt16:
                return new Vector3( ( float )_val._uint16, 0, 0 );
            case Type.Int16:
                return new Vector3( ( float )_val._int16, 0, 0 );
            case Type.Char:
                return new Vector3( ( float )_val._char, 0, 0 );
            case Type.UInt8:
                return new Vector3( ( float )_val._uint8, 0, 0 );
            case Type.Int8:
                return new Vector3( ( float )_val._int8, 0, 0 );
            case Type.Boolean:
                return new Vector3( ( _val._bool ? 1.0f : 0 ), 0, 0 );
            case Type.Color4f:
                return new Vector3( _val._color4f.r, _val._color4f.g, _val._color4f.b );
            case Type.Color32:
                return new Vector3( _val._color32.r / 255.0f, _val._color4f.g / 255.0f, _val._color4f.b / 255.0f );
            case Type.Quaternion:
                return new Vector3( _val._quat.x, _val._quat.y, _val._quat.z );
            case Type.Vector4i:
                return new Vector3( _val._vec4i.x, _val._vec4i.y, _val._vec4i.z );
            }
            return Vector3.zero;
        }

        public Vector4 ToVector4() {
            switch ( type ) {
            case Type.Vector4:
                return _val._vec4;
            case Type.Vector3:
                return new Vector4( _val._vec3.x, _val._vec3.y, _val._vec3.z, 0 );
            case Type.Vector2:
                return new Vector4( _val._vec2.x, _val._vec2.y, 0, 0 );
            case Type.Double:
                return new Vector4( ( float )_val._double, 0, 0, 0 );
            case Type.Single:
                return new Vector4( ( float )_val._single, 0, 0, 0 );
            case Type.UInt64:
                return new Vector4( ( float )_val._uint64, 0, 0, 0 );
            case Type.Int64:
                return new Vector4( ( float )_val._int64, 0, 0, 0 );
            case Type.Int32:
                return new Vector4( ( float )_val._int32, 0, 0, 0 );
            case Type.UInt32:
                return new Vector4( ( float )_val._uint32, 0, 0, 0 );
            case Type.UInt16:
                return new Vector4( ( float )_val._uint16, 0, 0, 0 );
            case Type.Int16:
                return new Vector4( ( float )_val._int16, 0, 0, 0 );
            case Type.Char:
                return new Vector4( ( float )_val._char, 0, 0, 0 );
            case Type.UInt8:
                return new Vector4( ( float )_val._uint8, 0, 0, 0 );
            case Type.Int8:
                return new Vector4( ( float )_val._int8, 0, 0, 0 );
            case Type.Boolean:
                return new Vector4( ( _val._bool ? 1.0f : 0 ), 0, 0, 0 );
            case Type.Color4f:
                return new Vector4( _val._color4f.r, _val._color4f.g, _val._color4f.b, _val._color4f.a );
            case Type.Color32:
                return new Vector4( _val._color32.r / 255.0f, _val._color4f.g / 255.0f, _val._color4f.b / 255.0f, _val._color4f.a / 255.0f );
            case Type.Quaternion:
                return new Vector4( _val._quat.x, _val._quat.y, _val._quat.z, _val._quat.w );
            case Type.Vector4i:
                return new Vector4( _val._vec4i.x, _val._vec4i.y, _val._vec4i.z, _val._vec4i.w );
            }
            return Vector3.zero;
        }

        public Quaternion ToQuaternion() {
            switch ( type ) {
            case Type.Quaternion:
                return _val._quat;
            case Type.Vector4:
                return new Quaternion( _val._vec4.x, _val._vec4.y, _val._vec4.z, _val._vec4.w );
            case Type.Vector3:
                return new Quaternion( _val._vec3.x, _val._vec3.y, _val._vec3.z, 0 );
            case Type.Vector2:
                return new Quaternion( _val._vec2.x, _val._vec2.y, 0, 0 );
            case Type.Double:
                return new Quaternion( ( float )_val._double, 0, 0, 0 );
            case Type.Single:
                return new Quaternion( ( float )_val._single, 0, 0, 0 );
            case Type.UInt64:
                return new Quaternion( ( float )_val._uint64, 0, 0, 0 );
            case Type.Int64:
                return new Quaternion( ( float )_val._int64, 0, 0, 0 );
            case Type.Int32:
                return new Quaternion( ( float )_val._int32, 0, 0, 0 );
            case Type.UInt32:
                return new Quaternion( ( float )_val._uint32, 0, 0, 0 );
            case Type.UInt16:
                return new Quaternion( ( float )_val._uint16, 0, 0, 0 );
            case Type.Int16:
                return new Quaternion( ( float )_val._int16, 0, 0, 0 );
            case Type.Char:
                return new Quaternion( ( float )_val._char, 0, 0, 0 );
            case Type.UInt8:
                return new Quaternion( ( float )_val._uint8, 0, 0, 0 );
            case Type.Int8:
                return new Quaternion( ( float )_val._int8, 0, 0, 0 );
            case Type.Boolean:
                return new Quaternion( ( _val._bool ? 1.0f : 0 ), 0, 0, 0 );
            case Type.Color4f:
                return new Quaternion( _val._color4f.r, _val._color4f.g, _val._color4f.b, _val._color4f.a );
            case Type.Color32:
                return new Quaternion( _val._color32.r / 255.0f, _val._color4f.g / 255.0f, _val._color4f.b / 255.0f, _val._color4f.a / 255.0f );
            case Type.Vector4i:
                return new Quaternion( _val._vec4i.x, _val._vec4i.y, _val._vec4i.z, _val._vec4i.w );
            }
            return Quaternion.identity;
        }

        public Color ToColor() {
            switch ( type ) {
            case Type.Color4f:
                return _val._color4f;
            case Type.Color32:
                return _val._color32;
            case Type.Quaternion:
                return new Color( _val._quat.x, _val._quat.y, _val._quat.z, _val._quat.w );
            case Type.Vector4:
                return new Color( _val._vec4.x, _val._vec4.y, _val._vec4.z, _val._vec4.w );
            case Type.Vector4i:
                return new Color( _val._vec4i.x / 255.0f, _val._vec4i.y / 255.0f, _val._vec4i.z / 255.0f, _val._vec4i.w / 255.0f );
            case Type.Vector3:
                return new Color( _val._vec3.x, _val._vec3.y, _val._vec3.z, 0 );
            case Type.Vector2:
                return new Color( _val._vec2.x, _val._vec2.y, 0, 0 );
            case Type.Double:
                return new Color( ( float )_val._double, 0, 0, 0 );
            case Type.Single:
                return new Color( ( float )_val._single, 0, 0, 0 );
            case Type.UInt64:
                return new Color( ( float )_val._uint64, 0, 0, 0 );
            case Type.Int64:
                return new Color( ( float )_val._int64, 0, 0, 0 );
            case Type.Int32:
                return new Color( ( float )_val._int32, 0, 0, 0 );
            case Type.UInt32:
                return new Color( ( float )_val._uint32, 0, 0, 0 );
            case Type.UInt16:
                return new Color( ( float )_val._uint16, 0, 0, 0 );
            case Type.Int16:
                return new Color( ( float )_val._int16, 0, 0, 0 );
            case Type.Char:
                return new Color( ( float )_val._char, 0, 0, 0 );
            case Type.UInt8:
                return new Color( ( float )_val._uint8, 0, 0, 0 );
            case Type.Int8:
                return new Color( ( float )_val._int8, 0, 0, 0 );
            case Type.Boolean:
                return new Color( ( _val._bool ? 1.0f : 0 ), 0, 0, 0 );
            }
            return Color.black;
        }

        public Color32 ToColor32() {
            switch ( type ) {
            case Type.Color32:
                return _val._color32;
            case Type.Color4f:
                return _val._color4f;
            case Type.Quaternion:
                return new Color( _val._quat.x, _val._quat.y, _val._quat.z, _val._quat.w );
            case Type.Vector4:
                return new Color( _val._vec4.x, _val._vec4.y, _val._vec4.z, _val._vec4.w );
            case Type.Vector4i:
                return new Color32( ( byte )_val._vec4i.x, ( byte )_val._vec4i.y, ( byte )_val._vec4i.z, ( byte )_val._vec4i.w );
            case Type.Vector3:
                return new Color( _val._vec3.x, _val._vec3.y, _val._vec3.z, 0 );
            case Type.Vector2:
                return new Color( _val._vec2.x, _val._vec2.y, 0, 0 );
            case Type.Double:
                return new Color( ( float )_val._double, 0, 0, 0 );
            case Type.Single:
                return new Color( ( float )_val._single, 0, 0, 0 );
            case Type.UInt64:
                return new Color( ( float )_val._uint64, 0, 0, 0 );
            case Type.Int64:
                return new Color( ( float )_val._int64, 0, 0, 0 );
            case Type.Int32:
                return new Color( ( float )_val._int32, 0, 0, 0 );
            case Type.UInt32:
                return new Color( ( float )_val._uint32, 0, 0, 0 );
            case Type.UInt16:
                return new Color( ( float )_val._uint16, 0, 0, 0 );
            case Type.Int16:
                return new Color( ( float )_val._int16, 0, 0, 0 );
            case Type.Char:
                return new Color( ( float )_val._char, 0, 0, 0 );
            case Type.UInt8:
                return new Color( ( float )_val._uint8, 0, 0, 0 );
            case Type.Int8:
                return new Color( ( float )_val._int8, 0, 0, 0 );
            case Type.Boolean:
                return new Color( ( _val._bool ? 1 : 0 ), 0, 0, 0 );
            }
            return Color.black;
        }
#endif
        public object ToObject()
        {
            if (ValueType == Type.Object) return _obj;
            return null;
        }

        public static SValue FromObject(object val)
        {
            return new SValue
            {
                ValueType = Type.Object,
                _obj = val
            };
        }

        public static SValue Ctor(bool val)
        {
            return new SValue
            {
                ValueType = Type.Boolean,
                _val = new InternalValue { _bool = val }
            };
        }

        public static SValue Ctor(byte val)
        {
            return new SValue
            {
                ValueType = Type.UInt8,
                _val = new InternalValue { _uint8 = val }
            };
        }

        public static SValue Ctor(sbyte val)
        {
            return new SValue
            {
                ValueType = Type.Int8,
                _val = new InternalValue { _int8 = val }
            };
        }

        public static SValue Ctor(char val)
        {
            return new SValue
            {
                ValueType = Type.Char,
                _val = new InternalValue { _char = val }
            };
        }

        public static SValue Ctor(short val)
        {
            return new SValue
            {
                ValueType = Type.Int16,
                _val = new InternalValue { _int16 = val }
            };
        }

        public static SValue Ctor(ushort val)
        {
            return new SValue
            {
                ValueType = Type.UInt16,
                _val = new InternalValue { _uint16 = val }
            };
        }

        public static SValue Ctor(int val)
        {
            return new SValue
            {
                ValueType = Type.Int32,
                _val = new InternalValue { _int32 = val }
            };
        }

        public static SValue Ctor(uint val)
        {
            return new SValue
            {
                ValueType = Type.UInt32,
                _val = new InternalValue { _uint32 = val }
            };
        }

        public static SValue Ctor(long val)
        {
            return new SValue
            {
                ValueType = Type.Int64,
                _val = new InternalValue { _int64 = val }
            };
        }

        public static SValue Ctor(ulong val)
        {
            return new SValue
            {
                ValueType = Type.UInt64,
                _val = new InternalValue { _uint64 = val }
            };
        }

        public static SValue Ctor(ref long val)
        {
            return new SValue
            {
                ValueType = Type.Int64,
                _val = new InternalValue { _int64 = val }
            };
        }

        public static SValue Ctor(ref ulong val)
        {
            return new SValue
            {
                ValueType = Type.UInt64,
                _val = new InternalValue { _uint64 = val }
            };
        }

        public static SValue Ctor(float val)
        {
            return new SValue
            {
                ValueType = Type.Single,
                _val = new InternalValue { _single = val }
            };
        }

        public static SValue Ctor(double val)
        {
            return new SValue
            {
                ValueType = Type.Double,
                _val = new InternalValue { _double = val }
            };
        }

        public static SValue Ctor(ref double val)
        {
            return new SValue
            {
                ValueType = Type.Double,
                _val = new InternalValue { _double = val }
            };
        }
#if RE_CLOSURE_FOR_UNITY
        public static SValue Ctor( Vector2 val ) {
            return new SValue {
                type = Type.Vector2,
                _val = new __Value { _vec2 = val }
            };
        }

        public static SValue Ctor( ref Vector2 val ) {
            return new SValue {
                type = Type.Vector2,
                _val = new __Value { _vec2 = val }
            };
        }

        public static SValue Ctor( Vector3 val ) {
            return new SValue {
                type = Type.Vector3,
                _val = new __Value { _vec3 = val }
            };
        }

        public static SValue Ctor( ref Vector3 val ) {
            return new SValue {
                type = Type.Vector3,
                _val = new __Value { _vec3 = val }
            };
        }

        public static SValue Ctor( Vector4 val ) {
            return new SValue {
                type = Type.Vector4,
                _val = new __Value { _vec4 = val }
            };
        }

        public static SValue Ctor( ref Vector4 val ) {
            return new SValue {
                type = Type.Vector4,
                _val = new __Value { _vec4 = val }
            };
        }

        public static SValue Ctor( Quaternion val ) {
            return new SValue {
                type = Type.Quaternion,
                _val = new __Value { _quat = val }
            };
        }

        public static SValue Ctor( ref Quaternion val ) {
            return new SValue {
                type = Type.Quaternion,
                _val = new __Value { _quat = val }
            };
        }

        public static SValue Ctor( Color val ) {
            return new SValue {
                type = Type.Color4f,
                _val = new __Value { _color4f = val }
            };
        }

        public static SValue Ctor( ref Color val ) {
            return new SValue {
                type = Type.Color4f,
                _val = new __Value { _color4f = val }
            };
        }

        public static SValue Ctor( Color32 val ) {
            return new SValue {
                type = Type.Color32,
                _val = new __Value { _color32 = val }
            };
        }
#endif
        public static SValue Ctor(string val)
        {
            return new SValue
            {
                ValueType = Type.String,
                _obj = val
            };
        }

        internal static class ReaderInit
        {
            static ReaderInit()
            {
                Reader<bool>.InternalInvoke = (ref SValue s) => s.ToBoolean();
                Reader<char>.InternalInvoke = (ref SValue s) => s.ToChar();
                Reader<byte>.InternalInvoke = (ref SValue s) => s.ToByte();
                Reader<sbyte>.InternalInvoke = (ref SValue s) => s.ToSByte();
                Reader<short>.InternalInvoke = (ref SValue s) => s.ToInt16();
                Reader<ushort>.InternalInvoke = (ref SValue s) => s.ToUInt16();
                Reader<int>.InternalInvoke = (ref SValue s) => s.ToInt32();
                Reader<uint>.InternalInvoke = (ref SValue s) => s.ToUInt32();
                Reader<long>.InternalInvoke = (ref SValue s) => s.ToInt64();
                Reader<ulong>.InternalInvoke = (ref SValue s) => s.ToUInt64();
                Reader<string>.InternalInvoke = (ref SValue s) => s.ToString();
                Reader<float>.InternalInvoke = (ref SValue s) => s.ToSingle();
                Reader<double>.InternalInvoke = (ref SValue s) => s.ToDouble();
#if RE_CLOSURE_FOR_UNITY
                Reader<Vector2>._invoke = ( ref SValue s ) => s.ToVector2();
                Reader<Vector3>._invoke = ( ref SValue s ) => s.ToVector3();
                Reader<Vector4>._invoke = ( ref SValue s ) => s.ToVector4();
                Reader<Vector4i>._invoke = ( ref SValue s ) => s.ToVector4i();
                Reader<Quaternion>._invoke = ( ref SValue s ) => s.ToQuaternion();
                Reader<Color>._invoke = ( ref SValue s ) => s.ToColor();
                Reader<Color32>._invoke = ( ref SValue s ) => s.ToColor32();
#endif
                Reader<object>.InternalInvoke = (ref SValue s) => s.ToObject();
            }

            public static void DoInit()
            {
            }
        }

        internal static class WriterInit
        {
            static WriterInit()
            {
                Writer<bool>.InternalInvoke = v => Ctor(v);
                Writer<char>.InternalInvoke = v => Ctor(v);
                Writer<byte>.InternalInvoke = v => Ctor(v);
                Writer<sbyte>.InternalInvoke = v => Ctor(v);
                Writer<short>.InternalInvoke = v => Ctor(v);
                Writer<ushort>.InternalInvoke = v => Ctor(v);
                Writer<int>.InternalInvoke = v => Ctor(v);
                Writer<uint>.InternalInvoke = v => Ctor(v);
                Writer<long>.InternalInvoke = v => Ctor(ref v);
                Writer<ulong>.InternalInvoke = v => Ctor(ref v);
                Writer<string>.InternalInvoke = v => Ctor(v);
                Writer<float>.InternalInvoke = v => Ctor(v);
                Writer<double>.InternalInvoke = v => Ctor(ref v);
#if RE_CLOSURE_FOR_UNITY
                Writer<Vector2>._invoke = v => SValue.Ctor( ref v );
                Writer<Vector3>._invoke = v => SValue.Ctor( ref v );
                Writer<Vector4>._invoke = v => SValue.Ctor( ref v );
                Writer<Vector4i>._invoke = v => SValue.Ctor( ref v );
                Writer<Quaternion>._invoke = v => SValue.Ctor( ref v );
                Writer<Color>._invoke = v => SValue.Ctor( ref v );
                Writer<Color32>._invoke = v => SValue.Ctor( v );
#endif
                Writer<object>.InternalInvoke = v => FromObject(v);
            }

            public static void DoInit()
            {
            }
        }

        public class Reader<T>
        {
            internal static FuncByRef<SValue, T> InternalInvoke;
            internal static readonly FuncByRef<SValue, T> Default = (ref SValue val) => (T)val.ToObject();

            static Reader()
            {
                ReaderInit.DoInit();
            }

            public static FuncByRef<SValue, T> Invoke => InternalInvoke ?? Default;
        }

        public class Writer<T>
        {
            internal static Func<T, SValue> InternalInvoke;

            internal static readonly Func<T, SValue> Default = v =>
            {
                Debug.Assert(typeof(T).IsValueType == false, "Please avoid value type boxing!");
                return FromObject(v);
            };

            static Writer()
            {
                WriterInit.DoInit();
            }

            public static Func<T, SValue> Invoke => InternalInvoke ?? Default;

            internal delegate void TW(T v);
        }
    }
}
//EOF