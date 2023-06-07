using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] protected Vector3 directionFireball = Vector3.right;
    Skill skill;
    protected virtual void Awake()
    {
        skill = GetComponentInParent<Skill>();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    private void Moving()
    {
        transform.parent.Translate(directionFireball * skill.Speed * Time.fixedDeltaTime);
    }

}
