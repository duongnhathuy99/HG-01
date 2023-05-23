using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAtPoint : MonoBehaviour
{
    [SerializeField] protected float ramdomDelay;
    [SerializeField] protected float ramdomTimer = 0f;
    [SerializeField] protected int enemyLimit;

    protected int timeLine = -1;
    [SerializeField] protected SpawnEnemySO spawnEnemySO;
    protected SpawnPoins spawnPoins;
    private void Awake()
    {
        spawnPoins = GameObject.FindWithTag("Player").GetComponentInChildren<SpawnPoins>();
    }
   
    private void FixedUpdate()
    {
        CheckTimeLine();
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
        Transform prefab = EnemySpawner.Instance.RandomPrefab();
        Transform enemyRamdom = EnemySpawner.Instance.Spawn(prefab, pos, rot);
        enemyRamdom.gameObject.SetActive(true);
    }
    protected virtual bool RamdomReachLimit()
    {
        int numerEnemyCurrent = EnemySpawner.Instance.Objects.Count;
        return numerEnemyCurrent >= enemyLimit;
    }
    protected void CheckTimeLine()
    {
        if (spawnEnemySO.TimeIncreaseList.Count <= timeLine+1) return;
        if (Time.time > spawnEnemySO.TimeIncreaseList[timeLine+1].timeline)
        {
            timeLine++;
            if(ramdomDelay > spawnEnemySO.TimeIncreaseList[timeLine].timeSpawn)
            ramdomDelay = spawnEnemySO.TimeIncreaseList[timeLine].timeSpawn;
            if(enemyLimit < spawnEnemySO.TimeIncreaseList[timeLine].enemyLimit)
            enemyLimit = spawnEnemySO.TimeIncreaseList[timeLine].enemyLimit;
        }
    }
}
