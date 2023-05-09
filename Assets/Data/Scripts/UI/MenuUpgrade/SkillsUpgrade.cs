using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUpgrade : MonoBehaviour
{
    public List<Skill> skills;
    int i = 0;
    private void OnEnable()
    {
        //Shuffle(skills);
    }
    public Skill GetSkillRandom()
    {
        i++;
        if (i == 3) i = 0;
        return skills[i];
    }
    public void ShuffleSkills()
    {
        Shuffle(skills);
    }
    void Shuffle<T>(List<T> inputList)
    {
        for (var i = 0; i < inputList.Count-1; ++i)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
