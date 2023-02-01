using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menus
{
    class ControlVolumen
    {
        public static Slider slider;
        public static TMPro.TextMeshProUGUI textoSlider;
        public static float volumenInicial;
        public static float maxTipificado;

        public static void CrearControl(Slider slider, TextMeshProUGUI textoSlider, float volumenInicial, float maxTipificado)
        {
            slider = slider;
            textoSlider = textoSlider;
            volumenInicial = volumenInicial;
            maxTipificado = maxTipificado;
        }

        public static void InicializarVolumen()
        {
            slider.value = volumenInicial;
            AudioListener.volume = volumenInicial * maxTipificado;
        }

        public static void CambiarVolumen()
        {
            AudioListener.volume = slider.value * maxTipificado;
            ActualizarTextoVolumen();
        }

        private static void ActualizarTextoVolumen()
        {
            int porcentajeVolumen = (int)(slider.value * 100);
            textoSlider.text = porcentajeVolumen + "%";
        }
    }
}
