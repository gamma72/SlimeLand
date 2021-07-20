using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemyMove : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    GameMng gameMng;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("isEnd").transform;
        agent = GetComponent<NavMeshAgent>();
        gameMng = GameObject.Find("GameMng").GetComponent<GameMng>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (target.transform.position.x + 1) && transform.position.x > (target.transform.position.x - 1) && transform.position.z < (target.transform.position.z + 1) && transform.position.z > (target.transform.position.z - 1))
        {
            gameMng.HpDown(1);
            Destroy(gameObject);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }
}
