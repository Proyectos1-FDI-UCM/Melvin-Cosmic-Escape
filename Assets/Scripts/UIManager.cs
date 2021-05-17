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
    bool fin = false;

    public AudioSource sonidoPerderVida;
    AudioSource clonSonidoPerderVida;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.GetInstance().SetUIManager(this);
        PanelGanar.SetActive(false);
        PanelPerder.SetActive(false);
    }
    //Metodo con el cual actualizamos la barra de vida junto a su porcentaje
    public void takeDamage(float vidaActual, float vidaMax, bool pierdeVida)
    {
        //Para evitar que la vida Actual se pueda sobrePasar la vidaMaxima *Para una vez se creen las curas*
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        if (vidaActual==0)
        {
            Perder();            
        }
        barraVida.fillAmount = vidaActual / vidaMax;
        numVida.text = vidaActual.ToString()+"%";

        if (pierdeVida)
        {
            clonSonidoPerderVida = Instantiate(sonidoPerderVida);
            clonSonidoPerderVida.Play();
            Invoke("DestruyeSonido", 1f);
        }
    }

    //Método que cambia de escena
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }    
    public void Exit()
    {
        Application.Quit();
    }

    public void Ganar()
    {
        PanelGanar.SetActive(true);
        fin = true;
        Invoke("Fuera", 3);

    }
    public void Perder()
    {
        PanelPerder.SetActive(true);
        Invoke("Fuera", 3);

        gm.Pausa(true);
    }

    void Fuera()
    {
        PanelGanar.SetActive(false);
        PanelPerder.SetActive(false);

        string escena = SceneManager.GetActiveScene().name;

        if (fin)
        {
            escena = "MENU";
        }

        ChangeScene(escena);
        Cursor.visible = true;
    }

    public void BarraPosesion()
    {
        //Pausa el juego
        GameManager.GetInstance().Pausa(true);

        //Activa la barra de posesion que a su vez iniciara todo su tinglado
        barraPosesion.gameObject.SetActive(true);
    }

    // Evita que haya GO innecesarios en la escena
    private void DestruyeSonido()
    {
        Destroy(clonSonidoPerderVida);
    }

}
