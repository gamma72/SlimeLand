using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneMng : MonoBehaviour
{
    GameObject startBtn, settingBtn, quitBtn, newBtn, conBtn, backBtn;

    private void Start()
    {
        startBtn = GameObject.Find("GameStartBtn");
        settingBtn = GameObject.Find("GameSettingBtn");
        quitBtn = GameObject.Find("GameQuitBtn");
        newBtn = GameObject.Find("NewGameBtn");
        conBtn = GameObject.Find("ContinueBtn");
        backBtn = GameObject.Find("BackMainBtn");

        GameObject.Find("SettingPanel").SetActive(false);

        newBtn.SetActive(false);
        conBtn.SetActive(false);
        backBtn.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (!PlayerPrefs.HasKey("NowStage"))
        {
            StartNewGame();
        }
    }

    public void GameStartBtn()
    {
        startBtn.SetActive(false);
        settingBtn.SetActive(false);
        quitBtn.SetActive(false);

        newBtn.SetActive(true);
        conBtn.SetActive(true);
        backBtn.SetActive(true);

        if (PlayerPrefs.HasKey("NowStage"))
        {
            conBtn.GetComponent<Button>().interactable = true;
        }
        else
        {
            conBtn.GetComponent<Button>().interactable = false;
        }
    }

    public void BackMainBtn()
    {
        newBtn.SetActive(false);
        conBtn.SetActive(false);
        backBtn.SetActive(false);

        startBtn.SetActive(true);
        settingBtn.SetActive(true);
        quitBtn.SetActive(true);
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("NowStage", 0);
        PlayerPrefs.SetInt("PlayerHp", 10);
        PlayerPrefs.SetInt("Money", 200);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
