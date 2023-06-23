using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class MinimapController : MonoBehaviour, IPointerClickHandler
{
    [Header("설정")]
    public bool useMinimapClickingMove = true;

    [Header("컴포넌트 세팅")]
    [SerializeField] Camera minimapCam;
    [SerializeField] RTSUnitController controller;

    private void Awake()
    {
        controller = FindObjectOfType<RTSUnitController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("좌클릭");//todo
        }
        else if(useMinimapClickingMove) Move(CalculatePos(eventData));
    }

    private void Move(Vector3 pos)
    {
        controller.MoveUnit(pos);
    }

    private Vector3 CalculatePos(PointerEventData eventData)
    {
        Texture texture = GetComponent<RawImage>().texture;
        Rect rect = GetComponent<RectTransform>().rect; 
        float coordX = Mathf.Clamp(0, ((eventData.position.x - rect.x) * texture.width) / rect.width, texture.width);
        float coordY = Mathf.Clamp(0, ((eventData.position.y - rect.y) * texture.height) / rect.height, texture.height);

        float calX = coordX / texture.width;
        float calY = coordY / texture.height;

        Debug.Log(calX + "," + calY);


        Vector3 worldPosition = minimapCam.ViewportToWorldPoint(new Vector3(calX, calY,
           0));
        Debug.Log(worldPosition);
        return new Vector3(worldPosition.x-6, 0, worldPosition.z+6);
    }
}