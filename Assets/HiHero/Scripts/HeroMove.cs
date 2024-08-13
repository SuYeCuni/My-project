using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{   // 刚体
    private Rigidbody rb;
    // 移动速度
    public float speed = 3.5f;
    // 转向速度
    public float turnSpeed = 30;
    // 是否在移动
    private bool isRunning;
    // 移动方向
    private Vector3 movement;
    // 旋转
    private Quaternion targetRotation;
    private Vector2 movementInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // 检查输入
        bool horizontalInput = !Mathf.Approximately(movementInput.x, 0);
        bool verticalInput = !Mathf.Approximately(movementInput.y, 0);
        isRunning = horizontalInput || verticalInput;
        movement.Set(movementInput.x, 0, movementInput.y);
        movement.Normalize();
        // 纵向移动跟随摄像机视角的正上方
        if (isRunning)
        {
            movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement;
        }
        // Vector3.RotateTowards 将当前方向朝目标方向旋转
        Vector3 lookForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0);
        targetRotation = Quaternion.LookRotation(lookForward);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MoveRotation(targetRotation);
    }
}
