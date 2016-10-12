using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MilkMgr : MonoBehaviour
{
    public static MilkMgr Instance = null;

    string[] str_atk =
    {
        "기뻐",
        "웃음",
        "진정돼",
        "따뜻해",
        "편안해",
        "기분좋아",
        "행복해",
        "즐거워",
        "기뻐",
    };

    string[] str_Boss =
    {
        "난 지금 굉장히 평온해",
        "난 행복한 사람이야",
        "긴장하지 않아도 돼",
        "나는 빛나는 사람이야",
        "나는 옳은 길을 걷고 있어",
        "나는 아무것도 두렵지 않아",
        "나는 나를 믿어",
    };

    public List<Sprite> NormalSprite = new List<Sprite>();
    public List<Sprite> PressedSprite = new List<Sprite>();

    //UI
    public PN_MilkNaming Naming = null;
    //public KeyInput keyInput = null;
    public GameObject GO_Pause = null;
    public GameObject GO_Alram = null;
    public PN_MilkIngame InGameUI = null;
    public PN_MilkMission MissionUI = null;
    public PN_Alert AlertUI = null;
    public PN_MilkResult ResultUI = null;
    public PN_MilkPause PauseUI = null;
    public PN_MilkMissionClear MCUI = null;
    public PN_MilkEmpty EmptyUI = null;

    //Logic
    public List<Milk_Enemy> Enemys = new List<Milk_Enemy>();
    public Milk_Bomb Bomb = null;
    List<int> Select = new List<int>();

    public float EnergyTime = 50;
    public int EnemyCnt = 0;
    public List<string> AtkString = new List<string>();
    public List<AudioClip> AC_Bomb = new List<AudioClip>();

    public bool IsBoss { get; set; }
    public bool isPause = true;
    public bool isGameOver = false;
    public bool usechance = false;
    public int atkCnt = 0;

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

    public void NamingComplete()
    {
        Naming.gameObject.SetActive(false);
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
        AtkString.Add(str_atk[(EnemyCnt * 3) % 9]);
        AtkString.Add(str_atk[(EnemyCnt * 3 + 1) % 9]);
        AtkString.Add(str_atk[(EnemyCnt * 3 + 2) % 9]);
        IsBoss = false;

        Bomb.Set(0);
        Enemys.ForEach(x => x.SetData(Select[Random.Range(0, Select.Count - 1)]));
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
        if (IsBoss)
            Bomb.Set(3);
        else
            Bomb.Set(++atkCnt);
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
            AtkString.Add(str_Boss[Random.Range(0, str_Boss.Length - 1)]);
            IsBoss = true;
        }
    }

    public void Boom()
    {
        Enemys.ForEach(x => x.Died());
        ChangeEnemy();
    }

    public void ChangeEnemy()
    {
        atkCnt = 0;
        StartCoroutine(changeEnemy());
    }

    IEnumerator changeEnemy()
    {
        yield return new WaitForSeconds(1.5f);

        EnemyCnt++;
        SetString();
        Enemys.ForEach(x => x.SetData(Select[Random.Range(0, Select.Count - 1)]));
        Bomb.Set(0);


        yield break;
    }





    public void OnClick_Start()
    {
        PlayStart();
        GO_Alram.SetActive(false);
    }
}
