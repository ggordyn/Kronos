using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdJump : ICommand
{
    private IMoveable moveable;
    public CmdJump(IMoveable moveable){
        this.moveable = moveable;
    }
    public void Execute() => moveable.Jump();


}
