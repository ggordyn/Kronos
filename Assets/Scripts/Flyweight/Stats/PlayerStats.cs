using UnityEngine;

[CreateAssetMenu(fileName="PlayerStats", menuName ="Stats/Player", order = 0)]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private PlayerStatValues _statValues;
    
    public int InitialLives => _statValues.InitialLives;
    public float HurtCooldown => _statValues.HurtCooldown;
    public float FallVelocityLimit => _statValues.FallVelocityLimit;
}

[System.Serializable]
public struct PlayerStatValues{
    public int InitialLives;
    public float HurtCooldown;
    public float FallVelocityLimit; 
}
