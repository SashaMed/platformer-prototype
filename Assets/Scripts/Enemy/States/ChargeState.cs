using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected D_ChargeState stateData;
    protected bool isPlayerInMinAgroRange;
    protected bool isDetectiongWall;
    protected bool isDetectiongLedge;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public ChargeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectiongLedge = core.CollisionSenses.CheckIsLedgeAhead() | entity.CheckObstacles();
        isDetectiongWall = core.CollisionSenses.CheckIsTouchingWall() | entity.CheckObstacles();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        isChargeTimeOver = false;
        core.Movement.SetVelocityX(stateData.chargeSpeed * core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        core.Movement.SetVelocityX(stateData.chargeSpeed * core.Movement.FacingDirection);
        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
