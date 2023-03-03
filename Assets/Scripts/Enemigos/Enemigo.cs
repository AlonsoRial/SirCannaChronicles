using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    //Hit box del ataque del enemigo
    [SerializeField] private Transform controladorAtaqueEnemigo;

    //Su vida
    [SerializeField] private float vida;

    //Recibe el objecto de Canna, para saber sus posiciones, variables y metodos
    [SerializeField] private GameObject Canna;

    //Variable para indicar cuanto tiempo debe de esperar para lanzar el siguiente ataque el enemigo
    [SerializeField] private float UltimoGolpe;

    //Su danyo en ataque
    [SerializeField] private float danyoGolpe;

    //Fisicas y hitbox
    private Rigidbody2D Rigidbody2D;
    CapsuleCollider2D capsuleCollider;

    //Tamanyo de la hitbox del ataque del enemigo
    [Header("Hitbox del Ataque")]
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;

    //Animación
    private Animator animator;

    //Esta variable hace que si el enemigo esta rcibiendo danyo, que no pueda atacar, así para hacer el juego más facil
    private bool estaRecibiendo;

    //Inicializa los componentes cuando arranca el juego
    private void Start()
    {
        animator = GetComponent<Animator>(); 
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //Lo que hace cada segundo
    private void Update()
    {
        if(Canna == null) return;

        //Guarda la distancia que hay entre el enemigo y Canna
        float distance = Mathf.Abs(Canna.transform.position.x - transform.position.x);
     
        //Si la distancia concuerda y trascurre el tiempo del ultimo golpe, llama el metodo golpear
        if (distance < 0.4f && Time.time > UltimoGolpe + 2.7f)
        {
            Golperar();
            UltimoGolpe = Time.time;

        }

        //Hacer que el enemigo gire en función de la posicion de Canna
        Vector3 direccion = Canna.transform.position - transform.position;
        if (direccion.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }




    }


    //Es el metodo de ataque del enemigo, ejecuta su animación y luego llama al metodo de Canna de Recibir daño
    public void Golperar()
    {

        if (estaRecibiendo == false)
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
        else estaRecibiendo = false;


    }



    //Metodo que recibe danyo el enemigo, su vida se reduce y cuando llega a 0, este llama al metodo de muerte
    //incorpora las animaciones de Danyo y de Muerte, las cuales se activan como triggers
    public void TomarDanyo(float danyo) {

        vida -= danyo;
        animator.SetTrigger("Danyo");


        if (vida <= 0) {
            animator.SetTrigger("Muerte");

            Muerte();
            
        }

        
        estaRecibiendo = true;

    }

    //El enemigo de destruye despues de 1 segundo
    private void Muerte() {
  

        Destroy(gameObject, 1.00f);
    }


    //Dibuja la hitbox del enemigo
    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;

        Gizmos.DrawWireCube(controladorAtaqueEnemigo.position, dimensionesCaja);

    }










}
