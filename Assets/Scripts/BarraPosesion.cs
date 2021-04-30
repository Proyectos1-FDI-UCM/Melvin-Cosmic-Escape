using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraPosesion : MonoBehaviour
{
    public int velFlecha;
    public PosesionController posesionController;
    public GameObject flecha;

    //Posicion inicial de la flecha para volver a ella cuando acabe
    RectTransform ini;

    //Grosor de la barra para saber hasta donde debe llegar la flecha
    float barWidth;

    //posicion de la flecha en x en todo momento
    float flec;

    //acabo es para decirle al update que deje de mover la flecha cuando ha acabado
        //dir determinara que direccion toma la flecha
    bool acabo, dir;

    private void Start()
    {
        ini = flecha.GetComponent<RectTransform>();
        barWidth = (GetComponent<RectTransform>().rect.width / 2) - 20;
        dir = true;
    }
    private void OnEnable()
    {
        acabo = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Si esta activado y no ha acabado...
        if (this.gameObject.activeSelf && !acabo)
        {
            //toma la posicion de la flecha multiplicada por 108 para que sea la posicion real (el canva esta reducido al 0.009)
            flec = flecha.GetComponent<RectTransform>().position.x * 108;

            //Determinamos que direccion toma la flecha comparando la posicion con el grosor de la barra
            if (flec >= barWidth)
                dir = false;
            else if (flec <= -barWidth)
                dir = true;

            //Dependiendo de la direccion la movera en un sentido u otro
            if (dir)
            {
                flecha.transform.Translate(new Vector2(velFlecha * Time.unscaledDeltaTime, 0));
            }
            else
            {
                flecha.transform.Translate(new Vector2(-velFlecha * Time.unscaledDeltaTime, 0));
            }
                
            //Cuando se pulse la E...
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Dejara de mover la flecha...
                flecha.transform.Translate(new Vector2(0, 0));

                //Determina que ha acabado...
                acabo = true;

                //Devuelve todo a la normalidad al segundo...
                Invoke(nameof(Deactive), 1);

                //Llama a posee con 0 (no hace nada)
                posesionController.Posee(0);
            }
            //Cuando se pulse el espacio...
            else if (Input.GetKey(KeyCode.Space))
            {
                //igual que arriba...
                flecha.transform.Translate(new Vector2(0, 0));
                acabo = true;

                //Dependiendo si la flecha esta tocando la zona verde...
                if (flecha.GetComponent<Flecha>().tocado)
                    //Llama a posee con 1 (posee al enemigo)
                    posesionController.Posee(1);
                else
                    //Falla la posesion
                    posesionController.Posee(2);

                //Devuelve todo a la normalidad al segundo
                Invoke(nameof(Deactive), 1);
            }
        }
    }
    //Devuelve todo a la normalidad
    void Deactive()
    {
        flecha.GetComponent<RectTransform>().position = ini.position;
        this.gameObject.SetActive(false);
        GameManager.GetInstance().Pausa(false);
    }
}
