using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
    public void RestartBtn()
    {

        SceneManager.LoadScene("MainLevel");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }


}
