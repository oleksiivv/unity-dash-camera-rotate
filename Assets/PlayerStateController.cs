using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private PlayerMoveController move;

    private UIController ui;

    public static bool CanMove=true;

    public CharacterAnimatorController characterAnimator;

    public LevelController level;

    void Start()
    {
        move = GetComponent<PlayerMoveController>();
        ui = GetComponent<UIController>();

        CanMove=true;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == TagsEnum.LOSE_LOWER_POINT){
            move.cameraOrientation.MoveBack();
            Death(true);
        } else if(other.gameObject.tag == TagsEnum.FINISH){
            move.Stop();
            move.cameraOrientation.ChangeCameraOrientation(0);
            
            ui.SetWinPanelVisibility(true);
            CanMove=false;

            //gameObject.SetActive(false);

            move.characterAnimator.BlackWholeCollission();
            
            level.Complete();

            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("tmp_coins", 0));
        }
    }

    public void Death(bool animate=true){
        move.Stop();
        move.cameraOrientation.followObject.follow=false;
            
        ui.SetLosePanelVisibility(true);
        CanMove=false;
        move.FallFromPlatform();

        if(animate){
            characterAnimator.Death();
        }
    }
}
