using UnityEngine;
using System.Collections;

public class Milk_Bomb : MonoBehaviour
{
    public UISprite sp_Main = null;

    public void Set(int _level)
    {
        switch (_level)
        {
            case 0:
                sp_Main.width = 86;
                sp_Main.height = 125;
                sp_Main.spriteName = "Milk_bombN";

                break;

            case 1:
                sp_Main.width = 129;
                sp_Main.height = 188;
                sp_Main.spriteName = "Milk_bombN";
                break;

            case 2:
                sp_Main.width = 172;
                sp_Main.height = 250;
                sp_Main.spriteName = "Milk_bombN";
                break;

            case 3:
                sp_Main.width = 671;
                sp_Main.height = 576;
                sp_Main.spriteName = "Milk_Bomb";
                break;
        }
    }
}
