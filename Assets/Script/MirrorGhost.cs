using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorGhost : Ghost
{
    private int soundCount;

    private void FixedUpdate()
    {
        var dis = Vector3.Distance(transform.position, K.playerMove.transform.position);

        if (dis < 3 && soundCount < 10)
        {
            soundCount++;

            SoundManager.Instance.Play("유리깨지는 소리");
            SoundManager.Instance.Play("책상 웃음");
            transform.GetChild(0).gameObject.SetActive(true);
            transform.gameObject.layer = 7;
        }
    }
}
