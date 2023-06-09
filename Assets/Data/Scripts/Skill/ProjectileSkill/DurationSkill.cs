using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationSkill : Skill
{
    float timeDamage = 0.2f;
    float timeDamageCD = 0;
    public bool doDamage = false;
    protected override void Awake()
    {
        base.Awake();
    }
    private void FixedUpdate()
    {
        CheckDoDamage();
    }
    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        if (!doDamage) return;
        skillSO.attribute.damageInflicted += skillSO.attribute.damage;
        health.TakeDamage(skillSO.attribute.damage);
    }
    private void CheckDoDamage()
    {
        timeDamageCD += Time.fixedDeltaTime;
        doDamage = false;
        if (timeDamageCD < timeDamage) return;
        doDamage = true;
        timeDamageCD = 0;
    }
}
