using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    public AudioSource sonidoCaja;
    AudioSource clonSonidoCaja;
    public Animator caja;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.gameObject.GetComponentInChildren<EnemigoFuerte>())
        {

            caja.SetTrigger("Destruye");

            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            Destroy(this.gameObject, 0.09f);
            clonSonidoCaja = (AudioSource)AudioSource.Instantiate(sonidoCaja);
            clonSonidoCaja.Play();
            Destroy(clonSonidoCaja, 3f);
        }
    }
}
