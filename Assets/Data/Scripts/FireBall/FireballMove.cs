using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : FireballAbstract
{
     [SerializeField] protected float moveSpeed;
     [SerializeField] protected Vector3 directionFireball = Vector3.right;
    private void Start()
    {
        moveSpeed = FireballCtrl.FireballSO.fireballSpeed;
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
