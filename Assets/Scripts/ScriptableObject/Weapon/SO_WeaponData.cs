using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class SO_WeaponData : ScriptableObject
{
    public int AmountOfAttacks { get; private set; }
    public float[] MovementSpeed { get; private set; }

    public WeaponAttackDetails[] AttackDetails { get => attackDetails; }

    [SerializeField] private WeaponAttackDetails[] attackDetails;

    private void OnEnable()
    {
        AmountOfAttacks = attackDetails.Length;

        MovementSpeed = new float[AmountOfAttacks];

        for (int i = 0; i < AmountOfAttacks; i++)
        {
            MovementSpeed[i] = attackDetails[i].movementSpeed;
        }
    }

}
