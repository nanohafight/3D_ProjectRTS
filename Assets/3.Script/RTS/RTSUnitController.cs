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
        Debug.Log("RTS��Ʈ�ѷ� : ������!");
        myUnit.MoveTo(end);
    }
}
