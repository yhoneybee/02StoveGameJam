using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletGhost : Ghost
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;

    [SerializeField] private Player pl;

    public void EndOfFrame()
    {
        sr.transform.gameObject.layer = 0;
        animator.Play("Non");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("Open");
            sr.transform.gameObject.layer = 7;
        }
    }

}
