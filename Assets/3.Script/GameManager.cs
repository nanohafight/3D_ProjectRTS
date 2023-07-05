using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Photon.MonoBehaviour
{
    #region singleton
    static GameManager instance = null;
    public static GameManager Instance
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

    [Header("Spawn Point")]
    public GameObject[] spawnPoint;
    private List<GameObject> shuffledSpawnPoints = new List<GameObject>();
    private int spawnCount = 1;
    public int shuffleTimes = 10;
    [Space]
    [Header("Selected Character")]
    public Champion selected;
    [Header("Unit Data")]
    public Champion archer;
    public Champion warrior;
    public Champion mage;


    //테스팅용
    [Space]
    [Header("Testing Object")]
    [Header("Dummy Container")]
    List<GameObject> dummies = new List<GameObject>();

    [Header("서버")]
    public int state = 0;
    void Connect()
    {
        PhotonNetwork.ConnectToBestCloudServer("V1.0");
    }
    void OnConnectedToServer()
    {
        GUI.Label(new Rect(10, 40, 200, 30), "Connected");
    }
    void OnJoinedLobby()
    {
        state = 1;
    }
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }
    void OnJoinedRoom()
    {
        state = 2;
    }

    private void OnGUI()
    {
        switch (state)
        {
            case 0:
                //Starting screen
                if (GUI.Button(new Rect(10, 10, 100, 30), "Connect"))
                {
                    Connect();
                }
                break;
            case 1:
                //Connecting to server
                GUI.Label(new Rect(10, 40, 200, 30), "Lobby");
                if (GUI.Button(new Rect(10, 10, 100, 30), "Search"))
                {
                    PhotonNetwork.JoinRandomRoom();
                }
                break;
            case 2:
                //Champion Select
                GUI.Label(new Rect(10, 10, 200, 30), "Select Your Champion");
                if (GUI.Button(new Rect(10, 40, 100, 30), "Archer"))
                {
                    selected = archer;
                    StartGame(0, selected);
                }
                break;
            case 3:
                //In Game

                break;
        }
    }
    void StartGame(int team, Champion champ)
    {
        state = 3;
        Debug.Log("You are on team " + team + ". And Are playing as " + champ.champName);
        SpawnPlayer(team, champ);
    }





    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        ShuffleSpawnPoints();
    }
   
    //랜덤 스폰 위치가 겹치지 않도록 셔플 알고리즘 사용
    private void ShuffleSpawnPoints()
    {
        shuffledSpawnPoints.Clear();
        shuffledSpawnPoints.AddRange(spawnPoint);
        // Fisher-Yates shuffle algorithm
        int n = shuffledSpawnPoints.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject temp = shuffledSpawnPoints[k];
            shuffledSpawnPoints[k] = shuffledSpawnPoints[n];
            shuffledSpawnPoints[n] = temp;
        }
    }
    public void SpawnPlayer(int team, Champion champ)
    {
        //todo 리스폰 알고리즘 짜야함. 여기서 플레이어를 리스폰 시키거나, 플레이어 리스폰 이벤트에 이 메소드를 추가해야 함
        GameObject player = PhotonNetwork.Instantiate(champ.name, shuffledSpawnPoints[spawnCount].transform.position, Quaternion.identity, 0);
        spawnCount++;
        player.GetComponent<Unit>().Init_myUnit(team);
        if (spawnCount >= shuffleTimes)
        {
            ShuffleSpawnPoints();
            spawnCount = 0;
        }
    }

    public void GameStart() //선택한 유닛을 스폰하고, myUnit으로 인잇해줌
    {        
        GameObject obj = Instantiate(selected.prefab, shuffledSpawnPoints[spawnCount].transform.position, Quaternion.identity);
        spawnCount++;
        obj.GetComponent<Unit>().Init_myUnit(0);
    }

    #region ButtonEvent(MakeDummy, AllDelete)
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
    #endregion
}
