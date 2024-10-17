using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed;

    public Transform checkGround;
    public float distanceGround = 0.2f;
    public LayerMask isGround;
    public bool inGround;

    public float gravity = -9.81f;
    Vector3 velocity;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Comprobar suelo
        inGround = Physics.CheckSphere(checkGround.position, distanceGround, isGround);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Movimiento personaje
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime; //Control gravedad
        
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
