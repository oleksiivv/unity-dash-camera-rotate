using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject winPanel, losePanel;

    public void SetWinPanelVisibility(bool visibility){
        winPanel.SetActive(visibility);
    }

    public void SetLosePanelVisibility(bool visibility){
        losePanel.SetActive(visibility);
    }

    public void OpenScene(int sceneId){
        Application.LoadLevel(sceneId);
    }

    public void Restart(){
        OpenScene(Application.loadedLevel);
    }
}
