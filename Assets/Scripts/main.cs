using System.Collections;
using System.Collections.Generic;
using MathFunctions;
using ObjectTypes;
using Unity.VisualScripting;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0, 10)] public float gravity;
    [Range(0, 1)] public float bounceFriction;
    [Range(0, 1)] public float ballRollFriction;
    
    List<ObjectType> movableObjects = new List<ObjectType>();
    List<ObjectType> objects = new List<ObjectType>();
    
    private void Start()
    {
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            switch (g.name)
            {
                case "Sphere":
                    var gameObjectSphere = g.gameObject;
                    var velocity = (Vector3)Variables.Object(gameObjectSphere).Get("velocity");
                    var newGameObjectSphere = new SphereObject(
                        gameObject: gameObjectSphere,
                        velocity: velocity,
                        radius:  gameObjectSphere.transform.localScale.x / 2
                    );
                    if (!g.CompareTag("static"))
                    {
                        movableObjects.Add(newGameObjectSphere);
                    }
                    objects.Add(newGameObjectSphere);
                    break;
                
                case "Plane":
                    var gameObjectPlane = g.gameObject;
                    var newGameObjectPlane = new PlaneObject(
                        gameObject: gameObjectPlane,
                        velocity: new Vector3(0, 0, 0)
                    );
                    if (!g.CompareTag("static"))
                    {
                        movableObjects.Add(newGameObjectPlane);
                    }
                    objects.Add(newGameObjectPlane);
                    break;
            } 
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (var movableObject in movableObjects)
        {
            //UpdatePosition(o: movableObject);
            CheckCollision(o1: movableObject);            
        }
    }

    /// <summary>
    /// Updates position of all movable (non static) objects
    /// </summary>
    /// <param name="o">ObjectType</param>
    
    //
    //
    //Debug.Log(o.getVelocity());
    //if (o is SphereObject)
    //{
    //    var sphere = (SphereObject)o; 
    //}

    /// <summary>
    /// Loops over all objects and passes objects to collision checkers
    /// </summary>
    /// <param name="o1">ObjectType</param>
    private void CheckCollision(ObjectType o1)
    {
        foreach (var o2 in objects)
        {
            if (o1.gameObject.name.Equals("Sphere") && o2.gameObject.name.Equals("Plane") && (o1 != o2))
            {
                SpherePlaneCollision(
                    sphere: (SphereObject)o1, 
                    plane: (PlaneObject)o2
                    );
            }

            if (o1.gameObject.name.Equals("Sphere") && o2.gameObject.name.Equals("Sphere") && (o1 != o2))
            {
                SphereSphereCollision(
                    sphere1: (SphereObject)o1,
                    sphere2: (SphereObject)o2
                    );
            }
        }
    }

    /// <summary>
    /// Checks for collision between sphere object and plane object
    /// </summary>
    /// <param name="sphere">SphereObject</param>
    /// <param name="plane">PlaneObject</param>
    private void SpherePlaneCollision(SphereObject sphere, PlaneObject plane)
    {
        var floorPosition = plane.getPosition().y;
        if ((sphere.getPosition().y - sphere.radius < floorPosition) && !(sphere.getVelocity().y <= 0.01 && sphere.getVelocity().y >= 0.01))
        {
            var bounceVelocity = sphere.getVelocity() * bounceFriction;
            bounceVelocity.y *= -1;
            sphere.setVelocity(bounceVelocity);

            var floorSphere = sphere.getPosition();
            floorSphere.y = floorPosition + sphere.radius;
            sphere.setPosition(floorSphere);
        }
        else if (sphere.getVelocity().y <= floorPosition + 0.01 && sphere.getVelocity().y >= floorPosition - 0.01)
        {
            var rollVelocity = sphere.getVelocity() * ballRollFriction;
            sphere.setVelocity(rollVelocity);
            sphere.updatePosition(sphere.velocity * Time.deltaTime);
        }
        else
        {
            sphere.updateVelocity(Vector3.down * (gravity * Time.deltaTime));
            sphere.updatePosition(sphere.getVelocity() * Time.deltaTime);
        }
    }

    private void SphereSphereCollision(SphereObject sphere1, SphereObject sphere2)
    {
        var distance = Vector.VectorToArray(sphere1.getPosition() - sphere2.getPosition());
        var distanceLength = Vector.Magnitude(distance);
        var alpha = Vector.AngleBetweenVector(Vector.VectorToArray(sphere1.velocity), Vector.VectorToArray(sphere2.velocity));
        if (distanceLength <= (sphere1.radius + sphere2.radius))
        {
            var sphere1NewVelocity = Vector.RotateVector(
                v: Vector.VectorToArray(sphere1.velocity),
                alpha: alpha,
                beta: 0f,
                gamma: 0f);
            sphere1.velocity = Vector.ArrayToVector(sphere1NewVelocity);
            
            var sphere2NewVelocity= Vector.RotateVector(
                v: Vector.VectorToArray(sphere2.velocity),
                alpha: alpha,
                beta: 0f,
                gamma: 0f);
            sphere2.velocity = Vector.ArrayToVector(sphere2NewVelocity);
        }
    }
}
