using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AjusteVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    
    void Start()
    {
        // Valor predeterminado q se guarda o tiene por defecto cuando arranca el juego
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        // Accede al componente
        AudioListener.volume = slider.value;       
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        // Actualizar el valor del sonido con el valor del slider
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;        
    }
    
}
