using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    public Animator animator;

    public List<GameObject> skins;

    void Awake(){
        var currentSkin = PlayerPrefs.GetInt("current_skin", 0);

        foreach(var skin in skins)skin.SetActive(false);
        skins[currentSkin].SetActive(true);

        animator = skins[currentSkin].GetComponent<Animator>();
    }

    public void StartRun(){
        animator.SetBool("jump", false);
        animator.SetBool("run", true);
    }

    public void Jump(){
        animator.SetBool("run", false);
        animator.SetBool("jump", true);
    }

    public void BlackWholeCollission(){
        animator.SetBool("run", false);
        animator.SetBool("jump", false);

        animator.SetBool("black_whole", true);
    }

    public void Death(){
        //Debug.Log("death anim here");
        animator.SetBool("run", false);
        animator.SetBool("jump", false);

        animator.SetBool("death", true);
    }
}
