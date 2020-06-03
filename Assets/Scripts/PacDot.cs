using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour
{
    
    public static int takenPacDots;
    private void Start()
    {
        takenPacDots = 0;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "pacman")
        {
            takenPacDots++;
            Destroy(gameObject);
        }
    }
    
}
