using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Player")]
public class SO_PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity;

    [Header("Jump State")]
    public int amountOfJumps;
    public float jumpVelocity;

    [Header("Wall Jump")]
    public float wallJumpVelocity;
    public float wallJumpTime;
    public Vector2 wallJumpAngle;

    [Header("In Air State")]
    public float coyoteTime;
    public float variableJumpHeightMultiplier;

    [Header("Wall Slide State")]
    public float wallSlideVelocity;

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Crouch State")]
    public float crouchMovementVelocity;
    public float crouchColliderHeight;
    public float standColliderHeight;
}
