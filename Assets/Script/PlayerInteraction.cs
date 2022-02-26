using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        var basicObstacle = collision.GetComponent<BasicObstacle>();

        if (!basicObstacle) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            var hintableObject = basicObstacle.GetComponent<HintableObject>();

            if (!hintableObject) return;

            if (hintableObject.hintInfo != null)
            {
                K.diagram.Chatting(Color.black, "......", "...?!", hintableObject.hintInfo.getHintCommnet);
                K.hintUI.GetHint(hintableObject.hintInfo);
                hintableObject.hintInfo = null;
            }
            else
            {
                int rand = Random.Range(1, 11);
                string comment = rand switch
                {
                    int i when i == 1 => "아무것도 없는데?",
                    int i when i == 2 => "여기서 뭐해?",
                    int i when i == 3 => "으... 더러워",
                    int i when i == 4 => "쓰레기잖아...",
                    int i when i == 5 => "여기서 시간낭비를 하는거야..?",
                    int i when i == 6 => "소리가 너무커...",
                    int i when i == 7 => "으... 먼지",
                    _ => "아무것도 없어...",
                };
                K.diagram.Chatting(Color.black, ".....", "...", comment);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            K.hintUI.OpenUI();
            K.hintUI.CloseUI();
        }
    }
}
