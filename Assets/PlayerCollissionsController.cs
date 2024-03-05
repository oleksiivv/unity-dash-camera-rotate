using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollissionsController : MonoBehaviour
{
    public PlayerStateController playerStateController;

    public UIController ui;

    void Awake(){
        PlayerPrefs.SetInt("tmp_coins", PlayerPrefs.GetInt("coins", 0));

        ui.UpdateCoinsTextWithPlayerPrefs(PlayerPrefs.GetInt("tmp_coins"));
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToUpper().Equals("BLACK_WHOLE")){
            playerStateController.Death(false);

            playerStateController.characterAnimator.BlackWholeCollission();

            return;
        }
        if(other.gameObject.tag.ToUpper().Equals("COIN")) {
            PlayerPrefs.SetInt("tmp_coins", PlayerPrefs.GetInt("tmp_coins")+5);

            ui.UpdateCoinsTextWithPlayerPrefs(PlayerPrefs.GetInt("tmp_coins"));

            playerStateController.audioEffects.Coin();
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToUpper().Equals("SPIDER_GREEN")){
            playerStateController.Death();
            other.gameObject.GetComponent<DynamicEnemy>().Idle();
        }
    }
}
