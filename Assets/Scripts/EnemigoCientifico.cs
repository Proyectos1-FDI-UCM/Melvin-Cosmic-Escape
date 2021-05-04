using UnityEngine;

public class EnemigoCientifico : MonoBehaviour
{
    public int numCientifico;

    public Sprite[] spritesCientificos = new Sprite[3];

    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke(nameof(CambioSprite), 0.01f);
    }

    // Update is called once per frame
    void CambioSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = spritesCientificos[numCientifico - 1]; //Importante colocar los sprites en orden
    }
}