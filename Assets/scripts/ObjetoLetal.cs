using UnityEngine;

public class ObjetoLetal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().MachucarJogador();
        }
    }
}
