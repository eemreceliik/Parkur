using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player Enter-Exit
    public bool playerEnter, playerExit;
  
    public GameObject level;

    private void Awake()
    {
        playerEnter = false;
        playerExit = false;
    }



    public void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x + 128, transform.position.y, transform.position.z);
        Instantiate(level, pos, Quaternion.identity);

    }
}
