using UnityEngine;

namespace Eccentric {

    public class BulletCreaterMove : MonoBehaviour {

        [SerializeField]
        private float _mouseSensitivity = 0.7f;
        [SerializeField]
        private float _moveSpeed = 10f;

        [SerializeField] FixedJoystick moveJoystick;
        [SerializeField] FixedJoystick rotateJoystick;

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
        }

        void Rotate() {

            if (rotateJoystick.Horizontal != 0f && rotateJoystick.Vertical != 0f)
            {
                if (Mathf.Abs(rotateJoystick.Horizontal) > Mathf.Abs(rotateJoystick.Vertical))
                {
                    if (rotateJoystick.Horizontal > 0f)
                    {
                        transform.Rotate(0, Time.deltaTime * 20f, 0);
                    }
                    else
                    {
                        transform.Rotate(0, -Time.deltaTime * 20f, 0);
                    }
                }
                else
                {
                   if (rotateJoystick.Vertical > 0f)
                   {
                      transform.Rotate(-Time.deltaTime * 20f, 0, 0);
                   }
                   else
                   {
                      transform.Rotate(Time.deltaTime * 20f, 0, 0);
                   }
                }
            }
        }
    }
}


