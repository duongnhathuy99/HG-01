using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner _instance;
    public static ItemSpawner Instance { get => _instance; }

    //public static string ItemHealth = "ItemHealth";
    //public static string ItemExp1 = "ItemExp1";
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
