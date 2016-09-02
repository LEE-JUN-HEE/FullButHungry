using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MilkMgr : MonoBehaviour
{
    public static MilkMgr Instance = null;

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


    //Logic
    public List<Milk_Enemy> Enemys = new List<Milk_Enemy>();
    public Milk_Bomb Bomb = null;
    List<int> Select = new List<int>();

    public float EnergyTime = 50;
    public int EnemyCnt = 0;
    public List<string> AtkString = new List<string>();

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
        Bomb.Set(0);
        Enemys.ForEach(x => x.SetData(Select[Random.Range(0, Select.Count - 1)]));
        isPause = false;
        funcupdate = update_real;
    }

    public void Pause(bool _isPause)
    {
        isPause = _isPause;
        GO_Pause.SetActive(isPause);
    }

    public void GameOver()
    {
        UserInfo.ExpUp(50);
        ResultUI.Show();

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
        Bomb.Set(++atkCnt);
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
