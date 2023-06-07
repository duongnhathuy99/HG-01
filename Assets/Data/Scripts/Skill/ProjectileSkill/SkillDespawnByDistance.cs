using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDespawnByDistance : MonoBehaviour
{
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    private void Awake()
    {
        mainCam = Transform.FindObjectOfType<Camera>().transform;
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
        distance = Vector3.Distance(transform.position, mainCam.transform.position);
        if (distance > disLimit) return true;
        else return false;
    }
    public virtual void DespawnObject()
    {
        SkillSpawner.Instance.Despawn(transform.parent);
    }

}
