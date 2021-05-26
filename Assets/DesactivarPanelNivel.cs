using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarPanelNivel : MonoBehaviour
{
    private void Start()
    {
        Invoke("DesactivarPanel", 2f);
    }

    void DesactivarPanel()
    {
        this.gameObject.SetActive(false);
        GameManager.GetInstance().pausa = false;
    }
}
