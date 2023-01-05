using UnityEngine;

public class Movement : CoreComponent
{
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public Rigidbody2D RB { get; private set; }

    private Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();

        FacingDirection = 1;
    }
    
    public void LogicUpdate() => CurrentVelocity = RB.velocity;

    #region Velocity Setters

    public void SetVelocityZero() => SetVelocity(Vector2.zero);

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetVelocity(workspace);
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        SetVelocity(workspace);
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        SetVelocity(workspace);
    }

    private void SetVelocity(Vector2 workspace)
    {
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    #endregion

    #region Flip Handling

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    #endregion
}
