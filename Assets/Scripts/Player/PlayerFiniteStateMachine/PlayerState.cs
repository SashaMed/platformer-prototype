using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Core core;
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;
    protected bool isAnimationFinished;


    private string animationBoolName;
    

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        animationBoolName = animationName;
        core = player.Core;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Animator.SetBool(animationBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        //Debug.Log("enter " + animationBoolName);
    }

    public virtual void Exit()
    {
        DoChecks();
        player.Animator.SetBool(animationBoolName, false);
        //Debug.Log("exit " + animationBoolName);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    protected virtual void IgnorePlatformLayer(bool t)
    {
        if (t)
        {
            Physics2D.IgnoreLayerCollision(10, 7, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(10, 7, false);
        }
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

}
