using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [Header("레이어 세팅")]
    [SerializeField]
    LayerMask layerUnit;
    [SerializeField]
    LayerMask layerGround;

    private Camera mainCamera;
    private RTSUnitController controller;

    private void Awake()
    {
        mainCamera = Camera.main;
        TryGetComponent(out controller);
    }
    private void Update()
    {
        OnMouseClickMove();
        OnMouseClickTargetting();
    }

    #region UpdateMethod
    private bool CheckUIClick()
    {
        // UI 클릭 여부 확인
        bool isUIHit = false;
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        if (results != null)
        {
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
                {
                    isUIHit = true;
                    break;
                }
            }
        }
        return isUIHit;
    }
    public void OnMouseClickMove()
    {
        if (Input.GetMouseButton(1))
        {
            if (CheckUIClick())
            {
                return;
            }
            // 이동 메서드
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                controller.myUnit.AddCommand(new MoveCommand(controller.myUnit, hit.point));
            }
        }
    }
    public void OnMouseClickTargetting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckUIClick())
            {
                return;
            }
            else
            {
                LeftClickTargetting();
            }
        }
    }
    private void LeftClickTargetting()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit))
        {
            controller.targetUnit = hit.transform.GetComponent<Unit>();
        }
        else controller.targetUnit = null;
    }
    #endregion
}