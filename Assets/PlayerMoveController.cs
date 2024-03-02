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

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        cameraOrientation = GetComponent<CameraOrientation>();
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
        inJump=false;
        speed=0.75f;
        characterAnimator.StartRun();
    }
}
