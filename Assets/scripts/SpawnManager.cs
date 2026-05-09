using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalesPrefabs;
    
    public float limiteX = 12f; 
    public float rangoYPos = 4f; 
    public float tiempoInicial = 2f;
    public float intervaloAparicion = 2f;

    void Start()
    {
        if (animalesPrefabs.Length > 0)
        {
            InvokeRepeating("SpawnAnimalLateral", tiempoInicial, intervaloAparicion);
        }
    }

    void SpawnAnimalLateral()
    {
        int indexAleatorio = Random.Range(0, animalesPrefabs.Length);
        
        // Elige izquierda (-1) o derecha (1)
        float lado = (Random.value > 0.5f) ? 1f : -1f;
        
        float posX = limiteX * lado;
        float posY = Random.Range(-rangoYPos, rangoYPos);
        Vector3 posGeneracion = new Vector3(posX, posY, 0);

        GameObject animal = Instantiate(animalesPrefabs[indexAleatorio], posGeneracion, Quaternion.identity);
        
        SpriteRenderer renderer = animal.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // Si viene de la derecha (1), lo flipeamos para que mire al centro
            renderer.flipX = (lado == 1f);
        }
    }
}