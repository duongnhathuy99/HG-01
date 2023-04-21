using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int moveSpeed = 5;
    [SerializeField] protected Vector3 directionBullet = Vector3.right;
    private void Start()
    {
        /*directionBullet = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionBullet.z = 0;
        directionBullet.Normalize();*/
    }
    private void FixedUpdate()
    {
        transform.Translate(directionBullet * moveSpeed * Time.fixedDeltaTime);
    }
}
