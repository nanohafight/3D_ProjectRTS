using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    [SerializeField]
    Unit myUnit;

    private void Start()
    {
        
    }
    public void InitMyUnit(Unit unit)
    {
        myUnit = unit;
    }
    public void MoveUnit(Vector3 end)
    {
        Debug.Log("RTS컨트롤러 : 움직여!");
        myUnit.MoveTo(end);
    }
}
