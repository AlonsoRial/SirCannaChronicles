using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateMelee : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danyoGolpe;

    [SerializeField] private float tiempoEntreAtaque;

    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tiempoSiguienteAtaque >0) {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.F) && tiempoSiguienteAtaque <=0  ) {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }


    private void Golpe() 
    {

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);


        foreach (Collider2D colisionador in objetos) 
        {
            if (colisionador.CompareTag("Enemigo")) 
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDanyo(danyoGolpe);
            }
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color  = Color.red;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);

    }



}
