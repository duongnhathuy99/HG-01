using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadSceneSelectLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectLevel");
    }
}
