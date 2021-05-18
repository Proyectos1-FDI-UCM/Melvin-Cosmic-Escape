using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaNivel : MonoBehaviour
{
    GameManager gm;
    public string nivel;

    public AudioSource sonidoFinNivel;
    AudioSource clonSonidoFinNivel;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            gm.PasarNivel(nivel);
            clonSonidoFinNivel = (AudioSource)AudioSource.Instantiate(sonidoFinNivel);
            clonSonidoFinNivel.Play();
            Destroy(clonSonidoFinNivel, 3f);
        }
    }
}
