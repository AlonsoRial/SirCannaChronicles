using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
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
