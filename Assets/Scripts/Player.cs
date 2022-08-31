using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6.0F;

    public float jumpSpeed = 8.0F;

    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
           Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


        }

        moveDirection.y -= gravity * Time.deltaTime;
        // Atualiza a posição do personagens nos eixos
        // XYZ. No caso os movimentos para os
        // lados e a gravidade.
        controller.Move(moveDirection * Time.deltaTime);
        // Se houver input executa a animação de corrida
        // observe que a animação é feita através do acesso ao
        // componente animation, onde ficam guardados os clipes
        // de animação. No momento de chamar a animação tome cuidado,
        // o nome deverá ser identico ao atribuido na criação do clipe.
        /*if (Input.GetAxis("Horizontal") != 0.0 || Input.GetAxis("Vertical") != 0)
        {
            //GetComponent<Animation>().CrossFade("run");
        }
        else
        {
            //GetComponent<Animation>().CrossFade("idle");
        }*/
    }
}
