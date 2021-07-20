using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public bool isCognize;

    Slider bgmS, effectS, responsiveS;
    GameMng gameMng;
    GameObject aimP, endPanel, settingPanel;
    Image damageRed;
    PostProcessVolume postProcess;
    Text countText, hpText, stageText, moneyText, finalRoundText;
    PlayerMove p01, p02;

    private void Awake()
    {
        p01 = GameObject.Find("Player01").GetComponent<PlayerMove>();
        p02 = GameObject.Find("Player02").GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameMng = gameObject.GetComponent<GameMng>();
        
        aimP = GameObject.Find("AimPoint");
        endPanel = GameObject.Find("GameEnd");
        settingPanel = GameObject.Find("SettingPanel");

        bgmS = GameObject.Find("BgmS").GetComponent<Slider>();
        effectS = GameObject.Find("EffectS").GetComponent<Slider>();
        responsiveS = GameObject.Find("ResponsiveS").GetComponent<Slider>();

        countText = GameObject.Find("TimeCount").GetComponent<Text>();
        hpText = GameObject.Find("PlayerHp").GetComponent<Text>();
        stageText = GameObject.Find("NowStage").GetComponent<Text>();
        moneyText = GameObject.Find("Money").GetComponent<Text>();
        finalRoundText = GameObject.Find("FanalRound").GetComponent<Text>();

        damageRed = GameObject.Find("DamageRed").GetComponent<Image>();
        postProcess = GameObject.Find("PostProcess").GetComponent<PostProcessVolume>();

        endPanel.SetActive(false);
        settingPanel.SetActive(false);

        ReValueSlide();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCognize) aimP.GetComponent<Image>().color = new Color(255, 0, 0, 1);
        else aimP.GetComponent<Image>().color = new Color(100, 100, 100, .3f);

        if (Time.timeScale == 0)
        {
            if (settingPanel.activeSelf)
            {
                endPanel.transform.GetChild(0).GetComponent<Button>().interactable = false;
                endPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }
            else
            {
                endPanel.transform.GetChild(0).GetComponent<Button>().interactable = true;
                endPanel.transform.GetChild(1).GetComponent<Button>().interactable = true;
            }

            endPanel.SetActive(true);
            finalRoundText.text = "최종 라운드 : " + (gameMng.nowStage+1);
        }
        else
        {
            endPanel.SetActive(false);
            settingPanel.SetActive(false);
        }

        countText.text = (int)(gameMng.stageTime) + "";
        hpText.text = "체력 : "+  gameMng.playerHp;
        stageText.text = (gameMng.nowStage < gameMng.LevelData.Count ? gameMng.LevelData[gameMng.nowStage]["Name"].ToString() : "Done") + (gameMng.isPlayGame ? " 진행중" : " 준비중");
        moneyText.text = "돈 : " + gameMng.money;
    }

    public void DamagePlayer()
    {
        Color baseColor = damageRed.color;
        baseColor.a = 0.7f;
        damageRed.color = baseColor;
        StartCoroutine("RunFadeOut");
    }
    IEnumerator RunFadeOut()
    {
        Color color = damageRed.color;
        while (color.a > 0.0f)
        {
            color.a -= 0.1f;
            damageRed.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TimeSetPlay()
    {
        Time.timeScale = 1;
    }

    public void ReValueSlide()
    {
        bgmS.value = PlayerPrefs.GetFloat("BgmV");
        effectS.value = PlayerPrefs.GetFloat("EffectV");
        responsiveS.value = PlayerPrefs.GetFloat("ResponsiveV");
    }

    public void PushSlideData()
    {
        PlayerPrefs.SetFloat("BgmV", bgmS.value);
        PlayerPrefs.SetFloat("EffectV", effectS.value);
        PlayerPrefs.SetFloat("ResponsiveV", responsiveS.value);

        p01.LookSpeedChange();
        p02.LookSpeedChange();
        GameObject.Find("Bgm").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BgmV");
    }
}

