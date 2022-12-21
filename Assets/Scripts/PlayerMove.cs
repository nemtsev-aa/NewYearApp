using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject ViewObject;

    private float _oldMousePositionX;
    private float _oldMousePositionY;
    private float _eulerY;

    private float fieldOfView;

    private GameObject viewManager;
    private Camera viewCamera;

    private void Awake()
    {
        viewManager = GameObject.Find("/Cameras/View");
        viewCamera = GameObject.Find("/Cameras/View/View").GetComponent<Camera>();
    }

    void LateUpdate()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _oldMousePositionY = Input.mousePosition.y;
            Rotation(0);
        }

        if (Input.GetMouseButton(0))
        {

            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            Debug.Log(deltaX);
            float deltaY = Input.mousePosition.y - _oldMousePositionY;
            Debug.Log(deltaY);

            if (Mathf.Abs(deltaX) > 10f)
            {
                
                Rotation(deltaX * 0.7f);
            }
           

            if (deltaY > 10f)
            {
                UpMove(true);
            }
            else
            {
                UpMove(false);
            }

            //_oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
           Rotation(0);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {

            fieldOfView = viewCamera.fieldOfView;

            fieldOfView += scroll * 10f;

            fieldOfView = Mathf.Clamp(fieldOfView, 10f, 25f);

            viewCamera.fieldOfView = fieldOfView;
        }
    }
    private void Rotation(float speed)
    {
        ViewObject.transform.Rotate(0, -Time.deltaTime * speed, 0);
    }

    public void UpMove(bool status)
    {
        Vector3 oldPosition = viewManager.transform.position;
        if (status)
        {
            _eulerY = oldPosition.y + 0.5f * Time.deltaTime;
        }
        else
        {
            _eulerY = oldPosition.y - 0.5f * Time.deltaTime;
        }

        viewManager.transform.position = new Vector3(viewManager.transform.position.x, Mathf.Clamp(_eulerY, -2f, -0.4f), viewManager.transform.position.z);

    }
}
