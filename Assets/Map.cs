using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public List<GameObject> objects;

    public List<GameObject> levels;

    public Color32 normalLevelColor, unavailableLevelColor;

    public GameObject levelsPanel;

    public int mapId;

    public int levelsNumber;

    public SceneNavigator sceneNavigator;

    public int scenesStartFrom=0;

    public AudioEffectsController audioEffect;

    bool allowSound=false;

    void Start(){
        UpdateLevelsPanel();
        Invoke(nameof(AllowSound), 1f);
    }

    void AllowSound(){
        allowSound=true;
    }

    public void SetVisibility(bool visibility){
        foreach (var item in objects)
        {
            item.SetActive(visibility);
        }

        if(visibility && allowSound)audioEffect.Pick();
    }

    public void UpdateLevelsPanel(){
        for(int i=0; i<levelsNumber; i++){
            if (IsAvailable(i+1+scenesStartFrom)) {
                levels[i].GetComponent<Image>().color = normalLevelColor;
            } else {
                levels[i].GetComponent<Image>().color = unavailableLevelColor;
            }
        }
    }

    public void OpenLevelsPanel(){
        levelsPanel.SetActive(true);

        audioEffect.Pick();
    }

    public void HideLevelsPanel(){
        levelsPanel.SetActive(false);
    }

    public void OpenLevel(int level){
        if (IsAvailable(level)) {
            PlayerPrefs.SetInt("current_map", mapId);

            sceneNavigator.OpenScene(level);

            audioEffect.Pick();
        }
    }

    private bool IsLevelCompleted(int level){
        return 1 == PlayerPrefs.GetInt("Completed_map#"+mapId.ToString()+"_level#"+level.ToString(), 0);
    }

    private bool IsMapLevelCompleted(int level, int map){
        return 1 == PlayerPrefs.GetInt("Completed_map#"+map.ToString()+"_level#"+level.ToString(), 0);
    }

    private bool IsMapCompleted(){
        for(int i=1; i<= levelsNumber; i++){
            if (IsLevelCompleted(i)) {
                return false;
            }
        }

        return true;
    }

    private bool IsMapAvailable(){        
        if (mapId==1) return true;

        for(int i=1; i<= levelsNumber; i++){
            if (!IsMapLevelCompleted(i, mapId-1)) {
                return false;
            }
        }

        return true;
    }

    private bool IsAvailable(int level){
        if (level%levelsNumber == 1) {
            return true;
        }
        int prevLevel = level-1;

        return 1 == PlayerPrefs.GetInt("Completed_map#"+mapId.ToString()+"_level#"+prevLevel.ToString(), 0);
    }
}
