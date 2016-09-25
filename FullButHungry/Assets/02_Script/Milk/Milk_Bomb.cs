using UnityEngine;
using System.Collections;

public class Milk_Bomb : MonoBehaviour
{
    public UISprite sp_Main = null;
    public TweenScale tw_scale = null;

    public void Set(int _level)
    {
        switch (_level)
        {
            case 0:
                sp_Main.width = 86;
                sp_Main.height = 125;
                sp_Main.spriteName = "Milk_bombN";
                tw_scale.duration = 0.5f;

                break;

            case 1:
                sp_Main.width = 129;
                sp_Main.height = 188;
                sp_Main.spriteName = "Milk_bombN";
                tw_scale.duration = 0.5f;
                break;

            case 2:
                sp_Main.width = 172;
                sp_Main.height = 250;
                sp_Main.spriteName = "Milk_bombN";
                tw_scale.duration = 0.5f;
                break;

            case 3:
                sp_Main.width = 671;
                sp_Main.height = 576;
                sp_Main.spriteName = "Milk_Bomb";
                tw_scale.duration = 0.2f;
                GetComponent<AudioSource>().Play();
                MilkMgr.Instance.Boom();
                break;
        }
    }
}
