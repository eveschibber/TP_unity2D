using UnityEngine;

public class CaminataAnimal : MonoBehaviour {
    public float velocidad = 2f;
    public float rangoCaminata = 5f; // Qué tan lejos pueden ir
    public float tiempoEntreCambios = 3f; // Segundos antes de cambiar de dirección
    
    private Vector2 puntoDestino;
    private Animator animator; // Para las animaciones de caminar

    void Start() {
        animator = GetComponent<Animator>();
        // Ejecuta la función de elegir un nuevo destino cada X segundos
        InvokeRepeating("ElegirPuntoAleatorio", 0.5f, tiempoEntreCambios);
    }

    void Update() {
        // Mueve al animal hacia el punto de destino
        transform.position = Vector2.MoveTowards(transform.position, puntoDestino, velocidad * Time.deltaTime);

        // Si ya llegó, se queda quieto (opcional, para animaciones de Idle)
        if (Vector2.Distance(transform.position, puntoDestino) < 0.1f) {
            animator.SetBool("Caminando", false); 
        } else {
            animator.SetBool("Caminando", true);
            
            // ESPEJAR (FLIP) según la dirección a la que camina
            if (puntoDestino.x < transform.position.x) {
                GetComponent<SpriteRenderer>().flipX = true; // Mira a la izquierda
            } else {
                GetComponent<SpriteRenderer>().flipX = false; // Mira a la derecha
            }
        }
    }

    void ElegirPuntoAleatorio() {
        // Define un nuevo punto aleatorio dentro del rango de la escena
        float xAleatoria = Random.Range(-rangoCaminata, rangoCaminata);
        float yAleatoria = Random.Range(-rangoCaminata + 2f, rangoCaminata - 2f); // Evita el borde superior/inferior
        puntoDestino = new Vector2(xAleatoria, yAleatoria);
    }
}