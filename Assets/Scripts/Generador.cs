using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject Enemigo1; // Prefab del enemigo que quieres generar
    public float intervalo = 5f; // Intervalo en segundos entre la generación de enemigos

    private float tiempoUltimaGeneracion;

    void Start()
    {
        // Inicializar el tiempo de la última generación al inicio del juego
        tiempoUltimaGeneracion = Time.time;
    }

    void Update()
    {
        // Comprobar si ha pasado el tiempo suficiente desde la última generación
        if (Time.time - tiempoUltimaGeneracion > intervalo)
        {
            // Generar un nuevo enemigo
            GenerarEnemigo();

            // Actualizar el tiempo de la última generación
            tiempoUltimaGeneracion = Time.time;
        }
    }

    void GenerarEnemigo()
    {
        // Instanciar un nuevo enemigo en la posición del generador
        Instantiate(Enemigo1, transform.position, Quaternion.identity);
    }
}
