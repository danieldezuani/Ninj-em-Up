using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //private string modoDeJogo;//pra saber se o jogo é local ou multiplayer
    //modoDeJogo = PlayerPrefs.GetString("modoJogo");

    private string estadoPlayer;
    private Rigidbody2D rb;

    //variaveis de movimentação
    private bool cima;
    private bool baixo;
    private bool direita;
    private bool esquerda;
    private bool pulo;

    void Start()
    {
        estadoPlayer = "chao";
        rb = GetComponent<Rigidbody2D>();
    }


    void Jump()
    {
        if(estadoPlayer == "chao" && cima || pulo)
            rb.AddForce(Vector2.up * 50);

    }

    void Multiplayer()
    {
        cima = Input.GetKeyDown(KeyCode.W);
        baixo = Input.GetKey(KeyCode.S);
        direita = Input.GetKey(KeyCode.D);
        esquerda = Input.GetKey(KeyCode.A);
        pulo = Input.GetKeyDown(KeyCode.Space);
    }

    void LocalP1()
    {
        cima = Input.GetKeyDown(KeyCode.W);
        baixo = Input.GetKey(KeyCode.S);
        direita = Input.GetKey(KeyCode.D);
        esquerda = Input.GetKey(KeyCode.A);
    }

    void LocalP2()
    {
        cima = Input.GetKeyDown(KeyCode.UpArrow);
        baixo = Input.GetKey(KeyCode.DownArrow);
        direita = Input.GetKey(KeyCode.RightArrow);
        esquerda = Input.GetKey(KeyCode.LeftArrow);
    }
}
