using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] NavMeshAgent navAgent;
    RTSUnitController controller;

    private void Start()
    {
        controller = FindObjectOfType<RTSUnitController>();
        Init();
    }
    public void SelectUnit()
    {
        marker.SetActive(true);
    }
    public void DeselectUnit()
    {
        marker.SetActive(false);
    }

    public void MoveTo(Vector3 end)
    {
        Debug.Log("네 움직일게요");
        navAgent.SetDestination(end);
    }

    public void Init()
    {
        controller.InitMyUnit(this);
    }
}
