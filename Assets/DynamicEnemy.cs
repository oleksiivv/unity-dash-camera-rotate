using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : MonoBehaviour
{
    private bool run=false;

    public Animation animation;

    public AnimationClip idleClip, runClip;

    private bool stopAtIdle=false;

    public Animator animator;

    public float speed=1;

    void Start(){
        animation.clip = idleClip;
        animation.Play();

        if(animator)animator.SetBool("run", false);
    }

    void Update(){
        if(run && !stopAtIdle){
            transform.Translate(Vector3.forward*Time.timeScale / 25 * speed);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToUpper().Equals("PLAYER") && !stopAtIdle){
            run=true;

            animation.clip = runClip;
            animation.Play();
            
            if(animator)animator.SetBool("run", true);
        }
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag.ToUpper().Equals("PLAYER") && !stopAtIdle){
            if(other.gameObject.transform.position.x < transform.position.x){
                Idle();
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag.ToUpper().Equals("PLAYER") && !stopAtIdle){
            run=false;

            animation.clip = idleClip;
            animation.Play();

            if(animator)animator.SetBool("run", false);
        }
    }

    public void Idle(){
        stopAtIdle=true;
        run=false;
        animation.clip = idleClip;
        animation.Play();

        if(animator)animator.SetBool("run", false);
    }
}
