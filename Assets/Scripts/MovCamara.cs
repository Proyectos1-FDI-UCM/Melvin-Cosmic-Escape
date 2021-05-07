using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera Camara;
    public GameObject canvas;
    public float VelocityScale;
    public GameObject[] lugar;    
    int I=0;      
    private void OnTriggerExit2D(Collider2D other)
    {
        if (FindObjectOfType<MelvinController>())
        {
            //Camara.transform.Translate( Vector3.MoveTowards(Camara.transform.position, lugar.transform.position, VelocityScale ));
            Camara.transform.position = lugar[I].transform.position;
            Camara.transform.position = new Vector3(Camara.transform.position.x, Camara.transform.position.y, -10);
            //Camara.transform.position= lugarCam.transform.position;            
            canvas.transform.position = lugar[I].transform.position;
            this.GetComponent<Collider2D>().isTrigger = false;
            I++;
        }
        if (I == 2) I = 0;
        Invoke("COLLIDER", 4);
    }
    void COLLIDER()
    {
        this.GetComponent<Collider2D>().isTrigger = true;
    }
}
