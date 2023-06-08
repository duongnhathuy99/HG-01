using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBullet : DurationSkill
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(Damage)) return;
        skillSO.attribute.damageInflicted += Damage;
        BulletSpawner.Instance.Despawn(transform);
    }
}
