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
        //OnDamage 구현해주세요. todo
        Debug.Log("화살이 맞았어요");
        gameObject.SetActive(false);
    }
    public void Init(float speed)
    {
        this.speed = speed;
    }
}
