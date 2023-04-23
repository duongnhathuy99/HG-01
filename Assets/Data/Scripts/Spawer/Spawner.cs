using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
/*
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;*/

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;
    [SerializeField] protected List<Transform> objects;
    public List<Transform> Objects => objects;
    protected virtual void Awake()
    {
        LoadPrefabs();
        holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab spawn not found " + prefabName);
            return null;
        }
        return Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        //spawnedCount++;
        objects.Add(newPrefab);
        return newPrefab;
    }
    public virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObject in poolObjects)
        {
            if (poolObject.name == prefab.name)
            {
                poolObjects.Remove(poolObject);
                return poolObject;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        newPrefab.SetParent(holder);
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        objects.Remove(obj);
        poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
        //spawnedCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, prefabs.Count);
        return prefabs[rand];
    }
    public virtual void Hold(Transform obj)
    {
        obj.parent = this.holder;
    }
}
