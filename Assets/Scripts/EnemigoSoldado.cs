using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSoldado : MonoBehaviour
{
    [SerializeField] GameObject prefabCampo;
    [SerializeField] GameObject bala;
    CampoDeVision campo;
    void Awake()
    {
        campo = Instantiate(prefabCampo, null).GetComponent<CampoDeVision>();
    }

    void Update()
    {
        /// ESTE BLOQUE DE CÓDIGO VA EN UPDATE SI EL ENEMIGO SOLDADO SE VA A MOVER, EN AWAKE SI NO SE MOVERÁ

        campo.Origen(this.transform.position);
        campo.Direccion(this.transform.rotation.eulerAngles); // dirección del fov

        if (campo.melvinEncontrado)
        {
            Instantiate(bala, transform.position, transform.rotation);
            Debug.Log("Bala disparada");
        }
    }
}
