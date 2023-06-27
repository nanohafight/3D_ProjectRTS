using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSUnitController : MonoBehaviour
{
    [SerializeField]
    public Unit myUnit;
    public Unit targetUnit;

    [Header("UI ¼³Á¤")]
    [SerializeField] GameObject TargetUI;
    [SerializeField] Image target_img;
    [SerializeField] Text target_username;
    [SerializeField] Text target_name;
    [SerializeField] Text target_lvl;
    [SerializeField] Text target_hp;
    [SerializeField] Text target_mp;

    private void Awake()
    {

    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if(targetUnit != null) {
            if(!TargetUI.activeSelf) TargetUI.SetActive(true);
        SetTargetUI(targetUnit);
        }
        else if (targetUnit == null)
        {
            if (TargetUI.activeSelf) TargetUI.SetActive(false);
        }
    }
    public void InitMyUnit(Unit unit)
    {
        myUnit = unit;
    }


    public void SetTargetUI(Unit unit)
    {
        target_img.sprite = unit.img;
        target_username.text = unit.champName;
        target_name.text = unit.champName;
        target_lvl.text = $"Level : {unit.level}";
        target_hp.text = $"{unit.curHp} / {unit.maxHp}";
    }
}
