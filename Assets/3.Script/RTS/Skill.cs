using UnityEngine;

public enum SkillType
{
    Instant,
    Targeted,
    NonTargeted
}

public class Skill : MonoBehaviour
{
    public float cooldown;
    public int manaCost;
    public string skillName;
    public Sprite skillUI;
    public SkillType skillType;

    public void Execute()
    {
        // 스킬 실행 로직
    }

    public void Execute(Unit target)
    {
        // 타게팅 스킬 실행 로직
    }
}
