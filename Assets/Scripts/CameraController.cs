using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    private Vector3 StartPos;

    private Camera cam;

    private float targetPos;

    private void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) StartPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x - StartPos.x;
            targetPos = Mathf.Clamp(transform.position.x - pos, -0.40f, 0.40f);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos, speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
