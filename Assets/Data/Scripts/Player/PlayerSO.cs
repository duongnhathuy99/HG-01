using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName = "SO/Player")]
public class PlayerSO : ScriptableObject
{
    public int heathMax = 1000;
    public float moveSpeed = 0.01f;
    public List<int> listLever;
}
