using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataMenu : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("MenuSelectArtifact").GetComponent<MenuSelectArtifact>().LoadListArtifact();
    }
}
