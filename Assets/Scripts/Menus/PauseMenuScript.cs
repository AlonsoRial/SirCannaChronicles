using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject panelPausado;
    public GameObject menuPausa;
    public GameObject menuOpciones;
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
        panelPausado.SetActive(true);
    }

    public void Despausar()
    {
        panelPausado.SetActive(false);
        interfaz.SetActive(true);
        Time.timeScale = 1;
    }

    public void SalirAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPausado.activeInHierarchy)
            {
                if (menuOpciones.activeInHierarchy)
                {
                    menuOpciones.SetActive(false);
                    menuPausa.SetActive(true);
                }
                else
                {
                    Despausar();
                }
            }
            else
            {
                Pausar();
            }
        }
    }
}
