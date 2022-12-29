/*
  Copyright (C) 2008-2011 Jeroen Frijters

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

namespace IKVM.Reflection
{
    /// <summary>
    /// Provides conversion to and from raw integer and float values.
    /// </summary>
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
    struct SingleConverter
    {

        [System.Runtime.InteropServices.FieldOffset(0)]
        private int i;

        [System.Runtime.InteropServices.FieldOffset(0)]
        private float f;

        /// <summary>
        /// Casts the float to an int without any conversion.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static int SingleToInt32Bits(float v)
        {
            var c = new SingleConverter();
            c.f = v;
            return c.i;
        }

        /// <summary>
        /// Casts the int to a float without any conversion.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static float Int32BitsToSingle(int v)
        {
            var c = new SingleConverter();
            c.i = v;
            return c.f;
        }

    }

}
