using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PN_CandyPause : MonoBehaviour {
    public GameObject Group1 = null;
    public GameObject Group2 = null;

    public void Show()
    {
        CandyMgr.Instance.Pause(true);
        Group1.SetActive(true);
        Group2.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_Stop1()
    {
        Group1.SetActive(false);
        Group2.SetActive(true);
    }

    public void OnClick_Continue()
    {
        Hide();
        CandyMgr.Instance.Pause(false);
    }

    public void OnClick_Cancel()
    {
        Hide();
        CandyMgr.Instance.Pause(false);
    }

    public void OnClick_Stop2()
    {
        SceneManager.LoadScene("01_Lobby");
    }
}
