using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Restart()
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
