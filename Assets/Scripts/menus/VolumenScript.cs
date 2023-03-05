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
        // Mirar si hay un volumen máximo guardado, y si no lo hay, se establece el por defecto
        float maxGuardado = PlayerPrefs.GetFloat("maxTipificado", -1);
        Debug.Log("maxGuardado: " + maxGuardado);
        if (maxGuardado != -1)
        {
            maxTipificado = maxGuardado;
        }

        // Mirar si hay un último volumen guardado, si no lo hay se establece el por defecto (69%)
        float volGuardado = PlayerPrefs.GetFloat("volumen", -1);
        Debug.Log("volGuardado: " + volGuardado);
        if (volGuardado != -1)
        {
            volumenInicial = volGuardado;
        }

        // Guardar de forma persistente el m�ximo y el volumen actual
        PlayerPrefs.SetFloat("maxTipificado", maxTipificado);
        PlayerPrefs.SetFloat("volumen", volumenInicial);

        // Aplicar en el slider y en el audio el volumen correspondiente
        slider.value = volumenInicial;
        AudioListener.volume = volumenInicial * maxTipificado;
        ActualizarTextoVolumen();
    }

    public void CambiarVolumen()
    {
        // El volumen se establece como porcentaje del máximo establecido
        AudioListener.volume = slider.value * maxTipificado;
        ActualizarTextoVolumen();
        // Cada vez que se cambia, se guarda de forma persistente
        PlayerPrefs.SetFloat("volumen", slider.value);
    }

    private void ActualizarTextoVolumen()
    {
        Debug.Log("ActualizarTextoVolumen> slider.value: " + slider.value);
        // Mostrar en el texto de la pantalla el porcentaje de volumen actual
        int porcentajeVolumen = (int)(slider.value * 100);
        textoSlider.text = porcentajeVolumen + "%";
    }

}
