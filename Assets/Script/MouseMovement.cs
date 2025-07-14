using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f; // public biar bisa diatur lewat inspector
    

    float Xrotation = 0f;
    float Yrotation = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        Yrotation += mouseX;

        transform.localRotation = Quaternion.Euler(Xrotation, Yrotation, 0f);
    }
}
