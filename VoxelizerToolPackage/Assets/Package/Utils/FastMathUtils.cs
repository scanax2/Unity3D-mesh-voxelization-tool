﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Voxelization.Utils
{
    public static class FastMathUtils
    {
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public static Vector3 Normalize(Vector3 value)
        {
            float mag = Magnitude(value);
            if (mag > Vector3.kEpsilon)
                return value / mag;
            else
                return Vector3.zero;
        }

        public static bool IsEquals(float a, float b)
        {
            return IsEquals(a, b, Mathf.Pow(10, -5));
        }

        public static bool IsEquals(float a, float b, float delta)
        {
            if (Abs(a - b) < delta)
            {
                return true;
            }
            return false;
        }

        public static float Magnitude(Vector3 vector)
        {
            return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        public static Vector3 Dot(Vector3 lhs, Vector3[] rhs)
        {
            Vector3 result = Vector3.zero;
            for (int i = 0; i < rhs.Length; i++)
            {
                result[i] = lhs.x * rhs[i].x + lhs.y * rhs[i].y + lhs.z * rhs[i].z;
            }
            return result;
        }

        // lhs and rhs must have the same .length
        public static float Dot(float[] lhs, float[] rhs)
        {
            float result = 0.0f;
            for (int i = 0; i < lhs.Length; i++)
            {
                result += lhs[i] * rhs[i];
            }
            return result;
        }

        // Faster than Vector3.Min
        public static Vector3 Min(Vector3 point, Vector3 min)
        {
            min.x = point.x < min.x ? point.x : min.x;
            min.y = point.y < min.y ? point.y : min.y;
            min.z = point.z < min.z ? point.z : min.z;
            return min;
        }

        // Faster than Vector3.Max
        public static Vector3 Max(Vector3 point, Vector3 max)
        {
            max.x = point.x > max.x ? point.x : max.x;
            max.y = point.y > max.y ? point.y : max.y;
            max.z = point.z > max.z ? point.z : max.z;
            return max;
        }

        // Faster than Mathf.Abs
        public static float Abs(float x)
        {
            return x > 0 ? x : -x;
        }

        // Faster than Mathf.Max
        public static float Max(float x1, float x2)
        {
            return x1 > x2 ? x1 : x2;
        }

        // Faster than Mathf.Min
        public static float Min(float x1, float x2)
        {
            return x1 < x2 ? x1 : x2;
        }

        // Fast log2 implementation
        public static int Log2(long v)
        {
            int r = (int)(0xFFFF - v >> 31 & 0x10);
            v >>= r;
            int shift = (int)(0xFF - v >> 31 & 0x8);
            v >>= shift;
            r |= shift;
            shift = (int)(0xF - v >> 31 & 0x4);
            v >>= shift;
            r |= shift;
            shift = (int)(0x3 - v >> 31 & 0x2);
            v >>= shift;
            r |= shift;
            r |= (int)(v >> 1);
            return r;
        }

        public static int TranslatePosition(float min, float pos, float delimeter)
        {
            float diff = pos - min;
            return Mathf.RoundToInt(diff / delimeter);
        }
    }
}
