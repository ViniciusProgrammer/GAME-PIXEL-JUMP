using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public string nomeDoMenuInicial;
    public string nomeDaProximaFase;

    public string nomeTelaGameOver = "GameOver";
    public float tempoParaRecarregarFase;
    public float tempoParaRecarregarNovaFase;

    public TextMeshProUGUI timeText;
    public float timeCount = 25.1f;
    public float timeAux;
    public bool timeOver = false;

    public static bool veioDoGameOver = false;
    private bool isGameOverTriggered = false; // evita conflitos no Update

    public static float savedTimeAux = -1f;
    void Start()
    {
        if (savedTimeAux < 0)
        {
            timeAux = timeCount;
        }
        else
        {
            timeAux = savedTimeAux;
        }
        veioDoGameOver = false;
        isGameOverTriggered = false;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            voltarAoMenu();
        }

        if (!timeOver && !isGameOverTriggered)
        {
            timeAux -= Time.deltaTime;

            if (timeAux <= 0f)
            {
                timeAux = 0f;
                timeOver = true;
                telaGameOver();
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timeText != null)
        {
            timeText.text = timeAux.ToString("F1") + "s";
        }
    }

    private void voltarAoMenu()
    {
        savedTimeAux = -1f;
        SceneManager.LoadScene(nomeDoMenuInicial);
    }

    public void GameOver()
    {
        if (isGameOverTriggered) return; // evita múltiplas chamadas

        isGameOverTriggered = true;
        veioDoGameOver = true;
        RodarCoroutineRecarregarFase();
    }

    public void RodarCoroutineRecarregarFase()
    {
        StartCoroutine(RecarregarFase());
    }

    private IEnumerator RecarregarFase()
    {
        yield return new WaitForSeconds(tempoParaRecarregarFase);
        savedTimeAux = timeAux; // salva antes de recarregar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RodaCoroutinePassarDeFase()
    {
        StartCoroutine(PassarDeFase());
    }

    private IEnumerator PassarDeFase()
    {
        savedTimeAux = -1;
        yield return new WaitForSeconds(tempoParaRecarregarNovaFase);
        SceneManager.LoadScene(nomeDaProximaFase);
    }

    private void telaGameOver()
    {
        SceneManager.LoadScene(nomeTelaGameOver);
    }
}
