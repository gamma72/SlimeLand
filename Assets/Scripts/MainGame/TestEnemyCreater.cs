using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyCreater : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public GameObject[] enemysN;
    public GameObject[] enemysR;
    public GameObject[] enemysB;

    GameMng gameMng;
    public List<GameObject> enemys;
    int enemyNum=0;
    float curTime, coolTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameMng = GameObject.Find("GameMng").GetComponent<GameMng>();
        EnemysSet();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (enemyCount <= enemyNum) return;
        curTime += Time.deltaTime;
        if(coolTime < curTime)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
            enemy.name = "Enemy_" + enemyNum++;
            curTime = 0;
        }*/

        if(enemys.Count > 0)
        {
            curTime += Time.deltaTime;
            if (coolTime < curTime)
            {
                GameObject enemy = Instantiate(enemys[0], transform.position, transform.rotation) as GameObject;
                enemys.RemoveAt(0);
                enemy.name = "Enemy_" + enemyNum++;
                curTime = 0;
            }

        }
        else
        {
            gameMng.createrDestroy = true;
            Destroy(gameObject);
        }
    }

    public void EnemysSet()
    {
        //Debug.Log(LevelData[i]["Name"].ToString());

        int nomal, rare, boss, total;
        nomal = int.Parse(gameMng.LevelData[gameMng.nowStage]["NomalC"].ToString());
        rare = int.Parse(gameMng.LevelData[gameMng.nowStage]["RareC"].ToString());
        boss = int.Parse(gameMng.LevelData[gameMng.nowStage]["BossC"].ToString());
        total = nomal + rare + boss;

        for (int i=0; i< total; i++)
        {
            int a = 0;
            if (i % 5 == 0 && rare > 0)
            {
                a = Random.Range(0, enemysR.Length);
                enemys.Add(enemysR[a]);
                continue;
            }
            if(i > total - boss && boss > 1)
            {
                a = Random.Range(0, enemysB.Length);
                enemys.Add(enemysB[a]);
                continue;
            }
            a = Random.Range(0, enemysN.Length);
            enemys.Add(enemysN[a]);
        }
    }

}
