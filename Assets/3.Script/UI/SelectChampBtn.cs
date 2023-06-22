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
        Debug.Log("클릭당햇서");
        SelectManager.Instance.ChangeChamp(champ);
    }
    public void SelectChamp()
    {
        Debug.Log($"{champ.champName} 선택");
        SelectManager.Instance.ChangeChamp(champ);
    }
}
