using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : BulletAbstract
{
     [SerializeField] protected float moveSpeed;
     [SerializeField] protected Vector3 directionBullet = Vector3.right;
    private void Start()
    {
        moveSpeed = BulletCtrl.BulletSO.bulletSpeed;
    }
    private void FixedUpdate()
     {
         Moving();
     }
     private void Moving()
     {
         transform.parent.Translate(directionBullet * moveSpeed * Time.fixedDeltaTime);
     }

}
