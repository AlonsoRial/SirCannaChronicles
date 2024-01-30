using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannaMovement : MonoBehaviour
{
    //variables para el sonido
    public AudioClip soniAtaque;
    public AudioClip soniDanyo;
    public AudioClip soniMuerte;
    public AudioClip soniGuerra;

    //reproductor de audios
    public AudioSource source { get { return GetComponent<AudioSource>(); } }

    //variables que sirver para recoger la hitbox de los ataques de Canna
    [SerializeField] public Transform controladorGolpe;
    [SerializeField] public Transform controladorGolpe2;

    //variable para el rango del del primer ataque
    [SerializeField] public float radioGolpe;

    //danyo del ataque
    [SerializeField] public float danyoGolpe;

    //variables para el rango del segundo ataque (combo)
    [SerializeField] public Vector2 dimensionesCaja;
    [SerializeField] public Transform posicionCaja;



    //variable que frena la cantidad de veces que puedes atacar, y así no poder espaunear todo el rato el ataque
    public bool isAttacking = false;

    //fisicas y gravedad de Canna
    private Rigidbody2D rb2D;

    //vida de canna
    [SerializeField] private float vida;

    //obtiene el objecto de la batta de vida
	[SerializeField] private BarraVida barraVida;

    //no sirve para nada, es solo para ordenar el codigo, como si fuera el h1 del html
    [Header("Movimiento")]
    
    //variable para el movimiento de canna, concretamente se usa para su animación
    private float MovimientoHorizontal = 0f;

    //SerializeField sirve para que muestre en el IDE de Unity la variable, como si estuviera en publica la variable
    //velocidad de movimiento, más velocidad, más rapido irá Canna
    [SerializeField] private float velocidadDeMovimiento = 110;




    //suavizadoDeSuelo sirve para que el movimiento no sea tan brusco
    //Range sirve para poner un range entre dos numeros
    [Range(0, 1f)][SerializeField] private float suavizadoDeMovimiento =0.1f;

    //para recoger la velocidad de canna en ese instante
    private Vector3 velocidad = Vector3.zero;

    //booleano que permitira girar horizontalmente a Canna
    private bool mirandoDerecha = true;


    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto = 160 ;

    //controla que es saltable y que no
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    //hit box en las piernas de Canna para saltar
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    //referencia a si mismo
    public static CannaMovement instance;

    //para animación
    [Header("Animacion")]
    public Animator animator;

    //Inicializa al arrancar
    private void Awake()
    {
        instance = this; 
    }


    //Lo mismo que Awake, pero de forma diferente, y inicializa el resto de los componentes
    private void Start()
    {

        gameObject.AddComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
		barraVida.InicializarBarraVida(vida);
    }


    //El update son las acciones que puede hace algo por segundo, tambien conocido por los FPS (fotogramas por segundo)
    //seria algo así como el Main de java
    private void Update()
    {
        //Metodo para el sonido de guerra de Canna tras pulsar K
        MetodoSoniGuerra();

        //Metodo para el ataque
        Attack();

        //variable que se le suma el movimiento cuando pulsar las fechas direcionelas o el A o D
        MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        //recoge el valor del movimiento y se lo manda a la variable de su animación en concreto
        animator.SetFloat("Horizontal", Mathf.Abs(MovimientoHorizontal));

        //Lo mismo pero para a cuando el personaje este en el aire, eje Y
        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        //SI pulsar la fecha de arriba o W, el valor que nos indica que el personaje saltara sera true
        if (Input.GetButtonDown("Jump")) { 
            salto = true;
        }


    }

    //Metodo para el ataque
    void Attack() {
        //Al pulsar F y si el valor de atacando es falso
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking) {

            //reproduce sonido de ataque
            source.PlayOneShot(soniAtaque);
            //su valor pasa a ser true, impidiento volver a atacar de nuevo
            isAttacking = true;
            
        }

    }

    //Explicado anterior mente
    void MetodoSoniGuerra()
    {
        if (Input.GetKeyDown(KeyCode.K) )
        {
            source.PlayOneShot(soniGuerra);
         
        }

    }


    //como el update(), pero orientado a cambios de fisicas
    private void FixedUpdate()
    {
        //booleano que recibe si canna esta en el aire o en el suelo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionCaja, 0f, queEsSuelo);

        //animación Idle (quieto) de Canna que se activa con un bool
        animator.SetBool("enSuelo", enSuelo);



        //Metodo que sirve para que Canna se pueda mover en cualquier sistema, tambien gira y salta
        Mover(MovimientoHorizontal * Time.fixedDeltaTime, salto);

        //El salto siempre estara desactivado salvo cuando pulse el boton de saltar
        salto = false;
    }

    //Metodo para mover a Canna
    private void Mover(float mover, bool saltar) {

        //guarda el valor para mover en tanto horizontal y vertical
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);

        //hace que canna de mueva
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        //Metodos que hacen girar a Canna
        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }
        else if (mover <0 && mirandoDerecha) {
            Girar();
        }


        //Metodo que hace que Canna salte una sola vez
        if (enSuelo && saltar) {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }



    }

    //Metodo que sera llamado por los enemigos y que hacen que Canna cerriba danyo y puedetambien llamar al metodo me morir
    public void RecibirDanyo(float danyo)
    {
        //contiene la animacion de sufrir danyo, su sonido, su vida y su barra se resta 
        source.PlayOneShot(soniDanyo);
        animator.SetTrigger("Hit");
        vida -= danyo;
		barraVida.RestarVida(danyo);
        if(vida <= 0)
        {

            source.PlayOneShot(soniMuerte);
            Muerte();
        }
    }

    //metodo que es llamado por la pociones que poder recuperar la vida

    public void RecuperaVida(int salud)
    {
        barraVida.SumarVida(salud);
        this.vida = this.vida + salud;
    }

    //para la muerte de canna, hace la animación, tanto Canna como su barra se destrullen y llama el metodo de la pantalla de muerte
    public void Muerte()
    {
        animator.SetTrigger("Muerte");
		barraVida.Destruir(5f);
        Destroy(gameObject, 5f);
        StartCoroutine(WaitForSceneLoad(1));
    }

    //metodo para la pantalla de muerte
	private IEnumerator WaitForSceneLoad(int seconds) {
 		yield return new WaitForSeconds(seconds);
 		SceneManager.LoadScene(2);
	}


    //Metodos que hacen girar a Canna, vasicamente, se pone en negativo su escala horizontal
    private void Girar() {

        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;

        escala.x *= -1;
        transform.localScale = escala;
    
    }

    //Metodo de Unity, dibuja lo que serian los hitboxs y los colliders
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionCaja);


        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);

        Gizmos.DrawWireCube(controladorGolpe2.position, dimensionesCaja);

    }


    


}