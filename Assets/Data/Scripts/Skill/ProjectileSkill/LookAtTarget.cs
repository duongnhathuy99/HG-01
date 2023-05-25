using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] protected float rot_speed = 3f;

    protected void FixedUpdate()
    {
        ObjLookAtTarget();
    }
    public virtual void SetRotSpeed(float speed)
    {
        rot_speed = speed;
    }
    protected void ObjLookAtTarget()
    {

        Vector3 diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = rot_speed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }
}
