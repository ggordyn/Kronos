using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveablle
{
    float Speed { get; }
    void Move(Vector3 direction);
}
