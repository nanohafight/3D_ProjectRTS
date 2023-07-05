using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [Header("UI 크기 조절 대상")]
    public RectTransform[] IngameUIs;

    public void SetSize(Vector3 size)
    {
        for (int i = 0; i < IngameUIs.Length; i++)
        {
            
        }
    }
}
