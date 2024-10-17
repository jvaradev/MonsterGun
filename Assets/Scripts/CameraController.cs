using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 300f;
    public float verticalRot = 0f;

    void Start()
    {
        // Bloquear el cursor al centro de la pantalla y ocultarlo
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Movimiento Camara vertical
        verticalRot -= y;
        verticalRot = Mathf.Clamp(verticalRot, -90, 90);
        transform.localRotation = Quaternion.Euler(verticalRot, 0f, 0f);
        
        // Movimiento Camara horizontal
        player.Rotate(Vector3.up * x);
    }
}