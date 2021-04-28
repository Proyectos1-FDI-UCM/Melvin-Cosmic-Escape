using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject bala;
    [SerializeField] GameObject prefabCampo;
    CampoDeVision campo;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (campo.melvinEncontrado)
        {
            Instantiate(bala, -transform.position, transform.rotation);
            Debug.Log("Bala disparada");
        }
    }
}
