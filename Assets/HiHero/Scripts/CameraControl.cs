using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cameraLook;
    private float distance;
    private Quaternion rotation;
    private Vector3 resultPosition;
    private Vector2 inputPos;
    private bool isClickRotate;
    public int yMinLimit = 3;
    public int yMaxLimit = 80;
    private float xAngle;
    private float yAngle;
    public float rotationSpeed = 100;
    public float moveLerp = 10;
    void Start()
    {
        distance = Vector3.Distance(cameraLook.transform.position, transform.position);
        rotation = transform.rotation;
        
        xAngle = Vector3.Angle(Vector3.right, transform.right);
        yAngle = Vector3.Angle(Vector3.up, transform.up);

    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    
    void FixedUpdate()
    {
        isClickRotate = Input.GetMouseButton(0);
        inputPos.x = Input.GetAxis("Mouse X");
        inputPos.y = Input.GetAxis("Mouse Y");

        if (isClickRotate)
        {
            xAngle += inputPos.x * rotationSpeed * Time.fixedDeltaTime;
            yAngle -= inputPos.y * rotationSpeed * Time.fixedDeltaTime;
            // 角度限制
            yAngle = ClampAngle(yAngle, yMinLimit, yMaxLimit);
            // Quaternion.Euler(绕X轴旋转多少度,绕Y轴旋转多少度,绕Z轴旋转多少度)
            // 得到最终旋转四元数
            rotation = Quaternion.Euler(yAngle, xAngle, 0);
            // 插值运算平滑旋转
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * 5);
        }
        
        resultPosition = cameraLook.transform.position - rotation * Vector3.forward * distance;
        transform.position = Vector3.Lerp(transform.position, resultPosition, Time.fixedDeltaTime  * moveLerp);
        transform.position = transform.position;

        
    }
}
