using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector3 offset; 

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
