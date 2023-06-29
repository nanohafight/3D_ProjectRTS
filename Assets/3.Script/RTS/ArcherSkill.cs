using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArcherSkill", menuName = "Skill/Archer")]
public class ArcherSkill : Skill
{
   
}
public class ArcherAttack : ArcherSkill
{
    public override void Execute(Unit unit, Unit target)
    {
        unit.AddCommand(new AttackCommand(unit, target));
    }
}