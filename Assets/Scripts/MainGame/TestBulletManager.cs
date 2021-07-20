using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletManager : MonoBehaviour
{
    public Material red, blue;
    public GameObject enemy;
    public float damage;
    public float speed = 3;
    public int type = 1;

    bool isColorChange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isColorChange)
        {
            switch (type)
            {
                case 0:
                    gameObject.GetComponent<MeshRenderer>().material = red;
                    break;
                case 1:
                    gameObject.GetComponent<MeshRenderer>().material = blue;
                    break;
            }
            isColorChange = true;
        }
        

        if(enemy != null)
        {
            transform.LookAt(enemy.transform);
            gameObject.transform.position = 
            transform.position = Vector3.Lerp(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == enemy)
        {
            if(type == 0) enemy.GetComponent<TestEnemyState>().ChangeHp(-damage);
            if (type == 1) enemy.GetComponent<TestEnemyState>().ChangeSpeed(-(damage*.1f));
            Destroy(gameObject);
        }
    }
}
