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
                    int i when i == 1 => "�ƹ��͵� ���µ�?",
                    int i when i == 2 => "���⼭ ����?",
                    int i when i == 3 => "��... ������",
                    int i when i == 4 => "�������ݾ�...",
                    int i when i == 5 => "���⼭ �ð����� �ϴ°ž�..?",
                    int i when i == 6 => "�Ҹ��� �ʹ�Ŀ...",
                    int i when i == 7 => "��... ����",
                    _ => "�ƹ��͵� ����...",
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
