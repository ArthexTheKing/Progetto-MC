using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }

    #endregion

    #region Components

    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    [SerializeField]
    private SO_PlayerData playerData;

    #endregion

    #region Unity Callback Functions

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, playerData, StateMachine, "idle");
        MoveState = new PlayerMoveState(this, playerData, StateMachine, "move");
        JumpState = new PlayerJumpState(this, playerData, StateMachine, "inAir");
        InAirState = new PlayerInAirState(this, playerData, StateMachine, "inAir");
        LandState = new PlayerLandState(this, playerData, StateMachine, "land");
        WallSlideState = new PlayerWallSlideState(this, playerData, StateMachine, "wallSlide");
        WallJumpState = new PlayerWallJumpState(this, playerData, StateMachine, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, playerData, StateMachine, "ledgeClimbState");
        CrouchIdleState = new PlayerCrouchIdleState(this, playerData, StateMachine, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, playerData, StateMachine, "crouchMove");
        AttackState = new PlayerAttackState(this, playerData, StateMachine, "attack");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>(); 
        InputHandler = GetComponent<PlayerInputHandler>();
        MovementCollider = GetComponent<BoxCollider2D>();
        Inventory = GetComponent<PlayerInventory>();

        AttackState.SetWeapon(Inventory.weapon);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Animation Triggers

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion

    #region Other Functions

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        Vector2 workspace = new(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }

    #endregion
}
