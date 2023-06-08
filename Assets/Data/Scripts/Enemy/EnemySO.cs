using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public int damage = 1;
    public int heathMax = 100;
    public float moveSpeed = 0.01f;
    public float timeIncrease = 0;
    public int damageIncrease = 0;
    public int heathIncrease = 0;
    public int spawnRate = 0;
    public int spawnRateIncrease = 0;
    public List<ItemDropRate> dropList;
}
