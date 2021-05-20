using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calidad : MonoBehaviour
{
    public Dropdown dropdownCalidad, dropdownResoluciones;
    public Toggle pantalla;
    int calidad;
    Resolution[] resoluciones;

    void Start()
    {       
        // Guarda la calidad por defecto si se cambia , de esta manera al arrancar el juego se guardas los valores anteriormente dados
        calidad = PlayerPrefs.GetInt("NumerodeCalidad", 3);
        dropdownCalidad.value = calidad;
        // Pantalla completa
        // Para guardar si esta en plantalla completa o no al iniciar el juego
        if (Screen.fullScreen) pantalla.isOn = true;
        else pantalla.isOn = false;
        // Resolucion Pantalla
        RevisarResolucion();
    }
    public void AjustarCalidad()
    {
        // Dependiendo de la opcion a escoger accedemos a la calidad y se cambia 
        QualitySettings.SetQualityLevel(dropdownCalidad.value);
        PlayerPrefs.GetInt("NumerodeCalidad", dropdownCalidad.value);
        // Para guardar la opcion escojida
        calidad = dropdownCalidad.value;
    }
    // Si el bool es true se activa pantalla completa
    public void PantallaCompleta(bool pantallaCompleta) { Screen.fullScreen = pantallaCompleta; }
    public void RevisarResolucion()
    {
        // Obtengo las resoluciones
        resoluciones = Screen.resolutions;
        // Limpio las opciones por defecto
        dropdownResoluciones.ClearOptions();
        // Creo una lista de opciones de pantalla
         List<string> opciones = new List<string>();
        // Inicializo el array de resoluciones para luego usarlño para cargar la ultima puesta o ya de por si la por defecto
        int resolucionActual = 0;
        // Creo las opciones
        for (int i = 0; i < resoluciones.Length; i++)
        {
            // Creo la opcion
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height + "x" + resoluciones[i].refreshRate;
            //Aado la opcion a la lista
            opciones.Add(opcion);
            // Miro hasta encontrar la resolucion q hay por defecto o esta guardada de antes
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && Screen.fullScreen &&
                resoluciones[i].height == Screen.currentResolution.height) 
            {
                resolucionActual = i;
            } 
        }
        // Las asocio al dropdown
        dropdownResoluciones.AddOptions(opciones);
        // Pongo la que tiene ya puesta de antes o por defecto
        dropdownResoluciones.value = resolucionActual;
        // Refresca el valor del dropdown
        dropdownResoluciones.RefreshShownValue();
    }
    public void CambiarResolucion(int IndiceResolucion)
    {
        // Recibo la opcion y la saco del array de resoluciones
        Resolution resolucion = resoluciones[IndiceResolucion];
        // Actualizo dicha resolucion
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
