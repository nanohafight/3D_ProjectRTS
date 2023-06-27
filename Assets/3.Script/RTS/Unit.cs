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
    [Header("�ڵ����� ������Ʈ")]
    [SerializeField] GameObject marker;
    [SerializeField] NavMeshAgent navAgent;
    //
    [Header("������ �ޱ�")]
    [SerializeField] Champion unitData;
    public Sprite img;
    public float maxHp;
    public float curHp;
    public float atk;
    public float range;
    public float moveSpeed;
    public int level;
    public string champName;
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
        //todo ���߿� ������Ʈ�������� �����
        if (commandQueue.Count > 0) commandQueue.Dequeue().Execute();
    }

    public void AddCommand(ICommand command)
    {
        commandQueue.Enqueue(command);
    }




    // Ŀ�ǵ忡�� ȣ���� �޼ҵ�
    public void MoveTo(Vector3 end)
    {
        //�̵�Ŀ�ǵ�
        navAgent.SetDestination(end);
    }
    public void Attack(Unit target)
    {
        //todo ����Ŀ�ǵ�
        Debug.Log($"{this.name}�� {target.name}�� ����");
    }
    public void AttackMove(Vector3 pos)
    {
        //todo ���ݹ��� Ŀ�ǵ�
        Debug.Log($"{this.name}�� {pos}���� �̵��ϸ� ���� �����մϴ�");
    }
    //========================




    public void Init_myUnit()
    {
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
