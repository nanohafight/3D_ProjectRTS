using System.Collections;
using System.Collections.Generic;
using RTS_Cam;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] NavMeshAgent navAgent;
    RTSUnitController controller;
    RTS_Camera cam;

    private void Awake()
    {
        controller = FindObjectOfType<RTSUnitController>();
        cam = FindObjectOfType<RTS_Camera>();
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
        //transform.LookAt(end);
    }

    public void Init()
    {
        controller.InitMyUnit(this);
        cam.InitPlayer(this);
    }
}
