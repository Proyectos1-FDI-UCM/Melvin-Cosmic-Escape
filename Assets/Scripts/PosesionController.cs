using UnityEngine;

public class PosesionController : MonoBehaviour
{
    public UIManager uiManager;

    public Animator anim;

    public float reposoTrasPoseer;

    int cientif;

    public GameObject melvin;

    public GameObject cientifico;
    public GameObject cientificoEne;

    public GameObject acido;
    public GameObject acidoEne;

    public GameObject fuerte;
    public GameObject fuerteEne;
    //Hay que declarar: el prefab del enemigo de dentro de player y el prefab del enemigo por su cuenta para cada uno

    private GameObject other;
    int opc;

    public bool poseyendo;
    bool enProceso;


    AudioSource clonSonidoPosesion;
    public AudioSource sonidoPosesion;

    private void Start()
    {
        poseyendo = false;
        enProceso = false;
    }

    void OnTriggerStay2D(Collider2D collision2D)
    {
        // Si se pulsa la tecla de poseer (Enter no veo como va) y no esta ya poseyendo, posee a lo que toque
        if (Input.GetKey(KeyCode.T) && !poseyendo && !enProceso && ( collision2D.gameObject.layer == 8 || collision2D.gameObject.layer == 9 || collision2D.gameObject.layer == 10))
        {
            other = collision2D.gameObject;

            //Llamamos al Uimanager para que inicie el proceso
            uiManager.BarraPosesion();

        }
    }

    public void Posee(int opc)
    {
        //Declaramos enProceso a true y tras el reposo vuelve a false, para controlar cuando puede poseer(se puede quitar sin mucho problema)
        enProceso = true;
        Invoke(nameof(FinCooldown), reposoTrasPoseer);

        //Si le llega 1 ocurre la posesion normal
        if (opc == 1)
        {

            anim.SetTrigger("Posee");

            switch (other.layer)
            {
                case 8:     //Este es el numero de capa del enemigo científico

                    // Pasa a ser el enemigo poseido
                    melvin.SetActive(false);
                    cientifico.SetActive(true);


                    cientif = other.gameObject.GetComponent<EnemigoCientifico>().numCientifico;
                    this.GetComponentInChildren<EnemigoCientifico>(true).numCientifico = cientif;

                    //Pasa a estar en la misma posicion
                    transform.position = other.gameObject.transform.position;

                    //Destruimos el gameobject del enemigo que acabamos de poseer
                    Destroy(other.gameObject);

                    //Declaramos poseyendo = true (supongo que nos servira mas adelante), y a lo mejor deberia estar en el GM?????

                    //Esta en un invoke ya que al intentar poseer se llamaba al metodo desposeer desde el melvin controller al instante.
                    Invoke("ConfirmarPosesion", reposoTrasPoseer);

                    break;
                case 9:     //Este es el numero de capa del enemigo ácido

                    // Pasa a ser el enemigo poseido
                    melvin.SetActive(false);
                    acido.SetActive(true);

                    //Pasa a estar en la misma posicion
                    transform.position = other.gameObject.transform.position;

                    //Destruimos el gameobject del enemigo que acabamos de poseer
                    Destroy(other.gameObject);

                    //Declaramos poseyendo = true (supongo que nos servira mas adelante), y a lo mejor deberia estar en el GM?????

                    //Esta en un invoke ya que al intentar poseer se llamaba al metodo desposeer desde el melvin controller al instante.
                    Invoke("ConfirmarPosesion", reposoTrasPoseer);

                    break;

                case 10:     //Este es el numero de capa del enemigo fuerte

                    // Pasa a ser el enemigo poseido
                    melvin.SetActive(false);
                    fuerte.SetActive(true);

                    //Pasa a estar en la misma posicion
                    transform.position = other.gameObject.transform.position;

                    //Destruimos el gameobject del enemigo que acabamos de poseer
                    Destroy(other.gameObject);

                    //Declaramos poseyendo = true (supongo que nos servira mas adelante), y a lo mejor deberia estar en el GM?????

                    //Esta en un invoke ya que al intentar poseer se llamaba al metodo desposeer desde el melvin controller al instante.
                    Invoke("ConfirmarPosesion", reposoTrasPoseer);

                    break;
                    //Se añade un case de este mismo estilo para cada enemigo
            }

            clonSonidoPosesion = Instantiate(sonidoPosesion);
            clonSonidoPosesion.Play();
            Destroy(clonSonidoPosesion, 1f);
        }
        //He modificado el CurarVida para que tambien acepte valores negativos y no pete
        else if (opc == 2)
        {
            GameManager.GetInstance().CurarVida(-30);
        }
    }

    void ConfirmarPosesion()
    {
        poseyendo = true;
        enProceso = false;
    }
    void ConfirmarDesposesion()
    {
        poseyendo = false;
    }
    void FinCooldown()
    {
        enProceso = false;
    }

    public void Desposeer()
    {
        if (cientifico.activeSelf)
        {
            cientifico.SetActive(false);
            Instantiate(cientificoEne, transform.position, transform.rotation).GetComponent<EnemigoCientifico>().numCientifico = cientif;
        }
        else if (acido.activeSelf)
        {
            acido.SetActive(false);
            Instantiate(acidoEne, transform.position, transform.rotation);
        }
        else if (fuerte.activeSelf)
        {
            fuerte.SetActive(false);
            Instantiate(fuerteEne, transform.position, transform.rotation);
        }
        //Y aqui mas else ifs para cada enemigo

        melvin.SetActive(true);
        Invoke("ConfirmarDesposesion", reposoTrasPoseer);
    }

}