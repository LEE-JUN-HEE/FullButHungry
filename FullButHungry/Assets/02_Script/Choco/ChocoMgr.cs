﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChocoMgr : MonoBehaviour
{
    public static ChocoMgr Instance = null;

    string[] str_atk = 
    {
        "사랑해",
        "좋아해",
        "아름다워",
        "멋져",
        "설레여",
        "사랑",
        "애정",
        "행복",
        "기뻐"
    };

    string[] str_Boss = 
    {
        "나의 내일은 더 빛날 거야",
        "애쓰지 않아도 괜찮아",
        "괜찮아 그럴 수 있어",
        "난 지금 잘하고 있어",
        "내가 있어서 행복해"
    };

    //InGame
    public Enemy enemy = null;
    public Transform Cannon = null;
    public Projectile proj = null;

    //UI
    public PN_Naming Naming = null;
    //public KeyInput keyInput = null;
    public GameObject GO_Pause = null;
    public GameObject GO_Alram = null;
    public PN_Ingame InGameUI = null;
    public PN_Mission MissionUI = null;
    public PN_Alert AlertUI = null;
    public PN_Result ResultUI = null;
    public PN_Pause PauseUI = null;
    public PN_Empty EmptyUI = null;
    public PN_MissionClear MCUI = null;

    List<int> Select = new List<int>();

    public float EnergyTime = 50;
    public int EnemyCnt = 0;
    public List<string> AtkString = new List<string>();

    public bool IsBoss { get; set; }
    public bool isPause = true;
    public bool isGameOver = false;
    public bool usechance = false;
    public string kingName = null;

    System.Action funcupdate;

    /// 
    ///  Logic
    /// 

    void Awake()
    {
        Instance = this;
        Naming.gameObject.SetActive(true);
        GO_Alram.SetActive(false);
        funcupdate = update_empty;
        IsBoss = false;
    }

    void Update()
    {
        funcupdate();
    }

    void update_empty() { }

    void update_real()
    {
        if (isPause) return;
        if (isGameOver) { GameOver(); return; }
        if (usechance == false && EnergyTime < 10) { EmptyUI.Show(); return; }


        EnergyTime -= Time.unscaledDeltaTime;
        isGameOver = EnergyTime <= 0;
    }

    public void NamingComplete(string _Kn)
    {
        Naming.gameObject.SetActive(false);
        kingName = _Kn;
        GO_Alram.SetActive(true);
        for (int i = 0; i < Naming.NamingList.Count; i++)
        {
            if (Naming.NamingList[i].isSelect)
                Select.Add(i);
        }
    }

    public void PlayStart()
    {
        GO_Alram.SetActive(false);
        //keyInput.Init();
        //keyInput.callback = CheckString;
        enemy.SetData(Select[Random.Range(0, Select.Count - 1)]);

        AtkString.Add(str_atk[(EnemyCnt * 3) % 9]);
        AtkString.Add(str_atk[(EnemyCnt * 3 + 1) % 9]);
        AtkString.Add(str_atk[(EnemyCnt * 3 + 2) % 9]);

        IsBoss = false;
        isPause = false;
        funcupdate = update_real;
        GameManager.Instance.PlayBgm(1, true);
    }

    public void Pause(bool _isPause)
    {
        isPause = _isPause;
    }

    public void GameOver()
    {
        UserInfo.ExpUp(50);
        ResultUI.Show();
        GameManager.Instance.PlayBgm(2, false);

        funcupdate = update_empty;
    }

    public void CheckString(string _arg)
    {
        if (AtkString.Contains(_arg))
            Fire();
    }

    public void Mission()
    {
        if (usechance) return;
        InGameUI.Input.isSelected = false;
        MissionUI.gameObject.SetActive(true);
        Pause(true);
    }

    public void MissionComplete()
    {
        Pause(false);
        usechance = true;
        EnergyTime = 50;
    }

    public void Fire()
    {
        GameObject go = (GameObject)Instantiate(proj.gameObject, Cannon.transform.localPosition, Quaternion.identity, Cannon.transform);
        go.transform.localPosition = Vector2.zero;
        go.SetActive(true);

        Debug.Log(go.tag);
        //proj.transform.localPosition = Cannon.transform.localPosition;
        //proj.gameObject.SetActive(true);
    }

    public void SetString()
    {
        AtkString.Clear();
        if (EnemyCnt % 4 != 0)
        {
            AtkString.Add(str_atk[(EnemyCnt * 3) % 9]);
            AtkString.Add(str_atk[(EnemyCnt * 3 + 1) % 9]);
            AtkString.Add(str_atk[(EnemyCnt * 3 + 2) % 9]);
            IsBoss = false;
        }
        else
        {
            AtkString.Add(str_Boss[Random.Range(0, str_Boss.Length -1)]);
            IsBoss = true;
        }
    }

    public void ChangeEnemy()
    {
        StartCoroutine(changeEnemy());
    }

    IEnumerator changeEnemy()
    {

        for (int i = 0; i < 4; i++)
        {
            enemy.SetAni(i);
            yield return new WaitForSeconds(0.3f);
        }

        while (enemy.sp_Enemy.alpha > 0)
        {
            enemy.sp_Enemy.alpha -= 0.2f;
            yield return null;
        }

        if (++EnemyCnt % 4 == 0)
        {
            enemy.SetData(9);
        }
        else
        {
            int rand = Random.Range(0, Select.Count - 1);
            enemy.SetData(Select[rand]);
        }
        SetString();

        yield break;
    }





    public void OnClick_Start()
    {
        PlayStart();
        GO_Alram.SetActive(false);
    }
}
