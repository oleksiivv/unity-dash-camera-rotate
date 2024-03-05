using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int map;

    public int level;

    public string mapName;

    public Text levelNumberText, mapNameText;

    void Awake(){
        levelNumberText.text = "Level "+level.ToString();
        mapNameText.text = mapName;
    }

    public void Complete(){
        PlayerPrefs.SetInt("Completed_map#"+map.ToString()+"_level#"+level.ToString(), 1);
    }

    public bool IsCompleted(){
        return 1 == PlayerPrefs.GetInt("Completed_map#"+map.ToString()+"_level#"+level.ToString(), 0);
    }

    public bool IsAvailable(){
        if (map==1 && level==1) {
            return true;
        }
        int prevLevel = level-1;

        return 1 == PlayerPrefs.GetInt("Completed_map#"+map.ToString()+"_level#"+prevLevel.ToString(), 0);
    }
}
