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
        //UserInfo.Click_Hot();
    }

    public void OnClick_Junk()
    {

        //UserInfo.Click_Junk();
    }

    public void OnClick_Noodle()
    {

        //UserInfo.Click_Bread();
    }

    public void OnClick_Choco()
    {
        UserInfo.Click_Choco();
        SceneManager.LoadScene("02_Choco");
    }

    public void OnClick_Candy()
    {
        UserInfo.Click_Candy();
        SceneManager.LoadScene("04_Candy");
    }

    public void OnClick_Milk()
    {
        UserInfo.Click_MIlk();
        SceneManager.LoadScene("03_Milk");
    }

    public void OnClick_Desert()
    {
        //UserInfo.Click_Desert();
    }

}
