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
        // Atualiza a posi��o do personagens nos eixos
        // XYZ. No caso os movimentos para os
        // lados e a gravidade.
        controller.Move(moveDirection * Time.deltaTime);
        // Se houver input executa a anima��o de corrida
        // observe que a anima��o � feita atrav�s do acesso ao
        // componente animation, onde ficam guardados os clipes
        // de anima��o. No momento de chamar a anima��o tome cuidado,
        // o nome dever� ser identico ao atribuido na cria��o do clipe.
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
