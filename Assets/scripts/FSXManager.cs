using UnityEngine;

public class FSXManager : MonoBehaviour
{
    public static FSXManager instance;
    public AudioSource somDaColeta, somDeDano, somDePulo;

    void Awake()
    {
        instance = this;
    }
}
