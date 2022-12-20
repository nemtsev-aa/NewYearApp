using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject RotationTarget;
    public float rotationSpeed; 

    // Update is called once per frame
    void Update()
    {
        RotationTarget.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);

    }
}
