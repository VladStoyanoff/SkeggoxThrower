using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [Header("Bounds")]
    float lowerBound = -20;
    float upperBound = 20;

    void Update()
    {
        if (transform.position.z < lowerBound || transform.position.z > upperBound)
        {
            Destroy(gameObject);
        }
    }
}
