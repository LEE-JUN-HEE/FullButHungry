using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_PreQA : MonoBehaviour 
{
    string[] str_choco = { "무언가가 널 외롭게\n만드니??", "네가 충분히 사랑받고\n있지 않다고 생각하니?", "불안하거나 허전함을\n느끼고있어?", "무언가에 긴장되거나\n편안하지 않은 감정이니?" };
    string[] str_candy = { "무언가에 지루함을\n느끼고 있니?", "기분전환이 필요하니?", "너의 생활에 만족하지\n못하고 있니?", "무언가에 무기력함을\n느끼고 있어?" };
    string[] str_milk = { "혹시 요즘 우울한일\n있었어?", "무언가가 널 실망스럽게\n만들었니?", "혹시 최근에 화가 나는\n일이라도 있었니?", "슬픈 감정을 마음속으로\n숨기고 있는거야?" };

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
