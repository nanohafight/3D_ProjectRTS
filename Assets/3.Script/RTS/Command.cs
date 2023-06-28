using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}
public class MoveCommand : ICommand
{
    private Unit unit;
    private Vector3 pos;
    public MoveCommand(Unit unit, Vector3 pos)
    {
        this.unit = unit;
        this.pos = pos;
    }
    public void Execute()
    {
        unit.MoveTo(pos);
    }
}

public class AttackCommand : ICommand
{
    private Unit unit;
    private Unit target;
    public AttackCommand(Unit unit, Unit target)
    {
        this.unit = unit;
        this.target = target;
    }
    public void Execute()
    {
    }
}

public class AttackMoveCommand : ICommand
{
    private Unit unit;
    private Vector3 pos;
    public AttackMoveCommand(Unit unit, Vector3 pos)
    {
        this.unit = unit;
        this.pos = pos;
    }
    public void Execute()
    {
    }
}
