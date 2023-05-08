using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : ProjectileAbstract
{
     protected float moveSpeed;
     [SerializeField] protected Vector3 directionFireball = Vector3.right;
    private void Start()
    {
        moveSpeed = Fireball.Speed;
    }
    private void FixedUpdate()
     {
         Moving();
     }
     private void Moving()
     {
         transform.parent.Translate(directionFireball * moveSpeed * Time.fixedDeltaTime);
     }

}
