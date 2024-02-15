using System;
using Codice.CM.Common;
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

        public static float AngleToRadians(float angle)
        {
            return (float)(angle * Math.PI / 180f);
        }

        public static float RadiansToAngle(float radians)
        {
            return (float)(radians * 180 / Math.PI);
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

        /// <summary>
        /// Rotates Vector through euler rotation
        /// </summary>
        /// <param name="v">Vector to be rotated</param>
        /// <param name="alpha"> Yaw angle </param>
        /// <param name="beta"> Pitch angle </param>
        /// <param name="gamma"> Roll angle </param>
        /// <returns>Rotated Vector</returns>
        public static float[] RotateVector(float[] v, float alpha, float beta, float gamma)
        {
            float alphaRad = Trig.AngleToRadians(alpha);
            float betaRad = Trig.AngleToRadians(beta);
            float gammaRad = Trig.AngleToRadians(gamma);
            
            float[,] rotationMatrix =
            {
                { Trig.Cos(alphaRad) * Trig.Cos(betaRad), 
                    Trig.Cos(alphaRad) * Trig.Sin(betaRad) * Trig.Sin(gammaRad) - Trig.Sin(alphaRad) * Trig.Cos(gammaRad), 
                    Trig.Cos(alphaRad) * Trig.Sin(betaRad) * Trig.Cos(gammaRad) + Trig.Sin(alphaRad) * Trig.Sin(gammaRad) },
                { Trig.Sin(alphaRad) * Trig.Cos(betaRad), 
                    Trig.Sin(alphaRad) * Trig.Sin(betaRad) * Trig.Sin(gammaRad) + Trig.Cos(alphaRad) * Trig.Cos(gammaRad), 
                    Trig.Sin(alphaRad) * Trig.Sin(betaRad) * Trig.Cos(gammaRad) - Trig.Cos(alphaRad) * Trig.Sin(gammaRad) },
                { -Trig.Sin(betaRad), Trig.Cos(betaRad) * Trig.Sin(gammaRad), Trig.Cos(betaRad) * Trig.Cos(gammaRad)}
            };
            var rotatedVector = MultiplyMatrix(rotationMatrix, v);
            return rotatedVector;
        }
        
        private static float[] MultiplyMatrix(float[,] matrix, float[] v)
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
        /// Calculates angle between two vectors
        /// </summary>
        /// <param name="v1">First Vector</param>
        /// <param name="v2">Second Vector</param>
        /// <returns>Angle between v1 and v2</returns>
        public static float AngleBetweenVector(float[] v1, float[] v2)
        {
            if ((v1[0] == 0 && v1[1] == 0 && v1[2] == 0 ) || (v2[0] == 0 && v2[1] == 0 && v2[2] == 0 ))
            {
                return 0f;
            }
            var phi = (float)Math.Acos(Vector.Dot(v1, v2) / (Vector.Magnitude(v1) * Vector.Magnitude(v2)));
            return Trig.RadiansToAngle(phi);
        }
    }
}