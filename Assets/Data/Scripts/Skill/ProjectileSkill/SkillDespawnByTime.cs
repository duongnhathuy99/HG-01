using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDespawnByTime : MonoBehaviour
{
    [SerializeField] protected float timeDuration;
    [SerializeField] protected float timeCD = 0f;

    private void Start()
    {
        timeDuration = transform.parent.GetComponent<Skill>().TimeDuration;
    }
    
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDesSpawn()) return;
        DespawnObject();
    }

    protected virtual bool CanDesSpawn()
    {
        timeCD += Time.fixedDeltaTime;
        if (timeCD > timeDuration) 
        {
            timeCD = 0;
            return true; 
        }
        else return false;
    }
    public virtual void DespawnObject()
    {
        SkillSpawner.Instance.Despawn(transform.parent);
    }

}
