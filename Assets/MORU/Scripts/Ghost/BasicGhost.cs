using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ó���� �� Ŭ������ ������� ��� �ͽ��� ����� ������ ���� Ÿ���� �ʹ� �޶� �� Ŭ������ �� �����̰� �� �� �����ϴ�.
/// </summary>
public class BasicGhost : MonoBehaviour, IDoorable
{
    #region Value Variables
    public Define.State cur_State = Define.State.Idle;
    public Define.Map cur_Map;
    public IngameMap myMap => MapManager.instance.maps[(int)cur_Map];

    [Tooltip("���۰����� �������� �����մϴ�.")]
    public bool isActived;

    [Tooltip("������ �� �ִ� �ͽ����� �����մϴ�. boolean�� ���� FSM�� ���� �������� �� �ֽ��ϴ�.")]
    [SerializeField] private bool _isMoveable;
    public bool isMoveable => _isMoveable;

    [Tooltip("�̵������� ���� �̵��ӵ�")]
    [SerializeField] private float _moveSpeed;
    public float moveSpeed => _moveSpeed;


    [Tooltip("Ž�� �Ÿ�")]
    [SerializeField] private float _observingRange;
    public float observingRange=> _observingRange;


    [Tooltip("�i�� �Ÿ�")]
    [SerializeField] private float _followingRange;
    public float followingRange => _followingRange;


    [Tooltip("�� ����� ã�� �ð�")]
    [SerializeField] protected float _searchTime;
    public float searchTime => _searchTime;
    public float cur_searchTime = 0;

    [Tooltip("Ÿ���� ���� ���� �ִ��̵� �Ÿ�")]
    [SerializeField] private float _moveRange;
    public float moveRange => _moveRange;

    [Tooltip("Ÿ���� ���� ���� �����̵� �ð�")]
    [SerializeField] private float _moveTime;
    public float moveTime => _moveTime;
    public float cur_moveTime;

    [SerializeField] private float _Observingterm = 0.2f;

    public bool isDooring;

    #endregion Value Variables

    #region Ref Variables
    [Tooltip("�i�ư��� �ϴ� ���")]
    public Transform targetPlayer;
    [Tooltip("�ٰ����� �ϴ� ��ġ")]
    public Vector3 targetPos;
    public Vector3 DoorPos;
    [SerializeField] Door selectedDoor; 
    #endregion Ref Variables

    void Start()
    {
        isDooring = false;
    }

    void Update()
    {
        if (!isDooring)
        { cur_searchTime += Time.deltaTime; }
        if(cur_searchTime > searchTime && targetPlayer == null && selectedDoor == null)
        {
            var doors = myMap.GetComponentsInChildren<Door>();
            var door = doors[Random.Range(0, doors.Length)];
            selectedDoor = door;
            TargetToDoor(door);
        }
    }

    /// <summary>
    /// Ž���Ÿ��� �ð������� �����ݴϴ�.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, observingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followingRange);
    }


    /// <summary>
    /// 0.2�ʸ��� �ֺ� ������Ʈ �߿��� ����� �÷��̾� �±׸� ã�� �i�ƴٴ� ������Ʈ�� �����մϴ�.
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
    /// AI�� targetPlayer�� �i�ư��⿡ ����� ������ �Ÿ����� Ȯ���մϴ�.
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
    /// AI�� ������ ���� ������ǥ�� �޾ƿɴϴ�.
    /// </summary>
    /// <returns></returns>
    /// 
    public bool  GetRandomPos_InMap(out Vector3 targetPos)
    {
        if(isDooring)
        {
            targetPos = DoorPos;
            return true;
        }
        Vector3 _point = Vector3.zero;
            var point = transform.position +
                new Vector3(Random.Range(-moveRange*2, moveRange*2), Random.Range(-moveRange, moveRange), 0);
            _point = point;
        targetPos = _point;
        Debug.Log($"{_point}");
        if (myMap.polygonCollider2D.OverlapPoint(_point))
        {
            
            return true;
        }
        else
            return false;


    }

    /// <summary>
    /// targetPos�� ������ �ٲߴϴ�.
    /// </summary>
    public void TargetToDoor(Door door)
    {
        if(targetPlayer == null)
        {
            targetPos = door.transform.position;
            DoorPos = door.transform.position;
            isDooring = true;
            Debug.Log("������ üũ");
            return;
        }
        else
        {
            targetPlayer = null;
            targetPos = door.transform.position;
            DoorPos = door.transform.position;
            isDooring = true;
            Debug.Log("������ üũ");
        }
    }

    /// <summary>
    /// ���� �����ϸ� ����˴ϴ�.
    /// </summary>
    public void OnDoor()
    {
        selectedDoor = null;
        targetPos = transform.position;
        isDooring = false;
        cur_searchTime = 0;
    }


}
