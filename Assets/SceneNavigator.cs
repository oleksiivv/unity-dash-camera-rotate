using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigator : MonoBehaviour
{
    public GameObject loadingPanel;

    void Awake(){
        Application.targetFrameRate = 65;

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 2));
    }

    public void OpenScene(int sceneId){
        Time.timeScale=1;
        
        loadingPanel.SetActive(true);

        Application.LoadLevelAsync(sceneId);
    }
}
