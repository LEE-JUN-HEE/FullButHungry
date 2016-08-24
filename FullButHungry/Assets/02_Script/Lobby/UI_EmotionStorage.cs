using UnityEngine;
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
    }

    public void OnClick_Junk()
    {

    }

    public void OnClick_Noodle()
    {

    }

    public void OnClick_Choco()
    {

    }

    public void OnClick_Candy()
    {

    }

    public void OnClick_Milk()
    {

    }

    public void OnClick_Desert()
    {

    }

}
