using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public LevelController level;

    public List<GameObject> coins;

    void Start(){
        if(level.IsCompleted()){
            foreach (var coin in coins)
            {
                coin.SetActive(false);
            }
        }
    }
}
