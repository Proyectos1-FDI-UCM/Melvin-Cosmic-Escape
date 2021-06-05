using UnityEngine;

public class EnemigoCientifico : MonoBehaviour
{
    public int numCientifico;
    public Sprite[] spritesCientificos = new Sprite[3];

    void OnEnable()
    {
        Invoke(nameof(CambioSprite), 0.01f);
    }

    void CambioSprite()
    {
        // Importante colocar los sprites en orden
        this.GetComponent<SpriteRenderer>().sprite = spritesCientificos[numCientifico - 1]; 
    }
}