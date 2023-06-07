using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectArtifact : MonoBehaviour
{
    public List<ArtifactSO> listArtifact;
    [SerializeField] ArtifactSO artifactNull;
    int i = -1;

    public void LoadListArtifact() 
    {
        artifactNull = (ArtifactSO)Resources.Load("Artifact null");
        Object[] artifacts= Resources.LoadAll("Artifacts", typeof(ArtifactSO));

        if (artifacts == null || artifacts.Length == 0)
        {
            Debug.Log("Artifact not found ");
        }

        foreach (Object obj in artifacts)
        {
            ArtifactSO artifact = (ArtifactSO)obj;
            listArtifact.Add(artifact);
        }
    }
    public ArtifactSO GetArtifactRandom()
    {
        i++;
        if (i < listArtifact.Count)
            return listArtifact[i];
        else  
            return artifactNull;
    }
    public void ShuffleArtifacts()
    {
        Shuffle(listArtifact);
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
    public void ResetArtifactI()
    {
        i = -1;
    }
}
