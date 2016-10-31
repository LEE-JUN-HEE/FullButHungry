using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInfo
{
    //영구 저장
    //어떤게임 몇번 플레이했는지도 추가될구 있음
    static public int Level = 1;
    static public float Exp = 0;
    static public float MaxExp = 150;
    static public int totalclick = 0;
    static public int hot = 0;
    static public int junk = 0;
    static public int bread = 0;
    static public int milk = 0;
    static public int candy = 0;
    static public int choco = 0;
    static public int desert = 0;
    static public int hungrycnt = 0;
    static public float totalhungry = 0;
    static public System.DateTime MissionTime;
    static public List<int> Mission = new List<int>();
    static public List<bool> MissionB = new List<bool>();
    static public float NormalizedExp { get { return Exp / MaxExp; } }

    //앱 켜저있을때만 저장
    static public bool isLevelUp = false;
    static public bool HungryCheck = false;
    static public List<bool> Hungry = new List<bool>(10);

    static public string[] mission = 
    {
        "엄마께 전화 한통 드리기",
        "따뜻한 차 한잔 마시기",
        "두번째 서랍 정리하기",
        "10번 깊게 호흡하기",
        "행복했던 순간 떠올리기",
        "나 스스로를 위한 선물하기",
        "내가 좋아하는 노래 한곡 부르기",
        "버킷리스트 작성하기",
        "친구에게 연락하기",
        "나의 팔 다리 마사지 하기",
        "가장 좋아하는 노래 한곡 듣기",
        "오늘의 감정을 생각나는대로 적기",
        "가장 하고싶은 일 상상하기",
        "5분동안 멍때리기",
        "인형이나 담요 등 포근한 것 끌어안기"
    };

    //////////////////////////////////////////////////////////////////


    static public void Init()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            Debug.Log("Load");
            Level = PlayerPrefs.GetInt("Level");
            Exp = PlayerPrefs.GetFloat("Exp");
            totalclick = PlayerPrefs.GetInt("Total_ClickCnt");
            hot = PlayerPrefs.GetInt("Hot");
            junk = PlayerPrefs.GetInt("Junk");
            bread = PlayerPrefs.GetInt("Bread");
            milk = PlayerPrefs.GetInt("Milk");
            candy = PlayerPrefs.GetInt("Candy");
            choco = PlayerPrefs.GetInt("Choco");
            desert = PlayerPrefs.GetInt("Desert");
            hungrycnt = PlayerPrefs.GetInt("HungryCnt");
            totalhungry = PlayerPrefs.GetFloat("TotalHungry");

            Mission.Clear();
            MissionTime = System.DateTime.Parse(PlayerPrefs.GetString("MissionTime"));
            System.DateTime Tomorrow = new System.DateTime(MissionTime.AddDays(1).Year, MissionTime.AddDays(1).Month, MissionTime.AddDays(1).Day, 0, 0, 0);
            if (System.DateTime.Today >= Tomorrow)
            {
                for (int i = 0; i < 3; )
                {
                    int index = Random.Range(0, mission.Length);
                    if (Mission.Contains(index) == false)
                    {
                        Mission.Add(index);
                        MissionB.Add(false);
                        i++;
                    }
                }
                PlayerPrefs.SetString("MissionTime", System.DateTime.Today.ToString());
            }
            else
            {
                Mission.Add(PlayerPrefs.GetInt("Mission1"));
                Mission.Add(PlayerPrefs.GetInt("Mission2"));
                Mission.Add(PlayerPrefs.GetInt("Mission3"));
                MissionB.Add(bool.Parse(PlayerPrefs.GetString("Mission1B")));
                MissionB.Add(bool.Parse(PlayerPrefs.GetString("Mission2B")));
                MissionB.Add(bool.Parse(PlayerPrefs.GetString("Mission3B")));
            }
        }
        else
        {
            Debug.Log("First");
            Level = 1;
            Exp = 0;
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetFloat("Exp", 0);
            PlayerPrefs.SetInt("Total_ClickCnt", 0);
            PlayerPrefs.SetInt("Hot", 0);
            PlayerPrefs.SetInt("Junk", 0);
            PlayerPrefs.SetInt("Bread", 0);
            PlayerPrefs.SetInt("Milk", 0);
            PlayerPrefs.SetInt("Candy", 0);
            PlayerPrefs.SetInt("Choco", 0);
            PlayerPrefs.SetInt("Desert", 0);

            PlayerPrefs.SetInt("HungryCnt", 0);
            PlayerPrefs.SetFloat("TotalHungry", 0);
            PlayerPrefs.SetString("MissionTime", System.DateTime.Today.ToString());
            for (int i = 0; i < 3; )
            {
                int index = Random.Range(0, mission.Length);
                if (Mission.Contains(index) == false)
                {
                    Mission.Add(index);
                    i++;
                    if (i == 0)
                        PlayerPrefs.SetInt("Mission1", index);
                    else if (i == 1)
                        PlayerPrefs.SetInt("Mission2", index);
                    else if (i == 2)
                        PlayerPrefs.SetInt("Mission3", index);
                }
            }
            PlayerPrefs.SetString("Mission1B", false.ToString());
            PlayerPrefs.SetString("Mission2B", false.ToString());
            PlayerPrefs.SetString("Mission3B", false.ToString());
            MissionB.Add(false);
            MissionB.Add(false);
            MissionB.Add(false);
            PlayerPrefs.Save();
        }
    }

    static public void ExpUp(float value)
    {
        Exp += value;
        if (Exp >= MaxExp)
        {
            isLevelUp = true;
            Level += 1;
            Exp -= MaxExp;
        }
        PlayerPrefs.SetFloat("Exp", Exp);
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.Save();
    }

    static public void Check_Hungry(float cur)
    {
        hungrycnt++;
        totalhungry += cur;

        PlayerPrefs.SetFloat("TotalHungry", totalhungry);
        PlayerPrefs.SetInt("HungryCnt", hungrycnt);
        PlayerPrefs.Save();
    }

    static public void Click_Choco()
    {
        totalclick++;
        choco++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Choco", choco);
        PlayerPrefs.Save();
    }

    static public void Click_Candy()
    {

        totalclick++;
        candy++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Candy", candy);
        PlayerPrefs.Save();
    }

    static public void Click_MIlk()
    {

        totalclick++;
        milk++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Milk", milk);
        PlayerPrefs.Save();
    }

    static public void Click_Hot()
    {

        totalclick++;
        hot++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Hot", hot);
        PlayerPrefs.Save();
    }

    static public void Click_Junk()
    {

        totalclick++;
        junk++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Junk", junk);
        PlayerPrefs.Save();
    }

    static public void Click_Desert()
    {

        totalclick++;
        desert++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Desert", desert);
        PlayerPrefs.Save();
    }

    static public void Click_Bread()
    {

        totalclick++;
        bread++;
        PlayerPrefs.SetInt("Total_ClickCnt", totalclick);
        PlayerPrefs.SetInt("Bread", bread);
        PlayerPrefs.Save();
    }
}
