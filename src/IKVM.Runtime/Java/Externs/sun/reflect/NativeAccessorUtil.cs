using IKVM.Internal;

using java.lang;

namespace IKVM.Java.Externs.sun.reflect
{

    static class NativeAccessorUtil
    {


#if FIRST_PASS == false

        /// <summary>
        /// Converts the given value to a Java primitive of the specified type.
        /// </summary>
        /// <param name="tw"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="IllegalArgumentException"></exception>
        public static object ConvertPrimitive(TypeWrapper tw, object value)
        {
            if (tw is null)
                throw new System.ArgumentNullException(nameof(tw));

            if (tw == PrimitiveTypeWrapper.BOOLEAN && value is global::java.lang.Boolean z)
            {
                return z.booleanValue();
            }
            else if (tw == PrimitiveTypeWrapper.BYTE && value is global::java.lang.Byte b)
            {
                return b.byteValue();
            }
            else if (tw == PrimitiveTypeWrapper.CHAR && value is Character c)
            {
                return c.charValue();
            }
            else if (tw == PrimitiveTypeWrapper.SHORT && value is Short s)
            {
                return s.shortValue();
            }
            else if (tw == PrimitiveTypeWrapper.SHORT && value is global::java.lang.Byte b2)
            {
                return b2.shortValue();
            }
            else if (tw == PrimitiveTypeWrapper.INT && value is Integer i)
            {
                return i.intValue();
            }
            else if (tw == PrimitiveTypeWrapper.INT && value is Short s2)
            {
                return s2.intValue();
            }
            else if (tw == PrimitiveTypeWrapper.INT && value is global::java.lang.Byte b3)
            {
                return b3.intValue();
            }
            else if (tw == PrimitiveTypeWrapper.INT && value is Character c2)
            {
                return (int)c2.charValue();
            }
            else if (tw == PrimitiveTypeWrapper.LONG && value is Long j)
            {
                return j.longValue();
            }
            else if (tw == PrimitiveTypeWrapper.LONG && value is Integer i2)
            {
                return i2.longValue();
            }
            else if (tw == PrimitiveTypeWrapper.LONG && value is Short s3)
            {
                return s3.longValue();
            }
            else if (tw == PrimitiveTypeWrapper.LONG && value is global::java.lang.Byte b4)
            {
                return b4.longValue();
            }
            else if (tw == PrimitiveTypeWrapper.LONG && value is Character c3)
            {
                return (long)c3.charValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is Float f)
            {
                return f.floatValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is Long j2)
            {
                return j2.floatValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is Integer i3)
            {
                return i3.floatValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is Short s4)
            {
                return s4.floatValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is global::java.lang.Byte b5)
            {
                return b5.floatValue();
            }
            else if (tw == PrimitiveTypeWrapper.FLOAT && value is Character c4)
            {
                return (float)c4.charValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is global::java.lang.Double d)
            {
                return d.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is Float f2)
            {
                return f2.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is Long j3)
            {
                return j3.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is Integer i4)
            {
                return i4.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is Short s5)
            {
                return s5.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is global::java.lang.Byte b6)
            {
                return b6.doubleValue();
            }
            else if (tw == PrimitiveTypeWrapper.DOUBLE && value is Character c5)
            {
                return (double)c5.charValue();
            }
            else
            {
                throw new IllegalArgumentException();
            }
        }

        /// <summary>
        /// Converts the specified objects given by <paramref name="args"/> based on the expected argument types given by <paramref name="argumentTypes"/>.
        /// </summary>
        /// <param name="loader"></param>
        /// <param name="argumentTypes"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="IllegalArgumentException"></exception>
        public static object[] ConvertArgs(ClassLoaderWrapper loader, TypeWrapper[] argumentTypes, object[] args)
        {
            if (loader is null)
                throw new System.ArgumentNullException(nameof(loader));
            if (argumentTypes is null)
                throw new System.ArgumentNullException(nameof(argumentTypes));
            if (args is null)
                throw new System.ArgumentNullException(nameof(args));

            var argv = new object[args == null ? 0 : args.Length];
            if (argv.Length != argumentTypes.Length)
                throw new IllegalArgumentException("wrong number of arguments");

            for (int i = 0; i < argv.Length; i++)
            {
                if (argumentTypes[i].IsPrimitive)
                {
                    argv[i] = ConvertPrimitive(argumentTypes[i], args[i]);
                }
                else
                {
                    if (args[i] != null && !argumentTypes[i].EnsureLoadable(loader).IsInstance(args[i]))
                        throw new IllegalArgumentException();

                    argv[i] = argumentTypes[i].GhostWrap(args[i]);
                }
            }

            return argv;
        }

#endif


    }

}
