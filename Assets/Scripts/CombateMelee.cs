using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CombateMelee : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private Transform controladorGolpe2;


    [SerializeField] private float radioGolpe;
    [SerializeField] private float danyoGolpe;
    [SerializeField] private float danyoGolpe2;

    [SerializeField] private float tiempoEntreAtaque;

    [SerializeField] private float tiempoSiguienteAtaque;

     [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicionCaja;
   


    private void Start()
    {
      
    }

    private void Update()
    {
        if (tiempoSiguienteAtaque >0) {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.F) ) {
            Golpe();


            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }

    

        if (Input.GetKeyDown(KeyCode.F))
        {

            Golpe2(); 

            
        }



    }


    private void Golpe() 
    {
       

       

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);


        foreach (Collider2D colisionador in objetos) 
        {
            if (colisionador.CompareTag("Enemigo")) 
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDanyo(danyoGolpe);
            }
        }

    }


    private void Golpe2()
    {


      


        Collider2D[] objetos = Physics2D.OverlapBoxAll( posicionCaja.position,  dimensionesCaja, 0f);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDanyo(danyoGolpe/2);
            }
        
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color  = Color.red;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);

        Gizmos.DrawWireCube(controladorGolpe2.position, dimensionesCaja);

    }



}
