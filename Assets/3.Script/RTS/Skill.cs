using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public enum SkillInputType { Instant, Target, NonTarget }
    public SkillInputType inputType;
    public enum SkillOutputType { None, Target, AoE }
    public SkillOutputType outputType;
    public enum SkillTargetType { None, Ally, Enemy }
    public SkillTargetType targetType;
    public new string name;
    public float cooldownTime;
    public float activateTime;
    public float durationTime;
    public float range;
    public float[] damage;
    public int skillLv = 1;
    public int maxLv = 5;
    public AudioClip[] SFX;
    protected SkillUser user;
    public virtual void Init(GameObject obj)
    {
        user = obj.GetComponent<SkillUser>();
    }
    public virtual void Activate() { }
    public virtual void Activate(GameObject targetObj) { }
    public virtual void Activate(Unit targetUnit) { }
    public virtual void Activate(Vector3 targetPos) { }

    public virtual void Execute() { }
    public virtual void Execute(GameObject targetObj) { }
    public virtual void Execute(Unit targetUnit) { }
    public virtual void Execute(Vector3 targetPos) { }
}
