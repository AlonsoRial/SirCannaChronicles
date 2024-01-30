using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuOpciones;

    void Start()
    {

    }

    void Update()
    {
        // A cada frame se comprueba si el jugador ha presionado la tecla escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si la presiona y está dentro del menú de opciones, este se cierra
            if (menuOpciones.activeInHierarchy)
            {
                menuOpciones.SetActive(false);
                menuPrincipal.SetActive(true);
            }
        }
    }

    public void Jugar()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        // Cerrar todo el juego
        Application.Quit();
    }

}
