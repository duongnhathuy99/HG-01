using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
     [SerializeField] protected int moveSpeed = 5;
     [SerializeField] protected Vector3 directionBullet = Vector3.right;

     private void FixedUpdate()
     {
         Moving();
     }
     private void Moving()
     {
         transform.parent.Translate(directionBullet * moveSpeed * Time.fixedDeltaTime);
     }

}
