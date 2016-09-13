using UnityEngine;
using System.Collections;

public class CandyMgr : MonoBehaviour
{
    Ray2D ray;
    Vector2 tempvec;
    void Update()
    {
        update_ray();
    }

    void update_ray()
    {
        //RayCast
        if (Input.GetMouseButtonDown(0))
        {
            tempvec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray = new Ray2D(tempvec, Vector2.zero);
            RaycastHit2D HitObj = Physics2D.Raycast(ray.origin, ray.direction);

            if (HitObj.collider != null && HitObj.transform.GetComponent<Candy_IT_Ingame>() != null)
            {
                HitObj.transform.GetComponent<Candy_IT_Ingame>().OnClick_Hit();
            }
        }
    }
}
