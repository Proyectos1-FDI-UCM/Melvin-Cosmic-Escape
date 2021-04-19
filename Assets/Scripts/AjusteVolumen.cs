using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AjusteVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    
    // Start is called before the first frame update
    void Start()
    {
        //valor predeterminado q se guarda o tiene por defecto cuando arranca el juego
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        //accede al componente
        AudioListener.volume = slider.value;       
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        //actualizar el valor del sonido con el valor del slider
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;        
    }
    
}
