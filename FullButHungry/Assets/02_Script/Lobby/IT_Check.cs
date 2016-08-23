﻿using UnityEngine;
using System.Collections;

public class IT_Check : MonoBehaviour 
{
    public UISprite sp_BG = null;
    public UILabel lb_Number = null;
    public UILabel lb_Question = null;

    public UISprite sp_Answer = null;

    public bool isYes = false;

    Color c_white = Color.white;
    Color c_pink = Color.red;

    string str_yes = "Check_Yes";
    string str_no = "Check_NO";

    public void SetData(int index, string _question, bool _isYes)
    {
        sp_BG.color = (index % 2 == 0) ? c_pink : c_white;
        lb_Number.text = index.ToString() + ".";
        lb_Question.text = _question;

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
}