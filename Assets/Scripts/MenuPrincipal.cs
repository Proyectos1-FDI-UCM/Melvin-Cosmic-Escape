using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject opciones, botonesiniciales,salir;
    private void Start()
    {
        opciones.SetActive(false);
        salir.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            // Compruebo si esta activado el GameObject con .activeInHierarchy
            if (opciones.activeInHierarchy) 
            { 
                opciones.SetActive(false); botonesiniciales.SetActive(true); 
            }
            else if (salir.activeInHierarchy) 
            { 
                salir.SetActive(false); botonesiniciales.SetActive(true); 
            }
            else if (!opciones.activeInHierarchy) 
            { 
                salir.SetActive(true);botonesiniciales.SetActive(false); 
            }
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
