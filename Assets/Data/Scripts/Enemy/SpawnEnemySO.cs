using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName = "SO/SpawnEnemy")]
public class SpawnEnemySO : ScriptableObject
{
    //public float ramdomDelay = 3f;
    //public int enemyLimit = 10;
    public List<TimeEnemyIncrease> TimeIncreaseList;
}

[Serializable]
public class TimeEnemyIncrease
{
    public int timeline;
    public float timeSpawn;
    public int enemyLimit;
}