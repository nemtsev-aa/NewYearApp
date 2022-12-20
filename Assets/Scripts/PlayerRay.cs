using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Transform Pointer;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward*100f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            Pointer.position = hit.point;
        }
    }
}
