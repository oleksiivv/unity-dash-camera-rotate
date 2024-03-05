using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEffectsController : MonoBehaviour
{
    public AudioClip lose, win, jump, coin;

    private AudioSource source;

    void Start(){
        source=GetComponent<AudioSource>();
        source.enabled=true;
        source.loop = false;
    }

    public void Lose(){
        if(PlayerPrefs.GetInt("!sound") == 1) return;

        source.enabled=false;
        source.clip=lose;
        source.enabled=true;
        source.Play();
    }

    public void Win(){
        if(PlayerPrefs.GetInt("!sound") == 1) return;

        source.enabled=false;
        source.clip=win;
        source.enabled=true;
        source.Play();
    }

    public void Jump(){
        if(PlayerPrefs.GetInt("!sound") == 1) return;

        source.enabled=false;
        source.clip=jump;
        source.enabled=true;
        source.Play();
    }

    public void Pick(){
        if(PlayerPrefs.GetInt("!sound") == 1) return;

        source.enabled=false;
        source.clip=jump;
        source.enabled=true;
        source.Play();
    }

    public void Coin(){
        if(PlayerPrefs.GetInt("!sound") == 1) return;

        source.enabled=false;
        source.clip=coin;
        source.enabled=true;
        source.Play();
    }
}
