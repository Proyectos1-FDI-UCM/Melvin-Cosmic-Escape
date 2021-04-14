using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasLaboratorio : MonoBehaviour
{
    public int numpuertas;
    public Sprite PuertaAbierta;
    SpriteRenderer PuertaCerrada;
    int enemigo;

    void Start()
    {
        PuertaCerrada = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<EnemigoCientifico>() != null && Input.GetKey(KeyCode.E))
        {
            enemigo = collision.collider.gameObject.GetComponent<EnemigoCientifico>().numCientifico;

            if (numpuertas == enemigo)
            {
                PuertaCerrada.sprite = PuertaAbierta;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
