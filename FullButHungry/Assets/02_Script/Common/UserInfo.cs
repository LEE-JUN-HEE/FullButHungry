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
        }
        else
        {
            Debug.Log("First");
            Level = 1;
            Exp = 0;
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetFloat("Exp", 0);
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
}
