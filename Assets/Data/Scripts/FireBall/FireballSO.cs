using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireball", menuName = "SO/Fireball")]
public class FireballSO : ScriptableObject
{
    public int damage = 50;
    public float fireballSpeed = 5f;
    public List<int> listDamageLevel;
}
