using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundSpawn : MonoBehaviour
{
    private void Start()
    {
        GroundSpawner.Instance.Spawn(GroundSpawner.ground, transform.position, transform.rotation).gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        GroundCollider groundCollider = other.GetComponent<GroundCollider>();
        if (groundCollider == null) return;
        groundCollider.SpawnGround();
    }
}
