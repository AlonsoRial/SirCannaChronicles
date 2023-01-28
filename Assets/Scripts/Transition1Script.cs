using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1Script : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CannaMovement.instance.isAttacking) {
            CannaMovement.instance.animator.Play("atk2");


            Collider2D[] objetos = Physics2D.OverlapBoxAll( CannaMovement.instance.posicionCaja.position, CannaMovement.instance.dimensionesCaja, 0f);


            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Enemigo"))
                {
                    colisionador.transform.GetComponent<Enemigo>().TomarDanyo(CannaMovement.instance.danyoGolpe / 2);
                }

            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
