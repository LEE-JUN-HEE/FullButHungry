using UnityEngine;
using System.Collections;

public class IT_Mission : MonoBehaviour 
{
    public bool isComplete = false;

    public UIButton sp_button = null;
    public UILabel lb_Mission = null;
    int index = 0;

    public void SetData(int _index)
    {
        index = _index;
        lb_Mission.text = UserInfo.mission[UserInfo.Mission[index]];
        sp_button.normalSprite = UserInfo.MissionB[index] ? "Mission_CheckP" : "Mission_Check";
        isComplete = UserInfo.MissionB[index];
    }

    public void OnClick_Complete()
    {
        isComplete = true;
        UserInfo.MissionB[index] = true;
        if (index == 0)
            PlayerPrefs.SetString("Mission1B", true.ToString());
        else if (index == 1)
            PlayerPrefs.SetString("Mission2B", true.ToString());
        else if(index == 2)
            PlayerPrefs.SetString("Mission3B", true.ToString());
        PlayerPrefs.Save();
        sp_button.normalSprite = "Mission_CheckP";
        LobbyManager.Instance.MissionUI.Refresh();
    }
}
