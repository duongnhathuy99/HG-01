using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    private void Awake()
    {
        LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + "LoadCamera:" + gameObject);
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
        BulletSpawner.Instance.Despawn(transform.parent);
    }

}
