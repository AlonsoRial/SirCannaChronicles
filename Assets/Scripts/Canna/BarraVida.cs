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
        sliderVida.maxValue = vidaMax;
        Debug.Log("vidaMax: " + sliderVida.maxValue);
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
