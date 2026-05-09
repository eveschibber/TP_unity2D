using UnityEngine;

public class Dardo : MonoBehaviour {
    public float velocidadDardo = 10f;

    void Update() {
        // El dardo vuela hacia arriba/adelante
        transform.Translate(Vector3.up * velocidadDardo * System.Convert.ToSingle(Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D otro) {
        // COLISIONES: Detecta qué animal tocamos
        GameManager gm = FindObjectOfType<GameManager>();

        if (otro.CompareTag("Axis")) {
            gm.CazarAxis();
            Destroy(otro.gameObject); // Desaparece el ciervo
            Destroy(this.gameObject); // Desaparece el dardo
        } 
        else if (otro.CompareTag("Guazuncho")) {
            gm.ErrorGuazuncho();
            Destroy(this.gameObject); // Solo desaparece el dardo, penaliza vida
        }
    }
}