using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjusteBrillo : MonoBehaviour
{
    public Slider slider;
    // Valor del Nuevo Slider
    public float sliderValue;
    // Panel de brillo
    public Image brightness;

    void Start()
    {
        // Para que al cerrar el juego y volverlo a abrir
        // Se mantenga de forma predefinida
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f); 
        // Cambia al valor por defecto y Accedemos a las propiedades de colores del panel
        brightness.color = new Color(brightness.color.r, brightness.color.g, brightness.color.b, slider.value);
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        // Guardamos el valor nuevo
        PlayerPrefs.SetFloat("brillo", sliderValue);
        // Cambiamos con el valor nuevo
        brightness.color = new Color(brightness.color.r, brightness.color.g, brightness.color.b, slider.value);
    }
  
}
