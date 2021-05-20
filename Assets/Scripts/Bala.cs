using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float VelocityScale;
    public AudioSource sonidoDisparo;
    AudioSource clonSonidoDisparo;

    GameManager gm;
    Vector2 melvin;

    void Start()
    {
        gm = GameManager.GetInstance();
        melvin = gm.PosicionDisparo();

        clonSonidoDisparo = Instantiate(sonidoDisparo);
        clonSonidoDisparo.Play();
        Destroy(clonSonidoDisparo, 1f);
    }

    // Se establece el desplazamiento de la bala.
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, melvin, VelocityScale * Time.deltaTime);
        if (new Vector2 (this.transform.position.x , this.transform.position.y) == melvin)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponentInParent<MelvinController>())
        { 
            gm.Impactarbala();
        }
    }
}
