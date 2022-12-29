using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public bool moveStatus = true;

    private void OnTriggerEnter(Collider other)
    {
        moveStatus = false;
        Debug.Log("Stop!" + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        moveStatus = true;
    }
}
