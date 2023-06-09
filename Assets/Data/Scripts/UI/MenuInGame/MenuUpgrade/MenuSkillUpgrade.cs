using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkillUpgrade : MonoBehaviour
{
    public List<Skill> listSkill;
    int i = 0;

    /* public void LoadListSkill() 
     {
         Skill[] skills = FindObjectsByType<Skill>(FindObjectsSortMode.None);
         if (skills == null || skills.Length == 0)
         {
             Debug.Log("Skill not found ");
         }

         foreach (Skill skill in skills)
         {
             listSkill.Add(skill);
         }
     }*/
    public Skill GetSkillRandom()
    {
        i++;
        if (i == 3) i = 0;
        return listSkill[i];
    }
    public void ShuffleSkills()
    {
        Shuffle(listSkill);
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
