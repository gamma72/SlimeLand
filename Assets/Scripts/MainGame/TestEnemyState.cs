using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemyState : MonoBehaviour
{
    public float hp, speed;
    public int getCost;
    public bool isBoss;
    public bool isSlow;
    public string type = "nomal";
    public GameObject slimeDeath;

    GameMng gameMng;
    NavMeshAgent state;

    float baseHp;
    float curTime, coolTime = 2.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        state = gameObject.GetComponent<NavMeshAgent>();
        gameMng = GameObject.Find("GameMng").GetComponent<GameMng>();
        baseHp = hp;
        ChangeSpeed(speed);

        if (isBoss)
        {
            gameObject.transform.GetChild(0).gameObject.transform.localScale = gameObject.transform.GetChild(0).gameObject.transform.localScale + new Vector3(1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            gameMng.money += getCost;
            Instantiate(slimeDeath, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if(hp != baseHp)
        {
            if((hp / baseHp) > 0.25f) gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, ResizeSlime(), Time.deltaTime * 4);

        }

        if (isSlow)
        {
            curTime += Time.deltaTime;
            if(curTime > coolTime)
            {
                SetSpeed(speed);
                isSlow = false;
            }
        }
    }

    public Vector3 ResizeSlime()
    {
        Vector3 test = new Vector3(hp/baseHp, hp / baseHp, hp / baseHp);
        return test;
    }

    public void SetSpeed(float value)
    {
        state.speed = value;
    }

    public void ChangeSpeed(float value)
    {
        state.speed += value;
        if (state.speed < .5f) state.speed = .5f;
        RestoreSpeed();

    }

    public void ChangeHp(float value)
    {
        hp += value;
    }

    public void RestoreSpeed()
    {
        isSlow = true;
        curTime = 0;
    }

    void OnDestroy()
    {
        print("Script was destroyed");
    }
}
