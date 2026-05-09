using UnityEngine;
using System.Collections;

public class ComportamientoAnimal : MonoBehaviour {
    public float velocidadCaminata = 1.5f;
    public float velocidadCarrera = 4f;
    
    private Animator anim;
    private SpriteRenderer spr;
    private Rigidbody2D rb; // <--- Nombre corregido aquí
    private Vector2 destino;

    void Start() {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // <--- Nombre corregido aquí
        
        if (rb == null) {
            Debug.LogError("¡Ojo! El objeto no tiene un componente Rigidbody2D.");
        }
        
        StartCoroutine(RutinaEtologica());
    }

    IEnumerator RutinaEtologica() {
        while (true) {
            // 1. IDLE (Quieto)
            CambiarEstado(0); 
            Frenar();
            yield return new WaitForSeconds(Random.Range(2f, 4f));

            // 2. PASTANDO (Cabeza abajo)
            CambiarEstado(1);
            Frenar();
            yield return new WaitForSeconds(Random.Range(4f, 8f));

            // 3. CAMINANDO
            ElegirDestino();
            CambiarEstado(2);
            while (Vector2.Distance(transform.position, destino) > 0.1f) {
                transform.position = Vector2.MoveTowards(transform.position, destino, velocidadCaminata * Time.deltaTime);
                yield return null; 
            }
        }
    }

    void CambiarEstado(int valor) {
        if (anim != null) anim.SetInteger("Estado", valor);
    }

    void Frenar() {
        if (rb != null) {
            // Si usás Unity 2023 o superior es velocity, sino es velocity
            rb.velocity = Vector2.zero; 
        }
    }

    void ElegirDestino() {
        destino = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
        spr.flipX = (destino.x < transform.position.x);
    }
}