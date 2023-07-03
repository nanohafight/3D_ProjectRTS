using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    private Skill selectedSkill;
    public Skill skill;
    float cooldownTime;
    float activeTime;
    enum SkillState { ready, active, cool }
    SkillState state = SkillState.ready;
    public KeyCode key;
    Vector3 targetPos;

    private void Start()
    {
        skill.Init(this.gameObject);
    }
    //Update�������� Input�� ����
    private void Update()
    {        
        switch (state)
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                    targetPos = Input.mousePosition;
                    switch((int)skill.inputType)
                    {
                        case 0:
                            state = SkillState.active;
                            activeTime = skill.activateTime;
                            break;
                        case 1:
                            //Ÿ���� �ε������� on
                            selectedSkill = skill;
                            break;
                        case 2:
                            //��Ÿ�� �ε������� on
                            selectedSkill = skill;
                            break;
                        default: break;
                    }                                     
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
                    transform.LookAt(GetWorldPositionFromScreen(targetPos));
                    skill.Execute(GetWorldPositionFromScreen(targetPos));
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

    Vector3 GetWorldPositionFromScreen(Vector3 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.point;
        }

        return Vector3.zero; // Ȥ�� �ٸ� �⺻���� ��ȯ
    }
}