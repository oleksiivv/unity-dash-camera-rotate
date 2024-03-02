using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject winPanel, losePanel, pausePanel;

    public SceneNavigator sceneNavigator;

    public Text coinsText;

    public void UpdateCoinsTextWithPlayerPrefs(int amount){
        coinsText.text = amount.ToString();
    }

    void Awake(){
        Time.timeScale = 1;
    }

    public void Pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);
    }

    public void Resume(){
        Time.timeScale=1;
        pausePanel.SetActive(false);
    }

    public void Menu(){
        sceneNavigator.OpenScene(0);
    }

    public void SetWinPanelVisibility(bool visibility){
        winPanel.SetActive(visibility);
    }

    public void SetLosePanelVisibility(bool visibility){
        losePanel.SetActive(visibility);
    }

    public void Restart(){
        sceneNavigator.OpenScene(Application.loadedLevel);
    }

    public void Next(bool isLast = false){
        sceneNavigator.OpenScene(isLast ? 0 : Application.loadedLevel+1);
    }
}
