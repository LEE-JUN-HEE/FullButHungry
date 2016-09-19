using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PN_CandyResult : MonoBehaviour {
    public UIProgressBar pb_level = null;
    public UILabel lb_Level = null;
    public UILabel lb_Count = null;

    public void Show()
    {
        lb_Level.text = UserInfo.Level.ToString();
        pb_level.value = UserInfo.NormalizedExp;
        lb_Count.text = (CandyMgr.Instance.EnemyCnt * 4).ToString();
        gameObject.SetActive(true);
    }

    public void OnClick_Home()
    {
        SceneManager.LoadScene("01_Lobby");
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("04_Candy");
    }
}
