using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumenScript : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI textoSlider;
    public float volumenInicial;
    public float maxTipificado;

    // Start is called before the first frame update
    void Start()
    {
        float maxGuardado = PlayerPrefs.GetFloat("maxTipificado", -1);
        Debug.Log("maxGuardado: " + maxGuardado);
        if (maxGuardado != -1)
        {
            maxTipificado = maxGuardado;
        }
        float volGuardado = PlayerPrefs.GetFloat("volumen", -1);
        Debug.Log("volGuardado: " + volGuardado);
        if(volGuardado != -1)
        {
            volumenInicial = volGuardado;
        }
        // Guardar de forma persistente el máximo y el volumen actual
        PlayerPrefs.SetFloat("maxTipificado", maxTipificado);
        PlayerPrefs.SetFloat("volumen", volumenInicial);
        // Aplicar en el slider y en el audio el volumen correspondiente
        slider.value = volumenInicial;
        AudioListener.volume = volumenInicial * maxTipificado;
        ActualizarTextoVolumen();
    }

    public void CambiarVolumen()
    {
        AudioListener.volume = slider.value * maxTipificado;
        ActualizarTextoVolumen();
        PlayerPrefs.SetFloat("volumen", slider.value);
    }

    private void ActualizarTextoVolumen()
    {
        //Debug.Log("ActualizarTextoVolumen> slider.value: " + slider.value);
        int porcentajeVolumen = (int)(slider.value * 100);
        textoSlider.text = porcentajeVolumen + "%";
    }

}
