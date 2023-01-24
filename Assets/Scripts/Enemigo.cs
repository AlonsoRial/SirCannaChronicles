using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float vida;

   // private Rigidbody2D Rigidbody2D;



    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }


    public void TomarDanyo(float danyo) {

        vida -= danyo;

        if (vida <= 0) {
            Muerte();
            Destroy(gameObject, 5.00f);
        }

    }


    private void Muerte() {
        animator.SetTrigger("Muerte");


    }




 


       

    




}
