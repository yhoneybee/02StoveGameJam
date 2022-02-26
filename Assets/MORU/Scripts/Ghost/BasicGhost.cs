using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 처음엔 이 클래스를 기반으로 모든 귀신을 만들려 했으나 몬스터 타입이 너무 달라 이 클래스가 곧 콩콩이가 될 것 같습니다.
/// </summary>
public class BasicGhost : MonoBehaviour, IDoorable
{
    #region Value Variables
    public Define.State cur_State = Define.State.Idle;
    public Define.Map cur_Map;
    public IngameMap myMap => MapManager.instance.maps[(int)cur_Map];

    [Tooltip("동작가능한 상태인지 결정합니다.")]
    public bool isActived;

    [Tooltip("움직일 수 있는 귀신인지 결정합니다. boolean에 따라 FSM에 의해 움직여질 수 있습니다.")]
    [SerializeField] private bool _isMoveable;
    public bool isMoveable => _isMoveable;

    [Tooltip("이동가능할 때의 이동속도")]
    [SerializeField] private float _moveSpeed;
    public float moveSpeed => _moveSpeed;


    [Tooltip("탐지 거리")]
    [SerializeField] private float _observingRange;
    public float observingRange=> _observingRange;


    [Tooltip("쫒기 거리")]
    [SerializeField] private float _followingRange;
    public float followingRange => _followingRange;


    [Tooltip("한 방당의 찾기 시간")]
    [SerializeField] protected float _searchTime;
    public float searchTime => _searchTime;
    public float cur_searchTime = 0;

    [Tooltip("타겟이 없을 때의 최대이동 거리")]
    [SerializeField] private float _moveRange;
    public float moveRange => _moveRange;

    [SerializeField] private float _Observingterm = 0.2f;

    #endregion Value Variables

    #region Ref Variables
    [Tooltip("쫒아가려 하는 대상")]
    public Transform targetPlayer;
    [Tooltip("다가가려 하는 위치")]
    public Vector3 targetPos;

    #endregion Ref Variables

    /// <summary>
    /// 탐지거리를 시각적으로 보여줍니다.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, observingRange);

    }


    /// <summary>
    /// 0.2초마다 주변 오브젝트 중에서 가까운 플레이어 태그를 찾아 쫒아다닐 오브젝트로 설정합니다.
    /// </summary>
    public void FindObject()
    {
        if(targetPlayer == null)
        {
            if(_Observingterm >= 0.2f)
            {
                _Observingterm = 0;
                var results = Physics2D.OverlapCircleAll(transform.position, _observingRange);
                foreach(var result in results)
                {
                    if(result.CompareTag("Player"))
                    {
                        targetPlayer = result.transform;
                    }
                }
            }
            else
            {
                _Observingterm += Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// AI의 targetPlayer와 쫒아가기에 충분히 근접한 거리인지 확인합니다.
    /// </summary>
    /// <returns></returns>
    public bool IsClosedToUnit()
    {
        if (targetPlayer == null) return false;
        
        if(Vector2.Distance(transform.position, targetPlayer.position) >= followingRange)
        {
            targetPlayer = null;
            return false;
        }
        else
        {

            return true;
        }
    }


    /// <summary>
    /// AI가 움직일 때의 랜덤좌표를 받아옵니다.
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomPos_InMap()
    {
        Vector3 _point = Vector3.zero;
        do
        {
            var point = transform.position +
                new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), 0);
            _point = point;
        }
        while (!myMap.polygonCollider2D.OverlapPoint(_point));

        return _point;
    }

    


}
