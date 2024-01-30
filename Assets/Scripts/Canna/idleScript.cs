using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleScript : StateMachineBehaviour
{
    /*
        Este Script es un script generado automaticamente por unity, por eso tiene tanto codigo en ingles
        Esta asociado a una animación, en este caso, la animación por defecto que es la de quedarse quieto
        Lo que es lo mismo, cuando el personaje este quieto, se ejecuta este script
        Puedes verlo mejor en el controlador de la animación de Canna
     */



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Funciona parecido al update

        //Cogiendo el script de Canna, si esta atacando, genera la animación del ataque1 
        if (CannaMovement.instance.isAttacking) {
            CannaMovement.instance.animator.Play("atk1");

            //Coge el objecto del que el ataque1 detecta
            Collider2D[] objetos = Physics2D.OverlapCircleAll(CannaMovement.instance.controladorGolpe.position, CannaMovement.instance.radioGolpe);

            
            //Lo recorremos
            foreach (Collider2D colisionador in objetos)
            {
                //Si detecta un objecto que tenga la etiqueta de Enemigo o Enemigo2, este llama el metodo del enemigo de recibir danyo
                if (colisionador.CompareTag("Enemigo"))
                {
                    colisionador.transform.GetComponent<Enemigo>().TomarDanyo(CannaMovement.instance.danyoGolpe);

                }

                if (colisionador.CompareTag("Enemigo2"))
                {
                 
                    colisionador.transform.GetComponent<Enemigo2>().TomarDanyo(CannaMovement.instance.danyoGolpe);
                }

            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Si la animación se acaba, Canna podra volver a ejecutar otra vez el ataque1, perdiendo la oportunidad de hacer el combo
        CannaMovement.instance.isAttacking = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
