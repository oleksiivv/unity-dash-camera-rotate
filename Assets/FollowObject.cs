using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 distanceDifference;

    public bool follow=true;

    public bool followY = false;

    void Start(){
        distanceDifference = transform.position - objectToFollow.transform.position;
    }

    void Update(){
        if(follow){
            transform.position = new Vector3(
                objectToFollow.transform.position.x + distanceDifference.x,
                followY ? objectToFollow.transform.position.y + distanceDifference.y : transform.position.y,
                transform.position.z
            );
        }
    }

    public void RestoreYPos(Vector3 position){
        follow=false;
        followY=false;

        StartCoroutine(FollowYAfterDelay(position));
    }

    private Vector3 positionToFollowZ;

    IEnumerator FollowYAfterDelay(Vector3 position){
        int n=10;
        var posIterator = transform.position;
        var target = objectToFollow.transform.position.y + distanceDifference.y;
        var step = (target - posIterator.y) / n;

        for(int i=0; i< n; i++){
            posIterator.y += step;
            transform.position = posIterator;

            yield return new WaitForSeconds(0.01f);
        }

        follow=true;
        followY=true;

        positionToFollowZ = position;
        Invoke(nameof(FollowZAFterDelayInvoke), 0.5f);
    }

    void FollowZAFterDelayInvoke(){
        StartCoroutine(FollowZAfterDelay(positionToFollowZ));
    }

    IEnumerator FollowZAfterDelay(Vector3 position){
        int n=10;
        var posIterator = transform.position;
        var target = position.z;
        var step = (target - posIterator.z) / n;

        for(int i=0; i< n; i++){
            posIterator.z += step;
            
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                posIterator.z
            );

            yield return new WaitForSeconds(0.005f);
        }
    }
}
