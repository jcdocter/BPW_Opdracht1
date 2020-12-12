using UnityEngine;

//made by Joey Docter
//move with mouse
public class MouseLook : MonoBehaviour
{
    private float mouseSensitivity = 200f;
    public Transform playerBody;
    private float xRotation = 0f;

    //disapear mouse cursor
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // if weapon wheel is active dont move 
        if (Cursor.lockState == CursorLockMode.Locked)
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
}
