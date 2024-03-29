using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject projetil;
    public float distaciaVisao;
    public float velocidade;
    public GameObject alvo;
    Vector3 posicaoIdle;
    bool atacando;



    int IDLE = 0;
    int PERSEGUIR = 1;
    int ATACAR = 2;
    int estado;

    void Idle()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            posicaoIdle, velocidade * Time.deltaTime);
    }

    void Perseguir()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            alvo.transform.position, velocidade * Time.deltaTime);
    }

    void Atacar()
    {
        if (atacando == false)
        {
            transform.LookAt(alvo.transform);
            StartCoroutine(Atirar());
            atacando = true;
        }
    }


    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(0.3f);
        if (estado == ATACAR)
        {
            Instantiate(projetil, transform.position, transform.rotation);
            StartCoroutine(Atirar());
        }
        else
        {
            atacando = false;
        }
    }

    void FSM()
    {
        if (estado == IDLE)
        {
            Idle();
        }
        else if (estado == PERSEGUIR)
        {
            Perseguir();
        }
        else if (estado == ATACAR)
        {
            Atacar();
        }
    }


    void Start()
    {
        // OBTEM A POSICAO PARA ONDE ELE DEVE RETORNAR
        posicaoIdle = transform.position;

        // OBTEM O JOGADOR
        alvo = GameObject.Find("Player");

    }


    void Update()
    {
        // IMPLEMENTAÇÃO DA REGRA
        float d = Vector3.Distance(transform.position, alvo.transform.position);

        if (d > distaciaVisao)
        {
            estado = IDLE;
        }
        else
        {
            if (d < distaciaVisao / 2)
            {
                estado = ATACAR;
            }
            else
            {
                estado = PERSEGUIR;
            }
        }


        FSM();

    }
}
