using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootprintsRotate : PlayerAbstract
{
    ParticleSystem Footprints;

    protected override void Awake()
    {
        base.Awake();
        Footprints = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Vector3 diff = PlayerCtrl.Rigidbody.velocity;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x);
        var ps = Footprints.main;
        ps.startRotation = -(rot_z - Mathf.PI / 2);
    }
}
