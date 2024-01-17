using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private PlayerMoveController move;

    private UIController ui;

    public static bool CanMove=true;

    void Start()
    {
        move = GetComponent<PlayerMoveController>();
        ui = GetComponent<UIController>();

        CanMove=true;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == TagsEnum.LOSE_LOWER_POINT){
            move.Stop();
            move.cameraOrientation.ChangeCameraOrientation(0);
            
            ui.SetLosePanelVisibility(true);
            CanMove=false;
        } else if(other.gameObject.tag == TagsEnum.FINISH){
            move.Stop();
            move.cameraOrientation.ChangeCameraOrientation(0);
            
            ui.SetWinPanelVisibility(true);
            CanMove=false;
            //TODO: save progress
        }
    }
}
