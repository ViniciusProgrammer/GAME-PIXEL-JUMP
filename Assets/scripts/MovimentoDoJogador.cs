using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    [Header("Refer ncias")]

    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("Movimento Horizontal")]

    public float velocidadeDoJogador;
    public bool indoParaDireita;

    [Header("Pulo")]
    public bool estaNoChao;
    public float alturaDoPulo;
    public float tamanhoDoRaioDeVerificacao;
    public Transform verificadorDeChao;
    public LayerMask layerDoChao;

    [Header("Wall Jump")]
    public bool estaNaParede;
    public bool estaPulandoNaParede;
    public float forcaXDoWallJump;
    public float forcaYDoWallJump;

    public Transform verficadorDeParede;

    [Header("Verifica  es")]
    public bool jogadorEstaVivo;


    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jogadorEstaVivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jogadorEstaVivo == true)
        {
            movimentarJogador();
            Pular();
            WallJump();
        }
    }

    private void movimentarJogador()
    {
        //Cuida da movimenta  o horizontal do jogador

        float movimentoHorizontal = Input.GetAxis("Horizontal");

        oRigidbody2D.linearVelocity = new Vector2(movimentoHorizontal * velocidadeDoJogador, oRigidbody2D.linearVelocity.y);

        //Espelha o jogador dependendo da sua dire  o

        if (movimentoHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            indoParaDireita = true;
        }
        else if (movimentoHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            indoParaDireita = false;
        }

        // Toca as anima  es do jogador  parado ou andando

        if (movimentoHorizontal == 0 && estaNoChao == true)
        {
            oAnimator.Play("jogador-idle");
        }
        else if (movimentoHorizontal != 0 && estaNoChao == true && estaNaParede == false)
        {
            oAnimator.Play("jogador-andando");
        }
    }

    private void Pular()
    {
        // Verifica se o jogador esta no encostando no ch o 

        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        if (Input.GetButtonDown("Jump") && estaNoChao == true)
        {
            FSXManager.instance.somDePulo.Play();
            oRigidbody2D.AddForce(new Vector2(0f, alturaDoPulo), ForceMode2D.Impulse);
        }
        // Soltar o jump para o pulo
        if (Input.GetButtonUp("Jump") && oRigidbody2D.linearVelocity.y > 0) oRigidbody2D.linearVelocity = new Vector2(oRigidbody2D.linearVelocity.x, (oRigidbody2D.linearVelocity.y * 0.5f));

        // Toca a animacao do jogador  pulando

        if (estaNoChao == false && estaNaParede == false)
        {
            oAnimator.Play("jogador-pulando");
        }
    }

    private void WallJump()
    {

        // Verifica se o jogador esta encontando em uma parede

        estaNaParede = Physics2D.OverlapCircle(verficadorDeParede.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        // Toca a anima  o do jogador deslizando na parede

        if (estaNaParede == true && estaNoChao == false)
        {
            oAnimator.Play("jogador-deslizando-na-parede");
        }

        // Diz que o jogador esta na parede e est  pulando

        if (Input.GetButtonDown("Jump") && estaNaParede == true && estaNoChao == false)
        {
            estaPulandoNaParede = true;
        }
        // Soltar o jump para o pulo
        if (Input.GetButtonUp("Jump") && oRigidbody2D.linearVelocity.y > 0) oRigidbody2D.linearVelocity = new Vector2(oRigidbody2D.linearVelocity.x, (oRigidbody2D.linearVelocity.y * 0.5f));


        // Faz o jogador pular na parede e (ir em dire  o oposta a ela)

        if (estaPulandoNaParede == true)
        {
            if (indoParaDireita == true)
            {
                oRigidbody2D.linearVelocity = new Vector2(-forcaXDoWallJump, forcaYDoWallJump);
            }
            else
            {
                oRigidbody2D.linearVelocity = new Vector2(forcaXDoWallJump, forcaYDoWallJump);
            }

            // Diz para unity que o jogador saiu da parede (ap s x segundos)

            Invoke(nameof(DeixarEstarPulandoNaParedeComoFalso), 0.1f);
        }
    }

    private void DeixarEstarPulandoNaParedeComoFalso()
    {
        estaPulandoNaParede = false;
    }

    public void ImpulsionarJogador(float forcaDoImpulso)
    {
        oRigidbody2D.linearVelocity = new Vector2(oRigidbody2D.linearVelocity.x, 0f);
        oRigidbody2D.AddForce(new Vector2(0f, forcaDoImpulso), ForceMode2D.Impulse);
    }
}
