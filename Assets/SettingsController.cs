using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject buttonSoundMuted, buttonSoundNormal;

    public GameObject buttonMusicMuted, buttonMusicNormal;

    public Dropdown quality;
    void Start()
    {
        if(PlayerPrefs.GetInt("quality", -1) == -1){
            PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        }
        
        quality.GetComponent<Dropdown>().value=PlayerPrefs.GetInt("quality");

        if(PlayerPrefs.GetInt("!sound")==0){

            buttonSoundMuted.SetActive(false);
            buttonSoundNormal.SetActive(true);

        }
        else{
            buttonSoundMuted.SetActive(true);
            buttonSoundNormal.SetActive(false);
        }

        
        if(PlayerPrefs.GetInt("!music")==0){

            buttonMusicMuted.SetActive(false);
            buttonMusicNormal.SetActive(true);
            GetComponent<AudioSource>().enabled=true;

        }
        else{
            buttonMusicMuted.SetActive(true);
            buttonMusicNormal.SetActive(false);
            GetComponent<AudioSource>().enabled=false;
        }
    }

    public void muteSound(){
        PlayerPrefs.SetInt("!sound",1);
        buttonSoundMuted.SetActive(true);
        buttonSoundNormal.SetActive(false);
        
        //GetComponent<AudioSource>().enabled=false;
    }

    public void unmuteSound(){
        PlayerPrefs.SetInt("!sound",0);
        buttonSoundMuted.SetActive(false);
        buttonSoundNormal.SetActive(true);

        //GetComponent<AudioSource>().enabled=true;
    }

    public void muteMusic(){
        PlayerPrefs.SetInt("!music",1);
        buttonMusicMuted.SetActive(true);
        buttonMusicNormal.SetActive(false);
        
        GetComponent<AudioSource>().enabled=false;
    }

    public void unmuteMusic(){
        PlayerPrefs.SetInt("!music",0);
        buttonMusicMuted.SetActive(false);
        buttonMusicNormal.SetActive(true);

        GetComponent<AudioSource>().enabled=true;
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);

        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    public GameObject undoProgressWindow;
    public void showUndoProgressWindow(){
        undoProgressWindow.SetActive(true);
    }

    public void undoProgress(){
        PlayerPrefs.DeleteAll();
        undoProgressWindow.SetActive(false);
        PlayerPrefs.SetInt("first",1);
        PlayerPrefs.SetInt("rated",1);

    }

    public void cancelUndoProgress(){
        undoProgressWindow.SetActive(false);
    }
}
