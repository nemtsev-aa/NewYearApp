using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatorName { Иван, Артём, Софья, Вероника }

public class ColliderRay : MonoBehaviour
{
    //[SerializeField] GameObject viewManager;

    [SerializeField] GameObject viewManager;
    
    [SerializeField] CreatorName creatorName;

    private GameObject gameManager;

    private Camera viewCamera;

    

    private void Awake()
    {
        //viewManager = GameObject.Find("/Cameras/View/View");
        viewCamera = viewManager.GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (GetComponent<Collider>().Raycast(ray, out hit, 100f))
        {
            gameManager.
            if (transform.localScale.x < 1f)
            {
                transform.localScale = Vector3.one * 0.2f;
            }
            else
            {
                transform.localScale = Vector3.one * 2f;
            }
            
        }
        else
        {
            transform.localScale = Vector3.one * 1f;
        }
        
    }
}
