using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    public GameObject camera;

    private Vector3 currentCameraRotation;

    void Start(){
        currentCameraRotation = camera.gameObject.transform.eulerAngles;
    }

    public void ChangeCameraOrientation(){
                            Debug.Log("Rot: "+camera.gameObject.transform.eulerAngles.z.ToString() + " ||| " + currentCameraRotation.z.ToString());

        currentCameraRotation = camera.gameObject.transform.eulerAngles;
        currentCameraRotation.z = (currentCameraRotation.z - 90f) % 360;

        StartCoroutine(Rotate());
    }

    IEnumerator Rotate(){
        var rotationIterator = camera.gameObject.transform.eulerAngles;
        while(rotationIterator.z != currentCameraRotation.z){
            rotationIterator.z += 1f * (camera.transform.eulerAngles.z - currentCameraRotation.z > 0 ? -1 : 1);
            camera.transform.eulerAngles = rotationIterator;

                    Debug.Log("Rot: "+rotationIterator.ToString() + " ||| " + currentCameraRotation.z.ToString());


            yield return new WaitForSeconds(0.01f);
        }
    }
}
