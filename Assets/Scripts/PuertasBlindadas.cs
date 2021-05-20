using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasBlindadas : MonoBehaviour
{
    public int poderPuertas;
    public Sprite PuertaAbiertaB;
    SpriteRenderer PuertaCerradaB;
    int poder;
    GameManager gm;

    public AudioSource sonidoAbrirPuerta;
    AudioSource clonSonidoAbrirPuerta;

    void Start()
    {
        PuertaCerradaB = GetComponent<SpriteRenderer>();
        gm = GameManager.GetInstance();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if ((gm.poderHabilidad >= poderPuertas) && (collision.collider.gameObject.GetComponentInChildren<MelvinGrowth>()))
            {
                PuertaCerradaB.sprite = PuertaAbiertaB;
                GetComponent<Collider2D>().enabled = false;

                // Efectos de sonido
                clonSonidoAbrirPuerta = (AudioSource)AudioSource.Instantiate(sonidoAbrirPuerta);
                clonSonidoAbrirPuerta.Play();
                Destroy(clonSonidoAbrirPuerta, 1f);
            }
        }
    }
}
