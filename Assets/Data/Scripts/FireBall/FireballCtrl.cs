using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCtrl : MonoBehaviour
{
    public BoxCollider BoxCollider { get; private set; }

    [SerializeField] protected SkillSO fireballSO;
    public SkillSO FireballSO => fireballSO;
    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider>();
        //fireballSO= GetComponent<Fireball>().fire;
    }
}
