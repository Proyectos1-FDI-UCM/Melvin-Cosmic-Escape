using UnityEngine;

public class PosesionController : MonoBehaviour
{
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

    public bool poseyendo;
    bool enProceso;

    private void Start()
    {
        poseyendo = false;
        enProceso = false;
    }

    void OnTriggerStay2D(Collider2D collision2D)
    {
        // Si se pulsa la tecla de poseer (Enter no veo como va) y no esta ya poseyendo, posee a lo que toque
        if (Input.GetKey(KeyCode.T) && !poseyendo && !enProceso)
        {
            //Nos aseguramos de que solo interactue con un enemigo a la vez
            if (other == null || other.layer != 8 || other.layer != 9 || other.layer != 10)
                other = collision2D.gameObject;

            if (other != null)
                switch (other.layer)
                {
                    case 8:     //Este es el numero de capa del enemigo científico

                        enProceso = true;

                        // Pasa a ser el enemigo poseido
                        melvin.SetActive(false);
                        cientifico.SetActive(true);

                        //Pasa a estar en la misma posicion
                        transform.position = other.gameObject.transform.position;

                        cientif = other.gameObject.GetComponent<EnemigoCientifico>().numCientifico;
                        this.GetComponentInChildren<EnemigoCientifico>().numCientifico = cientif;

                        //Destruimos el gameobject del enemigo que acabamos de poseer
                        Destroy(other.gameObject);

                        //Declaramos poseyendo = true (supongo que nos servira mas adelante), y a lo mejor deberia estar en el GM?????

                        //Esta en un invoke ya que al intentar poseer se llamaba al metodo desposeer desde el melvin controller al instante.
                        Invoke("ConfirmarPosesion", reposoTrasPoseer);

                        break;
                    case 9:     //Este es el numero de capa del enemigo ácido

                        enProceso = true;

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

                        enProceso = true;

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