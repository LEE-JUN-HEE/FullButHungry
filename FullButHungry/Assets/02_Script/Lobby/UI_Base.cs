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
    public SpriteRenderer Character = null;

    public Sprite sp_N = null;
    public Sprite sp_C = null;

    /// <summary>
    /// 
    /// </summary>

    float AniStart = 0;
    int count = 0;

    public void Init()
    {
        lb_Level.text = UserInfo.Level.ToString();
        pb_Exp.value = UserInfo.NormalizedExp;
        AniStart = Time.unscaledTime;
        Refresh();
    }

    void Update()
    {
        if (Time.unscaledTime > AniStart + 10.5)
        {
            Character.sprite = sp_N;
            AniStart = Time.unscaledTime;
        }
        else if (Time.unscaledTime > AniStart + 10)
        {
            Character.sprite = sp_C;
        }
        else if (Time.unscaledTime > AniStart + 4.5)
        {
            Character.sprite = sp_N;
        }
        else if (Time.unscaledTime > Time.unscaledTime)
        {
            Character.sprite = sp_C;
        }
        else if (Time.unscaledTime > AniStart + 3.5)
        {
            Character.sprite = sp_N;
        }
        else if (Time.unscaledTime > AniStart + 3)
        {
            Character.sprite = sp_C;
        }
    }

    public void Refresh()
    {
        refresh_hungry();
        refresh_induceclick();
        refresh_sprite();
    }

    void refresh_hungry()
    {
        count = 0;
        if (UserInfo.HungryCheck == true)
        {
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 1:
                    case 3:
                    case 4:
                    case 6:
                    case 8:
                    case 9:
                        if (UserInfo.Hungry[i])
                            count += 10;
                        break;

                    default:
                        if (!UserInfo.Hungry[i])
                            count += 10;
                        break;
                }
            }
        }
        string talk = null;
        if (count < 30)
            talk = "너무너무\n뇌고파요ㅠㅠ";
        else if (count < 50)
            talk = "너무너무\n뇌고파요ㅠㅠ2";
        else if (count < 70)
            talk = "너무너무\n뇌고파요ㅠㅠ3";
        else
            talk = "너무너무\n뇌고파요ㅠㅠ4";

        lb_Talk.text = talk;
        lb_Hungry.text = count + "%";

    }

    void refresh_induceclick()
    {
        go_ParticleL.SetActive(!UserInfo.HungryCheck);
        go_ParticleR.SetActive(UserInfo.HungryCheck);
    }

    void refresh_sprite()
    {
        int level = (UserInfo.Level > 10) ? 9 : UserInfo.Level;
        int percent = 0;
        if (count < 30)
            percent = 1;
        else if (count < 50)
            percent = 2;
        else if (count < 70)
            percent = 3;
        else
            percent = 4;

        string path = (string.Format("MainCharacter/{0}/{0}_{1}", level, percent));
        sp_N = Resources.Load<Sprite>(path);
        sp_C = Resources.Load<Sprite>(path + "_");
        Character.sprite = sp_N;
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
        UserInfo.ExpUp(150f);
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
        LobbyManager.Instance.DicUI.Show();
    }

    public void OnClick_Brain()
    {
    }
}
