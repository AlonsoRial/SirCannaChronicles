using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannaMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D Rigidbody2D;

    private float Horizontal;

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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




    }


    private void FixedUpdate()
    {
        //mover el personaje a la velocidad recogida por el Horizontal (teclado) hacia la dirección marcadaç
        //la variable Speed se refiere a la velocidad, cuanto más alta, mas rapido se movera 
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);

    }



}
