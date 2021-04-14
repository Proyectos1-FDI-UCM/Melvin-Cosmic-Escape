using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.gameObject.GetComponentInChildren<EnemigoFuerte>())
        {
            Destroy(this.gameObject);
        }
        
        // + animaciones, etc etc etc
    }
}
