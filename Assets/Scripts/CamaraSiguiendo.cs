using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSiguiendo : MonoBehaviour
{
    // Objeto al que seguirá la cámara
    public Transform melvin;
    // Desplazamiento de la cámara respecto a Melvin
    Vector3 offset;

    void Start()
    {
        // Guardamos la distancia que hay al inicio entre la cámara y el objeto
        offset = transform.position - melvin.position;
    }

    void LateUpdate()
    {
        // Actualizar la posición para que se mantenga la distancia del principio cada vez que se haga un Update
        transform.position = melvin.position + offset;
    }
}
