using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    private void Awake()
    {
    }
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
