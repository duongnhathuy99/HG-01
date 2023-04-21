using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public PlayerAttack PlayerAttack { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    private void Awake()
    {
        PlayerAttack = GetComponentInChildren<PlayerAttack>();
        PlayerMovement = GetComponentInChildren<PlayerMovement>();

        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
