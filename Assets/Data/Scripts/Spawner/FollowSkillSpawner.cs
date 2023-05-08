using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSkillSpawner: Spawner
{
    private static FollowSkillSpawner _instance;
    public static FollowSkillSpawner Instance { get => _instance; }

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
    protected override void LoadHolder()
    {
        holder = GameObject.FindGameObjectWithTag("Player").transform.Find("Attack").transform.Find("Satellite");
    }
}
