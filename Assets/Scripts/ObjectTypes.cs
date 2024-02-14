using UnityEngine;

namespace ObjectTypes
{
    public abstract class ObjectType
    {
        public GameObject gameObject;
        public Vector3 velocity;
        
        // Getters and Setters
        
        /// <summary>
        /// Gives current position of Object
        /// </summary>
        /// <returns>Position - Vector3</returns>
        public Vector3 getPosition()
        {
            return gameObject.transform.position;
        }

        /// <summary>
        /// Sets position of Object
        /// </summary>
        /// <param name="newPosition">Vector3</param>
        public void setPosition(Vector3 newPosition)
        {
            this.gameObject.transform.position = newPosition;
        }

        /// <summary>
        /// Gives current velocity of Object
        /// </summary>
        /// <returns></returns>
        public Vector3 getVelocity()
        {
            return this.velocity;
        }

        /// <summary>
        /// Sets velocity of Object
        /// </summary>
        /// <param name="newVelocity">Vector3</param>
        public void setVelocity(Vector3 newVelocity)
        {
            this.velocity = newVelocity;
        }

        /// <summary>
        /// Updates position of Object by increment
        /// </summary>
        /// <param name="deltaPosition">Vector3</param>
        public void updatePosition(Vector3 deltaPosition)
        {
            this.gameObject.transform.position += deltaPosition;
        }

        /// <summary>
        /// Updates velocity of Object by incerement
        /// </summary>
        /// <param name="deltaVelocity">Vector3</param>
        public void updateVelocity(Vector3 deltaVelocity)
        {
            this.velocity += deltaVelocity;
        }
    }

    public class SphereObject : ObjectType
    {
        public float radius;

        public SphereObject(GameObject gameObject, Vector3 velocity, float radius)
        {
            this.gameObject = gameObject;
            this.velocity = velocity;
            this.radius = radius;
        }

        public Vector3 getRotation()
        {
            return this.gameObject.transform.eulerAngles;
        }

        public void setRotation(Vector3 rotation)
        {
            this.gameObject.transform.eulerAngles = rotation;
        }
    }

    public class CubeObject : ObjectType
    {
        public double[] vertices;
    }

    public class PlaneObject : ObjectType
    {
        public PlaneObject(GameObject gameObject, Vector3 velocity)
        {
            this.gameObject = gameObject;
            this.velocity = velocity;
        }
    }
}