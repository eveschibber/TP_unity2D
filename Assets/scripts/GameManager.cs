using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    // VARIABLES
    public float vidaGuazuncho = 100f;
    public float poblacionAxis = 20f;
    public Slider barraGuazuncho; 
    public Slider barraAxis;

    void Update() {
        // CONDICIONAL: Si hay muchos Axis, el Guazuncho sufre
        if (poblacionAxis > 50f) {
            vidaGuazuncho -= Time.deltaTime * 1.5f; 
        }
        ActualizarUI();
    }

    // FUNCIÓN
    void ActualizarUI() {
        if(barraGuazuncho != null) barraGuazuncho.value = vidaGuazuncho;
        if(barraAxis != null) barraAxis.value = poblacionAxis;
    }

    public void CazarAxis() {
        poblacionAxis -= 5f;
        vidaGuazuncho += 2f;
    }

    public void ErrorGuazuncho() {
        vidaGuazuncho -= 15f;
    }
}