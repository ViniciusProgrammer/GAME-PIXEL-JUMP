using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inimigos : MonoBehaviour
{
    [Header("Caminho do Inimigo")]
    public Transform[] pontosDoCaminho;
    public int pontoAtual;

    [Header("Movimento do Inimigo")]
    public float velocidadeDoInimigo;
    public float ultimaPosicaoX;

    void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaminho[0].position;
    }

    void Update()
    {
        MoverInimigo();
        EspelharInimigo();
    }

    private void MoverInimigo()
    {
        //Move o inimigo para o próximo ponto do array de pontos da caminhada
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDoInimigo * Time.deltaTime);

        // Verifica se o inimigo chegou no ponto que tinha que chegar
        if(transform.position == pontosDoCaminho[pontoAtual].position)
        {
            // Troca o próximo ponto que o inimigo tem que ir
            pontoAtual += 1;

            //Armazena a posição X atual do inimigo
            ultimaPosicaoX = transform.localPosition.x;


            //Verifica se o próximo ponto existe tem no array
            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }

     
    private void EspelharInimigo()
    {
        // Espelha o sprite do inimigo dependendo da sua direção (usando a variável ultimaPosição)
        if (transform.localPosition.x < ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (transform.localPosition.x > ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
