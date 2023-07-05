using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    Unit myUnit;
    float attackSpeed { get { return myUnit.attackSpeed; } set { myUnit.attackSpeed = value; } }
    float attackCoolTime;
    float currentAttackCoolTime;
    Animator animator;
    void Start()
    {
        SetAttackSpeed(attackSpeed);
    }
    private void SetAttackSpeed(float _attackSpeed)
    {
        attackSpeed = _attackSpeed;

        //���� ��Ÿ�� ���
        attackCoolTime = 1f / attackSpeed;

        //���� ���� �ٷ� �����ϵ��� ����
        currentAttackCoolTime = attackCoolTime;

        //���ݼӵ��� 1���� ������ �ִϸ��̼� ������ ����ϱ� ���ؼ� ��� ����, �ƴϸ� �⺻�ӵ� 1�� ���
        if (attackSpeed > 1) animator.SetFloat("AttackSpeed", attackSpeed);
        else animator.SetFloat("AttackSpeed", 1);
    }

    public void Init(Unit myUnit, Animator animator)
    {
        this.myUnit = myUnit;
        this.animator = animator;
    }

}
