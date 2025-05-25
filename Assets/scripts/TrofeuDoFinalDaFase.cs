using UnityEngine;

public class TrofeuDoFinalDaFase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().RodaCoroutinePassarDeFase();
        }
    }
}
