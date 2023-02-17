using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform controlador;

    [SerializeField] private GameObject canna;

    Rigidbody2D rigidbody2D;

    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;

    [SerializeField] private int vida;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<CannaMovement>().RecuperaVida(vida);
                Destroy(gameObject);
            }

        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;

        Gizmos.DrawWireCube(controlador.position, dimensionesCaja);

    }

}
