using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoins : MonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    private void Awake()
    {
        LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
    }

    public virtual Transform GetRamdom()
    {
        int rand = Random.Range(0, points.Count);

        return points[rand];
    }

}
