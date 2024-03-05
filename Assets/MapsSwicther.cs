using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapsSwicther : MonoBehaviour
{
    public List<Map> maps;

    public int currentMap;

    public Text coinsText;

    public GameObject studyPanel, studyPanelAnim;

    void Start(){
        if(PlayerPrefs.GetInt("studied", 0) == 0){
            studyPanel.SetActive(true);
            PlayerPrefs.SetInt("studied", 1);

            PlayerPrefs.SetInt("coins", 50);
        }

        currentMap = PlayerPrefs.GetInt("current_map", 0) == 0 ? 1 : PlayerPrefs.GetInt("current_map", 0);
        currentMap--;

        ShowMap();

        if(PlayerPrefs.GetInt("coins", 0) == 0){
            coinsText.gameObject.SetActive(false);
        }
        else {
            coinsText.text = PlayerPrefs.GetInt("coins", 0).ToString();
            coinsText.gameObject.SetActive(true);
        }
    }

    public void ShowStudyAnimation(){
        studyPanelAnim.SetActive(true);
    }

    public void CompleteStudy(){
        studyPanel.SetActive(false);
        studyPanelAnim.SetActive(false);
    }

    public void Right(){
        currentMap++;

        if(currentMap>=maps.Count){
            currentMap=0;
        }

        ShowMap();
    }

    public void Left(){
        currentMap--;

        if(currentMap<0){
            currentMap=maps.Count-1;
        }

        ShowMap();
    }

    public void ShowMap(){
        foreach(var map in maps)map.SetVisibility(false);

        maps[currentMap].SetVisibility(true);
    }
}
