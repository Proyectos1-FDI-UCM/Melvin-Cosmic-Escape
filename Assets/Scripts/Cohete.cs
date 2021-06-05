using UnityEngine;

public class Cohete : MonoBehaviour
{
    GameManager gm;
    public GameObject cinematicaFinal;
    
    private void Start()
    {
         gm = GameManager.GetInstance();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (Input.GetKey(KeyCode.E))
        {
            gm.GanarPartida();
            GameObject cinematica = (GameObject)GameObject.Instantiate(cinematicaFinal);
            cinematica.transform.position = gm.melvin.transform.position;

            Destroy(cinematica.gameObject, 5f);
        }
    }
}
