using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 distanceDifference;

    void Start(){
        distanceDifference = transform.position - objectToFollow.transform.position;
    }

    void Update(){
        transform.position = objectToFollow.transform.position + distanceDifference;
    }
}
