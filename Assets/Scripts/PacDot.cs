using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "pacman")
        {
            Destroy(gameObject);
        }
    }
}
