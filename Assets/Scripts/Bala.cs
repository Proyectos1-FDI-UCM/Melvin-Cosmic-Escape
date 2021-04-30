using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float VelocityScale;
    Rigidbody2D bulletfisica;

    GameManager gm;

    Vector2 melvin;
    // Acceso a componente Rigidbody
    void Start()
    {
        gm = GameManager.GetInstance();
        melvin = gm.PosicionDisparo();

        // bulletfisica = GetComponent<Rigidbody2D>();
    }

    // Se establece el desplazamiento de la bala.
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, melvin, VelocityScale * Time.deltaTime);

        
    }

    void DestruyeBala()
    {
        Destroy(this.gameObject);
    }

}
