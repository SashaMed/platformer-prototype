using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Transform playerCheck;
    [SerializeField] private Transform obstaclesCheck;

    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Animator animator { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }
    public Core Core { get; private set; }


    private float lastDamageTime;
    private Vector2 velocityWorkSpace;

    protected bool isDead;
    protected bool isStunned;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        animator = GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        atsm = GetComponent<AnimationToStateMachine>();
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
        animator.SetFloat("yVelocity", Core.Movement.Rigidbody.velocity.y);
        if (Time.time >= lastDamageTime + entityData.stunRecoveryTime) 
        {
            ResetStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }


    public virtual bool CheckObstacles()
    {
        return Physics2D.Raycast(obstaclesCheck.position, transform.right, entityData.obstaclesCheckDistance, entityData.whatIsObstacles);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkSpace.Set(Core.Movement.Rigidbody.velocity.x, velocity);
        Core.Movement.Rigidbody.velocity = velocityWorkSpace;
    }

    public virtual void ResetStunResistance()
    {
        isStunned = false;
    }
}
