using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Seal
{
    public struct Matrix
    {
        private readonly float _m11;
        private readonly float _m12;
        private readonly float _m21;
        private readonly float _m22;
        private readonly float _m31;
        private readonly float _m32;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> struct.
        /// </summary>
        /// <param name="m11">The first element of the first row.</param>
        /// <param name="m12">The second element of the first row.</param>
        /// <param name="m21">The first element of the second row.</param>
        /// <param name="m22">The second element of the second row.</param>
        /// <param name="offsetX">The first element of the third row.</param>
        /// <param name="offsetY">The second element of the third row.</param>
        public Matrix(
            float m11,
            float m12,
            float m21,
            float m22,
            float offsetX,
            float offsetY)
        {
            _m11 = m11;
            _m12 = m12;
            _m21 = m21;
            _m22 = m22;
            _m31 = offsetX;
            _m32 = offsetY;
        }

        /// <summary>
        /// Returns the multiplicative identity matrix.
        /// </summary>
        public static Matrix Identity
        {
            get
            {
                return new Matrix(1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);
            }
        }

        /// <summary>
        /// Returns whether the matrix is the identity matrix.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return Equals(Identity);
            }
        }

        /// <summary>
        /// The first element of the first row
        /// </summary>
        public float M11
        {
            get
            {
                return _m11;
            }
        }

        /// <summary>
        /// The second element of the first row
        /// </summary>
        public float M12
        {
            get
            {
                return _m12;
            }
        }

        /// <summary>
        /// The first element of the second row
        /// </summary>
        public float M21
        {
            get
            {
                return _m21;
            }
        }

        /// <summary>
        /// The second element of the second row
        /// </summary>
        public float M22
        {
            get
            {
                return _m22;
            }
        }

        /// <summary>
        /// The first element of the third row
        /// </summary>
        public float M31
        {
            get
            {
                return _m31;
            }
        }

        /// <summary>
        /// The second element of the third row
        /// </summary>
        public float M32
        {
            get
            {
                return _m32;
            }
        }

        /// <summary>
        /// Multiplies two matrices together and returns the resulting matrix.
        /// </summary>
        /// <param name="value1">The first source matrix.</param>
        /// <param name="value2">The second source matrix.</param>
        /// <returns>The product matrix.</returns>
        public static Matrix operator *(Matrix value1, Matrix value2)
        {
            return new Matrix(
                (value1.M11 * value2.M11) + (value1.M12 * value2.M21),
                (value1.M11 * value2.M12) + (value1.M12 * value2.M22),
                (value1.M21 * value2.M11) + (value1.M22 * value2.M21),
                (value1.M21 * value2.M12) + (value1.M22 * value2.M22),
                (value1._m31 * value2.M11) + (value1._m32 * value2.M21) + value2._m31,
                (value1._m31 * value2.M12) + (value1._m32 * value2.M22) + value2._m32);
        }

        /// <summary>
        /// Negates the given matrix by multiplying all values by -1.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <returns>The negated matrix.</returns>
        public static Matrix operator -(Matrix value)
        {
            return value.Invert();
        }

        /// <summary>
        /// Returns a boolean indicating whether the given matrices are equal.
        /// </summary>
        /// <param name="value1">The first source matrix.</param>
        /// <param name="value2">The second source matrix.</param>
        /// <returns>True if the matrices are equal; False otherwise.</returns>
        public static bool operator ==(Matrix value1, Matrix value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        /// Returns a boolean indicating whether the given matrices are not equal.
        /// </summary>
        /// <param name="value1">The first source matrix.</param>
        /// <param name="value2">The second source matrix.</param>
        /// <returns>True if the matrices are not equal; False if they are equal.</returns>
        public static bool operator !=(Matrix value1, Matrix value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        /// Creates a rotation matrix using the given rotation in radians.
        /// </summary>
        /// <param name="radians">The amount of rotation, in radians.</param>
        /// <returns>A rotation matrix.</returns>
        public static Matrix CreateRotation(float radians)
        {
            float cos = (float)System.Math.Cos(radians);
            float sin = (float)System.Math.Sin(radians);
            return new Matrix(cos, sin, -sin, cos, 0, 0);
        }

        /// <summary>
        /// Creates a scale matrix from the given X and Y components.
        /// </summary>
        /// <param name="xScale">Value to scale by on the X-axis.</param>
        /// <param name="yScale">Value to scale by on the Y-axis.</param>
        /// <returns>A scaling matrix.</returns>
        public static Matrix CreateScale(float xScale, float yScale)
        {
            return CreateScale(new Vector2D(xScale, yScale));
        }

        /// <summary>
        /// Creates a scale matrix from the given vector scale.
        /// </summary>
        /// <param name="scales">The scale to use.</param>
        /// <returns>A scaling matrix.</returns>
        public static Matrix CreateScale(Vector2D scales)
        {
            return new Matrix(scales.X, 0, 0, scales.Y, 0, 0);
        }

        /// <summary>
        /// Creates a translation matrix from the given vector.
        /// </summary>
        /// <param name="position">The translation position.</param>
        /// <returns>A translation matrix.</returns>
        public static Matrix CreateTranslation(Vector2D position)
        {
            return CreateTranslation(position.X, position.Y);
        }

        /// <summary>
        /// Creates a translation matrix from the given X and Y components.
        /// </summary>
        /// <param name="xPosition">The X position.</param>
        /// <param name="yPosition">The Y position.</param>
        /// <returns>A translation matrix.</returns>
        public static Matrix CreateTranslation(float xPosition, float yPosition)
        {
            return new Matrix(1.0f, 0.0f, 0.0f, 1.0f, xPosition, yPosition);
        }

        /// <summary>
        /// Converts an ange in degrees to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(float angle)
        {
            return angle * 0.0174532925f;
        }

        /// <summary>
        /// Calculates the determinant for this matrix.
        /// </summary>
        /// <returns>The determinant.</returns>
        /// <remarks>
        /// The determinant is calculated by expanding the matrix with a third column whose
        /// values are (0,0,1).
        /// </remarks>
        public float GetDeterminant()
        {
            return (_m11 * _m22) - (_m12 * _m21);
        }

        /// <summary>
        /// Returns a boolean indicating whether the matrix is equal to the other given matrix.
        /// </summary>
        /// <param name="other">The other matrix to test equality against.</param>
        /// <returns>True if this matrix is equal to other; False otherwise.</returns>
        public bool Equals(Matrix other)
        {
            return _m11 == other.M11 &&
                   _m12 == other.M12 &&
                   _m21 == other.M21 &&
                   _m22 == other.M22 &&
                   _m31 == other.M31 &&
                   _m32 == other.M32;
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this matrix instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
            {
                return false;
            }

            return Equals((Matrix)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return M11.GetHashCode() + M12.GetHashCode() +
                   M21.GetHashCode() + M22.GetHashCode() +
                   M31.GetHashCode() + M32.GetHashCode();
        }

        /// <summary>
        /// Returns a String representing this matrix instance.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            var ci = System.Globalization.CultureInfo.CurrentCulture;
            return string.Format(
                ci,
                "{{ {{M11:{0} M12:{1}}} {{M21:{2} M22:{3}}} {{M31:{4} M32:{5}}} }}",
                M11.ToString(ci),
                M12.ToString(ci),
                M21.ToString(ci),
                M22.ToString(ci),
                M31.ToString(ci),
                M32.ToString(ci));
        }

        /// <summary>
        /// Inverts the Matrix.
        /// </summary>
        /// <returns>The inverted matrix.</returns>
        public Matrix Invert()
        {
            if (GetDeterminant() == 0)
            {
                throw new InvalidOperationException("Transform is not invertible.");
            }

            float d = GetDeterminant();

            return new Matrix(
                _m22 / d,
                -_m12 / d,
                -_m21 / d,
                _m11 / d,
                ((_m21 * _m32) - (_m22 * _m31)) / d,
                ((_m12 * _m31) - (_m11 * _m32)) / d);
        }
    }
}
