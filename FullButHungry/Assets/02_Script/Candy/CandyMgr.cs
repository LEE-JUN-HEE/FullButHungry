using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CandyMgr : MonoBehaviour
{
    Ray2D ray;
    Vector2 tempvec;

    public static CandyMgr Instance = null;


    public List<Sprite> NormalSprite = new List<Sprite>();
    public List<Sprite> PressedSprite = new List<Sprite>();
    public List<Transform> tr_Hole = new List<Transform>();
    public Dictionary<int, Candy_IT_Ingame> Dic_Pair = new Dictionary<int, Candy_IT_Ingame>();
    public Candy_IT_Ingame Enemy = null;

    //InGame
    public Transform tr_Parent = null;

    //UI
    public PN_CandyNaming Naming = null;
    public GameObject GO_Pause = null;
    public GameObject GO_Alram = null;
    public PN_CandyIngame InGameUI = null;
    public PN_CandyMission MissionUI = null;
    public PN_Alert AlertUI = null;
    public PN_CandyResult ResultUI = null;
    public PN_CandyPause PauseUI = null;

    List<int> Select = new List<int>();

    public float EnergyTime = 50;
    public int EnemyCnt = 0;
    
    public bool isPause = true;
    public bool isGameOver = false;
    public bool usechance = false;

    float revealtime = 3;

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
        for(int i = 0; i< 12; i++)
        {
            Dic_Pair.Add(i, null);
        }
    }

    void Update()
    {
        funcupdate();
    }

    void update_ray()
    {
        //RayCast
        if (Input.GetMouseButtonDown(0))
        {
            tempvec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray = new Ray2D(tempvec, Vector2.zero);
            RaycastHit2D HitObj = Physics2D.Raycast(ray.origin, ray.direction);

            if (HitObj.collider != null && HitObj.transform.GetComponent<Candy_IT_Ingame>() != null)
            {
                HitObj.transform.GetComponent<Candy_IT_Ingame>().OnClick_Hit();
            }
        }
    }


    void update_revealTime()
    {
        revealtime += Time.fixedDeltaTime;

        if(revealtime >= 3f)
        {
            Debug.Log("Create");
            CreateEnemy();
        }
    }

    void update_empty() { }

    void update_real()
    {
        if (isPause) return;
        if (isGameOver) { GameOver(); return; }

        EnergyTime -= Time.unscaledDeltaTime;
        isGameOver = EnergyTime <= 0;
        update_ray();
        update_revealTime();
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
        //enemy.SetData(Select[Random.Range(0, Select.Count - 1)]);
        isPause = false;
        funcupdate = update_real;
    }

    public void Pause(bool _isPause)
    {
        isPause = _isPause;
    }

    public void GameOver()
    {
        UserInfo.ExpUp(50);
        ResultUI.Show();

        funcupdate = update_empty;
    }

    public void Mission()
    {
        if (usechance) return;
        MissionUI.gameObject.SetActive(true);
        Pause(true);
    }

    public void MissionComplete()
    {
        usechance = true;
        EnergyTime = 50;
    }
    
    public void CreateEnemy()
    {
        int index = Random.Range(0, 11);

        if(Dic_Pair[index] == null)
        {
            //Create
            revealtime = 0;
            GameObject Go = (GameObject)Instantiate(Enemy.gameObject, tr_Parent);
            Go.transform.localPosition = tr_Hole[index].localPosition;
            Dic_Pair[index] = Go.GetComponent<Candy_IT_Ingame>();
            Dic_Pair[index].SetData(Select[Random.Range(0, Select.Count - 1)]);
        }
        //StartCoroutine(changeEnemy());
    }

    //IEnumerator changeEnemy()
    //{

    //    //for (int i = 0; i < 4; i++)
    //    //{
    //    //    enemy.SetAni(i);
    //    //    yield return new WaitForSeconds(0.3f);
    //    //}

    //    //while (enemy.sp_Enemy.alpha > 0)
    //    //{
    //    //    enemy.sp_Enemy.alpha -= 0.2f;
    //    //    yield return null;
    //    //}

    //    //if (++EnemyCnt % 4 == 0)
    //    //{
    //    //    enemy.SetData(9);
    //    //}
    //    //else
    //    //{
    //    //    int rand = Random.Range(0, Select.Count - 1);
    //    //    enemy.SetData(Select[rand]);
    //    //}

    //    yield break;
    //}





    public void OnClick_Start()
    {
        PlayStart();
        GO_Alram.SetActive(false);
    }
}
