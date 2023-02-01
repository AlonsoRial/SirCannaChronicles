using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAtaque : MonoBehaviour
{

    private Animator ani;
    public int nroP;
    public bool canP;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        canP = true;
        nroP = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canP && nroP<2)
            {
                nroP++;
                ani.SetInteger("nextAtaque", nroP);
                canP  = false;
            }
        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("CannaIdle") && nroP==0)
        {
            canP=true;
        }
    
    }

   public void verificarCombo()
    {
        if (canP)
        {
            canP=false;
            nroP=0;
            ani.SetInteger("nextAtaque", nroP);
        }
    }


    public void canPTrue()
    {
        canP = true;
    }




}
