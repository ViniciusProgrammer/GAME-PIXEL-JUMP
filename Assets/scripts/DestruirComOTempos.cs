using UnityEngine;

public class DestruirComOTempos : MonoBehaviour
{
    public float tempoDeVida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, tempoDeVida);   
    }
}
