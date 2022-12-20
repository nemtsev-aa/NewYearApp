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
    
    private GameObject viewManager;

    private void Awake()
    {
        viewManager = GameObject.Find("/Cameras/View");
        Rotation(true);
    }

    void LateUpdate()
    {
        Rotation(true);

        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _oldMousePositionY = Input.mousePosition.y;
            Rotation(false);
        }

        if (Input.GetMouseButton(0))
        {
            //Vector3 newPosition = transform.position + transform.right * Time.deltaTime * _speed;
            //newPosition.x = Mathf.Clamp(newPosition.x, 0f, 1f);
            //transform.position = newPosition;
            Rotation(false);

            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            float deltaY = Input.mousePosition.y - _oldMousePositionY;
            
            Debug.Log(deltaX);
            Debug.Log(deltaY);

            if (deltaX > 0)
            {
                _eulerY += deltaX;
                _eulerY = Mathf.Clamp(_eulerY, -3f, 3f);
                ViewObject.transform.Rotate(0, -_eulerY, 0);
            }

            if (deltaY > 0)
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
           Rotation(true);
        }
    }
    private void Rotation(bool status)
    {
        if (status)
        {
            ViewObject.transform.Rotate(0, Time.deltaTime * _speed, 0);
        } 
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
        viewManager.transform.position = new Vector3(viewManager.transform.position.x, Mathf.Clamp(_eulerY, -2f, 0f), viewManager.transform.position.z);

    }
}
