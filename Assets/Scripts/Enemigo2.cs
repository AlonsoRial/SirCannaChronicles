using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    // Start is called before the first frame update

  //  [SerializeField] private Transform controladorAtaqueEnemigo;

    [SerializeField] private float vida;
    [SerializeField] private GameObject Canna;

    [SerializeField] private float UltimoGolpe;

    [SerializeField] private float danyoGolpe;

    public Rigidbody2D Rigidbody2D;
    CapsuleCollider2D capsuleCollider;


    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;



    private Animator animator;
    public Transform jugador;



    private void Start()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        if (Canna == null) return;

        float distance = Mathf.Abs(Canna.transform.position.x - transform.position.x);
        //  print(distance);

        if (distance < 0.4f && Time.time > UltimoGolpe + 2.7f)
        {
           // Golperar();
            print("golpeando");
            UltimoGolpe = Time.time;

        }


        Vector3 direccion = Canna.transform.position - transform.position;

        if (direccion.x > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }


    }




    /*
    public void Golperar()
    {

        animator.SetTrigger("Golpear");


        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<CannaMovement>().RecibirDanyo(danyoGolpe);
            }

        }




    }

    */




    public void TomarDanyo(float danyo)
    {

        vida -= danyo;



        if (vida <= 0)
        {


            Muerte();

        }

    }


    private void Muerte()
    {
 

        Destroy(gameObject, 1.00f);
    }



  /*  private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;

        Gizmos.DrawWireCube(controladorAtaqueEnemigo.position, dimensionesCaja);

    }

    */

}
