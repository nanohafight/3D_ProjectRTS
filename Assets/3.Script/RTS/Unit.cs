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
    [Header("자동세팅 컴포넌트")]
    [SerializeField] GameObject marker;
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator anim;
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
    public bool myUnit = false;
    //
    Unit Target { get { return controller.targetUnit; } }

    [SerializeField] Queue<ICommand> commandQueue = new Queue<ICommand>();


    private void Awake()
    {
        controller = FindObjectOfType<RTSUnitController>();
        cam = FindObjectOfType<RTS_Camera>();
        Init_status();
    }

    private void Update()
    {
        //todo 나중에 스테이트패턴으로 해줘요
        if (commandQueue.Count > 0) commandQueue.Dequeue().Execute();
    }








    public void AddCommand(ICommand command)
    {
        commandQueue.Enqueue(command);
    }
    // 커맨드에서 호출할 메소드
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












    public void Init_myUnit()
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
