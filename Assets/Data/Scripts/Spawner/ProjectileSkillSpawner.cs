using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkillSpawner : Spawner
{
    private static ProjectileSkillSpawner _instance;
    public static ProjectileSkillSpawner Instance { get => _instance; }

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
