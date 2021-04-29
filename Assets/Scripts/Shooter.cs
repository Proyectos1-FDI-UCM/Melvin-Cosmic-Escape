using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject bala;
    [SerializeField] GameObject prefabCampo;
    CampoDeVision campo;

    bool retardo = false;

    void Awake()
    {
        campo = Instantiate(prefabCampo, null).GetComponent<CampoDeVision>();
    }

    void Update()
    {
        campo.Origen(this.transform.position);
        campo.Direccion(this.transform.rotation.eulerAngles); // dirección del fov

        if (campo.melvinEncontrado && !retardo)
        {
            Instantiate(bala, transform.position, transform.rotation);
            Debug.Log("Bala disparada");
            retardo = true;
            Invoke("DeshacerRetardo",1f);
        }
    }

    void DeshacerRetardo()
    {
        retardo = false;
    }
}
