using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarPanelNivel : MonoBehaviour
{
    public bool panelActivo = false;
    private void Start()
    {
        panelActivo = true;
        Invoke("DesactivarPanel", 2f);
    }

    void DesactivarPanel()
    {
        this.gameObject.SetActive(false);
        panelActivo = false;
        GameManager.GetInstance().pausa = false;
    }
}
