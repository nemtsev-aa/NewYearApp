using UnityEngine;

namespace Eccentric {
    [ExecuteInEditMode]
    public class BulletCreaterMove : MonoBehaviour 
    {

        [Range(30f, 50f)]
        public float _mouseSensitivity;

        [Range(2f, 5f)]
        public float _moveSpeed;

        [SerializeField] FixedJoystick moveJoystick;
        [SerializeField] FixedJoystick rotateJoystick;
        [SerializeField] StopMove stopMove;

        private Vector3 startCameraPosition;
        private Quaternion startCameraRotation;

        public float max_x = 4f;
        public float max_z = 4f;
        public float min_x = -2f;
        public float min_z = -2f;

        private void Start()
        {
            startCameraPosition = transform.position;
            startCameraRotation = transform.rotation;
        }
        void LateUpdate()
        {
            if (stopMove.moveStatus == true)
            {
                Move();
                Rotate();
            }
            else
            {
                if (transform.position.x < 2f && moveJoystick.Vertical > 0)
                {
                    transform.position = new Vector3(4f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x > -2f && moveJoystick.Vertical < 0)
                {
                    transform.position = new Vector3(-4f, transform.position.y, transform.position.z);
                }
                else if (transform.position.z < 2f && moveJoystick.Horizontal > 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 4f);
                }
                else if (transform.position.z < -2f && moveJoystick.Horizontal < 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -4f);
                }
                stopMove.moveStatus = true;

                Rotate();
            }

           

            
        }
        void Move()
        {
            float right = moveJoystick.Horizontal;
            float forward = moveJoystick.Vertical;
            float up = 0;

            Vector3 offset = new Vector3(right, up, forward) * _moveSpeed * Time.unscaledDeltaTime;
            transform.Translate(offset);

            if (transform.position.x >= 4f)
            {
                transform.position = new Vector3(4f, 1.5f, transform.position.z);
            }
            if (transform.position.x <= -4f)
            {
                transform.position = new Vector3(-4f, 1.5f, transform.position.z);
            }

            if (transform.position.z >= 4f)
            {
                transform.position = new Vector3(transform.position.x, 1.5f, 4f);
            }
            if (transform.position.z <= -4f)
            {
                transform.position = new Vector3(transform.position.x, 1.5f, -4f);
            }
        }

        void Rotate()
        {

            if (rotateJoystick.Horizontal != 0f && rotateJoystick.Vertical != 0f)
            {
                Vector3 euler = new Vector3(0, 0, 0);

                if (Mathf.Abs(rotateJoystick.Horizontal) > Mathf.Abs(rotateJoystick.Vertical))
                {
                    float _yRotate;
                    if (rotateJoystick.Horizontal > 0f)
                    {
                        if (transform.rotation.y < 20f)
                        {
                            _yRotate = Time.deltaTime * _mouseSensitivity;
                            transform.Rotate(0, _yRotate, 0);
                        }

                    }
                    else
                    {
                        if (transform.rotation.y > -20f)
                        {
                            _yRotate = -Time.deltaTime * _mouseSensitivity;
                            transform.Rotate(0, _yRotate, 0);
                        }
                    }
                }
                else
                {
                    if (rotateJoystick.Vertical > 0f)
                    {
                        float _xRotate = -Time.deltaTime * _mouseSensitivity;
                        _xRotate = Mathf.Clamp(_xRotate, -120f, 120f);
                        transform.Rotate(_xRotate, 0, 0, Space.World);
                    }
                    else
                    {
                        float _xRotate = Time.deltaTime * _mouseSensitivity;
                        _xRotate = Mathf.Clamp(_xRotate, -10f, 180f);
                        transform.Rotate(_xRotate, 0, 0, Space.World);
                    }
                }
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z * 0f, 0f);
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 1f);
            }

        }

        public void ResetCameraPosition()
        {
            transform.position = startCameraPosition;
            transform.rotation = startCameraRotation;
        }
    }
}



