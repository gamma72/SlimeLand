using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    public JsonData LevelData;
    public int playerHp;
    public int nowStage;
    public int money;
    public int numObject = 0;
    public float stageTime, ReadyTime, nextWaveTime;
    public bool createrDestroy;
    public bool isPlayGame = false;
    public GameObject roundEndSound;
    public GameObject damagePlayerSound;

    int lastHp;
    CreateMap createMap;
    UiManager uiMng;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("NowStage"))
        {
            PlayerPrefs.SetInt("NowStage", 0);
            PlayerPrefs.SetInt("PlayerHp", 10);
            PlayerPrefs.SetInt("Money", 200);
        }
        Load();
        playerHp = PlayerPrefs.GetInt("PlayerHp");
        nowStage = PlayerPrefs.GetInt("NowStage");
        money = PlayerPrefs.GetInt("Money");
        lastHp = playerHp;
    }

    private void Start()
    {
        uiMng = gameObject.GetComponent<UiManager>();
        createMap = GameObject.Find("MapCreater").GetComponent<CreateMap>();
        createrDestroy = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(playerHp <= 0)
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                uiMng.PushSlideData();
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;

            }
            
        }

        if(nowStage < LevelData.Count)
        {
            if(createrDestroy) stageTime += Time.deltaTime;

            if (!isPlayGame && stageTime >= ReadyTime)
            {
                isPlayGame = true;
                stageTime = 0;
                createrDestroy = false;
                createMap.EnemyCreaterMake();
            }

            if (isPlayGame && stageTime >= nextWaveTime)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0) return;
                Instantiate(roundEndSound, transform.position, transform.rotation);
                isPlayGame = false;
                stageTime = 0;
                nowStage++;
                int pushMoney = money + GameObject.FindGameObjectsWithTag("Box").Length * 20 + GameObject.FindGameObjectsWithTag("Tower").Length * 20;
                PlayerPrefs.SetInt("PlayerHp", playerHp);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void HpDown(int num)
    {
        playerHp -= num;
        Instantiate(damagePlayerSound, transform.position,transform.rotation);
        uiMng.DamagePlayer();
    }

    public void Load()
    {
        string JsonString = File.ReadAllText(Application.dataPath + "/Resources/LevelData.json");
        LevelData = JsonMapper.ToObject(JsonString);
        //Debug.Log(LevelData[i]["Name"].ToString());
    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        if (nowStage != 0)
        {
            if (!isPlayGame)
            {

                PlayerPrefs.SetInt("NowStage", nowStage);

            }
            else
            {
                PlayerPrefs.SetInt("NowStage", nowStage - 1);
            }
        }
        int pushMoney = money + GameObject.FindGameObjectsWithTag("Box").Length * 20 + GameObject.FindGameObjectsWithTag("Tower").Length * 20;
        PlayerPrefs.SetInt("Money", pushMoney);
        SceneManager.LoadScene("MainScene");
    }
}
