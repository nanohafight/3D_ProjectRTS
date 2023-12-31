using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Champion", menuName = "MakeChampionData")]
public class Champion : ScriptableObject
{
    [Header("UI용 이미지")]
    public Sprite img;
    [Header("시작 프리펩, 시작 위치")]
    public GameObject prefab;
    public Vector3 startPos;
    [Header("기본 스탯")]
    public string champName;
    public float maxHp;
    public float maxMp;
    public float moveSpeed;
    public float atk;
    public float atkRange;
}
