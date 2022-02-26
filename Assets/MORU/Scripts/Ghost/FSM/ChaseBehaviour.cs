using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    [Tooltip("�ִϸ��̼� Ÿ�� ����")]
    public Define.AnimationType animType;
    [Tooltip("�ִϸ��̼� Ŭ�� ����, Enter �� ������")]
    public string ClipName;

    public BasicGhost ghost;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ghost == null) ghost = animator.GetComponent<BasicGhost>();
        ghost.skeletonAnim.AnimationName = ClipName;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //��Ʈ�� Ÿ�����ְ� ����� ������� Ȯ���մϴ�.
        if (ghost.IsClosedToUnit())     //����� ����� ���
        {
            //����� �i�ư��ϴ�.
            var nextPos = (ghost.targetPlayer.position - animator.transform.position).normalized;
            animator.transform.Translate(nextPos * ghost.moveSpeed * Time.fixedDeltaTime);
        }
        else if(ghost.isDooring)
        {
            //����� �i�ư��ϴ�.
            var nextPos = (ghost.targetPos - animator.transform.position).normalized;
            animator.transform.Translate(nextPos * ghost.moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //���� �ִϸ��̼� Ű���� �����մϴ�.
            animator.SetBool("isTarget", false);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
