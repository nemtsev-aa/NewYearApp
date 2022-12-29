using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCameraController : MonoBehaviour
{
    [SerializeField] Joystick rotateJoystick;

    private float mouseX;
    private float mouseY;

    private float eulerX;
    private float eulerY;

    [Header("Чувствительность мыши")]
    public float _sensivityMouse = 100f;

    public Transform Player;
    public Transform Camera;

    private float xRot;
    private float yRot;

    private Quaternion startCameraRotation;

    void Start()
    {
        startCameraRotation = Player.transform.localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Считываем вертикальное отклонение джойстика
        float mY = rotateJoystick.Vertical * _sensivityMouse * Time.deltaTime;
        //Управляем поворотом оси Х - вверх-вниз (знак "-" инвертирует управление)
        xRot -= mY;
        //Корректируем угол поворота в установленных пределах
        //С учётом положительного направления обхода окружности
        //-30f - предел отклонения вверх
        //30f - предел отклонения вниз
        xRot = Mathf.Clamp(xRot, -30f, 30f);
        //Поворачиваем камеру на полученный угол поворота
        Camera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        //Считываем горизонтальное отклонение джойстика
        float mX = rotateJoystick.Horizontal * _sensivityMouse * Time.deltaTime;
        //Управляем поворотом оси Y - влево-вправо
        yRot += mX;
        //Корректируем угол поворота в установленных пределах
        //yRot = Mathf.Clamp(yRot, -360f, 360f);
        //Поворачиваем игрока на полученный угол поворота
        //Player.transform.Rotate(Vector3.up * mX);
        Player.transform.localRotation = Quaternion.Euler(0f, yRot, 0f);
        
    }

    public void ResetPosition()
    {
         Player.transform.rotation = new Quaternion(0f,0f,0f,0f);
    }

}
