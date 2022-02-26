using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<HintInfo> hints;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var basicObstacle = collision.GetComponent<BasicObstacle>();

        if (!basicObstacle) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //��Ʈ �ִ� ������Ʈ�� ���� ��ȣ�ۿ� ��
            var hintableObject = basicObstacle.GetComponent<HintableObject>();
            var hiddenable_Object = basicObstacle.GetComponent<IHideable>();
            if (hintableObject)
            {

                if (!hintableObject.taken)
                {
                    int rand = Random.Range(0,hints.Count);
                    var hintInfo = hints[rand];
                    hints.RemoveAt(rand);
                    K.diagram.Chatting(Color.black, "......", "...?!", hintInfo.getHintCommnet);
                    K.hintUI.GetHint(hintInfo);
                    hintableObject.taken = true;
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
            //���� �� �ִ� ������Ʈ�� ���� ��ȣ�ۿ� ��
            else if (hiddenable_Object != null)
            {
                if (Player.instance.cur_State != Define.State.Hide)
                {
                    hiddenable_Object.Hide(this.transform);
                    Player.instance.cur_State = Define.State.Hide;
                    Player.instance.PM.skeletonAnimation.gameObject.SetActive(false);
                    Player.instance.GetComponent<Collider2D>().isTrigger = true;
                    K.moveable = false;
                    K.camable = false;
                    PostProcessing.Instance.GradingEffect2(Color.black);
                }
                else if (Player.instance.cur_State == Define.State.Hide)
                {
                    hiddenable_Object.UnHide(this.transform);
                    Player.instance.cur_State = Define.State.Idle;
                    Player.instance.PM.skeletonAnimation.gameObject.SetActive(true);
                    Player.instance.GetComponent<Collider2D>().isTrigger = false;
                    K.moveable = true;
                    K.camable = true;
                    PostProcessing.Instance.GradingEffect2(Color.white);
                }
            }

            else { return; }
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
