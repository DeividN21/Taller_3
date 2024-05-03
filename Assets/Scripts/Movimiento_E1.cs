using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movimiento_E1 : MonoBehaviour
{
    public float velocidad = 0.001f; // Velocidad de avance del enemigo
    private bool colisionDetectada = false;

    void Update()
    {
        // Avanzar en la dirección especificada mientras no se haya detectado una colisión
        if (!colisionDetectada)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

    // Detectar colisiones con otros objetos
    void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisiona es el objeto con el que quieres que se detenga
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            // Detener el movimiento
            colisionDetectada = true;
            velocidad = 0f;
            // Salir del modo de juego
            EditorApplication.isPlaying = false; // Si estás en el Editor de Unity
        }

    }
}
