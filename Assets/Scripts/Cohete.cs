using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete : MonoBehaviour
{
    GameManager gm;
    public GameObject cinematicaFinal;

    private void Start()
    {
         gm = GameManager.GetInstance();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            gm.GanarPartida();
            cinematicaFinal.SetActive(true);
        }
    }

    void DesactivaCinematica()
    {
        cinematicaFinal.SetActive(false);
    }
}
