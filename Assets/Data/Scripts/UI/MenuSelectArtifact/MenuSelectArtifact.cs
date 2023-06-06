using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectArtifact : MonoBehaviour
{
    public List<ArtifactSO> artifacts;
    int i = 0;
    private void OnEnable()
    {
        //Shuffle(skills);

    }
    public ArtifactSO GetArtifactRandom()
    {
        i++;
        if (i == 3) i = 0;
        return artifacts[i];
    }
    public void ShuffleArtifacts()
    {
        Shuffle(artifacts);
    }
    void Shuffle<T>(List<T> inputList)
    {
        for (var i = 0; i < inputList.Count - 1; ++i)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
