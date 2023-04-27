using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : Spawner
{
    private static FireballSpawner _instance;
    public static FireballSpawner Instance { get => _instance; }

    public static string bulletOne = "Fireball";
    public static string bulletTwo = "Fireball (1)";
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
}
