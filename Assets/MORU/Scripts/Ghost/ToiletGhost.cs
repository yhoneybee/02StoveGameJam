using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletGhost : Ghost
{
    public bool isCallable = true;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;

    [SerializeField] private Player pl;

    public void EndOfFrame()
    {
        sr.transform.gameObject.layer = 0;
        animator.Play("Non");
        isCallable = true;
    }

    public void PlayVoice()
    {
        SoundManager.Instance.Play("≥Î≈©");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("Open");
            sr.transform.gameObject.layer = 7;
            isCallable = false;
        }
    }

}
