using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlopOnCollision : MonoBehaviour
{
    // Variable del Game Manager
    private GameManager gameManager;

    private void Start()
    { // Acceso a la info del GameManager
        gameManager = GameManager.GetInstance();
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        // ...comprobará si ha colisionado con Melvin y además la tecla de interacción está pulsada y de que no este en pausa
        if (Input.GetKey(KeyCode.E) && collider2D.gameObject.GetComponent<MelvinGrowth>() && !gameManager.pausa)
        {
            // Destruirá al glop e informará de ello al GM
            Destroy(this.gameObject);
            gameManager.GlopFusionado();
        }
    }
}
