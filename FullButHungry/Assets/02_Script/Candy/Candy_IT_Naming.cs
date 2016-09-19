using UnityEngine;
using System.Collections;

public class Candy_IT_Naming : MonoBehaviour
{
    public SpriteRenderer sp_Main = null;
    public bool isSelect = false;
    public int index = -1;
    
    public void SetData(int _index)
    {
        index = _index;
        sp_Main.sprite = CandyMgr.Instance.NormalSprite[_index];
        //sp_Main.spriteName = _index + "_N";
        isSelect = false;
    }

    public void OnClick_ThisS()
    {
        isSelect = !isSelect;
        sp_Main.sprite = isSelect ? CandyMgr.Instance.PressedSprite[index] : CandyMgr.Instance.NormalSprite[index];
    }
}
