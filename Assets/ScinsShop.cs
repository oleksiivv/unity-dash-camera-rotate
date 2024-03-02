using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScinsShop : MonoBehaviour
{
    public GameObject panel;

    public void SetPanelVisibility(bool visibility){
        panel.SetActive(visibility);
    }
}
