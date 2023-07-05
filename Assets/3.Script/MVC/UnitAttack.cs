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

        //공격 쿨타임 계산
        attackCoolTime = 1f / attackSpeed;

        //최초 공격 바로 시작하도록 설정
        currentAttackCoolTime = attackCoolTime;

        //공격속도가 1보다 빠르면 애니메이션 빠르게 재생하기 위해서 배속 설정, 아니면 기본속도 1로 재생
        if (attackSpeed > 1) animator.SetFloat("AttackSpeed", attackSpeed);
        else animator.SetFloat("AttackSpeed", 1);
    }

    public void Init(Unit myUnit, Animator animator)
    {
        this.myUnit = myUnit;
        this.animator = animator;
    }

}
