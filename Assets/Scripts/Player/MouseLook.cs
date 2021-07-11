using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerCamera;

    public float mouseSensetivity = 2f;

    //переменные ограничения угла вращения по оси X
    public float minimumX = -360f;
    public float maximumX = 360f;

    //переменные ограничения угла вращения по оси Y
    public float minimumY = -360f;
    public float maximumY = 360f;

    //переменные определяющие текущий угол вращения
    private float rotationX = 0f;
    private float rotationY = 0f;

    //переменная содержащая тип вращения "Quaternion"
    private Quaternion originalRotation;
    private Quaternion originalRotationCam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        originalRotation = transform.localRotation;
        originalRotationCam = transform.localRotation;
    }

    void Update()
    {
        //записываем угол поворота мыши с учетом чувствительности
        rotationX += Input.GetAxis("Mouse X") * mouseSensetivity;
        rotationY += Input.GetAxis("Mouse Y") * mouseSensetivity;

        //ограничения поворота
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        //расчёт кватернионов
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

        //поворот
        transform.localRotation = originalRotation * xQuaternion;
        playerCamera.localRotation = originalRotationCam * yQuaternion;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
