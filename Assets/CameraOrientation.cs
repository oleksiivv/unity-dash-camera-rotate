using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    public GameObject camera;

    private Vector3 currentCameraRotation, currentCameraPosition;

    public FollowObject followObject;

    void Start(){
        currentCameraRotation = camera.gameObject.transform.eulerAngles;
        currentCameraPosition = camera.gameObject.transform.position;
    }

    public void ChangeCameraOrientation(int degree = -1){
        currentCameraRotation = camera.gameObject.transform.eulerAngles;
        currentCameraRotation.z = degree == -1 ? (currentCameraRotation.z - 90f) % 360 : degree;

        StartCoroutine(Rotate());
    }

    public void MoveBack(){
        StartCoroutine(MoveCameraBack());
    }

    IEnumerator MoveCameraBack(){
        while(camera.transform.position.z < 10){
            camera.transform.position = new Vector3(
                camera.transform.position.x,
                camera.transform.position.y,
                camera.transform.position.z + 0.5f
            );

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Rotate(){
        var rotationIterator = camera.gameObject.transform.eulerAngles;
        while(rotationIterator.z != currentCameraRotation.z){
            rotationIterator.z += 5f * (camera.transform.eulerAngles.z - currentCameraRotation.z > 0 ? -1 : 1);
            camera.transform.eulerAngles = rotationIterator;

            camera.transform.position = new Vector3(
                camera.transform.position.x,
                camera.transform.position.y,
                camera.transform.position.z + 0.3f
            );

            //Debug.Log("Rot: "+rotationIterator.ToString() + " ||| " + currentCameraRotation.z.ToString());


            yield return new WaitForSeconds(0.01f);
        }

        followObject.RestoreYPos(currentCameraPosition);
    }
}
