using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float[] dmg;
    public Sprite icon;
    public enum Type { instant, target, none_target}
    public Type type;
    public virtual void Execute(GameObject player)
    {

    }
    public virtual void Execute(GameObject player, Unit target)
    {

    }
    public virtual void Execute(GameObject player, Vector3 targetpos)
    {

    }
}

public class ArcherSkill : Skill
{

}