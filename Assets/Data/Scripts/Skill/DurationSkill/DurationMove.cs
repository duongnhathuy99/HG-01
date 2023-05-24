using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationMove : MonoBehaviour
{
     protected float moveSpeed;
     [SerializeField] protected Vector3 directionFireball = Vector3.right;
    private void Start()
    {
        moveSpeed = transform.parent.GetComponent<DurationSkill>().Speed;
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
