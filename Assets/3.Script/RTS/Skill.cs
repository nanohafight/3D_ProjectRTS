using UnityEngine;

public enum SkillType
{
    Instant,
    Targeted,
    NonTargeted
}
public class Skill : ScriptableObject
{
    public string skillName;
    public string animation_ID;
    public SkillType skillType;
    public float range;
    public struct Indicator
    {
        public enum Type { TARGET, MISSILE, AOE };
        public float radius;
        public Vector2 square;
    }
    public float cooldown;
    public double mana;    
    public Sprite skillUI;


    public virtual void Execute(Unit unit)
    {
        // 스킬 실행 로직
    }

    public virtual void Execute(Unit unit, Unit target)
    {
        // 타게팅 스킬 실행 로직
    }

    public virtual void Execute(Unit unit, Vector3 targetpos)
    {
        //논타게팅 스킬 로직
    }
}
