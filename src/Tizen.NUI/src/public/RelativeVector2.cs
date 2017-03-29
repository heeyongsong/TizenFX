/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
 using System;

namespace Tizen.NUI
{

    /// <summary>
    /// RelativeVector2 is a two dimensional vector.
    /// Both values(x and y) should be between [0, 1].
    /// </summary>
    public class RelativeVector2 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal RelativeVector2(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector2 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~RelativeVector2()
        {
            DisposeQueue.Instance.Add(this);
        }

        public virtual void Dispose()
        {
            if (!Stage.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_Vector2(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }


        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">Vector to add</param>
        /// <param name="arg2">Vector to add</param>
        /// <returns>A vector containing the result of the addition</returns>
        public static RelativeVector2 operator +(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Add(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">Vector to subtract</param>
        /// <param name="arg2">Vector to subtract</param>
        /// <returns>A vector containing the result of the subtraction</returns>
        public static RelativeVector2 operator -(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Subtract(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The vector to multiply</param>
        /// <returns>A vector containing the result of the multiplication</returns>
        public static RelativeVector2 operator *(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector2 operator *(RelativeVector2 arg1, float arg2)
        {
            RelativeVector2 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The vector to divide</param>
        /// <returns>A vector containing the result of the division</returns>
        public static RelativeVector2 operator /(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The float value to scale the vector by</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector2 operator /(RelativeVector2 arg1, float arg2)
        {
            RelativeVector2 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }


        /// <summary>
        /// Const array subscript operator overload. Should be 0, 1.
        /// </summary>
        /// <param name="index">Subscript index</param>
        /// <returns>The float at the given index</returns>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// </summary>
        internal static RelativeVector2 GetRelativeVector2FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector2 ret = new RelativeVector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public RelativeVector2() : this(NDalicPINVOKE.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x component</param>
        /// <param name="y">y component</param>
        public RelativeVector2(float x, float y) : this(NDalicPINVOKE.new_Vector2__SWIG_1(x, y), true)
        {
            ValueCheck(x);
            ValueCheck(y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector3">RelativeVector3 to create this vector from</param>
        public RelativeVector2(RelativeVector3 relativeVector3) : this(NDalicPINVOKE.new_Vector2__SWIG_3(RelativeVector3.getCPtr(relativeVector3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector4">RelativeVector4 to create this vector from</param>
        public RelativeVector2(RelativeVector4 relativeVector4) : this(NDalicPINVOKE.new_Vector2__SWIG_4(RelativeVector4.getCPtr(relativeVector4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        private RelativeVector2 Add(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Add(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Subtract(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Subtract__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Multiply(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Multiply__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Multiply(float rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Divide(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Divide__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Divide(float rhs)
        {
            RelativeVector2 ret = new RelativeVector2(NDalicPINVOKE.Vector2_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = NDalicPINVOKE.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false</returns>
        public bool EqualTo(RelativeVector2 rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, RelativeVector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false</returns>
        public bool NotEqualTo(RelativeVector2 rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_NotEqualTo(swigCPtr, RelativeVector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// x component
        /// </summary>
        public float X
        {
            set
            {
                ValueCheck(value);
                NDalicPINVOKE.Vector2_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_X_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// y component
        /// </summary>
        public float Y
        {
            set
            {
                ValueCheck(value);
                NDalicPINVOKE.Vector2_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// </summary>
        public static implicit operator Vector2(RelativeVector2 relativeVector2)
        {
            return new Vector2(relativeVector2.X, relativeVector2.Y);
        }

        /// <summary>
        /// </summary>
        public static implicit operator RelativeVector2(Vector2 vec)
        {
            ValueCheck(vec.X);
            ValueCheck(vec.Y);
            return new RelativeVector2(vec.X, vec.Y);
        }

        internal static void ValueCheck(RelativeVector2 relativeVector2)
        {
            if(relativeVector2.X < 0.0f)
            {
                relativeVector2.X = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector2.X > 1.0f)
            {
                relativeVector2.X = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector2.Y < 0.0f)
            {
                relativeVector2.Y = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector2.Y > 1.0f)
            {
                relativeVector2.Y = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
        }

        internal static void ValueCheck(float value)
        {
            if(value < 0.0f)
            {
                value = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Parameters is invalid! Should be between [0, 1].");
            }
            else if(value > 1.0f)
            {
                value = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Parameters is invalid! Should be between [0, 1].");
            }
        }
    }

}


