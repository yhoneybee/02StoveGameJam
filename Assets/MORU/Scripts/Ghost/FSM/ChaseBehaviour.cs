using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    [Tooltip("애니메이션 타입 결정")]
    public Define.AnimationType animType;
    [Tooltip("애니메이션 클립 네임, Enter 시 결정됨")]
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
        //고스트의 타겟유닛과 충분히 가까운지 확인합니다.
        if (ghost.IsClosedToUnit())     //충분히 가까울 경우
        {
            //대상을 쫒아갑니다.
            var nextPos = (ghost.targetPlayer.position - animator.transform.position).normalized;
            animator.transform.Translate(nextPos * ghost.moveSpeed * Time.fixedDeltaTime);
        }
        else if(ghost.isDooring)
        {
            //대상을 쫒아갑니다.
            var nextPos = (ghost.targetPos - animator.transform.position).normalized;
            animator.transform.Translate(nextPos * ghost.moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //추적 애니메이션 키값을 해제합니다.
            animator.SetBool("isTarget", false);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
