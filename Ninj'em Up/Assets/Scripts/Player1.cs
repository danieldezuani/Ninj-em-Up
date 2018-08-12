using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    private string modoDeJogo;//pra saber se o jogo é local ou multiplayer
    

    private string estadoPlayer;
    private Rigidbody2D rb;
    public float forcaPulo;
    public float velocity;

    //variaveis de movimentação
    private bool cima;
    private bool baixo;
    private bool direita;
    private bool esquerda;
    private bool pulo;

    void Start()
    {
        //modoDeJogo = PlayerPrefs.GetString("modoJogo");
        modoDeJogo = "Multiplayer";
        estadoPlayer = "chao";
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (modoDeJogo == "Multiplayer")
            MultiplayerControl();
        else
            LocalP1();

        Jump();    
    }

    void Jump()
    {
        if (estadoPlayer == "chao" && cima || pulo)
            rb.AddForce(Vector2.up * forcaPulo);
        if (estadoPlayer == "Ar" && cima || pulo)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * forcaPulo);
            estadoPlayer = "limiteMaxPulo";
        }

    }

    void MultiplayerControl()
    {
        cima = Input.GetKeyDown(KeyCode.W);
        baixo = Input.GetKey(KeyCode.S);
        direita = Input.GetKey(KeyCode.D);
        esquerda = Input.GetKey(KeyCode.A);
        pulo = Input.GetKeyDown(KeyCode.Space);

        if (direita)
            rb.velocity = new Vector2(Mathf.Abs(transform.position.x )+ velocity * Time.deltaTime, 0f);
        if(esquerda)
            rb.velocity = new Vector2((Mathf.Abs(transform.position.x)* -1) - velocity * Time.deltaTime, 0f);
       
    }

    void LocalP1()
    {
        cima = Input.GetKeyDown(KeyCode.W);
        baixo = Input.GetKey(KeyCode.S);
        direita = Input.GetKey(KeyCode.D);
        esquerda = Input.GetKey(KeyCode.A);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chao"))
            estadoPlayer = "chao";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("chao"))
            estadoPlayer = "Ar";
    }
}
