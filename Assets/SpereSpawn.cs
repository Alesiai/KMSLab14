using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpereSpawn : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float nX;
    public float nY;
    public float nZ;

    void Start()
    {
        nY = gameObject.transform.position.y + 5;

    }

    void Update()
    {
        minX = gameObject.transform.position.x - 10;
        maxX = gameObject.transform.position.x + 10;
        minZ = gameObject.transform.position.z - 10;
        maxZ = gameObject.transform.position.z + 10;
        float red = Random.Range(.0f, 1.0f);
        float green = Random.Range(.0f, 1.0f);
        float blue = Random.Range(.0f, 1.0f);
        Color col1 = new Color(red, green, blue);

        nX = Random.Range(minX, maxX);
        nZ = Random.Range(minZ, maxZ);
        if (Input.GetKey(KeyCode.B))
        {
            GameObject cub = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cub.transform.position = new Vector3(nX, 25, nZ);
            cub.AddComponent<Rigidbody>();
            cub.GetComponent<Renderer>().material.color = col1;
        }
    }
}
