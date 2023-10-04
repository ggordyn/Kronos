using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShift : MonoBehaviour
{
    public TimeShiftStats Stats => _timeShiftStats;
    [SerializeField] public TimeShiftStats _timeShiftStats;
}
