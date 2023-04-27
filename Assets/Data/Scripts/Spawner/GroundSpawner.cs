using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : Spawner
{
    private static GroundSpawner _instance;
    public static GroundSpawner Instance { get => _instance; }

    public static string ground = "Ground";
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public bool IsPosGroundExist(Vector3 posGround)
    {
        foreach (Transform obj in Objects)
        {
            if (posGround == obj.position)
                return true;
        }
        return false;
    }
}
