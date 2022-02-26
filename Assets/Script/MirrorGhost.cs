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

            SoundManager.Instance.Play("���������� �Ҹ�");
            SoundManager.Instance.Play("å�� ����");
            transform.GetChild(0).gameObject.SetActive(true);
            transform.gameObject.layer = 7;
        }
    }
}
