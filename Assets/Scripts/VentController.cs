using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    public int numVent;

    public Sprite[] spritesVent = new Sprite[3];

    void Awake()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesVent[numVent - 1]; //Importante colocar los sprites en orden
        this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = spritesVent[numVent - 1];
    }
}
