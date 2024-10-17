using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera playerCamera;  // Renombramos la variable para evitar el conflicto
    public float range = 100f;
    public GameObject bulletDecal;

    // Start is called before the first frame update
    void Start()
    {
        // Si la cámara no está asignada, buscar la cámara principal
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Disparar cuando se presione el botón Fire1 (por defecto el clic izquierdo del ratón)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Crear un raycast desde la posición de la cámara hacia adelante
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            GameObject decal =
                Instantiate(bulletDecal, hit.point + (hit.normal * 0.025f), Quaternion.identity) as GameObject;

            // Rotamos la decal hacia la superficie impactada
            decal.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            // Hacemos que la decal sea hija del objeto impactado
            decal.transform.parent = hit.transform;
        }
    }
}