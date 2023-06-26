using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    [Header("마우스 클릭을 받을 레이어 정보")]
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
        OnMouseClickMove();
    }

    public void OnMouseClickMove()
    {
        if (Input.GetMouseButton(1))
        {
            // 미니맵 클릭 여부 확인
            bool isUIHit = false;
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
                {
                    isUIHit = true;
                    break;
                }
            }
            if (isUIHit)
            {
                return;
            }

            // 이동 메서드
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                unitController.MoveUnit(hit.point);
            }
            else
            {
            }
        }
    }



    
}