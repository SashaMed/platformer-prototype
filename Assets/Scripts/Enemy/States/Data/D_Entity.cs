using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 30f;
    public float damageHopSpeed = 3f;
    public float wallCheckDistance = 0.3f;
    public float obstaclesCheckDistance = 0.6f;
    public float ledgeCheckDistance = 0.5f;
    public float closeRangeActionDistance = 1f;
    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;
    public float groundCheckRadius = 0.3f;
    public float stunResistance = 3f;
    public float stunRecoveryTime = 2f;

    public GameObject hitParticle;

    public LayerMask whatIsObstacles;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;
}
