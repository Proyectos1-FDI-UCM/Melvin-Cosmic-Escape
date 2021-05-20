using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.GetComponentInChildren<EnemigoAcido>() == null)
        {
            gm.Pisarcharco();
        }
    }
}
