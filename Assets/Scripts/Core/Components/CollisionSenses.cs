using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck { get => groundCheck; }
    public Transform WallCheck { get => wallCheck; }
    public Transform LedgeCheck { get => ledgeCheck; }
    public Transform CeilingCheck { get => ceilingCheck; }

    public float GroundCheckRadius { get => collisionSensesData.groundCheckRadius; }
    public float WallCheckDistance { get => collisionSensesData.wallCheckDistance; }
    public LayerMask WhatIsGround { get => collisionSensesData.whatIsGround; }

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform ceilingCheck;

    [SerializeField] private SO_CollisionSensesData collisionSensesData;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, collisionSensesData.groundCheckRadius);
        Gizmos.DrawWireSphere(ceilingCheck.position, collisionSensesData.groundCheckRadius);
        Gizmos.DrawRay(wallCheck.position, new Vector3(collisionSensesData.wallCheckDistance, 0f, 0f));
        Gizmos.DrawRay(wallCheck.position, new Vector3(-collisionSensesData.wallCheckDistance, 0f, 0f));
        Gizmos.DrawRay(ledgeCheck.position, new Vector3(collisionSensesData.wallCheckDistance, 0f, 0f));
    }

    #region Check Properties

    public bool Ceiling => Physics2D.OverlapCircle(ceilingCheck.position, collisionSensesData.groundCheckRadius, collisionSensesData.whatIsGround);
    public bool Grounded => Physics2D.OverlapCircle(groundCheck.position, collisionSensesData.groundCheckRadius, collisionSensesData.whatIsGround);
    public bool WallFront => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);
    public bool Ledge => Physics2D.Raycast(ledgeCheck.position, Vector2.right * core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);
    public bool WallBack => Physics2D.Raycast(wallCheck.position, Vector2.right * -core.Movement.FacingDirection, collisionSensesData.wallCheckDistance, collisionSensesData.whatIsGround);

    #endregion
}
