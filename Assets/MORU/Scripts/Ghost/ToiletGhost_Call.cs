using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletGhost_Call : MonoBehaviour
{
    public Transform to_Ghost;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (to_Ghost == null)
            {
                to_Ghost = FindObjectOfType<ToiletGhost>().gameObject.transform.parent;
            }
            to_Ghost.transform.position = this.transform.position;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (to_Ghost == null)
            {
                if (FindObjectOfType<ToiletGhost>() != null)
                {
                    to_Ghost = FindObjectOfType<ToiletGhost>().gameObject.transform.parent;
                }
            }
            if (to_Ghost != null)
            { to_Ghost.transform.position = this.transform.position; }
        }

    }

}
