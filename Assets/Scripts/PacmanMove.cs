using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    void Start()
    {
        dest = transform.position;
    }
    private void FixedUpdate()
    {
        //move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        //check for input if not moving
        if((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if(Input.GetKey(KeyCode.DownArrow)&& Valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
            }
            if(Input.GetKey(KeyCode.RightArrow)&& Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            if(Input.GetKey(KeyCode.LeftArrow)&& Valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
            }

            //animation parametrs
            Vector2 dir = dest - (Vector2)transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }
    bool Valid(Vector2 dir)
    {
        //cast line from next to pacman to pacman
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

}
