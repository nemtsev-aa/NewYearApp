using UnityEngine;

public class ScrinMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject ViewObject;
    
    private float _oldMousePositionX;
   
    private GameObject viewManager;
    private Camera viewCamera;

    private void Awake()
    {
        viewManager = ViewObject;
        viewCamera = ViewObject.transform.GetChild(0).GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            Rotation(0);
        }

        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            
            if (Mathf.Abs(deltaX) > 10f)
            {
                Rotation(deltaX * 0.5f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Rotation(0);
        }
    }
    private void Rotation(float speed)
    {
        viewManager.transform.Rotate(0, -Time.deltaTime * speed, 0);
    }
}
