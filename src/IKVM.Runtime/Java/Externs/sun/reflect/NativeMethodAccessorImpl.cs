using ikvm.@internal;

using IKVM.Internal;

using java.lang.reflect;

namespace IKVM.Java.Externs.sun.reflect
{

    /// <summary>
    /// Provides the implementations of the native methods in <see cref="global::sun.reflect.NativeMethodAccessorImpl"/>.
    /// </summary>
    static class NativeMethodAccessorImpl
    {

        /// <summary>
        /// Implementation of native method 'invoke0'.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="InvocationTargetException"></exception>
        public static object invoke0(Method m, object obj, object[] args)
        {
#if FIRST_PASS
            throw new NotImplementedException();
#else
            var mw = MethodWrapper.FromExecutable(m);
            mw.Link();
            mw.ResolveMethod();

            if (mw.IsStatic == false && mw.DeclaringType.IsInstance(obj) == false)
            {
                if (obj == null)
                    throw new global::java.lang.NullPointerException();

                throw new global::java.lang.IllegalArgumentException("object is not an instance of declaring class");
            }

            // if the method is an interface method, we must explicitly run <clinit>,
            // because .NET reflection doesn't
            if (mw.DeclaringType.IsInterface)
                mw.DeclaringType.RunClassInit();

            CallerID.getCallerID();
            if (mw.HasCallerID)
                args = ArrayUtil.Concat(args, callerID);

            // convert the arguments from their incoming types to the types required by the constructor
            var argv = NativeAccessorUtil.ConvertArgs(mw.DeclaringType.GetClassLoader(), mw.GetParameters(), args);

            try
            {
                return mw.Invoke(obj, argv);
            }
            catch (System.Exception e)
            {
                throw new InvocationTargetException(global::ikvm.runtime.Util.mapException(e));
            }
#endif
        }

    }

}
