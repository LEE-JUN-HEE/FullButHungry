using UnityEngine;
using System.Collections;

public class IT_Naming : MonoBehaviour {

    public UISprite sp_Main = null;
    public UISprite sp_Select = null;
    public bool isSelect = false;
    public bool isKing = false;
    

    public void SetData(int _index)
    {
        sp_Main.spriteName = sp_Select.spriteName = _index + "_N";
        isSelect = false;
        isKing = _index == 9;
        sp_Select.gameObject.SetActive(isSelect);
    }

    public void OnClick_ThisS()
    {
        isSelect = !isSelect;
        sp_Select.gameObject.SetActive(isSelect);
    }
}
