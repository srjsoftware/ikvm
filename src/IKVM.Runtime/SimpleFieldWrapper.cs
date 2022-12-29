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
    /// Represents a field of a simple type.
    /// </summary>
    sealed class SimpleFieldWrapper : FieldWrapper
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
        internal SimpleFieldWrapper(TypeWrapper declaringType, TypeWrapper fieldType, FieldInfo fi, string name, string sig, ExModifiers modifiers) :
            base(declaringType, fieldType, name, sig, modifiers, fi)
        {
            if (IsVolatile && (fieldType == PrimitiveTypeWrapper.DOUBLE || fieldType == PrimitiveTypeWrapper.LONG))
                throw new ArgumentException(nameof(fieldType));
        }

#if EMITTERS

        protected override void EmitGetImpl(CodeEmitter ilgen)
        {
            if (!IsStatic && DeclaringType.IsNonPrimitiveValueType)
                ilgen.Emit(OpCodes.Unbox, DeclaringType.TypeAsTBD);
            if (IsVolatile)
                ilgen.Emit(OpCodes.Volatile);
            ilgen.Emit(IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, GetField());
        }

        protected override void EmitSetImpl(CodeEmitter ilgen)
        {
            var fi = GetField();
            if (!IsStatic && DeclaringType.IsNonPrimitiveValueType)
            {
                var temp = ilgen.DeclareLocal(FieldTypeWrapper.TypeAsSignatureType);
                ilgen.Emit(OpCodes.Stloc, temp);
                ilgen.Emit(OpCodes.Unbox, DeclaringType.TypeAsTBD);
                ilgen.Emit(OpCodes.Ldloc, temp);
            }
            if (IsVolatile)
            {
                ilgen.Emit(OpCodes.Volatile);
            }
            ilgen.Emit(IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, fi);
            if (IsVolatile)
            {
                ilgen.EmitMemoryBarrier();
            }
        }

#endif

#if !IMPORTER && !EXPORTER && !FIRST_PASS

        internal override object GetValue(object obj)
        {
            return GetField().GetValue(obj);
        }

        internal override void SetValue(object obj, object value)
        {
            GetField().SetValue(obj, value);
        }

#endif 

    }

}
