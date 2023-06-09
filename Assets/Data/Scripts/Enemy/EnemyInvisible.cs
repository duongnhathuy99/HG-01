using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvisible : EnemyAbstract
{
    [SerializeField] protected float timeDuration = 6f;
    [SerializeField] protected float timeInvisible = 6f;
    float timeCD = 0f;
    public bool IsInvisible { get; private set; } = false;
    protected void FixedUpdate()
    {
        CheckTimeInvisible();
    }
    protected void CheckTimeInvisible() 
    {
        timeCD += Time.fixedDeltaTime;
        if (timeCD < timeInvisible) return;
        Invisible(true);
        if (timeCD < timeInvisible + timeDuration) return;
        Invisible(false);
        timeCD = 0;
    }
    protected void Invisible(bool isInvisible) 
    {
        if (IsInvisible == isInvisible) return;
        IsInvisible = isInvisible;
        EnemyCtrl.Enemy.Undamaged = isInvisible;
        if (isInvisible) EnemyCtrl.SpriteRenderer.color = new Color(1, 1, 1, 0.5f);
        else EnemyCtrl.SpriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}
