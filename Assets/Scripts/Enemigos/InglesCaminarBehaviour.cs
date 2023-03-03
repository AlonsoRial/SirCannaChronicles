using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InglesCaminarBehaviour : StateMachineBehaviour
{
    //Este Script se ejecuta cuando se realiza una animación, en este caso la de correr

    //obtiene el Enemigo2, sus fisicas y la velocidad de movimiento
    private Enemigo2 ingles;
    private Rigidbody2D rb2D;

    [SerializeField] private float velocidadMovimiento;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Inicializa los componentes cuando se realiza la animación, es como el Start
        ingles = animator.GetComponent<Enemigo2>();
        rb2D = ingles.rb2D;

        //Llama al metodo de mirar al jugador
        ingles.MirarJugador();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Durante la animación el enemigo se movera hacia la posición de Canna
        rb2D.velocity = new Vector2(velocidadMovimiento, rb2D.velocity.y) * animator.transform.right;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Cuando su animación cambia o termina, su velocidad pasa a ser 0
        rb2D.velocity = new Vector2(0,rb2D.velocity.y);
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
