using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera Camara;
    public GameObject canvas;
    //public float VelocityScale;
    //public GameObject[] lugar;
    //public static MovCamara aEntrar;
    //bool a, b;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (FindObjectOfType<MelvinController>())
        //{
        //    a == true
        //    aEntrar = this;
        //    Debug.Log(this.gameObject.name);
        //}

        Camara.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -10);

        canvas.transform.position = this.gameObject.transform.position;

    }
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (FindObjectOfType<MelvinController>())
    //    {
    //        //Camara.transform.Translate( Vector3.MoveTowards(Camara.transform.position, lugar.transform.position, VelocityScale ));
    //        //Camara.transform.position = lugar[I].transform.position;
    //        Camara.transform.position = new Vector3(aEntrar.gameObject.transform.position.x, aEntrar.gameObject.transform.position.y, -10);
    //        //Camara.transform.position= lugarCam.transform.position;            
    //        canvas.transform.position = aEntrar.gameObject.transform.position;

    //        Camara.transform.localScale = new Vector3(aEntrar.gameObject.transform.localScale.x, aEntrar.gameObject.transform.localScale.y, -10);
    //        //Camara.transform.position= lugarCam.transform.position;            
    //        canvas.transform.localScale = aEntrar.gameObject.transform.localScale * 0.009256008f;

    //        //this.GetComponent<Collider2D>().isTrigger = false;
    //        //I++;
    //    }
    //    //if (I == 2) I = 0;
    //    //Invoke("COLLIDER", 4);
    //}
    //void COLLIDER()
    //{
    //    this.GetComponent<Collider2D>().isTrigger = true;
    //}
    //void FactorDeCorreccion()
    //{

    //}
}
