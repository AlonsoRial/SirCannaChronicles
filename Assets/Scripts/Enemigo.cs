using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float vida;
    [SerializeField] private GameObject Canna;

    [SerializeField] private float UltimoGolpe;


    private Rigidbody2D Rigidbody2D;
    CapsuleCollider2D capsuleCollider;



    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(Canna == null) return;

        float distance = Mathf.Abs(Canna.transform.position.x - transform.position.x);
      //  print(distance);

        if (distance < 0.4f && Time.time > UltimoGolpe + 2.7f)
        {
            Golperar();
            print("golpeando");
            UltimoGolpe = Time.time;

        }


    }



    public void Golperar()
    {

        animator.SetTrigger("Golpear");



    }




    public void TomarDanyo(float danyo) {

        vida -= danyo;
        animator.SetTrigger("Danyo");


        if (vida <= 0) {
            
            
            Muerte();
            
        }

    }


    private void Muerte() {
        animator.SetTrigger("Muerte");
        
        Destroy(gameObject, 1.00f);
    }




 


       

    




}
