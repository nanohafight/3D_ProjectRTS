using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    [Header("���콺 Ŭ���� ���� ���̾� ����")]
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
            // �̴ϸ� Ŭ�� ���� Ȯ��
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

            // �̵� �޼���
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