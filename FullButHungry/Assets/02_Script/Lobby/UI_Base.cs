using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour 
{
    public UILabel lb_Level = null;
    public UIProgressBar pb_Exp = null;
    public GameObject go_CheckList = null;
    public UILabel lb_Hungry = null;
    public UILabel lb_Talk = null;
    public GameObject go_ParticleL = null;
    public GameObject go_ParticleR = null;

    public void Init()
    {
        lb_Level.text = UserInfo.Level.ToString();
        pb_Exp.value = UserInfo.NormalizedExp;
        go_ParticleL.SetActive(!UserInfo.HungryCheck);
        go_ParticleR.SetActive(UserInfo.HungryCheck);
        Refresh_Hungry();
    }

    
    public void OnClick_Check()
    {
        LobbyManager.Instance.HungryCheckUI.Show();
    }

    public void OnClick_MainGame()
    {
        LobbyManager.Instance.SelectFoodUI.Show();
    }

    public void Refresh_Hungry()
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
}
