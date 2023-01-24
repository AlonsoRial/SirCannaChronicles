using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float vida;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }


    public void TomarDanyo(float danyo) {

        vida -= danyo;

        if (vida <= 0) {
            Muerte();
        }

    }


    private void Muerte() {
        animator.SetTrigger("Muerte");
    }






}
