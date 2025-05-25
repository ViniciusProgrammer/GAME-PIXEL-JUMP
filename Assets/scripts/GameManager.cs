using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string nomeDoMenuInicial;
    public string nomeDaProximaFase;
    public float tempoParaRecarregarFase;

    public float tempoParaRecarregarNovaFase;
    void Start()
    {
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            voltarAoMenu();
        }
    }

    private void voltarAoMenu()
    {
        SceneManager.LoadScene(nomeDoMenuInicial);
    }

    public void GameOver()
    {
        RodarCoroutineRecarregarFase();
    }

    public void RodarCoroutineRecarregarFase()
    {
        StartCoroutine(RecarregarFase());
    }

    private IEnumerator RecarregarFase()
    {
        yield return new WaitForSeconds(tempoParaRecarregarFase);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RodaCoroutinePassarDeFase()
    {
        StartCoroutine(PassarDeFase());
    }
    private IEnumerator PassarDeFase()
    {
        yield return new WaitForSeconds(tempoParaRecarregarNovaFase);
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}
