using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxe: MonoBehaviour
{
    private int rotationSpeed = 8;
    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime * rotationSpeed);
    }
}
