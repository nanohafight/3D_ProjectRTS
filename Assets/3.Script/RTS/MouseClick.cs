using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    LayerMask layerUnit;
    [SerializeField]
    LayerMask layerGround;

    private Camera mainCamera;
    private RTSUnitController unitController;

    private void Awake()
    {
        mainCamera = Camera.main;
        TryGetComponent(out unitController);
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log("��Ŭ��");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                Debug.Log("������!");
                unitController.MoveUnit(hit.point);
            }
            else
            {
                Debug.Log(Input.mousePosition);
            }
        }
    }
}
