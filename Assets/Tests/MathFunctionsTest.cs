using System;
using MathFunctions;
using NUnit.Framework;

namespace Tests
{
    public class MathFunctionsTest
    {
        [Test]
        [TestCase(new []{0f, 0f, 0f}, 0)]
        [TestCase(new []{2f, 0f, 0f}, 2)]
        [TestCase(new []{0f, 2f, 0f}, 2)]
        [TestCase(new []{0f, 0f, 2f}, 2)]
        [TestCase(new []{2f, 2f, 0f}, 2.82842f)]
        [TestCase(new []{0f, 2f, 2f}, 2.82842f)]
        [TestCase(new []{2f, 0f, 2f}, 2.82842f)]
        [TestCase(new []{2f, 2f, 2f}, 3.46410f)]
        public void MagnitudeTest(float[] v, float magnitude)
        {
            Assert.AreEqual(magnitude, Vector.Magnitude(v), 5);
        }

        [Test]
        [TestCase(new []{ 0f, 0f, 0f }, new []{ 0f, -1f, 0f }, 0f)]
        [TestCase(new []{ 0f, -1f, 0f }, new []{ 0f, -1f, 0f }, 0f)]
        [TestCase(new []{ 0f, -1f, 0f }, new []{ 0f, 1f, 0f }, 180f)]
        [TestCase(new []{ 0f, -1f, 0f }, new []{ 1f, 0f, 1f }, 90f)]
        [TestCase(new []{ 0f, -1f, 0f }, new []{1f, 2f, 0f}, 153.435f)]
        public void AngleBetweenVectorsTest(float[] v1, float[] v2, float angle)
        {
            Assert.AreEqual(angle, Vector.AngleBetweenVector(v1, v2), 3);
        }

        [Test]
        [TestCase(new []{ 1f, 0f, 0f }, 0, 0, 0, new []{1f, 0f, 0f})]
        
        [TestCase(new []{ 1f, 0f, 0f }, 90, 0, 0, new []{0f, 1f, 0f})]
        [TestCase(new []{ 0f, 1f, 0f }, 90, 0, 0, new []{-1f, 0f, 0f})]
        [TestCase(new []{ 0f, 0f, 1f }, 90, 0, 0, new []{0f, 0f, 1f})]
        
        [TestCase(new []{ 1f, 0f, 0f }, 0, 90, 0, new []{0f, 0f, -1f})]
        [TestCase(new []{ 0f, 1f, 0f }, 0, 90, 0, new []{0f, 1f, 0f})]
        [TestCase(new []{ 0f, 0f, 1f }, 0, 90, 0, new []{1f, 0f, 0f})]
        
        [TestCase(new []{ 1f, 0f, 0f }, 0, 0, 90, new []{1f, 0f, 0f})]
        [TestCase(new []{ 0f, 1f, 0f }, 0, 0, 90, new []{ 0f, 0f, -1f})]
        [TestCase(new []{ 0f, 0f, 1f }, 0, 0, 90, new []{0f, 1f, 0f})]
        
        [TestCase(new []{ 1f, 0f, 0f }, 45, 45, 45, new []{0.5f, 0.5f, -0.707f})]        
        [TestCase(new []{ 0f, 1f, 0f }, 45, 45, 45, new []{-0.146f, 0.854f, 0.5f})]
        [TestCase(new []{ 0f, 0f, 1f }, 45, 45, 45, new []{0.854f, -0.146f, 0.5f})]
        public void RotateVectorTest(float[] vector, float alpha, float beta, float gamma, float[] rotatedVector)
        {
            var vectorRot = Vector.RotateVector(vector, alpha, beta, gamma);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(rotatedVector[i], vectorRot[i], 5);
            }
        }
    }

    public class MainTest
    {
        public static void CollisionDetection()
        {
            
        }
    }
}

