using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDoJogo : MonoBehaviour
{
    public GameObject painelDoMenuInicial, painelDaTelaDeCreditos;
    public string nomeDaPrimeiraFase;
    public void carregarJogo()
    {
        SceneManager.LoadScene(nomeDaPrimeiraFase);
    }

    public void AtivarPainelDoMenuInicial()
    {
        painelDaTelaDeCreditos.SetActive(false);
        painelDoMenuInicial.SetActive(true);
    }

    public void AtivarPainelDeTelaDeCreditos()
    {
        painelDoMenuInicial.SetActive(false);
        painelDaTelaDeCreditos.SetActive(true);
    }
    public void sairDoJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
