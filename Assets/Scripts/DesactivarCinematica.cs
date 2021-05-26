using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCinematica : MonoBehaviour
{
    public float tiempoDesactivar;
    public bool cinematicaActiva = false;
    public GameObject panel;
    public GameObject videoPlayer;

    void Start()
    {
        this.enabled = true;
        cinematicaActiva = true;
        Invoke("Desactivar", tiempoDesactivar);
    }

    private void Update()
    {
        // Si pulsa el espacio se salta la cinemática
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Desactivar();
            Invoke("DesactivarPanel", 2f);
        }

    }

    void Desactivar()
    {
        //Debug.Log("Desactivar llamado.");
        this.gameObject.SetActive(false);
        videoPlayer.SetActive(false);
        cinematicaActiva = false;
        panel.SetActive(true);
        Invoke("DesactivarPanel", 2f);
    }

    void DesactivarPanel() 
    {
        GameManager.GetInstance().pausa = false;
        panel.SetActive(false); 
    }
}
