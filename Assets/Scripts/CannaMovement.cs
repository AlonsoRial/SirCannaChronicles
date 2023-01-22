using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannaMovement : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;

    private Rigidbody2D Rigidbody2D;



    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    /*
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();

    }
*/

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }



    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }



    /*


    //hola

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();

    }




    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }//si se pulsa a la derecha, cambia a su escala a la positiva
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Animator.SetBool("IsJumping", true);
        }

    }


    public void OnLanding()
    {
        Animator.SetBool("IsJumping", false);
    }


    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        //mover el personaje a la velocidad recogida por el Horizontal (teclado) hacia la dirección marcadaç
        //la variable Speed se refiere a la velocidad, cuanto más alta, mas rapido se movera 
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    */

}
