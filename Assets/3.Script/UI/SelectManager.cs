using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    #region singleton
    static SelectManager instance = null;
    public static SelectManager Instance
    {
        get
        {
            if (instance != null) return instance;
            else return null;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion



    [SerializeField] Champion selected_champ;

    [Header("UI세팅해줘")]
    [SerializeField] Image selected_img;


    [Header("필요자료_스폰지점")]
    [SerializeField] Transform[] spawnPoint;

    public void ChangeChamp(Champion champ)
    {
        selected_champ = champ;
        selected_img.sprite = selected_champ.img;
    }
    public void StartBtn()
    {
        GameObject obj = Instantiate(selected_champ.prefab, spawnPoint[Random.Range(0, spawnPoint.Length - 1)].position, Quaternion.identity);
        obj.GetComponent<Unit>().Init_myUnit();
        gameObject.SetActive(false);
    }
}
