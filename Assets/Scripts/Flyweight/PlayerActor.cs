using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    public PlayerStats Stats => _playerStats;
    [SerializeField] public PlayerStats _playerStats;
}
