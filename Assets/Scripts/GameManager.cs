using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Array que contiene los niveles del juego, se controla desde el editor
    public string[] scenesInOrder;

    public bool pausa = true    ;

    // Variable que almacena la instancia del GameManager
    private static GameManager instance;
    // Variable para poder comunicarme con el UIManager
    private UIManager theUIManager;
    
    // Variable de referencia al objeto de Melvin
    public GameObject melvin;
    // Variables de la vida del jugador
    float vidaMaxima = 100;
    public float vidaActual = 100;
    
    // Variables del poder del jugador
    public int poderHabilidad = 0;

    // Variable que lleva el recuento de con cuántos Glops se ha fusionado
    int glopsFusionados = 0;

    // Al activar el objeto asociado, evita que haya dos controladores del GameManager
    private void Awake()
    {
        instance = this;
        // Si no tiene instancia ya creada, almacena la actual
        if (instance == null)
        {
            instance = this;
            //No destruye el Game Manager aunque se cambie de escena  
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Si ya hay instancia creada lo destruye porque no se necesita otro
            Destroy(this);
        }
    }

    // Permite a los otros objetos conocer el estado de la instancia del game manager pero sin poder acceder a ella
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Invocamos al UIManager
    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
        uim.takeDamage(vidaActual, vidaMaxima, false, false);
    }

    // Asigna el GO correspondiente a Melvin
    public void MelvinCreated(GameObject melvinCreado)
    {
        melvin = melvinCreado;
    }

    // Se llama a este método cuando un glop entra en contacto con Melvin
    public void GlopFusionado()
    {
        if (!pausa)
        {
            glopsFusionados++;
            vidaMaxima += 10;
            vidaActual = vidaMaxima;
            poderHabilidad += 10;

            // Aumenta el tamaño de Melvin
            melvin.GetComponentInChildren<MelvinGrowth>().GrowMelvin();
            // Invoco UIManager para actualizar la vida max
            SetUIManager(theUIManager);
            theUIManager.takeDamage(vidaActual, vidaMaxima, false, true);
        }
    }

    public void Pisarcharco()
    {
        if (!pausa)
        {
            vidaActual = 0;
            theUIManager.takeDamage(vidaActual, vidaMaxima, false, false);
            theUIManager.Perder();
        }
    }

    public void Impactarbala()
    {
        //Actualización de la vida de Melvin
        vidaActual = vidaActual - 50;

        //Representación por pantalla
        theUIManager.takeDamage(vidaActual, vidaMaxima, true, false);
    }


    //Curar vida de Melvin
    public void CurarVida (int vidaCurada)
    {
  
        if ((vidaCurada > 0) && ((vidaActual < vidaMaxima && vidaCurada > 0) || (vidaActual > vidaCurada && vidaCurada < 0)))
        {
            vidaActual = vidaActual + vidaCurada;
            SetUIManager(theUIManager);
            theUIManager.takeDamage(vidaActual, vidaMaxima, false, true);
            Debug.Log("vida curada");
        }else if ((vidaCurada < 0) && (vidaActual < vidaMaxima && vidaCurada > 0) || (vidaActual > vidaCurada && vidaCurada < 0))
        {
            vidaActual = vidaActual + vidaCurada;
            theUIManager.takeDamage(vidaActual, vidaMaxima, true, false);
            Debug.Log("vida perdida");
        }
    }


    //Ganar partida
    public void GanarPartida ()
    {
        theUIManager.Ganar();
    }

    // He tenido que declarar esta variable y metodo para que funcione todo
        // Se añadirían los elementos que se vean afectados por la pausa
    public void Pausa(bool pausaActiva)
    {
        pausa = pausaActiva;
    }


    //Obtener la posicion de Melvin
    public Vector2 PosicionDisparo()
    {
        return melvin.transform.position;
    }


    //Cambio de nivel
    public void PasarNivel(string nivel)
    {
        theUIManager.ChangeScene(nivel);
    }
  
}


