using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject Menu;
    public Button boton;
    bool pause=false;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible= false;
    }

    // Update is called once per frame
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
