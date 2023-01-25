using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float vida;
    [SerializeField] private GameObject Canna;

    [SerializeField] private float UltimoGolpe;


    // private Rigidbody2D Rigidbody2D;



    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
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
            Destroy(gameObject, 5.00f);
        }

    }


    private void Muerte() {
        animator.SetTrigger("Muerte");


    }




 


       

    




}
