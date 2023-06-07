using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMove: MonoBehaviour
{
    [SerializeField] protected Vector3 directionSpin = Vector3.forward;
    [SerializeField] protected Player player;
    protected  void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void FixedUpdate()
    {
         Moving();
    }
    private void Moving()
    {
        Vector3 center = player.transform.position;
        transform.parent.RotateAround(center, directionSpin, transform.parent.GetComponent<Skill>().Speed * Time.fixedDeltaTime);
    }

}
