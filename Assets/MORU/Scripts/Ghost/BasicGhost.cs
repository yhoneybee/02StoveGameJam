using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;

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
    public float observingRange => _observingRange;


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

    [Tooltip("타겟이 없을 때의 랜덤이동 시간")]
    [SerializeField] private float _moveTime;
    public float moveTime => _moveTime;
    public float cur_moveTime;

    [SerializeField] private float _Observingterm = 0.2f;

    public bool isDooring;
    public bool isActive;

    #endregion Value Variables

    #region Ref Variables
    [Tooltip("쫒아가려 하는 대상")]
    public Transform targetPlayer;
    [Tooltip("다가가려 하는 위치")]
    public Vector3 targetPos;
    public Vector3 DoorPos;
    [SerializeField] Door selectedDoor;

    public Vector3 prePos;

    public SkeletonAnimation skeletonAnim;


    public float bug_Refresh;
    public float cur_Bug_Refresh;

    #endregion Ref Variables

    void Start()
    {
        isDooring = false;
        isActive = true;
    }

    void Update()
    {
        if (!isDooring)
        { cur_searchTime += Time.deltaTime; }
        if (cur_searchTime > searchTime && targetPlayer == null && selectedDoor == null)
        {
            var doors = myMap.GetComponentsInChildren<Door>();
            var door = doors[Random.Range(0, doors.Length)];
            selectedDoor = door;
            TargetToDoor(door);
        }
        if (cur_Bug_Refresh < bug_Refresh && targetPlayer != null)
        {
            cur_Bug_Refresh += Time.deltaTime;
        }
        else
        {
            cur_Bug_Refresh = 0;
            targetPlayer = null;
        }
    }

    /// <summary>
    /// 탐지거리를 시각적으로 보여줍니다.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, observingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followingRange);
    }


    /// <summary>
    /// 0.2초마다 주변 오브젝트 중에서 가까운 플레이어 태그를 찾아 쫒아다닐 오브젝트로 설정합니다.
    /// </summary>
    public void FindObject()
    {
        if (targetPlayer == null)
        {
            if (_Observingterm >= 0.2f)
            {
                _Observingterm = 0;
                var results = Physics2D.OverlapCircleAll(transform.position, _observingRange);
                foreach (var result in results)
                {
                    if (result.CompareTag("Player"))
                    {
                        if (result.GetComponent<Player>().cur_State != Define.State.Hide)
                        { targetPlayer = result.transform; }
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

        if (Vector2.Distance(transform.position, targetPlayer.position) >= followingRange)
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
    /// 
    public bool GetRandomPos_InMap(out Vector3 targetPos)
    {
        if (isDooring)
        {
            targetPos = DoorPos;
            return true;
        }

        Vector3 _point = Vector3.zero;
        var point = transform.position +
            new Vector3(Random.Range(-moveRange * 2, moveRange * 2), Random.Range(-moveRange, moveRange), 0);
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
    /// targetPos를 문으로 바꿉니다.
    /// </summary>
    public void TargetToDoor(Door door)
    {
        if (targetPlayer == null)
        {
            targetPos = door.transform.position;
            DoorPos = door.transform.position;
            isDooring = true;
            return;
        }
        else
        {
            targetPlayer = null;
            targetPos = door.transform.position;
            DoorPos = door.transform.position;
            isDooring = true;
        }
    }

    /// <summary>
    /// 문에 입장하면 실행됩니다.
    /// </summary>
    public void OnDoor()
    {
        selectedDoor = null;
        targetPos = transform.position;
        isDooring = false;
        cur_searchTime = 0;
    }

    private void BugCheck()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            K.moveable = false;
            isActive = false;
            _isMoveable = false;
            var canvas = GameObject.Find("DeadCanvas");
            if (canvas != null)
            {
                canvas.transform.GetChild(0).gameObject.SetActive(true);
                StartCoroutine(Co_End());
            }
        }
    }

    private IEnumerator Co_End()
    {
        ///최대 6.5초
        yield return new WaitForSeconds(6.5f);

        SceneManager.LoadScene("GameOver");

        yield return null;
    }

    public void SetDirection(Vector3 pre, Vector3 current)
    {
        if(pre.x > current.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
