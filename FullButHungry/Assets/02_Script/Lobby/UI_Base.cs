using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour 
{
    public UILabel lb_Level = null;
    public UIProgressBar pb_Exp = null;
    public UILabel lb_Hungry = null;
    public UILabel lb_Talk = null;
    public GameObject go_ParticleL = null;
    public GameObject go_ParticleR = null;


    /// <summary>
    /// 
    /// </summary>

    public void Init()
    {
        lb_Level.text = UserInfo.Level.ToString();
        pb_Exp.value = UserInfo.NormalizedExp;
        Refresh();
    }

    public void Refresh()
    {
        refresh_hungry();
        refresh_induceclick();
    }
    
    void refresh_hungry()
    {
        int count = 0;
        if (UserInfo.HungryCheck == true)
        {
            for (int i = 0; i < 10; i++)
            {
                if (UserInfo.Hungry[i])
                    count += 10;
            }
        }
        lb_Hungry.text = count + "%";
    }

    void refresh_induceclick()
    {
        go_ParticleL.SetActive(!UserInfo.HungryCheck);
        go_ParticleR.SetActive(UserInfo.HungryCheck);
    }

    /// <summary>
    /// /////////
    /// </summary>
    /// 

    public void OnClick_Check()
    {
        LobbyManager.Instance.HungryCheckUI.Show();
    }

    public void OnClick_MainGame()
    {
        LobbyManager.Instance.SelectFoodUI.Show();
    }

    public void OnClick_Mission()
    {
        LobbyManager.Instance.MissionUI.Show();
    }

    public void OnClick_Home()
    {
    }
    public void OnClick_Storage()
    {
        LobbyManager.Instance.EmotionStorageUI.Show();
    }

    public void OnClick_Dic()
    {
    }

    public void OnClick_Brain()
    {
    }
}
