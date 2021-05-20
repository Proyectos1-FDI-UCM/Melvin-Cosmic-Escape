using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelvinController : MonoBehaviour
{
    //0.1 m/s
    public float speed;
    Rigidbody2D rb;
    Vector2 movimiento;
    Quaternion rotacion;
    public Animator melvin, acido, fuerte;

    GameObject mel, aci, fue;

    public PosesionController posesionController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mel = this.transform.GetChild(0).gameObject;
        aci = this.transform.GetChild(2).gameObject;
        fue = this.transform.GetChild(3).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //Nueva condicion de si el juego esta en pausa
        if (!GameManager.GetInstance().pausa)
        {
            //input del jugadors
            float deltaX = Input.GetAxis("Horizontal");
            float deltaY = Input.GetAxis("Vertical");
            movimiento = new Vector2(deltaX, deltaY);

            //Activamos las animaciones cuando correspondan
            if (mel.activeSelf)
            {
                melvin.SetFloat("vel", Mathf.Abs(deltaX) + Mathf.Abs(deltaY));
            }
            //faltaria el del cientifico
            else if (aci.activeSelf)
            {
                acido.SetFloat("vel", Mathf.Abs(deltaX) + Mathf.Abs(deltaY));
            }
            else if (fue.activeSelf)
            {
                fuerte.SetFloat("vel", Mathf.Abs(deltaX) + Mathf.Abs(deltaY));
            }

            if (deltaX < 0)
                transform.rotation = new Quaternion(0, -180, 0, 0);
            else if (deltaX > 0)
                transform.rotation = new Quaternion(0, 0, 0, 0);
            /*else if (deltaY > 0)
                transform.rotation = new Quaternion(0, 0, 45, 45);
            else if (deltaY < 0)
                transform.rotation = new Quaternion(0, 0, 45, -45);*/

            if (Input.GetKey(KeyCode.T) && posesionController.poseyendo)
                posesionController.Desposeer();
            else if (Input.GetKey(KeyCode.E))
            {
                if (fue.activeSelf)
                    fuerte.SetTrigger("gorpe");
            }
        }
        else
        {
            movimiento = new Vector2(0, 0);

            if (mel.activeSelf)
            {
                melvin.SetFloat("vel", 0);
            }
            //faltaria el del cientifico
            else if (aci.activeSelf)
            {
                acido.SetFloat("vel", 0);
            }
            else if (fue.activeSelf)
            {
                fuerte.SetFloat("vel", 0);
            }
        }

    }
    void FixedUpdate()
    {

        rb.velocity = (movimiento * speed);



    }
}
