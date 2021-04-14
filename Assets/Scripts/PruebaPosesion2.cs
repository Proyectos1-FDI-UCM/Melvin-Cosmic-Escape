using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPosesion2 : MonoBehaviour
{

    Color color;

    private void Awake()
    {
        color = new Color(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponentInChildren<SpriteRenderer>().color = color;
            color = new Color(0f, 1f, 0f);
        }
    }
}
