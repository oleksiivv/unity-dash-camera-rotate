using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 distanceDifference;

    public bool followY = true;

    void Start(){
        distanceDifference = transform.position - objectToFollow.transform.position;
    }

    void Update(){
        transform.position = new Vector3(
            objectToFollow.transform.position.x + distanceDifference.x,
            followY ? objectToFollow.transform.position.y + distanceDifference.y : transform.position.y,
            objectToFollow.transform.position.z + distanceDifference.z
        );
    }
}
