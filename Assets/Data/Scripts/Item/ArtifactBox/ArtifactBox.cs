using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactBox : MonoBehaviour, IItem
{
    [SerializeField] private RectTransform selectArtifact;
    public void PickItem(Player player)
    {
        selectArtifact.GetComponent<MenuSelectArtifact>().ShuffleArtifacts();
        selectArtifact.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
