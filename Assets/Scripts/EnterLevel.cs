using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{

    public LevelManager levelManager;
    public bool enter;
    private void OnTriggerEnter(Collider other)
    {

        if (enter)
        {
            levelManager.SpawnLevel();

            enter = false;
        }
    }
}
