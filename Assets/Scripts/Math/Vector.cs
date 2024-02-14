using System;
using UnityEngine;

namespace MathFunctions
{
    public class Trig
    {
        public static float Sin(float value)
        {
            return (float)Math.Sin(value);
        }

        public static float Cos(float value)
        {
            return (float)Math.Cos(value);
        }
    }
    
    public class Vector
    {
        public static float Dot(float[] v1, float[] v2)
        {
            var dotProduct = 0f;
            
            for (var i = 0; i < v1.Length; i++)
            {
                dotProduct += v1[i] * v2[i];
            }

            return dotProduct;
        }

        public static float Magnitude(float[] v)
        {
            var length = (float)Math.Sqrt(Vector.Dot(v, v));
            return length;
        }
        
        public static float[] VectorToArray(Vector3 v)
        {
            var changedVector = new []{v.x, v.y, v.z};
            return changedVector;
        }

        public static Vector3 ArrayToVector(float[] v)
        {
            var changedVector = new Vector3(v[0], v[1], v[2]);
            return changedVector;
        }

        public static float[] RotateVector(float[] v, float alpha, float beta, float gamma)
        {
            float[,] rotationMatrix =
            {
                { Trig.Cos(alpha) * Trig.Cos(gamma), 
                    Trig.Sin(alpha) * Trig.Sin(beta) * Trig.Cos(gamma) - Trig.Cos(alpha) * Trig.Sin(gamma), 
                    Trig.Cos(alpha) * Trig.Sin(beta) * Trig.Cos(gamma) + Trig.Sin(alpha) * Trig.Sin(gamma) },
                { Trig.Cos(beta) * Trig.Sin(gamma), 
                    Trig.Sin(alpha) * Trig.Sin(beta) * Trig.Sin(gamma) + Trig.Cos(alpha) * Trig.Cos(gamma), 
                    Trig.Cos(alpha) * Trig.Sin(beta) * Trig.Sin(gamma) - Trig.Sin(alpha) * Trig.Cos(gamma) },
                { -Trig.Sin(beta), Trig.Sin(alpha) * Trig.Cos(beta), Trig.Cos(alpha) * Trig.Cos(beta)}
            };
            var rotatedVector = MultiplyMatrix(rotationMatrix, v);
            return rotatedVector;
        }
        
        public static float[] MultiplyMatrix(float[,] matrix, float[] v)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var vNew = new float[3];
            
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    vNew[i] += matrix[i,j] * v[j];
                }
            }

            return vNew;
        }
        
        /// <summary>
        /// Calculates angle between two vectors based on formula cos^(-1) (a * b / ||a|| ||b||)
        /// </summary>
        /// <param name="v1">Vector3</param>
        /// <param name="v2">Vector3</param>
        /// <returns>Angle</returns>
        public static float AngleBetweenVector(float[] v1, float[] v2)
        {
            var phi = (float)Math.Acos(Vector.Dot(v1, v2) / (Vector.Magnitude(v1) * Vector.Magnitude(v2)));
            return phi;
        }
    }
    
    
    
    
}