using UnityEngine;
using System.Collections;

public class UI_MyInfo : MonoBehaviour
{
    public UILabel lb_Eval = null;
    public UILabel lb_Cur = null;
    public UILabel lb_Lv = null;

    public UIProgressBar pb_Hot = null;
    public UIProgressBar pb_Junk = null;
    public UIProgressBar pb_Bread = null;
    public UIProgressBar pb_Milk = null;
    public UIProgressBar pb_Candy = null;
    public UIProgressBar pb_Choco = null;
    public UIProgressBar pb_Desert = null;

    public void Show()
    {
        lb_Lv.text = "Lv." + UserInfo.Level.ToString();
        lb_Eval.text = ((int)(UserInfo.totalhungry * 100 / UserInfo.hungrycnt)).ToString() +"%";
        int count = 0;
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
                        if (!UserInfo.Hungry[i])
                            count += 10;
                        break;

                    default:
                        if (UserInfo.Hungry[i])
                            count += 10;
                        break;
                }
            }
            lb_Cur.text = count + "%";
        }
        else
        {
            lb_Cur.text = "00%";
        }
        pb_Hot.value = (float)UserInfo.hot / 10f;
        pb_Junk.value = (float)UserInfo.junk / 10f;
        pb_Milk.value = (float)UserInfo.milk / 10f;
        pb_Bread.value = (float)UserInfo.bread / 10f;
        pb_Candy.value = (float)UserInfo.candy  / 10f;
        pb_Choco.value = (float)UserInfo.choco / 10f;
        pb_Desert.value = (float)UserInfo.desert / 10f;

        pb_Hot.thumb.gameObject.SetActive(pb_Hot.value == 1);
        pb_Junk.thumb.gameObject.SetActive(pb_Junk.value == 1);
        pb_Milk.thumb.gameObject.SetActive(pb_Milk.value == 1);
        pb_Bread.thumb.gameObject.SetActive(pb_Bread.value == 1);
        pb_Candy.thumb.gameObject.SetActive(pb_Candy.value == 1);
        pb_Choco.thumb.gameObject.SetActive(pb_Choco.value == 1);
        pb_Desert.thumb.gameObject.SetActive(pb_Desert.value == 1);

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Close()
    {
        Hide();
    }
}
