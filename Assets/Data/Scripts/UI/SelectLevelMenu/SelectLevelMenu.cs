using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class SelectLevelMenu : MonoBehaviour
{
    public GameObject sceneLevelBtn;
    string LevelKey = "Level";
    void Start()
    {
        List<string> Scenes = new List<string>();
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var temp = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            var checkname = temp.IndexOf(LevelKey);
            if (checkname == 0)
            {
                Scenes.Add(temp);
                int lengthKey = LevelKey.Length;
                string level = temp.Substring(lengthKey, 1);
                var sceneBoard = Instantiate(sceneLevelBtn, transform.position, Quaternion.identity);
                sceneBoard.transform.SetParent(this.transform);
                sceneBoard.transform.localScale = new Vector3(1, 1, 1);
                sceneBoard.gameObject.SetActive(true);
                //Debug.Log(temp);
                sceneBoard.GetComponent<Button>().onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(temp);
                    
                });
                sceneBoard.GetComponentInChildren<TextMeshProUGUI>().SetText(level);
            }
            
        }

    }
    public void OnClickBackBtn() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
