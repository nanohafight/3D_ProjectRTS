using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChampBtn : MonoBehaviour
{
    [SerializeField] Champion champ;
    Image champImg;

    private void Awake()
    {
        champImg = GetComponent<Image>();
    }
    private void Start()
    {
        champImg.sprite = champ.img;
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Ŭ�����޼�");
        SelectManager.Instance.ChangeChamp(champ);
    }
    public void SelectChamp()
    {
        Debug.Log($"{champ.champName} ����");
        SelectManager.Instance.ChangeChamp(champ);
    }
}
