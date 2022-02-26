using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : BasicObstacle, IHideable
{
    #region Ref Variables
    [Tooltip("���� �������� ��ġ�Դϴ�.")]
    [SerializeField] Transform _HiddenPosition;
    #endregion Ref Variables

    #region Interface
    public Transform HiddenPosition { get; set; }
    public Vector3 LastPosition { get; set; }

    public void Hide(Transform target)
    {
        //������ �÷��̾��� ��ǥ�� ����(�ٽ� ���� ����� ������� ������ ����)
        LastPosition = target.transform.position;
        //���� ��ҷ� �÷��̾ �̵���Ŵ
        target.transform.position = HiddenPosition.position;

        //�÷��̾��� ������ ó���� �÷��̾�� �� �ʿ䰡 �ֽ��ϴ�.
        //����Ʈ ������ �� ������ ó���ص� �����ϴ�.
    }

    public void UnHide(Transform target)
    {
        //���������� �÷��̾ ��ġ�ߴ� ��ҷ� �÷��̾ �̵���Ŵ
        target.transform.position = LastPosition;
        
        //���������� �÷��̾��� ���� ����ó���� �÷��̾�� ��Ź�帳�ϴ�.
        //����Ʈ ����� �̰����� ó���ص� �����ϴ�.
    }
    #endregion Interface

    protected override void Awake()
    {
        base.Awake();
        HiddenPosition = _HiddenPosition;
    }

}
