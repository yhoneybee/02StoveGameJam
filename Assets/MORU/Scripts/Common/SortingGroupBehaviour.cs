using UnityEngine;
using UnityEngine.Rendering;


[RequireComponent(typeof(SortingGroup))]
public class SortingGroupBehaviour : MonoBehaviour
{
    #region Ref Variables

    SortingGroup _sortingGroup;
    /// <summary>
    /// 소팅 레이어를 참조합니다.
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

    [Tooltip("오더인레이어 값을 y축에 따라 변화시킵니다.")]
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
    /// 소팅그룹을 초기화합니다.
    /// </summary>
    private void Init_SortingLayer()
    {
        //오브젝트의 렌더러를 참조합니다.
        var RendererComponent = GetComponent<Renderer>();

        //렌더러가 없을 경우 해당스크립트의 동작을 중지합니다.
        if (RendererComponent == null)
        {
            isOrderControl_Y = false;
        }

        //렌더러의 레이어가 다를 경우 오리지널 렌더러의 레이어로 변환합니다.
        else if (sortingGroup.sortingLayerID != RendererComponent.sortingLayerID)
        {
            sortingGroup.sortingLayerID = RendererComponent.sortingLayerID;
        }
    }


    /// <summary>
    /// 오더인 레이어값을 변경합니다.
    /// </summary>
    private void Update_Order_In_Layer()
    {
        //bool을 만족 시 SortingOrder를 y값을 따라 바꿉니다.
        if (isOrderControl_Y)
        {
            sortingGroup.sortingOrder = (int)(transform.position.y * -1000);
        }
    }
    #endregion Help Methods
}
