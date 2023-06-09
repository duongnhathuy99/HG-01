using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get => _instance; }
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public Transform RamdomPrefabByRatio()
    {
        int maxExclusive = 1;
        foreach (Transform trans in prefabs)
        {
            EnemyCtrl enemy = trans.GetComponent<EnemyCtrl>();
            maxExclusive += enemy.SpawnRate;
        }
        int rand = Random.Range(1, maxExclusive);
        foreach (Transform trans in prefabs)
        {
            EnemyCtrl enemy = trans.GetComponent<EnemyCtrl>();
            
            if (enemy.SpawnRate >= rand)
                return enemy.transform;
            else
                rand -= enemy.SpawnRate;
        }
        Debug.Log("spawn enemy null");
        return null;
    }
}
