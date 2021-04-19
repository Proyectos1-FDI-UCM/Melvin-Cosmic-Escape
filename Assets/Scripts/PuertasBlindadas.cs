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

    void Start()
    {
        PuertaCerradaB = GetComponent<SpriteRenderer>();
        gm = GameManager.GetInstance();
        print(poder);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {

            print("aaaaa");

            if (gm.poderHabilidad == poderPuertas)
            {
                PuertaCerradaB.sprite = PuertaAbiertaB;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
