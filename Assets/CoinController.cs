using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private ParticleSystem effect;

    void Start(){
        //rigidbody = GetComponent<Rigidbody>();
        effect = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // void OnCollisionEnter(Collision other){
    //     if(other.gameObject.tag.ToUpper().Equals("PLATFORM") || (other.gameObject.tag.ToUpper().Equals("COIN") && other.gameObject.transform.position.y < transform.position.y)){
    //         Vector3 scale = transform.localScale;
    //         transform.parent = other.gameObject.transform;
    //     }
    //     if(other.gameObject.tag.ToUpper().Equals("PLATFORMENEMY")){
    //         Destroy(gameObject);
    //     }
    // }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToUpper().Equals("PLAYER")){
            effect.gameObject.transform.parent = null;
            effect.Play();

            Destroy(gameObject);
        }
    }
}
