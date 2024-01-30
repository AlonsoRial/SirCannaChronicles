using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider sliderVida;
    public GameObject canna;

    public void InicializarBarraVida(float vidaMax)
    {
        // Estblecer el valor máximo del slider en la vida máxima que puede tener Canna
        sliderVida.maxValue = vidaMax;
        Debug.Log("vidaMax: " + sliderVida.maxValue);
        // Canna empieza con la vida máxima
        sliderVida.value = vidaMax;
        Debug.Log("vida actual: " + sliderVida.maxValue);
    }

    public void RestarVida(float danyo)
    {
        sliderVida.value -= danyo;
    }

    public void SumarVida(float salud)
    {
        sliderVida.value += salud;
    }


    public void Destruir(float delay)
    {
        Destroy(gameObject, delay);
    }
}
