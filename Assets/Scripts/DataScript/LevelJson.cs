using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class Level
{
    public int Num;
    public string Name;
    public int NomalC;
    public int RareC;
    public int BossC;
    public int Time;
    public int Xsize;
    public int Ysize;

    public Level(int n1, string name, int c1, int c2, int c3)
    {
        Num = n1;
        Name = name;
        NomalC = c1;
        RareC = c2;
        BossC = c3;
        Time = 60;
        Xsize = 12;
        Ysize = 12;
    }
    public Level(int n1, string name, int c1, int c2, int c3, int time, int x, int y)
    {
        Num = n1;
        Name = name;
        NomalC = c1;
        RareC = c2;
        BossC = c3;
        Time = time;
        Xsize = x;
        Ysize = y;
    }
}

public class LevelJson : MonoBehaviour
{
    public List<Level> LevelList = new List<Level>();
    void Start()
    {
        Save();
    }

    public void Save()
    {
        LevelList.Add(new Level(0, "�������� 01", 5, 0, 0));
        LevelList.Add(new Level(1, "�������� 02", 10, 1, 0));
        LevelList.Add(new Level(2, "�������� 03", 15, 2, 0));
        LevelList.Add(new Level(3, "�������� 04", 20, 3, 0));
        LevelList.Add(new Level(4, "�������� 05", 30, 0, 1));
        LevelList.Add(new Level(5, "�������� 06", 15, 2, 0));
        LevelList.Add(new Level(6, "�������� 07", 25, 4, 0));
        LevelList.Add(new Level(7, "�������� 08", 35, 6, 0));
        LevelList.Add(new Level(8, "�������� 09", 30, 0, 2));
        LevelList.Add(new Level(9, "�������� 01", 5, 0, 0));
        LevelList.Add(new Level(10, "�������� 02", 10, 1, 0));
        LevelList.Add(new Level(11, "�������� 03", 15, 2, 0));
        LevelList.Add(new Level(12, "�������� 04", 20, 3, 0));
        LevelList.Add(new Level(13, "�������� 05", 30, 0, 1));
        LevelList.Add(new Level(14, "�������� 06", 15, 2, 0));
        LevelList.Add(new Level(15, "�������� 07", 25, 4, 0));
        LevelList.Add(new Level(16, "�������� 08", 35, 6, 0));

        JsonData LevelJson = JsonMapper.ToJson(LevelList);

        File.WriteAllText(Application.dataPath + "/Resources/LevelData.json", LevelJson.ToString());
    }

    public void Load()
    {
        Debug.Log("Load");

        string JsonString = File.ReadAllText(Application.dataPath + "/Resources/LevelData.json");

        JsonData LevelData = JsonMapper.ToObject(JsonString);

        for(int i=0; i<LevelData.Count; i++)
        {
            Debug.Log(LevelData[i]["Name"].ToString());
        }
    }
}
