using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasBlindadas : MonoBehaviour
{
    public int poderPuertas;
    public Sprite PuertaAbiertaB;
    SpriteRenderer PuertaCerradaB;
    int poder;

    void Start()
    {
        PuertaCerradaB = GetComponent<SpriteRenderer>();

        print(poder);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("aaaaa");

        if (collision.collider.gameObject.GetComponent<PosesionController>() != null && Input.GetKey(KeyCode.E))
        {
            print("uuuuuu");
            poder = collision.collider.gameObject.GetComponent<GameManager>().poderHabilidad;
            
            print(poder);

            if (poder == poderPuertas)
            {
                PuertaCerradaB.sprite = PuertaAbiertaB;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
