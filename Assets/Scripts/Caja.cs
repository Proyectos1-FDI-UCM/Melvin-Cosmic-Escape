using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    public AudioSource sonidoCaja;
    AudioSource clonSonidoCaja;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.gameObject.GetComponentInChildren<EnemigoFuerte>())
        {
            Destroy(this.gameObject);
            clonSonidoCaja = (AudioSource)AudioSource.Instantiate(sonidoCaja);
            clonSonidoCaja.Play();
            Destroy(clonSonidoCaja, 3f);
        }
    }
}
