using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    //public GameObject projetil;
    public float distaciaVisao;
    public float velocidade;
    public GameObject alvo;
    Vector3 posicaoIdle;
    bool atacando;

    

    int IDLE = 0;
    int PERSEGUIR = 1;
    //int ATACAR = 2;
    int estado;

    void Idle()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            posicaoIdle, velocidade * Time.deltaTime);
    }

    void PerseguirI()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            alvo.transform.position, velocidade * Time.deltaTime);
    }



    void FSM()
    {
        if (estado == IDLE)
        {
            Idle();
        }
        else if (estado == PERSEGUIR)
        {
            PerseguirI();
        }
        /*else if (estado == ATACAR)
        {
            Atacar();
        }*/
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
                estado = PERSEGUIR;
            }

        }

        // MAQUINA DE ESTADO
        FSM();

    }
}
