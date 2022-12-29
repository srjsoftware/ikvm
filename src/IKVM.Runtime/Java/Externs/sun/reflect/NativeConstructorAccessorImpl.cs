using System;

using IKVM.Internal;

using java.lang.reflect;

namespace IKVM.Java.Externs.sun.reflect
{

    /// <summary>
    /// Provides the implementations of the native methods in <see cref="global::sun.reflect.NativeConstructorAccessorImpl"/>.
    /// </summary>
    static class NativeConstructorAccessorImpl
    {

        /// <summary>
        /// Implementation of native method 'newInstance0'.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="InvocationTargetException"></exception>
        public static object newInstance0(Constructor c, object[] args)
        {
#if FIRST_PASS
            throw new NotImplementedException();
#else
            var ctor = MethodWrapper.FromExecutable(c);
            ctor.Link();
            ctor.ResolveMethod();

            // convert the arguments from their incoming types to the types required by the constructor
            var argv = NativeAccessorUtil.ConvertArgs(ctor.DeclaringType.GetClassLoader(), ctor.GetParameters(), args);

            try
            {
                return ctor.CreateInstance(argv);
            }
            catch (Exception e)
            {
                throw new InvocationTargetException(global::ikvm.runtime.Util.mapException(e));
            }
#endif
        }

    }

}
