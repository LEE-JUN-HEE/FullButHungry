using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour
{
    public UILabel lb_Level = null;
    public UIProgressBar pb_Exp = null;
    public UILabel lb_Hungry = null;
    public UILabel lb_Talk = null;
    public UILabel lb_Levelup = null;
    public GameObject go_ParticleL = null;
    public GameObject go_ParticleR = null;
    public TweenAlpha TA_L = null;
    public TweenAlpha TA_R = null;
    public SpriteRenderer Character = null;

    public Sprite sp_N = null;
    public Sprite sp_C = null;

    /// <summary>
    /// 
    /// </summary>

    float AniStart = 0;
    int count = 0;
    float leveluptime = 9999f;

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

        if (leveluptime + 3f < Time.unscaledTime)
        {
            UserInfo.isLevelUp = false;
            refresh_hungry();
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
        if (UserInfo.isLevelUp)
        {
            leveluptime = Time.unscaledTime;
            lb_Levelup.gameObject.SetActive(true);
        }
        else if (UserInfo.HungryCheck == true)
        {
            lb_Levelup.gameObject.SetActive(false);
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
                        if (!UserInfo.Hungry[i])
                            count += 10;
                        break;

                    default:
                        if (UserInfo.Hungry[i])
                            count += 10;
                        break;
                }
            }
        string talk = null;
        
        if (count < 30)
            talk = "뇌불러서\n행복해요 ㅎㅎ";
        else if (count < 50)
            talk = "뇌고파요 ㅠㅠ";
        else if (count < 70)
            talk = "너무너무\n뇌고파요ㅠㅠ";
        else
            talk = "뇌고파서\n힘들어요ㅠㅠ";

        lb_Talk.text = talk;
        lb_Hungry.text = count + "%";
        }
        else
        {
            lb_Levelup.gameObject.SetActive(false);
            lb_Talk.text = "오늘 나의 허기지수는?";
            lb_Hungry.text = "00%";
        }

    }

    void refresh_induceclick()
    {
        go_ParticleL.SetActive(!UserInfo.HungryCheck);
        go_ParticleR.SetActive(UserInfo.HungryCheck);
        TA_L.enabled = !UserInfo.HungryCheck;
        TA_R.enabled = UserInfo.HungryCheck;
        TA_L.GetComponent<UISprite>().alpha = 1.0f;
        TA_R.GetComponent<UISprite>().alpha = 1.0f;
    }

    void refresh_sprite()
    {
        int level = (UserInfo.Level > 10) ? 9 : UserInfo.Level;
        int percent = 0;
        if (count < 30)
            percent = 4;
        else if (count < 50)
            percent = 3;
        else if (count < 70)
            percent = 2;
        else
            percent = 1;

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
        LobbyManager.Instance.MyInfoUI.Show();
    }
}
