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
    static public float NormalizedExp { get { return Exp / MaxExp; } }

    //앱 켜저있을때만 저장
    static public bool isLevelUp = false;
    static public bool HungryCheck = false;
    static public List<bool> Hungry = new List<bool>(10);


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
