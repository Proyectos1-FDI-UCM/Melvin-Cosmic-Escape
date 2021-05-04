using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera Camara;
    public GameObject canvas;
    public float VelocityScale;
    public GameObject lugar;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FindObjectOfType<MelvinController>())
        {
            //Camara.transform.Translate( Vector3.MoveTowards(Camara.transform.position, lugar.transform.position, VelocityScale ));
            Camara.transform.position= lugar.transform.position;  
            Camara.transform.position = new Vector3(Camara.transform.position.x, Camara.transform.position.y, -10);
            //Camara.transform.position= lugarCam.transform.position;            
            canvas.transform.position = lugar.transform.position;
           
        }        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (FindObjectOfType<MelvinController>())
        {
            this.GetComponent<Collider2D>().isTrigger = false;
            
        }
       
    }

}
