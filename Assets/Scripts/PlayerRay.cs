using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Transform Pointer;
    public Camera gameCamera;

    // Update is called once per frame
    void Update()
    {
        //Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(gameCamera.transform.position, gameCamera.transform.forward);
        Debug.DrawRay(gameCamera.transform.position, gameCamera.transform.forward * 7f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Pointer.position = hit.point;
            //Debug.DrawRay(gameCamera.transform.position, hit.point, Color.yellow);
        }
    }
}
