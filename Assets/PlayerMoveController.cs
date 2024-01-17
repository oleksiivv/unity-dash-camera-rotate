using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed=0.75f;

    private bool inJump=true;

    [HideInInspector]
    public CameraOrientation cameraOrientation;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        cameraOrientation = GetComponent<CameraOrientation>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.AddForce(Vector3.left*100 * speed);
        transform.Translate((Vector3.left/50) * speed);

        if(Input.GetMouseButtonDown(0) && !inJump && PlayerStateController.CanMove){
            inJump=true;
            cameraOrientation.ChangeCameraOrientation();

            rigidbody.AddForce(Vector3.up*100, ForceMode.Impulse);
            rigidbody.AddForce(Vector3.left*10, ForceMode.Impulse);
        }
    }

    public void Stop(){
        speed=0;
    }

    void OnCollisionExit(Collision other){
        if(!inJump){
            Stop();
        }
    }

    void OnCollisionEnter(Collision other){
        inJump=false;
        speed=0.75f;
    }
}
