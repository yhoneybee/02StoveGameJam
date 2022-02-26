using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ó���� �� Ŭ������ ������� ��� �ͽ��� ����� ������ ���� Ÿ���� �ʹ� �޶� �� Ŭ������ �� �����̰� �� �� �����ϴ�.
/// </summary>
public class BasicGhost : MonoBehaviour
{
    #region Value Variables
    public Define.State cur_State = Define.State.Idle;
    public Define.Map cur_Map;

    [Tooltip("���۰����� �������� �����մϴ�.")]
    public bool isActived;

    [Tooltip("������ �� �ִ� �ͽ����� �����մϴ�. boolean�� ���� FSM�� ���� �������� �� �ֽ��ϴ�.")]
    [SerializeField] private bool _isMoveable;
    public bool isMoveable => _isMoveable;

    [Tooltip("�̵������� ���� �̵��ӵ�")]
    [SerializeField] private float _moveSpeed;
    public float moveSpeed => _moveSpeed;


    [Tooltip("Ž���Ÿ�")]
    [SerializeField] private float _observingRange;
    public float observingRange=> _observingRange;

    [Tooltip("�� ����� ã�� �ð�")]
    [SerializeField] protected float _searchTime;
    public float searchTime => _searchTime;

    #endregion Value Variables

    #region Ref Variables
    [Tooltip("�i�ư��� �ϴ� ���")]
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
