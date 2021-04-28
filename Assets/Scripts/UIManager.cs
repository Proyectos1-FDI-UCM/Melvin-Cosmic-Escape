using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public float vidaMax, vidaActual;
    public Image barraVida;
    public Text numVida; 
    GameManager gm;
    public GameObject PanelGanar;
    public GameObject PanelPerder;
    public BarraPosesion barraPosesion;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.GetInstance().SetUIManager(this);
        PanelGanar.SetActive(false);
        PanelPerder.SetActive(false);
    }
    //Metodo con el cual actualizamos la barra de vida junto a su porcentaje
    public void takeDamage(float vidaActual, float vidaMax)
    {
        //Para evitar que la vida Actual se pueda sobrePasar la vidaMaxima *Para una vez se creen las curas*
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        if (vidaActual==0)
        {
            Perder();
        }
        barraVida.fillAmount = vidaActual / vidaMax;
       numVida.text = vidaActual.ToString()+"%";
    }

    //Método que cambia de escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
    public void Exit()
    {
        Application.Quit();
    }


    public void Ganar()
    {
        PanelGanar.SetActive(true);
        Invoke("Fuera", 3);

    }
    public void Perder()
    {
        PanelPerder.SetActive(true);
        Invoke("Fuera", 3);
    }

    void Fuera()
    {
        PanelGanar.SetActive(false);
        PanelPerder.SetActive(false);

        ChangeScene("MENU");
        Cursor.visible = true;
    }

    public void BarraPosesion()
    {
        //Pausa el juego
        GameManager.GetInstance().Pausa(true);

        //Activa la barra de posesion que a su vez iniciara todo su tinglado
        barraPosesion.gameObject.SetActive(true);
    }

}
