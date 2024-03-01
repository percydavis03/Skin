using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    private float yRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

   

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.fixedDeltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);

        yRotation += (mouseX * Time.fixedDeltaTime) * xSensitivity;

        //Apply this to our camera transform
        
    }
    private void LateUpdate()
    {
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, transform.rotation.z);
    }
}
