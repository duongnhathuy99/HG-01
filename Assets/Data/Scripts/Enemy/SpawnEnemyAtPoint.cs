using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAtPoint : MonoBehaviour
{
    [SerializeField] protected float ramdomDelay = 3f;
    [SerializeField] protected float ramdomTimer = 0f;
    [SerializeField] protected int enemyLimit = 10;
    protected SpawnPoins spawnPoins;
    private void Awake()
    {
        spawnPoins = GameObject.FindWithTag("Player").GetComponentInChildren<SpawnPoins>();
    }
   
    private void FixedUpdate()
    {
        EnemySpawning();
    }
    protected virtual void EnemySpawning()
    {
        if (RamdomReachLimit()) return;
        ramdomTimer += Time.fixedDeltaTime;
        if (ramdomTimer < ramdomDelay) return;
        ramdomTimer = 0;

        Transform ramPoint = spawnPoins.GetRamdom();
        Vector3 pos = ramPoint.position;
        Quaternion rot = transform.rotation;
        //Transform prefab = spawnPoins.RandomPrefab();
        Transform enemyRamdom = EnemySpawner.Instance.Spawn(EnemySpawner.Enemy_0, pos, rot);
        enemyRamdom.gameObject.SetActive(true);
    }
    protected virtual bool RamdomReachLimit()
    {
        int numerEnemyCurrent = EnemySpawner.Instance.SpawnedCount;
        return numerEnemyCurrent >= enemyLimit;
    }
}
