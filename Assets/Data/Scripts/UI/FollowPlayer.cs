using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 1;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    protected void FixedUpdate()
    {
        Following();
    }
    protected virtual void Following()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed);
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
