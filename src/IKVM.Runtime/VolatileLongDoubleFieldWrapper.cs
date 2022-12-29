/*
  Copyright (C) 2002-2014 Jeroen Frijters

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Jeroen Frijters
  jeroen@frijters.net
  
*/
using System;
using System.Diagnostics;

#if IMPORTER || EXPORTER
using IKVM.Reflection;
using IKVM.Reflection.Emit;

using Type = IKVM.Reflection.Type;
#else
using System.Reflection;
using System.Reflection.Emit;
#endif

#if IMPORTER
using IKVM.Tools.Importer;
#endif

namespace IKVM.Internal
{

    /// <summary>
    /// Represents a volatile long or a volatile double field. Java provides for atomic operations on these values, while .NET does not.
    /// </summary>
    sealed class VolatileLongDoubleFieldWrapper : FieldWrapper
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringType"></param>
        /// <param name="fieldType"></param>
        /// <param name="fi"></param>
        /// <param name="name"></param>
        /// <param name="sig"></param>
        /// <param name="modifiers"></param>
        internal VolatileLongDoubleFieldWrapper(TypeWrapper declaringType, TypeWrapper fieldType, FieldInfo fi, string name, string sig, ExModifiers modifiers) :
            base(declaringType, fieldType, name, sig, modifiers, fi)
        {
            if (declaringType is null)
                throw new ArgumentNullException(nameof(declaringType));

            if (IsVolatile == false)
                throw new InvalidOperationException();

            if (sig != "J" && sig != "D")
                throw new InvalidOperationException();
        }

#if EMITTERS

        /// <summary>
        /// Emits IL capable of getting the value of the field.
        /// </summary>
        /// <param name="ilgen"></param>
        protected override void EmitGetImpl(CodeEmitter ilgen)
        {
            var fi = GetField();
            if (fi.IsStatic)
            {
                ilgen.Emit(OpCodes.Ldsflda, fi);
            }
            else
            {
                if (DeclaringType.IsNonPrimitiveValueType)
                    ilgen.Emit(OpCodes.Unbox, DeclaringType.TypeAsTBD);

                ilgen.Emit(OpCodes.Ldflda, fi);
            }

            if (FieldTypeWrapper == PrimitiveTypeWrapper.DOUBLE)
            {
                ilgen.Emit(OpCodes.Call, ByteCodeHelperMethods.volatileReadDouble);
            }
            else
            {
                Debug.Assert(FieldTypeWrapper == PrimitiveTypeWrapper.LONG);
                ilgen.Emit(OpCodes.Call, ByteCodeHelperMethods.volatileReadLong);
            }
        }

        /// <summary>
        /// Emits IL capable of setting the value of the field.
        /// </summary>
        /// <param name="ilgen"></param>
        protected override void EmitSetImpl(CodeEmitter ilgen)
        {
            var fi = GetField();
            var temp = ilgen.DeclareLocal(FieldTypeWrapper.TypeAsSignatureType);
            ilgen.Emit(OpCodes.Stloc, temp);

            if (fi.IsStatic)
            {
                ilgen.Emit(OpCodes.Ldsflda, fi);
            }
            else
            {
                if (DeclaringType.IsNonPrimitiveValueType)
                    ilgen.Emit(OpCodes.Unbox, DeclaringType.TypeAsTBD);

                ilgen.Emit(OpCodes.Ldflda, fi);
            }
            ilgen.Emit(OpCodes.Ldloc, temp);

            if (FieldTypeWrapper == PrimitiveTypeWrapper.DOUBLE)
            {
                ilgen.Emit(OpCodes.Call, ByteCodeHelperMethods.volatileWriteDouble);
            }
            else
            {
                Debug.Assert(FieldTypeWrapper == PrimitiveTypeWrapper.LONG);
                ilgen.Emit(OpCodes.Call, ByteCodeHelperMethods.volatileWriteLong);
            }
        }

#endif

#if !IMPORTER && !EXPORTER && !FIRST_PASS

        /// <summary>
        /// Gets the value of the field.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal override object GetValue(object obj)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Sets the value of the field.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        internal override void SetValue(object obj, object value)
        {
            throw new InvalidOperationException();
        }

#endif

    }

}
