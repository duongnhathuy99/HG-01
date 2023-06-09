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
    /*public virtual void SetRotSpeed(float speed)
    {
        rot_speed = speed;
    }*/
    protected void ObjLookAtTarget()
    {
        //diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;*/
        Vector3 diff = RandomPosEnemy() - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = rot_speed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }
    
    protected Vector3 RandomPosEnemy()
    {
        if (EnemySpawner.Instance.Objects.Count == 0)
            return new Vector3(Random.Range(-10, 10), Random.Range(-4.5f, 4.5f), 0);
        int random = Random.Range(0, EnemySpawner.Instance.Objects.Count);
        Vector3 posEnemy = EnemySpawner.Instance.Objects[random].position;
        return posEnemy;
    }
}
