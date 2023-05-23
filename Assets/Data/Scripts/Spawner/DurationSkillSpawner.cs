using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationSkillSpawner : Spawner
{
    private static DurationSkillSpawner _instance;
    public static DurationSkillSpawner Instance { get => _instance; }

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
