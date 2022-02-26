using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 처음엔 이 클래스를 기반으로 모든 귀신을 만들려 했으나 몬스터 타입이 너무 달라 이 클래스가 곧 콩콩이가 될 것 같습니다.
/// </summary>
public class BasicGhost : MonoBehaviour
{
    #region Value Variables
    public Define.State cur_State = Define.State.Idle;
    public Define.Map cur_Map;

    [Tooltip("동작가능한 상태인지 결정합니다.")]
    public bool isActived;

    [Tooltip("움직일 수 있는 귀신인지 결정합니다. boolean에 따라 FSM에 의해 움직여질 수 있습니다.")]
    [SerializeField] private bool _isMoveable;
    public bool isMoveable => _isMoveable;

    [Tooltip("이동가능할 때의 이동속도")]
    [SerializeField] private float _moveSpeed;
    public float moveSpeed => _moveSpeed;


    [Tooltip("탐지거리")]
    [SerializeField] private float _observingRange;
    public float observingRange=> _observingRange;

    [Tooltip("한 방당의 찾기 시간")]
    [SerializeField] protected float _searchTime;
    public float searchTime => _searchTime;

    #endregion Value Variables

    #region Ref Variables
    [Tooltip("쫒아가려 하는 대상")]
    public Transform targetPlayer;

    #endregion Ref Variables


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, observingRange);

    }

    public void FindObject()
    {

    }
}
