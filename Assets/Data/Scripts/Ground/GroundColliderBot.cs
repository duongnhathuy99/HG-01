using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderBot : GroundCollider
{
    public override void SpawnGround()
    {
        Vector3 posSpawn = transform.parent.position;
        posSpawn.y -= groundHeight;
        if (GroundSpawner.Instance.IsPosGroundExist(posSpawn)) return;
        Transform newGround = GroundSpawner.Instance.Spawn(GroundSpawner.ground, posSpawn, transform.parent.rotation);
        newGround.gameObject.SetActive(true);
    }
}
