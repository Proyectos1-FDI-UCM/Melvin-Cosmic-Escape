using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public bool tocado;

    //Si esta en la zona verde vale true, si no vale false :vvv
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ParteVerde")
            tocado = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ParteVerde")
            tocado = false;
    }
}
