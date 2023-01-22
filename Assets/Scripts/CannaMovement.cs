using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannaMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    //no sirve para nada, es solo para ordenar el codigo, como si fuera el Head del html
    [Header("Movimiento")]
    
    private float MovimientoHorizontal = 0f;

    //SerializeField sirve para que muestre en el IDE de Unity la variable, como si estuviera en publica la variable
    [SerializeField] private float velocidadDeMovimiento = 0;

    //suavizadoDeSuelo sirve para que el movimiento no sea tan brusco
    //Range sirve para poner un range entre dos numeros
    [Range(0, 1f)][SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;


    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;

    //controla que es saltable y que no
    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimensionCaja;

    [SerializeField] private bool enSuelo;

    private bool salto = false;




    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;


        if (Input.GetButtonDown("Jump")) { 
            salto = true;
        }



    }

    //como el update(), pero orientado a cambios de fisicas
    private void FixedUpdate()
    {
        //mover para cualquier equipo
        Mover(MovimientoHorizontal * Time.fixedDeltaTime);
    }

    private void Mover(float mover) {

        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);

        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }
        else if (mover <0 && mirandoDerecha) {
            Girar();
        }



    }

    private void Girar() {

        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;

        escala.x *= -1;
        transform.localScale = escala;
    
    }





}