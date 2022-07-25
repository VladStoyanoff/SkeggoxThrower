using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatWidth = -15;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.z < repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
