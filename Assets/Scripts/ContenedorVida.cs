using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorVida : MonoBehaviour
{
    public int vidaCurada = 5;
    bool usado = false;
    public Sprite contlleno;
    SpriteRenderer contvacio;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
        contvacio = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Aaaaa");
        if (Input.GetKey(KeyCode.E) && !usado && collision.gameObject.GetComponentInChildren<MelvinGrowth>() != null)
        {
            usado = true;
            gm.CurarVida(vidaCurada);
            contvacio.sprite = contlleno;
        }
    }
}
