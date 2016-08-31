using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public UIProgressBar pb_hp = null;
    public UISprite sp_Enemy = null;
    public UISprite sp_Bomb = null;
    public UISprite sp_thumb = null;
    public UILabel lb_KingName = null;
    public int HP = 0;
    public int index = 0;

    void Update()
    {
        if (pb_hp.value == 0)
            sp_thumb.alpha = 0;
        else
            sp_thumb.alpha = 1;

    }


    public void SetData(int _index)
    {
        index = _index;

        HP = 3;
        pb_hp.value = 1f;
        sp_Enemy.spriteName = _index + "_N";
        sp_Enemy.alpha = 1;
        if(_index >= 9)
        {
            lb_KingName.gameObject.SetActive(true);
            lb_KingName.text = ChocoMgr.Instance.kingName;
        }
        else
            lb_KingName.gameObject.SetActive(false);

        sp_Bomb.gameObject.SetActive(false);
    }

    public void SetAni(int level)
    {
        sp_Bomb.gameObject.SetActive(true);
        switch (level)
        {
            case 0:
                sp_Enemy.spriteName = index + "_N";
                sp_Bomb.spriteName = "Ani_S";
                sp_Bomb.width = 115;
                sp_Bomb.height = 84;
                break;
            case 1:
                sp_Enemy.spriteName = index + "_N";
                sp_Bomb.spriteName = "Ani_M";
                sp_Bomb.width = 149;
                sp_Bomb.height = 109;
                break;
            case 2:
                sp_Enemy.spriteName = index + "_N";
                sp_Bomb.spriteName = "Ani_L";
                sp_Bomb.width = 201;
                sp_Bomb.height = 145;
                break;
            case 3:
                sp_Enemy.spriteName = index + "_D";
                sp_Bomb.spriteName = "Ani_L";
                sp_Bomb.width = 201;
                sp_Bomb.height = 145;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.tag == "Proj")
        {
            HP--;
            pb_hp.value = (float)HP / 3f;
            Destroy(_col.gameObject);
            if (HP <= 0)
            {
                ChocoMgr.Instance.ChangeEnemy();
            }
        }
    }
}
