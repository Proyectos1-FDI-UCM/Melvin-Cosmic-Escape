using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public GameObject Camara;
    public float VelocityScale;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PosesionController>() != null)
        {
            Camara.transform.Translate( Vector3.MoveTowards(Camara.transform.position, this.transform.position, VelocityScale * Time.deltaTime));
        }
    }

    
}
