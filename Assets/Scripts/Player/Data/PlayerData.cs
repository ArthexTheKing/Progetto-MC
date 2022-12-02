using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementSpeed;

    [Header("Jump State")]
    public int amountOfJumps;
    public float jumpVelocity;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

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
