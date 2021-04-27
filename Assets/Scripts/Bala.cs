using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float VelocityScale;
    Rigidbody2D bulletfisica;


    // Acceso a componente Rigidbody
    void Start()
    {

        bulletfisica = GetComponent<Rigidbody2D>();

    }


    // Se establece el desplazamiento de la bala.
    private void FixedUpdate()
    {
        bulletfisica.velocity = transform.up * VelocityScale;
    }
}
