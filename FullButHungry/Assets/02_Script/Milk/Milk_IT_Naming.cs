using UnityEngine;
using System.Collections;

public class Milk_IT_Naming : MonoBehaviour
{
    //public UISprite sp_Main = null;
    public SpriteRenderer sp_Main = null;
    public bool isSelect = false;
    public int index = -1;


    public void SetData(int _index)
    {
        index = _index;
        sp_Main.sprite = MilkMgr.Instance.NormalSprite[_index];
        //sp_Main.spriteName = _index + "_N";
        isSelect = false;
    }

    public void OnClick_ThisS()
    {
        isSelect = !isSelect;
        sp_Main.sprite = isSelect ? MilkMgr.Instance.PressedSprite[index] : MilkMgr.Instance.NormalSprite[index];
        //sp_Main.spriteName = GetComponent<UIButton>().normalSprite = (isSelect) ? index + "_P" : index + "_N";
    }
}
