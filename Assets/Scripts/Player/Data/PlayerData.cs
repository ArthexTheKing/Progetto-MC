using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementSpeed;

    [Header("Jump State")]
    public float jumpVelocity;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public LayerMask whatIsGround;

}
