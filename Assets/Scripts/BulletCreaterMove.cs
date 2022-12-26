using UnityEngine;

namespace Eccentric {
    [ExecuteInEditMode]
    public class BulletCreaterMove : MonoBehaviour {

        [Range(30f, 50f)]
        public float _mouseSensitivity;

        [Range(2f, 5f)]
        public float _moveSpeed;

        [SerializeField] FixedJoystick moveJoystick;
        [SerializeField] FixedJoystick rotateJoystick;

        private Vector3 startCameraPosition;
        private Quaternion startCameraRotation;

        private void Start()
        {
            startCameraPosition = transform.position;
            startCameraRotation = transform.rotation;
        }
        void Update() {

            Move();
            Rotate();
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
                transform.position = new Vector3(-4f, 1.5f, transform.position.z) ;
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

        void Rotate() {

            if (rotateJoystick.Horizontal != 0f && rotateJoystick.Vertical != 0f)
            {
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
                        _xRotate = Mathf.Clamp(_xRotate, -70f, 70f);
                        transform.Rotate(_xRotate, 0 , 0);
                   }
                   else
                   {
                        float _xRotate = Time.deltaTime * _mouseSensitivity;
                        _xRotate = Mathf.Clamp(_xRotate, -70f, 70f);
                        transform.Rotate(_xRotate, 0, 0);
                   }
                }
            }
        }
    
        public void ResetCameraPosition()
        {
            transform.position = startCameraPosition;
            transform.rotation = startCameraRotation;
        }
    }

}


