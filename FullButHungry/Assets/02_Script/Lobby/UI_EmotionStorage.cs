using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_EmotionStorage : MonoBehaviour
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
    /// 
    public void OnClick_Back()
    {
        Hide();
    }

    public void OnClick_Hot()
    {
        LobbyManager.Instance.NotReadyUI.Show();
        //UserInfo.Click_Hot();
    }

    public void OnClick_Junk()
    {

        LobbyManager.Instance.NotReadyUI.Show();
        //UserInfo.Click_Junk();
    }

    public void OnClick_Noodle()
    {

        LobbyManager.Instance.NotReadyUI.Show();
        //UserInfo.Click_Bread();
    }

    public void OnClick_Choco()
    {
        GameManager.OpenType = Common.opentype.emotion;
        UserInfo.Click_Choco();
        SceneManager.LoadScene("02_Choco");
    }

    public void OnClick_Candy()
    {
        GameManager.OpenType = Common.opentype.emotion;
        UserInfo.Click_Candy();
        SceneManager.LoadScene("04_Candy");
    }

    public void OnClick_Milk()
    {
        GameManager.OpenType = Common.opentype.emotion;
        UserInfo.Click_MIlk();
        SceneManager.LoadScene("03_Milk");
    }

    public void OnClick_Desert()
    {
        LobbyManager.Instance.NotReadyUI.Show();
        //UserInfo.Click_Desert();
    }

}
