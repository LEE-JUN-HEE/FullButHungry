using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_PreQA : MonoBehaviour 
{
    string[] str_choco = { "혹시 요즘 우울한일\n있었어?", "무언가가 널 실망스럽게\n만들었니?", "혹시 최근에 화가 나는\n일이라도 있었니?", "슬픈 감정을 마음속으로\n숨기고 있는거야" };
    string[] str_candy = { "c1", "c2", "c3", "c4" };
    string[] str_milk = { "m1", "m2", "m3", "m4" };

    public List<GameObject> spot = new List<GameObject>();
    public UILabel lb_Text = null;

    List<string> ask;
    Common.opentype type = Common.opentype.choco;
    int QAIndex = 0;
    int NOCnt = 0;

    public void Show(Common.opentype _type)
    {
        type = _type;
        QAIndex = 0;
        NOCnt = 0;
        spot.ForEach(x => x.SetActive(false));
        spot[QAIndex].SetActive(true);

        switch (type)
        {
            case Common.opentype.candy:
                ask = new List<string>(str_candy);
                break;
            case Common.opentype.choco:
                ask = new List<string>(str_choco);
                break;
            case Common.opentype.milk:
                ask = new List<string>(str_milk);
                break;
        }
        lb_Text.text = ask[QAIndex];

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Yes()
    {
        if (++QAIndex >= 4)
        {
            //결과
            LobbyManager.Instance.QAResult.Show(type, NOCnt == 0);
            Hide();
        }
        else
        {
            spot.ForEach(x => x.SetActive(false));
            spot[QAIndex].SetActive(true);

            lb_Text.text = ask[QAIndex];
            //질문세팅
        }
    }

    public void OnClick_No()
    {
        NOCnt++;
        if (++QAIndex >= 4)
        {
            //결과
            LobbyManager.Instance.QAResult.Show(type, NOCnt == 0);
            Hide();
        }
        else
        {
            spot.ForEach(x => x.SetActive(false));
            spot[QAIndex].SetActive(true);
            lb_Text.text = ask[QAIndex];
            //질문세팅
        }
    }
}
