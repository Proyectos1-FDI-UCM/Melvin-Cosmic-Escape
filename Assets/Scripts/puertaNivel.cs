using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaNivel : MonoBehaviour
{

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            gm.PasarNivel();
        }
    }
}
