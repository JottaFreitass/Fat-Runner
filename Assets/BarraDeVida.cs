using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public int RealVida = 10;
    
    public void SetarVidaMax(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }

    public void SetarVida()
    {
        slider.value = RealVida;
    }
}
