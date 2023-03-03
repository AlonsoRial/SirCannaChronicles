using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{

    //Igual que el Script Enemigo, pero con la diferencia de en vez de que los metodos los llama por el update, los llama en su mayoria
    //el Script de InglesCaminarBehaviour, el cual es un Script que se ejecuta y se llama durante una animación

    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danyoAtaque;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }


    public void TomarDanyo(float danyo)
    {
        vida -= danyo;

        if (vida <= 0)
        {
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.transform.GetComponent<BoxCollider2D>().enabled = false;
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            animator.SetTrigger("Muerte");
            Muerte();
        }

    }

    private void Muerte()
    {
        Destroy(gameObject,3f);
    }




    public void MirarJugador()
    {

        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0);
        }

    }

    //Este metodo es llamado poro un fotograma, cuando se realiza este fotograma de una animación, llamara a este metodo, funciona igual que el metodo de ataque del enemigo
    public void Ataque()
    {
        Collider2D[] objectos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colision in objectos)
        {

            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<CannaMovement>().RecibirDanyo(danyoAtaque);

            }


        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }


}
