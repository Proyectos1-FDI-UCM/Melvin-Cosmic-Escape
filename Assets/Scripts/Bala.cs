using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float VelocityScale;
    public AudioSource sonidoDisparo;
    AudioSource clonSonidoDisparo;

    Rigidbody2D bulletfisica;

    GameManager gm;

    Vector2 melvin;
    // Acceso a componente Rigidbody
    void Start()
    {
        gm = GameManager.GetInstance();
        melvin = gm.PosicionDisparo();

        Instantiate(sonidoDisparo);

        clonSonidoDisparo = Instantiate(sonidoDisparo);
        clonSonidoDisparo.Play();
        Invoke("DestruyeSonido", 2f);

        // bulletfisica = GetComponent<Rigidbody2D>();
    }

    // Evita que haya GO innecesarios en la escena
    private void DestruyeSonido()
    {
        Destroy(clonSonidoDisparo);
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
