using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public enum CollectibleType { Diamond, Key, Chest }  // Agregado el tipo de baúl
    public CollectibleType collectibleType;

    public float flipInterval = 0.5f;  // Intervalo de tiempo en segundos entre cada cambio de sentido

    public static int diamondCount = 0;           // Contador de diamantes
    public static bool hasKey = false;            // Estado de la llave
    public static bool levelCompleted = false;    // Estado de nivel completado

    void Start()
    {
        // Invoca el método Flip cada cierto intervalo de tiempo
        InvokeRepeating("Flip", flipInterval, flipInterval);
    }

    void Flip()
    {
        // Invierte el valor de la escala en el eje X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica si el objeto que colisiona es el jugador
        {
            switch (collectibleType)
            {
                case CollectibleType.Diamond:
                    diamondCount++;     // Incrementa el contador de diamantes
                    Debug.Log("Diamantes: " + diamondCount);
                    break;

                case CollectibleType.Key:
                    hasKey = true;      // Marca la llave como obtenida
                    Debug.Log("Llave obtenida: " + hasKey);
                    break;

                case CollectibleType.Chest:
                    if (hasKey)         // Verifica si el jugador tiene la llave
                    {
                        levelCompleted = true;  // Marca el nivel como completado
                        Debug.Log("¡Nivel completado!");
                    }
                    else
                    {
                        Debug.Log("Necesitas la llave para abrir el baúl.");
                    }
                    break;
            }

            if (collectibleType != CollectibleType.Chest)  // No destruir el baúl si es tocado
            {
                Destroy(gameObject);         // Destruye el coleccionable después de recogerlo
            }
        }
    }
}
