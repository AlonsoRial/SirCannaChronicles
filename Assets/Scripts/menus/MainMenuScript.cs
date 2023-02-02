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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpciones.activeInHierarchy)
            {
                menuOpciones.SetActive(false);
                menuPrincipal.SetActive(true);
            }
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
