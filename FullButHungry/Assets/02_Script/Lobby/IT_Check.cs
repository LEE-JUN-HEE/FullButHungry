using UnityEngine;
using System.Collections;

public class IT_Check : MonoBehaviour
{
    public UISprite sp_BG = null;
    public UILabel lb_Number = null;
    public UILabel lb_Question = null;

    public UISprite sp_Answer = null;

    public bool isYes = false;

    string str_yes = "Check_Yes";
    string str_no = "Check_NO";

    public void SetData(int index,  bool _isYes)
    {
        sp_BG.spriteName = (index % 2 == 0) ? "Check_BG2" : "Check_BG1";
        lb_Number.text = index.ToString() + ".";
        lb_Question.text = Setstring(index);

        if (isYes)
        {
            sp_Answer.spriteName = str_yes;
        }
        else
        {
            sp_Answer.spriteName = str_no;
        }
    }

    public void OnClick_Ans()
    {
        isYes = !isYes;

        if (isYes)
        {
            sp_Answer.spriteName = str_yes;
            sp_Answer.GetComponent<UIButton>().normalSprite = str_yes;
        }
        else
        {
            sp_Answer.spriteName = str_no;
            sp_Answer.GetComponent<UIButton>().normalSprite = str_no;
        }
    }

    string Setstring(int index)
    {
        switch (index)
        {
            case 0:
                return "친구가 치킨을 먹자고 하면 갑자기 치킨이 먹고 싶어지니?";
            case 1:
                return "배에서 꼬르륵 소리가 나고있어?";
            case 2:
                return "지금 먹으면 죄책감이 들 것 같니?";
            case 3:
                return "아무 생각이 나지 않을 만큼 배가 고파?";
            case 4:
                return "식사를 한지 4 - 5시간이 지났어?";
            case 5:
                return "특정 음식을 먹고싶은 생각이 강하니?";
            case 6:
                return "배가 서서히 고파오고 있어?";
            case 7:
                return "먹는것에 불편한 감정을 느끼니?";
            case 8:
                return "감정적으로 심란한 상황이야?";
            case 9:
                return "배가 고프지만 당장 먹지 않아도 괜찮을 것 같아?";
            default:
                return null;
        }
    }

    /*
1,3,4,6,8,9 - 응 대답
2,5,7,10    - 아니 대답
    */
}
