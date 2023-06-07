using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawner : Spawner
{
    private static SkillSpawner _instance;
    public static SkillSpawner Instance { get => _instance; }

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
