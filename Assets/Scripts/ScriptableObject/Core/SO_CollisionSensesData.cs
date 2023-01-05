using UnityEngine;

[CreateAssetMenu(fileName = "newCollisionSenses", menuName = "Data/Core Data/Collision Senses")]
public class SO_CollisionSensesData : ScriptableObject
{
    public float groundCheckRadius;
    public float wallCheckDistance;
    public LayerMask whatIsGround;
}
