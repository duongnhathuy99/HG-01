using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public int heathMax = 100;
    public float moveSpeed = 0.01f;
}
