using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSUnitController : MonoBehaviour
{
    [SerializeField]
    public Unit myUnit;
    public Unit targetUnit;

    [Header("Target UI 설정")]
    [SerializeField] public GameObject TargetUI;  //todo 게임오브젝트 UI로 모은 건 나중에 설정에서 크기조절하려고
    [SerializeField] Image target_img;
    [SerializeField] Text target_username;
    [SerializeField] Text target_name;
    [SerializeField] Text target_lvl;
    [SerializeField] Text target_hp;
    [SerializeField] Text target_mp;

    [Header("My UI 설정")]
    [SerializeField] public GameObject MyUI;  //todo 게임오브젝트 UI로 모은 건 나중에 설정에서 크기조절하려고
    [SerializeField] Image[] Imgs_mySkills;
    [SerializeField] Image Img_myChamp;
    [SerializeField] Text Text_myLvl;
    [SerializeField] Slider Slider_myExp;


    private void Update()
    {
        TargetUIUpdate();
    }
    public void InitMyUnit(Unit unit)
    {
        myUnit = unit;
    }


    private void TargetUIUpdate()
    {
        if (targetUnit != null)
        {
            if (!TargetUI.activeSelf) TargetUI.SetActive(true);
            SetTargetUI(targetUnit);
        }
        else if (targetUnit == null)
        {
            if (TargetUI.activeSelf) TargetUI.SetActive(false);
        }

        if (myUnit != null)
        {
            SetMyUI(myUnit);
        }
    }
    private void SetTargetUI(Unit unit)
    {
        target_img.sprite = unit.img;
        target_username.text = unit.champName;
        target_name.text = unit.champName;
        target_lvl.text = $"Level : {unit.level}";
        target_hp.text = $"{unit.curHp} / {unit.maxHp}";
    }

    private void SetMyUI(Unit unit)
    {
            Img_myChamp.sprite = unit.img;
            Text_myLvl.text = $"{unit.level}";
        //todo 나머지 Imgs_mySkills, Slider_myExp
    }
}
