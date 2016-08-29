using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChocoMgr : MonoBehaviour
{
    public static ChocoMgr Instance = null;

    //InGame
    public Enemy enemy = null;
    public Projectile proj = null;

    //UI
    public PN_Naming Naming = null;
    public KeyInput keyInput = null;
    public GameObject GO_Alram = null;
    public PN_Ingame InGameUI = null;

    List<int> Select = new List<int>();

    public float EnergyTime = 50;
    public int EnemyCnt = 0;
    public List<string> AtkString = new List<string>();

    public bool isPause = true;
    public bool isGameOver = false;

    /// 
    ///  Logic
    /// 

    void Awake()
    {
        Instance = this;
        Naming.gameObject.SetActive(true);
        GO_Alram.SetActive(false);
    }

    void Update()
    {
        if (isPause) return;
        if (isGameOver) return;

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
        keyInput.Init();
        keyInput.callback = CheckString;
        isPause = false;
    }

    public void Pause(bool _isPause)
    {
        isPause = _isPause;
    }

    public void CheckString(string _arg)
    {
        if (AtkString.Contains(_arg))
            Fire();
    }

    public void Fire()
    {
        proj.transform.localPosition = enemy.transform.localPosition;
        proj.gameObject.SetActive(true);
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

        int rand = Random.Range(0, Select.Count - 1);
        enemy.SetData(Select[rand]);
        yield break;
    }

    public void SetEnemy(int _Index)
    {

    }
    




    public void OnClick_Start()
    {
        PlayStart();
        GO_Alram.SetActive(false);
    }
}
