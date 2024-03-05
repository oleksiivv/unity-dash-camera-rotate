using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed=1.25f;

    private bool inJump=true;

    [HideInInspector]
    public CameraOrientation cameraOrientation;

    public CharacterAnimatorController characterAnimator;

    private AudioEffectsController audioEffects;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        cameraOrientation = GetComponent<CameraOrientation>();

        audioEffects = GetComponent<AudioEffectsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.AddForce(Vector3.left*100 * speed);
        transform.Translate((Vector3.left/50) * speed * Time.timeScale);
    }

    public void Jump(){
        if(Time.timeScale == 1 && !inJump && PlayerStateController.CanMove){
            inJump=true;
            characterAnimator.Jump();
            cameraOrientation.ChangeCameraOrientation();

            rigidbody.AddForce(Vector3.up*100, ForceMode.Impulse);
            rigidbody.AddForce(Vector3.left*15, ForceMode.Impulse);

            audioEffects.Jump();
        }
    }

    public void Stop(){
        speed=0;
    }

    public void FallFromPlatform(){
        rigidbody.AddForce(Vector3.up*25, ForceMode.Impulse);
        rigidbody.AddForce(Vector3.back*75, ForceMode.Impulse);
        FallFromPlatformPart2();

        Invoke(nameof(FallFromPlatformPart2), 0.8f);

        audioEffects.Lose();
    }

    public void FallFromPlatformPart2(){
        rigidbody.AddForce(Vector3.up*-50, ForceMode.Impulse);
    }

    void OnCollisionExit(Collision other){
        if(!inJump){
            Stop();
        }

        inJump=true;
    }

    void OnCollisionEnter(Collision other){
        if(!PlayerStateController.CanMove)return;

        inJump=false;
        speed=0.75f;
        characterAnimator.StartRun();

        if(other.gameObject.tag.ToUpper() == "UNTAGGED"){
            //Debug.Log(other.gameObject.name);
            if(other.gameObject.transform.position.y>(transform.position.y-0.25f)){
                Debug.Log("stucked");
                rigidbody.AddForce(Vector3.up*50, ForceMode.Impulse);
                rigidbody.AddForce(Vector3.right*50, ForceMode.Impulse);
            }
        }
    }
}
