using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerController : MonoBehaviour
{
    [SerializeField] Joystick moveJoystick;
    [SerializeField] float _speed = 3f;

    private float vertical;
    private float horizontal;

    private Vector3 startPlayerPosition;
    private Quaternion startPlayerRotation;

    private void Start()
    {
        startPlayerPosition = transform.position;
        startPlayerRotation = new Quaternion(0, 0, 0, 0);
    }
    void Update()
    {
        GetMobileInput();
    }

    public void GetMobileInput()
    {
        vertical = moveJoystick.Vertical;
        horizontal = moveJoystick.Horizontal;

        if (vertical >= 0.5f)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
        if (vertical <= -0.5f)
        {
            transform.position += -transform.forward * _speed * Time.deltaTime;
        }
        if (horizontal <= 0.5f)
        {
            transform.position += -transform.right * _speed * Time.deltaTime;
        }
        if (horizontal >= -0.5f)
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }



        if (transform.position.x > 7f)
        {
            transform.position = new Vector3(7f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -7f)
        {
            transform.position = new Vector3(-7f, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > 7f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 7f);
        }
        else if (transform.position.z < -7f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -7f);
        }
        
    }

    public void ResetPosition()
    {
        transform.position = startPlayerPosition;
        transform.rotation = startPlayerRotation;
    }
}
