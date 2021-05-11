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

    void Desactivar()
    {
        Debug.Log("Desactivar llamado.");
        Destroy(this.gameObject);
    }
}
