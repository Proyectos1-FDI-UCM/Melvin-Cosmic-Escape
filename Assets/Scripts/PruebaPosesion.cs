using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPosesion : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
        }
    }
}
