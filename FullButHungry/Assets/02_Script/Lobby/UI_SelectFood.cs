using UnityEngine;
using System.Collections;

public class UI_SelectFood : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>

    public void OnClick_Back()
    {
        Hide();
    }

    public void OnClick_Hot()
    {
       // UserInfo.Click_Hot();
    }

    public void OnClick_Junk()
    {

        //UserInfo.Click_Junk();
    }

    public void OnClick_Noodle()
    {

        UserInfo.Click_Bread();
    }

    public void OnClick_Choco()
    {
        UserInfo.Click_Choco();
        LobbyManager.Instance.QA.Show(Common.opentype.choco);
    }

    public void OnClick_Candy()
    {
        UserInfo.Click_Candy();
        LobbyManager.Instance.QA.Show(Common.opentype.candy);
    }

    public void OnClick_Milk()
    {
        UserInfo.Click_MIlk();
        LobbyManager.Instance.QA.Show(Common.opentype.milk);
    }

    public void OnClick_Desert()
    {

//UserInfo.Click_Desert();
    }

}
