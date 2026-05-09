using UnityEngine;

public class Guardaparque : MonoBehaviour {
    public float velocidad = 5f;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        // Movimiento simple
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0).normalized;
        transform.position += dir * velocidad * Time.deltaTime;

        // Actualizar animación (si existe el animator)
        if (anim != null) {
            anim.SetFloat("Velocidad", dir.magnitude);
        }

// Dentro del Update, al final, reemplazá tu código de Flip por este:

// Obtenemos el SpriteRenderer que ya está en el objeto
SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

if (spriteRenderer != null) {
    if (h > 0) {
        // Mira a la derecha (normal)
        spriteRenderer.flipX = false;
    } else if (h < 0) {
        // Mira a la izquierda (invertido)
        spriteRenderer.flipX = true;
    }
}
// NOTA: Si al moverte a la derecha el personaje mira a la izquierda (y viceversa), 
// simplemente invertí 'true' y 'false' en el código de arriba.
    }
}