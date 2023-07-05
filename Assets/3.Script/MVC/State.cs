using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Exit();
    void FixedUpdate();
    void LateUpdate();
    void Update();
}

public class IdleState : IState
{
    Unit myUnit;
    Vector3 searchArea;
    Unit targetUnit;
    public IdleState(Unit myUnit)
    {
        this.myUnit = myUnit;
        searchArea = new Vector3(myUnit.range, myUnit.range, myUnit.range);
    }
    public void Enter()
    {
        myUnit.Stop();
    }
    public void Exit()
    {
        
    }
    public void FixedUpdate()
    {
        
    }
    public void LateUpdate()
    {
        
    }
    public void Update()
    {
        if (Search())
        {
            if (targetUnit != null) myUnit.SetState(new AttackState(myUnit, targetUnit));
            else Debug.Log("Idle state searched target but targetUnit is null, IDK why doesn't");
        }
    }
    bool Search()
    {
        Collider[] hitted =
            Physics.OverlapBox(myUnit.transform.position, searchArea, Quaternion.identity, LayerMask.NameToLayer("Unit"));
        if (hitted != null)
        {
            foreach (var col in hitted)
            {
                if (col.GetComponent<Unit>().GetTeam() != myUnit.GetTeam())
                {
                    targetUnit = col.GetComponent<Unit>();
                    return true;
                }
            }
        }
        return false;
    }
}

public class AttackState : IState
{
    Unit myUnit;
    Unit t_unit;
    Vector3 t_pos;
    bool isTarget;
    //myUnit.공격스테이트를 바꾸고
    //myUnit.Update에서 if(공격쿨)
    
    public AttackState(Unit myUnit, Unit t_unit)
    {
        this.myUnit = myUnit;
        this.t_unit = t_unit;
        this.t_pos = t_unit.transform.position;
        isTarget = true;
    }
    public AttackState(Unit myUnit, Vector3 t_pos)
    {
        this.myUnit = myUnit;
        this.t_unit = null;
        this.t_pos = t_pos;
        isTarget = false;
    }
    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void LateUpdate()
    {
       
    }

    public void Update()
    {
        
    }
}