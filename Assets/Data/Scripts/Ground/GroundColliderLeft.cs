using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderLeft : GroundCollider
{
    public override void SpawnGround()
    {
        Vector3 posSpawn = transform.parent.position;
        posSpawn.x -= groundWidth;
        if (GroundSpawner.Instance.IsPosGroundExist(posSpawn)) return;
        Transform newGround = GroundSpawner.Instance.Spawn(GroundSpawner.ground, posSpawn, transform.parent.rotation);
        newGround.gameObject.SetActive(true);
    }
}
