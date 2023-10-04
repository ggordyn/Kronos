using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMovement : ICommand
{
    private IMoveable moveable;
    private Vector3 direction;
    public CmdMovement(Vector3 direction, Player player, IMoveable moveable){
        this.moveable = moveable;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetAngle, ref player.turnSmoothVelocity, player.turnSmoothTime);
        player.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        this.direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
    }
    public void Execute() => moveable.Move(direction.normalized);


}
