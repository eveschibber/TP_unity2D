using UnityEngine;

public class Guardaparque : MonoBehaviour {
    public float velocidad = 5f;
    public GameObject dardoPrefab; 
    public Transform puntoDisparo;
    public AudioSource sonidoDisparo; 

    void Update() {
        // INPUTS de movimiento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, v, 0) * velocidad * Time.deltaTime);

        // INPUT de acción
        if (Input.GetKeyDown(KeyCode.Space)) {
            Disparar();
        }
    }

    void Disparar() {
        // INSTANTIATE: Crea el dardo
        if(dardoPrefab != null) {
            Instantiate(dardoPrefab, puntoDisparo.position, Quaternion.identity);
            if(sonidoDisparo != null) sonidoDisparo.Play();
        }
    }
}