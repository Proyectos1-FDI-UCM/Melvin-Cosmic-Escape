using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCinematica : MonoBehaviour
{
    void Start()
    {
        this.enabled = true;

        Invoke("Desactivar", 29f);
    }

    private void Update()
    {
        // Si pulsa el espacio se salta la cinemática
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Desactivar();
        }
    }

    void Desactivar()
    {
        //Debug.Log("Desactivar llamado.");
        Destroy(this.gameObject);
    }
}
