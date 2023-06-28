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
        // ��ų ���� ����
    }

    public void Execute(Unit target)
    {
        // Ÿ���� ��ų ���� ����
    }
}
