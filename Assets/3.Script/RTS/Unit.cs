using System.Collections;
using System.Collections.Generic;
using RTS_Cam;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    RTSUnitController controller;
    RTS_Camera cam;
    int team = 0; // 0 = blue, 1 = red;
    [Header("자동세팅 컴포넌트")]
    [SerializeField] GameObject marker;
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] public Animator anim;
    //
    [Header("데이터 받기")]
    [SerializeField] Champion unitData;
    public Sprite img;
    public float maxHp;
    public float curHp;
    public float atk;
    public float range;
    public float moveSpeed;
    public int level;
    public string champName;
    public float attackSpeed;
    public bool myUnit = false;
    //
    Unit Target { get { return controller.targetUnit; } }

    [SerializeField] Queue<ICommand> commandQueue = new Queue<ICommand>();
    [SerializeField] IState cur_state;
    [Space]
    [Header("Unit Controller")]
    UnitAttack attack;





    private void Awake()
    {
        controller = FindObjectOfType<RTSUnitController>();
        cam = FindObjectOfType<RTS_Camera>();
        attack = GetComponent<UnitAttack>();
    }   
    private void Start()
    {
        Init_status();
    }
    private void Update()
    {
        cur_state.Update();
    }
    private void FixedUpdate()
    {
        cur_state.FixedUpdate();
    }
    private void LateUpdate()
    {
        cur_state.LateUpdate();
    }
    public void SetState(IState state)
    {
        cur_state.Exit();
        cur_state = state;
        cur_state.Enter();
    }  








    public int GetTeam()
    {
        return team;
    }
    public void MoveTo(Vector3 end)
    {
        //이동커맨드
        navAgent.SetDestination(end);
    }
    public void Stop()
    {
        navAgent.SetDestination(transform.position);
        anim.Play("Idle", -1, 0f);
    }

    public void Init_myUnit(int team)
    {
        myUnit = true;
        controller.InitMyUnit(this);
        cam.InitPlayer(this);
    }
    public void Init_status()
    {
        img = unitData.img;
        maxHp = unitData.maxHp;
        curHp = unitData.maxHp;
        atk = unitData.atk;
        range = unitData.atkRange;
        moveSpeed = unitData.moveSpeed;
        level = 1;
        champName = unitData.champName;
        attack.Init(this, anim);
    }



    #region SelectUnit&MarkerActivate
    public void SelectUnit()
    {
        marker.SetActive(true);
    }
    public void DeselectUnit()
    {
        marker.SetActive(false);
    }
    #endregion
}
