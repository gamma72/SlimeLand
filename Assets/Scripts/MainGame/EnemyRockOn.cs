using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRockOn : MonoBehaviour
{
    public Material red, blue;
    public List<GameObject> enemys;
    public GameObject bullet;
    public float shotSpeed = 1;
    public float dmg, bulletSpeed;
    public int type;
    public GameObject enemyTarget, shotTarget;

    IsLandingManager landMng;
    float targetDis;
    float curTime;

    // Start is called before the first frame update
    void Start()
    {
        landMng = gameObject.GetComponent<IsLandingManager>();
        enemyTarget = GameObject.Find("Target");
        switch (type)
        {
            case 0:
                gameObject.GetComponent<MeshRenderer>().material = red;
                break;
            case 1:
                gameObject.GetComponent<MeshRenderer>().material = blue;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (landMng.isDown)
        {
            if (enemys.Count > 0)
            {
                curTime += Time.deltaTime;
                if (curTime > shotSpeed)
                {
                    if (enemys[0] == null) enemys.RemoveAt(0);
                    else
                    {
                        targetDis = Vector3.Distance(enemys[0].transform.position, enemyTarget.transform.position);
                        shotTarget = enemys[0];
                    }
                    for (int i = 0; i < enemys.Count; i++)
                    {
                        if (enemys[i] == null)
                        {
                            enemys.RemoveAt(i);
                            continue;
                        }
                        float distance = Vector3.Distance(enemys[i].transform.position, enemyTarget.transform.position);
                        if (distance < targetDis)
                        {
                            shotTarget = enemys[i];
                            targetDis = distance;
                        }
                    }

                    ShotBullet(shotTarget, dmg, bulletSpeed, type);
                    curTime = 0;
                }
            }
            if (shotTarget != null) gameObject.transform.LookAt(new Vector3(shotTarget.transform.position.x, gameObject.transform.position.y ,shotTarget.transform.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }

    public void ShotBullet(GameObject target, float dmg, float speed, int type)
    {
        GameObject pop = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        pop.GetComponent<TestBulletManager>().enemy = target.gameObject;
        pop.GetComponent<TestBulletManager>().damage = dmg;
        pop.GetComponent<TestBulletManager>().speed = speed;
        pop.GetComponent<TestBulletManager>().type = type;
    }
}
