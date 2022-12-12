using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity;

    [Header("Jump State")]
    public int amountOfJumps;
    public float jumpVelocity;

    [Header("In Air State")]
    public float coyoteTime;
    public float variableJumpHeightMultiplier;

    [Header("Wall Slide State")]
    public float wallSlideVelocity;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public float wallCheckDistance;
    public LayerMask whatIsGround;
}
