using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject menuPausa;
    public GameObject interfaz;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        interfaz.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Despausar()
    {
        menuPausa.SetActive(false);
        interfaz.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPausa.active)
            {
                Despausar();
            }
            else
            {
                Pausar();
            }
        }
    }
}
