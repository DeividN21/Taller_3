using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string targetTag = "Player"; // Tag del objeto a seguir
    public float smoothSpeed = 5f; // Velocidad de suavizado

    private Transform target; // Transform del objeto a seguir

    void Start()
    {
        // Encuentra el objeto con el tag especificado al comienzo del juego
        GameObject player = GameObject.FindGameObjectWithTag(targetTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag " + targetTag);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición deseada de la cámara manteniendo la misma altura (eje Y)
            Vector3 desiredPosition = target.position;
            desiredPosition.y = transform.position.y;

            // Ajusta la posición de la cámara hacia la posición deseada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}

