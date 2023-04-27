using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundCollider : MonoBehaviour
{
    protected int groundWidth = 38;
    protected int groundHeight = 28;
    public abstract void SpawnGround();
}
