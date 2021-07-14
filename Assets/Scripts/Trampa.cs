using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void Update()
    {
        Invoke("Desactivar", 2);
        Invoke("Activar", 4);
    }
    void Desactivar()
    {
        this.gameObject.SetActive(false);
    }
    void Activar()
    {
        this.gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.activeSelf && collision.gameObject.GetComponent<MelvinController>())
        {
            GameManager.GetInstance().Pisarcharco();
        }
    }
}
