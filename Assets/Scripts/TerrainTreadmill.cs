using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTreadmill : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector3 startPosition;
    public float terrainLength;

    private void Start()
    {
        startPosition = transform.position;
//terrainLength = GetComponent<Renderer>().bounds.size.z;
    }

    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        if (transform.position.z < startPosition.z - terrainLength)
        {
            transform.position = startPosition;
        }
    }
}
