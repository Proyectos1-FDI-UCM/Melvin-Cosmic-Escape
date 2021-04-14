using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelvinGrowth : MonoBehaviour
{
    [SerializeField] 
    private GameManager gameManager;

    private void Awake()
    {
        // Llamo al GM para declarar este gameobject como el Melvin actual
        gameManager.MelvinCreated(this.gameObject);
    }

    public void GrowMelvin()
    {
        // Declarar un vector con el nuevo tamaño
        Vector2 newSize = new Vector2(gameObject.transform.localScale.x + 0.1f, gameObject.transform.localScale.y + 0.1f);
        // Cambiar el tamaño de Melvin
        gameObject.transform.localScale = newSize;
    }
}
