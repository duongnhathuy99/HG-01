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
    //protected SpawnPoins spawnPoins;
    Transform player;
    float a = 14f;
    float b = 8f;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //spawnPoins = GameObject.FindWithTag("Player").GetComponentInChildren<SpawnPoins>();
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
        //Transform ramPoint = spawnPoins.GetRamdom();
        Vector3 pos = /*ramPoint.position*/SpawnPosElip() + player.position;
        SpawnPosElip();
        Quaternion rot = transform.rotation;
        Transform prefab = EnemySpawner.Instance.RandomPrefab();
        Transform enemyRamdom = EnemySpawner.Instance.Spawn(prefab, pos, rot);
        enemyRamdom.gameObject.SetActive(true);
    }
    private Vector3 SpawnPosElip()
    {
        float x, y;
        if (Random.Range(0, 2) == 1)
        {
            x = Random.Range(-a, a);
            y = Mathf.Sqrt((1 - (Mathf.Pow(x, 2) / Mathf.Pow(a, 2))) * b * b);
            if (Random.Range(0, 2) == 1)
                return new Vector3(x, y, 0);
            else
                return new Vector3(x, -y, 0);
        }
        else
        {
            y = Random.Range(-b, b);
            x = Mathf.Sqrt((1 - (Mathf.Pow(y, 2) / Mathf.Pow(b, 2))) * a * a);
            if (Random.Range(0, 2) == 1)
                return new Vector3(x, y, 0);
            else
                return new Vector3(-x, y, 0);
        }
    }
    protected virtual bool RamdomReachLimit()
    {
        int numerEnemyCurrent = EnemySpawner.Instance.Objects.Count;
        return numerEnemyCurrent >= enemyLimit;
    }
    protected void CheckTimeLine()
    {
        if (spawnEnemySO.TimeIncreaseList.Count <= timeLine+1) return;
        if (TextTimer.timeGame > spawnEnemySO.TimeIncreaseList[timeLine+1].timeline)
        {
            timeLine++;
            if(ramdomDelay > spawnEnemySO.TimeIncreaseList[timeLine].timeSpawn)
            ramdomDelay = spawnEnemySO.TimeIncreaseList[timeLine].timeSpawn;
            if(enemyLimit < spawnEnemySO.TimeIncreaseList[timeLine].enemyLimit)
            enemyLimit = spawnEnemySO.TimeIncreaseList[timeLine].enemyLimit;
        }
    }
}
