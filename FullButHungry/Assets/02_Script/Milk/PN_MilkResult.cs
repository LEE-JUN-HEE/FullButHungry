using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PN_MilkResult : MonoBehaviour {
    public UIProgressBar pb_level = null;
    public UILabel lb_Level = null;
    public UILabel lb_Count = null;

    public void Show()
    {
        lb_Level.text = UserInfo.Level.ToString();
        pb_level.value = UserInfo.NormalizedExp;
        lb_Count.text = MilkMgr.Instance.EnemyCnt.ToString();
        MilkMgr.Instance.InGameUI.Input.isSelected = false;
        gameObject.SetActive(true);
    }

    public void OnClick_Home()
    {
        SceneManager.LoadScene("01_Lobby");
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("03_Milk");
    }
}
