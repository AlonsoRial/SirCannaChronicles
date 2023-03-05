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
        // Poner el tiempo a 0 pausa el juego
        Time.timeScale = 0;
        // Ocultar la interfaz con la barra de vida
        interfaz.SetActive(false);
        // Mostrar opciones de pausa
        panelPausado.SetActive(true);
    }

    public void Despausar()
    {
        // Ocultar opciones de pausa
        panelPausado.SetActive(false);
        // Mostrar la interfaz
        interfaz.SetActive(true);
        // Despausar el juego
        Time.timeScale = 1;
    }

    public void SalirAlMenu()
    {
        // Abandonar la escena del juego y cargar la del menú principal
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobar si el jugador pulsa escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si l
            if (panelPausado.activeInHierarchy)
            {
                if (menuOpciones.activeInHierarchy)
                {
                    // Si está en el menú de opciones, se vuelve al menú de pausa
                    menuOpciones.SetActive(false);
                    menuPausa.SetActive(true);
                }
                else
                {
                    // Si está en el menú de pausa, se ejecuta el método de despausar
                    Despausar();
                }
            }
            else
            {
                // Si no está activado el menú de pausa, se llama al método de pausar
                Pausar();
            }
        }
    }

}

