using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
    private float speed = 5f;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //OnDamage �������ּ���. todo
        Debug.Log("ȭ���� �¾Ҿ��");
        gameObject.SetActive(false);
    }
    public void Init(float speed)
    {
        this.speed = speed;
    }
}
