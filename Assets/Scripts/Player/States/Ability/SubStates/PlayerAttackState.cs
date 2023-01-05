public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private int xInput;

    private bool setVelocity;
    private bool shouldCheckFlip;

    private float velocityToSet;

    #region Constructor
    public PlayerAttackState(Player player, PlayerData playerData, PlayerStateMachine stateMachine, string animBoolName) : base(player, playerData, stateMachine, animBoolName)
    {
    }

    #endregion

    #region Overrides

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

        weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;

        if (shouldCheckFlip)
        {
            player.CheckIfShouldFlip(xInput);
        }

        if (setVelocity)
        {
            player.SetVelocityX(velocityToSet * player.FacingDirection);
        }
    }

    #endregion

    #region Animation Overrides

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    #endregion

    #region Setter

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this);
    }

    public void SetPlayerVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    #endregion
}
