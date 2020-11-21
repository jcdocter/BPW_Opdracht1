using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseSensitivity = 200f;
    public Transform playerBody;
    private float xRotation = 0f;

    //disapear mousr cursor
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //rotate players vision
        float mouseX = Input.GetAxis(Axis.MOUSEX) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(Axis.MOUSEY) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.down * mouseY);
    }
}
