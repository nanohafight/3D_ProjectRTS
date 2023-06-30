using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSet : MonoBehaviour
{
    public Skill skill;
    float cooldownTime;
    float activeTime;
    enum SkillState { ready, active, cool }
    SkillState state = SkillState.ready;

    public KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                    //skill.Type(즉발, 타게팅, 논타게팅) 즉발이면/타게팅이면 타겟입력기다렸다가 Execute(Unit target); /논타겟 Execute(Vector3 pos);
                    state = SkillState.active;
                    activeTime = skill.activeTime;                    
                }
                break;

            case SkillState.active:
                if(activeTime > 0) { 
                    activeTime -= Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        state = SkillState.ready;
                        break;
                    }
                }
                else {
                    skill.Execute(gameObject);
                    state = SkillState.cool;
                    cooldownTime = skill.cooldownTime;
                }
                break; 

            case SkillState.cool:
                if (cooldownTime > 0) { cooldownTime -= Time.deltaTime; }
                else { state = SkillState.ready; }
                break;
        }
    }
}