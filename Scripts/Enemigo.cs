using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

    private Vector2 startPosition;
    private int direction = 1;

    public static bool gameOver = false;  // Estado de pérdida

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!gameOver)  // Solo mueve el enemigo si no se ha perdido
        {
            // Mueve al enemigo en dirección horizontal
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

            // Si el enemigo alcanza el límite del rango, cambia de dirección
            if (Mathf.Abs(transform.position.x - startPosition.x) >= range)
            {
                direction *= -1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica si el objeto que colisiona es el jugador
        {
            gameOver = true;  // Marca el estado como 'perdido'
            Debug.Log("¡Has perdido el nivel!");
            // Aquí puedes agregar más lógica, como detener el juego o reiniciar el nivel.
        }
    }
}
