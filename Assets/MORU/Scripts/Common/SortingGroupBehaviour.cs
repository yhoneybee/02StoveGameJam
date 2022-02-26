using UnityEngine;
using UnityEngine.Rendering;


[RequireComponent(typeof(SortingGroup))]
public class SortingGroupBehaviour : MonoBehaviour
{
    #region Ref Variables

    SortingGroup _sortingGroup;
    /// <summary>
    /// ���� ���̾ �����մϴ�.
    /// </summary>
    public SortingGroup sortingGroup
    {
        get
        {
            if (_sortingGroup == null)
            { _sortingGroup = GetComponent<SortingGroup>(); }
            return _sortingGroup;
        }
    }

    #endregion Ref Variables

    #region Variables

    [Tooltip("�����η��̾� ���� y�࿡ ���� ��ȭ��ŵ�ϴ�.")]
    public bool isOrderControl_Y = true;

    #endregion Variables


    #region Unity Callback Methods
    void Start()
    {
        Init_SortingLayer();
    }

    void Update()
    {
        Update_Order_In_Layer();
    }

    #endregion Unity Callback Methods


    #region Help Methods
    /// <summary>
    /// ���ñ׷��� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Init_SortingLayer()
    {
        //������Ʈ�� �������� �����մϴ�.
        var RendererComponent = GetComponent<Renderer>();

        //�������� ���� ��� �ش罺ũ��Ʈ�� ������ �����մϴ�.
        if (RendererComponent == null)
        {
            isOrderControl_Y = false;
        }

        //�������� ���̾ �ٸ� ��� �������� �������� ���̾�� ��ȯ�մϴ�.
        else if (sortingGroup.sortingLayerID != RendererComponent.sortingLayerID)
        {
            sortingGroup.sortingLayerID = RendererComponent.sortingLayerID;
        }
    }


    /// <summary>
    /// ������ ���̾�� �����մϴ�.
    /// </summary>
    private void Update_Order_In_Layer()
    {
        //bool�� ���� �� SortingOrder�� y���� ���� �ٲߴϴ�.
        if (isOrderControl_Y)
        {
            sortingGroup.sortingOrder = (int)(transform.position.y * -1000);
        }
    }
    #endregion Help Methods
}
