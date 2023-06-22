using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Champion", menuName = "MakeChampionData")]
public class Champion : ScriptableObject
{
    [Header("UI�� �̹���")]
    public Sprite img;
    [Header("���� ������, ���� ��ġ")]
    public GameObject prefab;
    public Vector3 startPos;
    [Header("�⺻ ����")]
    public string champName;
    public float maxHp;
    public float maxMp;
    public float moveSpeed;
    public float atk;
    public float atkRange;
}
