using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [Tooltip("애니메이션 타입 결정")]
    public Define.AnimationType animType;
    [Tooltip("애니메이션 클립 네임, Enter 시 결정됨")]
    public string ClipName;

    public BasicGhost ghost;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ghost == null) ghost = animator.GetComponent<BasicGhost>();
        ghost.skeletonAnim.AnimationName = ClipName;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //분기는 타겟이 존재하냐 유무에 변합니다.
        if(ghost.targetPlayer != null)
        {
            animator.SetBool("isTarget", true);
            animator.SetBool("isMove", true);
        }
        else
        {
            ghost.FindObject(); //플레이어 오브젝트를 주변에서 탐색합니다.

            if(ghost.cur_moveTime < ghost.moveTime && !ghost.isDooring)
            {
                ghost.cur_moveTime += Time.deltaTime;
            }
            else
            {
                if(ghost.GetRandomPos_InMap(out Vector3 targetPos))
                {
                    ghost.targetPos = targetPos;
                    ghost.cur_moveTime = 0;
                    animator.SetBool("isMove", true);
                }
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }



    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
