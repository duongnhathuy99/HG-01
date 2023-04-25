using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("va cham " + other.gameObject.name);
        IItem item = other.GetComponent<IItem>();
        if (item == null) return;

        ItemSpawner.Instance.Despawn(other.transform);
    }
}
