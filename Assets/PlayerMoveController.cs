using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float speed=0.75f;

    private bool inJump=true;

    private CameraOrientation cameraOrientation;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        cameraOrientation = GetComponent<CameraOrientation>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.AddForce(Vector3.left*100 * speed);
        transform.Translate(Vector3.left/100 * speed);

        if(Input.GetMouseButtonDown(0) && !inJump){
            inJump=true;
            cameraOrientation.ChangeCameraOrientation();

            rigidbody.AddForce(Vector3.up*100, ForceMode.Impulse);
            rigidbody.AddForce(Vector3.left*10, ForceMode.Impulse);
        }
    }

    void OnCollisionExit(Collision other){
        if(!inJump){
            speed=0;
        }
    }

    void OnCollisionEnter(Collision other){
        inJump=false;
        speed=0.75f;
    }
}
