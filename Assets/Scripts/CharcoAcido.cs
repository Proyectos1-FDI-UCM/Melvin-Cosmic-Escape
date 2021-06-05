using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    

    //Comprobación que Melvin esta poseyendo al enemigo ácido 
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.GetComponentInChildren<EnemigoAcido>() == null)
        {
            gm.Pisarcharco();
        }
    }
}
