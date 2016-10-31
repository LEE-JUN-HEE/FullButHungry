using UnityEngine;
using System.Collections;

public class UI_DicInfo : MonoBehaviour 
{
    public UISprite sp_Icon = null;
    public UILabel lb_Title = null;

    //리소스 로드로 인풋 불러오자

    public void Show(int _Index, string _Title)
    {
        lb_Title.text = _Title;
        gameObject.SetActive(true);
    }

    public void Hide()
    {

        gameObject.SetActive(false);
    }

    public void OnClick_Back() { Hide(); }

    public void OnClick_Cheat()
    {
        PlayerPrefs.DeleteAll();
    }
}
