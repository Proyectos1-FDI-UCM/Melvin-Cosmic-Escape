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

    public PosesionController posesionController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Nueva condicion de si el juego esta en pausa
        if (!GameManager.GetInstance().pausa)
        {
            //input del jugador
            float deltaX = Input.GetAxis("Horizontal");
            float deltaY = Input.GetAxis("Vertical");
            movimiento = new Vector2(deltaX, deltaY);

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
        }
        else movimiento = new Vector2(0, 0); ;

    }
    void FixedUpdate()
    {

        rb.velocity = (movimiento * speed);

    }
}
