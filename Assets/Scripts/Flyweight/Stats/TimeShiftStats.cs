using UnityEngine;

[CreateAssetMenu(fileName="TimeShiftStats", menuName ="Stats/TimeShift", order = 0)]
public class TimeShiftStats : ScriptableObject
{
    [SerializeField] private TimeShiftStatValues _statValues;
    
    public float TimeShiftLimit => _statValues.TimeShiftLimit;
    public float TimeShiftCooldown => _statValues.TimeShiftCooldown;
}

[System.Serializable]
public struct TimeShiftStatValues{
    public float TimeShiftLimit;
    public float TimeShiftCooldown;
}
