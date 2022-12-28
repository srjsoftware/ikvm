using System;

using IKVM.Internal;

using java.lang.annotation;
using java.lang.reflect;

using static sun.rmi.rmic.iiop.CompoundType;

namespace IKVM.Java.Externs.sun.reflect
{

    /// <summary>
    /// Provides the implementations of the native methods in <see cref="global::sun.reflect.NativeConstructorAccessorImpl"/>.
    /// </summary>
    static class NativeConstructorAccessorImpl
    {

        static object ConvertPrimitive(TypeWrapper tw, object value)
        {
            if (tw == PrimitiveTypeWrapper.BOOLEAN)
                if (value is global::java.lang.Boolean b)
                    return b.booleanValue();
            else if (tw == PrimitiveTypeWrapper.BYTE)
                if (value is global::java.lang.Byte by)
                    return by.byteValue();
            else if (tw == PrimitiveTypeWrapper.CHAR)
                if (value is global::java.lang.Character c)
                    return c.charValue();
            else if (tw == PrimitiveTypeWrapper.SHORT)
                if (value is global::java.lang.Short || value is global::java.lang.Byte)
                    return ((global::java.lang.Number)value).shortValue();
            else if (tw == PrimitiveTypeWrapper.INT)
            {
                if (value is global::java.lang.Integer || value is global::java.lang.Short || value is global::java.lang.Byte)
                {
                    return ((global::java.lang.Number)value).intValue();
                }
                else if (value is global::java.lang.Character)
                {
                    return (int)((global::java.lang.Character)value).charValue();
                }
            }
            else if (tw == PrimitiveTypeWrapper.LONG)
            {
                if (value is global::java.lang.Long || value is global::java.lang.Integer || value is global::java.lang.Short || value is global::java.lang.Byte)
                {
                    return ((global::java.lang.Number)value).longValue();
                }
                else if (value is global::java.lang.Character)
                {
                    return (long)((global::java.lang.Character)value).charValue();
                }
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT)
            {
                if (value is global::java.lang.Float || value is global::java.lang.Long || value is global::java.lang.Integer || value is global::java.lang.Short || value is global::java.lang.Byte)
                {
                    return ((global::java.lang.Number)value).floatValue();
                }
                else if (value is global::java.lang.Character)
                {
                    return (float)((global::java.lang.Character)value).charValue();
                }
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE)
            {
                if (value is global::java.lang.Double || value is global::java.lang.Float || value is global::java.lang.Long || value is global::java.lang.Integer || value is global::java.lang.Short || value is global::java.lang.Byte)
                {
                    return ((global::java.lang.Number)value).doubleValue();
                }
                else if (value is global::java.lang.Character)
                {
                    return (double)((global::java.lang.Character)value).charValue();
                }
            }
            throw new global::java.lang.IllegalArgumentException();
        }

        static object[] ConvertArgs(ClassLoaderWrapper loader, TypeWrapper[] argumentTypes, object[] args)
        {
            var nargs = new object[args == null ? 0 : args.Length];
            if (nargs.Length != argumentTypes.Length)
                throw new global::java.lang.IllegalArgumentException("wrong number of arguments");

            for (int i = 0; i < nargs.Length; i++)
            {
                if (argumentTypes[i].IsPrimitive)
                {
                    nargs[i] = ConvertPrimitive(argumentTypes[i], args[i]);
                }
                else
                {
                    if (args[i] != null && !argumentTypes[i].EnsureLoadable(loader).IsInstance(args[i]))
                        throw new global::java.lang.IllegalArgumentException();

                    nargs[i] = argumentTypes[i].GhostWrap(args[i]);
                }
            }

            return nargs;
        }

        public static object newInstance0(Constructor c, object[] args)
        {
            var ctor = TypeWrapper.FromClass(c.getDeclaringClass()).GetMethodWrapper(c.getName(), c.getSignature().Replace('/', '.'), true);
            ctor.Link();
            ctor.ResolveMethod();

            var argv = ConvertArgs(ctor.DeclaringType.GetClassLoader(), ctor.GetParameters(), args);

            try
            {
                return ctor.CreateInstance(argv);
            }
            catch (Exception e)
            {
                throw new global::java.lang.reflect.InvocationTargetException(global::ikvm.runtime.Util.mapException(e));
            }
        }
    }

}
