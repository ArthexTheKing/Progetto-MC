using UnityEngine;

public class Weapon : MonoBehaviour
{   
    [SerializeField] private SO_WeaponData weaponData;

    private Animator weaponAnimator;
    private PlayerAttackState attackState;

    private int attackCounter;

    #region Unity Callback Functions

    private void Start()
    {
        weaponAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    #endregion

    #region Animation Trigger

    public void AnimationFinishTrigger() => attackState.AnimationFinishTrigger();

    public void AnimationStartMovementTrigger() => attackState.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);

    public void AnimationStopMovementTrigger() => attackState.SetPlayerVelocity(0f);

    public void AnimationTurnOffFlipTrigger() => attackState.SetFlipCheck(false);

    public void AnimationTurnOnFlipTrigger() => attackState.SetFlipCheck(true);

    #endregion

    public void EnterWeapon()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }

        weaponAnimator.SetBool("attack", true);

        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    public void InitializeWeapon(PlayerAttackState attackState)
    {
        this.attackState = attackState;
    }

}
