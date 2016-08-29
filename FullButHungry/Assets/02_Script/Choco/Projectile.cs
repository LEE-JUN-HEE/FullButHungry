using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.1f * Time.deltaTime, 0);
    }
}
