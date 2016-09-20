using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_QAResult : MonoBehaviour
{
    public UISprite sp_LandMark = null;
    public UILabel lb_Title = null;
    public UISprite sp_Text = null;
    public UISprite sp_GO = null;
    public UIButton bt_Go = null;
    Common.opentype current = Common.opentype.choco;


    public void Show(Common.opentype type, bool isNeed)
    {
        current = type;
        switch (type)
        {
            case Common.opentype.candy:
                lb_Title.text = "사탕젤리";
                sp_LandMark.spriteName = "QAR_Candy";
                sp_LandMark.width = 331;
                sp_LandMark.height = 335;
                sp_Text.spriteName = isNeed ? "QAR_YES_Candy" : "QAR_NO_Candy";
                break;

            case Common.opentype.choco:
                lb_Title.text = "초콜렛";
                sp_LandMark.spriteName = "QAR_Choco";
                sp_LandMark.width = 331;
                sp_LandMark.height = 310;
                sp_Text.spriteName = isNeed ? "QAR_YES_Choco" : "QAR_NO_Choco";
                break;

            case Common.opentype.milk:
                lb_Title.text = "유제품";
                sp_LandMark.spriteName = "QAR_Milk";
                sp_LandMark.width = 331;
                sp_LandMark.height = 310;
                sp_Text.spriteName = isNeed ? "QAR_YES_Milk" : "QAR_NO_Milk";
                break;
        }
        sp_GO.spriteName = bt_Go.normalSprite = isNeed ? "QA_GOGO" : "QA_GO";
        bt_Go.pressedSprite = isNeed ? "QA_GOGO2" : "QA_GOP";

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Go()
    {
        switch (current)
        {
            case Common.opentype.candy:
                SceneManager.LoadScene("04_Candy");
                break;

            case Common.opentype.choco:
                SceneManager.LoadScene("02_Choco");
                break;

            case Common.opentype.milk:
                SceneManager.LoadScene("03_Milk");
                break;
        }
    }

    public void OnClick_No()
    {
        Hide();
    }
}
