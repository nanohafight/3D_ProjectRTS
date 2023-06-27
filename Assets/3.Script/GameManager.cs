using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Unit Data")]
    public Champion archer;
    public Champion warrior;
    public Champion mage;

    [Header("Dummy Container")]
    [SerializeField] List<GameObject> dummies = new List<GameObject>();
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    void Update()
    {
        
    }
    public void MakeDummy()
    {
        dummies.Add(Instantiate(mage.prefab));
        dummies[dummies.Count - 1].transform.position = new Vector3(150, 1, 130);
    }
    public void AllDelete()
    {
        foreach (var gameObjects in dummies)
        {
            Destroy(gameObjects);
        }
    }
}
