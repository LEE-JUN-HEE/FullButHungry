using UnityEngine;
using System.Collections;

public class UI_Base : MonoBehaviour 
{
    public UILabel lb_Level = null;
    public UIProgressBar pb_Exp = null;
    public GameObject go_CheckList = null;
    public UILabel lb_Hungry = null;
    public UILabel lb_Talk = null;
    public GameObject go_ParticleL = null;
    public GameObject go_ParticleR = null;

    public void Init()
    {
        lb_Level.text = string.Format("Lv.{0}",UserInfo.Level);
        pb_Exp.value = UserInfo.NormalizedExp;
        lb_Hungry.text = string.Format("{0:00}%", 0);
    }
}
