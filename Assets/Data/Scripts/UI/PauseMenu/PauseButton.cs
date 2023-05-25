using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public Transform pauseMenu;
    private void Awake()
    {
        pauseMenu = transform.Find("PauseMenu");
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
}
