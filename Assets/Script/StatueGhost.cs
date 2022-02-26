using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueGhost : Ghost
{
    [SerializeField] private List<Animator> animators;

    private bool isSound;

    private void FixedUpdate()
    {
        var dis = Vector3.Distance(transform.position, K.playerMove.transform.position);

        if (dis < 3 && !isSound)
        {
            isSound = true;

            SoundManager.Instance.Play("µ¹ ¿òÁ÷");

            transform.GetChild(0).gameObject.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                animators[i].Play($"Blood{i}");
            }

            transform.gameObject.layer = 7;
        }
    }
}
