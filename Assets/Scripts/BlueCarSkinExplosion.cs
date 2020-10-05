using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarSkinExplosion : MonoBehaviour
{
    public float sphereSize = 0.2f;
    public int spheresInRow = 4;

    float spherePivotDistance;
    Vector3 spherePivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {
        //calculate pivot distance
        spherePivotDistance = sphereSize * spheresInRow / 2;
        //use this value to create pivot vector)
        spherePivot = new Vector3(spherePivotDistance, spherePivotDistance, spherePivotDistance);
    }

    /// <summary>
    /// function to explode the skeleton after too many hits
    /// </summary>
    public void ExplodeCarSkin()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < spheresInRow; x++)
        {
            for (int y = 0; y < spheresInRow; y++)
            {
                for (int z = 0; z < spheresInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }
        if (gameObject.layer == 0) // if the objects layer is default (because we want the explosion to ignore some blocks)
        {
            //get explosion position
            Vector3 explosionPos = transform.position;
            //get colliders in that position and radius
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            //add explosion force to all colliders in that overlap sphere
            foreach (Collider hit in colliders)
            {
                //get rigidbody from collider object
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //add explosion force to this body with given parameters
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
                }
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer r = piece.GetComponent<Renderer>(); // Get the renderer of the object object
        r.material.color = Color.blue; // apply the blue colour

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(sphereSize * x, sphereSize * y, sphereSize * z) - spherePivot;
        piece.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = sphereSize;

        Destroy(piece, 5); // destory piece after 5 seconds
    }
}
