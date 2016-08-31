using UnityEngine;
using System.Collections;

public class IT_Naming : MonoBehaviour
{
    public UISprite sp_Main = null;
    public bool isSelect = false;
    public bool isKing = false;
    public int index = -1;


    public void SetData(int _index)
    {
        index = _index;
        sp_Main.spriteName = _index + "_N";
        isSelect = false;
        isKing = _index == 9;
    }

    public void OnClick_ThisS()
    {
        isSelect = !isSelect;
        sp_Main.spriteName = GetComponent<UIButton>().normalSprite = (isSelect) ? index + "_P" : index + "_N";
    }
}
