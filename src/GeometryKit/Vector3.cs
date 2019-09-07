﻿using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace GeometryKit
{
    public struct Vector3
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;
        public static readonly Vector3 ZERO_VECTOR = new Vector3(DEFAULT_COORDINATE_VALUE, DEFAULT_COORDINATE_VALUE, DEFAULT_COORDINATE_VALUE);

        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public void Zero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
        }

        public bool IsZero()
        {
            return x * x + y * y + z * z <= MathConstant.SQUARE_EPSYLON;
        }

        public void SetValues(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetValues(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public double Scalar(Vector3 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector3 Vector(Vector3 v)
        {
            return new Vector3(
                this.y * v.z - this.z * v.y,
                this.z * v.x - this.x * v.z,
                this.x * v.y - this.y * v.x
            );
        }

        public double Module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public void Normalize()
        {
            double squareModule = this.x * this.x + this.y * this.y + this.z * this.z;

            if (squareModule == 1.0 || squareModule == 0.0)
            {
                return;
            }

            if (squareModule < MathConstant.SQUARE_EPSYLON)
            {
                this.Zero();
                return;
            }

            double module = Math.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;
            this.z /= module;
        }

        public Vector3 GetNormalized()
        {
            Vector3 result = this;
            result.Normalize();
            return result;
        }

        public void Add(Vector3 v)
        {
            this.x += v.x;
            this.y += v.y;
            this.z += v.z;
        }

        public void Subtract(Vector3 v)
        {
            this.x -= v.x;
            this.y -= v.y;
            this.z -= v.z;
        }

        public void Multiply(double value)
        {
            this.x *= value;
            this.y *= value;
            this.z *= value;
        }

        public void VectorMultiplyAt(Vector3 vector)
        {
            this.SetValues(
                this.y * vector.z - this.z * vector.y,
                this.z * vector.x - this.x * vector.z,
                this.x * vector.y - this.y * vector.x
           );
        }

        public void Divide(double value)
        {
            this.x /= value;
            this.y /= value;
            this.z /= value;
        }

        public void Reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Vector3 GetReverted()
        {
            return new Vector3(-this.x, -this.y, -this.z);
        }

        public Angle AngleWith(Vector3 vector)
        {
            double m1 = this.Module();
            double m2 = vector.Module();

            if (m1 < MathConstant.EPSYLON || m2 < MathConstant.EPSYLON)
            {
                return new Angle(0.0);
            }

            return new Angle(Math.Acos(this.Scalar(vector) / (m1 * m2)));
        }

        public bool IsEqualTo(Vector3 v)
        {
            return Comparison.AreEqual(this.x, v.x) && Comparison.AreEqual(this.y, v.y) && Comparison.AreEqual(this.z, v.z);
        }

        public bool IsStrictlyEqualTo(Vector3 v)
        {
            return this.x == v.x && this.y == v.y && this.z == v.z;
        }

        public bool IsParallelTo(Vector3 v)
        {
            return Comparison.AreEqual(this.x * v.y, this.y * v.x) && Comparison.AreEqual(this.x * v.z, this.z * v.x) && Comparison.AreEqual(this.y * v.z, this.z * v.y);
        }

        public bool IsCoDirectionalTo(Vector3 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) >= 0;
        }

        public bool IsAntiDirectionalTo(Vector3 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) < 0;
        }

        public bool IsOrthogonalTo(Vector3 v)
        {
            double scalar = this.Scalar(v);
            return -MathConstant.SQUARE_EPSYLON <= scalar && scalar <= MathConstant.SQUARE_EPSYLON;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 vector, double value)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator *(double value, Vector3 vector)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator /(Vector3 vector, double value)
        {
            return new Vector3(vector.x / value, vector.y / value, vector.z / value);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public override string ToString()
        {
            return String.Format("Vector3({0}, {1}, {2})", this.x, this.y, this.z);
        }
    }
}