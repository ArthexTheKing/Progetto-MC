using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Private Variables
    private Animator weaponAnimator;
    private PlayerAttackState attackState;

    #endregion

    #region Unity Callback Functions
    private void Start()
    {
        weaponAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    #endregion

    #region Funtions
    public void InitializeWeapon(PlayerAttackState attackState) => this.attackState = attackState;

    public void EnterWeapon()
    {
        gameObject.SetActive(true);

        weaponAnimator.SetBool("attack", true);
    }

    public void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }

    #endregion

    #region Animation Trigger
    public void AnimationFinishTrigger()
    {
        attackState.AnimationFinishTrigger();
    }

    #endregion
}
