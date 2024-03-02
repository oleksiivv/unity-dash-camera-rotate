using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeSpawner : MonoBehaviour
{
    public List<GameObject> landscapeObjects;

    public float zPos, yPos;

    public Vector2 xPosRange;

    public float distanceBetweenObjects;

    void Awake(){
        if(landscapeObjects.Count>0){
            Spawn();
        }
    }

    public void Spawn(){
        int objectN = 0;
        for(float xPos = xPosRange.x; xPos < xPosRange.y; xPos += distanceBetweenObjects){
            var newLandscapeObject = Instantiate(
                landscapeObjects[objectN],
                new Vector3(xPos, yPos, zPos),
                landscapeObjects[objectN].transform.rotation
            );

            if (objectN < landscapeObjects.Count - 1) objectN++;
            else objectN = 0;
        }
    }
}
