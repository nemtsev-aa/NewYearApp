using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //public float mouseSense = 100f;

    //public Transform playerBody;

    //float yRotation = -40f;
    public GameObject targetObj;

    public float speed;

    // Update is called once per frame
    void LateUpdate()
    {

        transform.Rotate(0, speed * Time.deltaTime, 0);

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Click");
        //    float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        //    float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

        //    yRotation -= mouseY;
        //    yRotation = Mathf.Clamp(yRotation, -900f, 900f);

        //    transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        //}
        
        ////Определяем размер обьекта по колайдеру, если он есть
        //if (characterController == null)
        //{
        //    if (targetObj.GetComponent<CharacterController>() != null)
        //    {
        //        characterController = targetObj.GetComponent<CharacterController>();
        //        tmpPositionY = characterController.height + 0.5f;
        //    }
        //    else
        //    {
        //        tmpPositionY = 2;
        //    }
        //}

        ////mouseSence = GlobalPlayerConfig.MouseSance;//Скорость вращения камеры
        ////                                           //Сохраняем значение осей мыши и умножаем на скорость вращения камеры
        ////                                           // + и - отвечают за инверсию осей мыши
        
        //rotationX += (Input.GetAxis("Mouse X") * (mouseSence));
        //rotationY -= (Input.GetAxis("Mouse Y") * (mouseSence));
        
        ////Приближаем камеру
        //cameraPositionZ = Mathf.Clamp(cameraPositionZ + (Input.GetAxis("Mouse ScrollWheel") * speedScrollCamera), minimumZ, maximumZ);

        ////Ограничиваем угол повора камеры по оси Y, если нужно
        //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        ////Ограничиваем угол повора камеры по оси Y, если нужно
        //rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        ////Определяем позицию обьекта, вокруг которого вращаемся
        //tempPositionBot = new Vector3(targetObj.transform.position.x,
        //                               targetObj.transform.position.y + tmpPositionY,//Здесь определяется точка фокуса камеры
        //                               targetObj.transform.position.z);

        //tmpPositionZ = cameraPositionZ * 0.1f;

        //newRotation = Quaternion.Euler(rotationY, rotationX, 0f);
        //newPosition = newRotation * new Vector3(0f, 0f, tmpPositionZ) + tempPositionBot;

        //transform.rotation = newRotation;
        //transform.position = newPosition;


    }
    
 
}
