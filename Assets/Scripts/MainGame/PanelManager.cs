using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    TextMesh countEnemy;
    public List<GameObject> enemys;

    // Start is called before the first frame update
    private void Awake()
    {
        countEnemy = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        enemys = gameObject.transform.parent.parent.GetChild(1).GetComponent<EnemyOnTileManager>().enemys;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (enemys != null) countEnemy.text = "" + enemys.Count;
        else countEnemy.text = "0";
    }
}
