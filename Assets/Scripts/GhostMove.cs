using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    public bool isDead = false;
    private void FixedUpdate()
    {
        if(isDead != true)
        {
        if((Vector2)transform.position != (Vector2)waypoints[cur].position)
        {
            //move to the waypoint
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
        {
            //reached to the waypoint , update the current waypoint
            //means if current position index eguals to length of array , set to current position index to 0
            cur = (cur + 1) % waypoints.Length;
        }


        //animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
        else
        {

        }
    }


    //if pacman hits the ghost pacman will be destroyed
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "pacman")
        {
            isDead = true;
            Destroy(collider.gameObject);
        }
    }
}
