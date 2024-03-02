using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb;

    public float delayBeforeFall = 0.5f;

    void Start(){
        rb=GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToUpper().Equals("PLAYER")){
            Invoke(nameof(Fall), delayBeforeFall);
        }
    }

    void Fall(){
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
