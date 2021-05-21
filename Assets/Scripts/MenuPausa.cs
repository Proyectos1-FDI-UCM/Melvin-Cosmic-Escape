using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public BarraPosesion scriptBarra;
    public GameObject Menu;
    public Button boton;
    bool pause = false;

    void Start()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible= false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))         
        {
            if (pause)
            {
                pause = false;
                Time.timeScale = 1;
                AudioListener.volume = 1;
                Cursor.visible = false;
                Menu.SetActive(false);
            }
            else if (!pause )
            {
                pause = true;
                Time.timeScale = 0;
                AudioListener.volume = 0;
                Cursor.visible = true;
                Menu.SetActive(true);
                if (scriptBarra.gameObject.activeSelf)
                {
                    scriptBarra.Deactive();
                }
            }
        }      
    }
    public void botonCursor()
    {
        pause = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Cursor.visible = false;        
    }
}
