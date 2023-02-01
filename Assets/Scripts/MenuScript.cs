using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI textoSlider;
    public float volumenInicial;
    public float maxTipificado;

    public void Start()
    {
        slider.value = volumenInicial;
        AudioListener.volume = volumenInicial * maxTipificado;
    }

    public void CambiarVolumen()
    {
        AudioListener.volume = slider.value * maxTipificado;
        ActualizarTextoVolumen();
    }

    private void ActualizarTextoVolumen()
    {
        int porcentajeVolumen = (int) (slider.value * 100);
        textoSlider.text = porcentajeVolumen + "%";
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
