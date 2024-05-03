using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMaxima = 5f; // Velocidad máxima del tanque
    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody del tanque
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en las entradas horizontal y vertical
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        // Si hay entrada de movimiento diagonal, eliminar un componente para forzar el movimiento en una sola dirección
        if (movimientoHorizontal != 0 && movimientoVertical != 0)
        {
            movimiento.x = 0;
        }

        // Si hay entrada de movimiento, calcular la rotación deseada
        if (movimiento != Vector3.zero)
        {
            // Calcular la rotación deseada basada en el vector de movimiento
            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);

            // Aplicar la rotación deseada al transform del tanque
            transform.rotation = rotacionDeseada;
        }

        // Calcular la velocidad deseada basada en la velocidad máxima y la entrada del jugador
        Vector3 velocidadDeseada = movimiento * velocidadMaxima;

        // Aplicar la velocidad deseada al Rigidbody del tanque
        rb.MovePosition(rb.position + velocidadDeseada * Time.fixedDeltaTime);
    }
}







