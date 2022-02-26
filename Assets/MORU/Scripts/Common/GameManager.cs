using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleToneMono<GameManager>
{
    ///게임매니저에서 최초 인게임 진입 시 랜덤적으로 선택될 요소들을 결정한다
    ///어떤 랜덤요소들이 있을지는 모르겠음
    #region Variables
    public float KongSpawnTime;
    private float cur_KongTime;
    #endregion Variables

    #region Ref Variables
    bool isSpawned_KongKong;
    public MapManager _MapManager;
    public GameObject KongKong;

    public Transform[] SpawnPos;

    #endregion Ref Variables
    /// <summary>
    /// 추후 스코어 관리를 위한 변수와 델리게이트 목록입니다.
    /// </summary>
    #region Score/Delegate_Variables

    private int onDoorCount = 0;
    public int OnDoorCount => onDoorCount;

    public delegate void DoorCountUp();
    public DoorCountUp Del_DoorCountUp;


    private int onHiddenCout = 0;
    public int OnHiddenCout => onHiddenCout;

    public delegate void HiddenCountUp();
    public HiddenCountUp Del_HiddenCountUp;


    #endregion Score/Delegate_Variables

    protected override void Awake()
    {
        base.Awake();
        Init_Delegate();
        _MapManager = MapManager.instance;
        SpawnPos = _MapManager.maps[(int)Define.Map.Toilet].DangerZone;
        isSpawned_KongKong = false;
    }

    private void Update()
    {
        //if (KongSpawnTime <= cur_KongTime && !isSpawned_KongKong)
        //{
        //    int value = Random.Range(0, SpawnPos.Length);
        //    GameObject kong = Instantiate(KongKong, SpawnPos[value].position, Quaternion.identity);
        //    kong.GetComponent<BasicGhost>().cur_Map = Define.Map.Toilet;
        //    isSpawned_KongKong = true;
        //}
        //else
        //{
        //    cur_KongTime += Time.deltaTime;
        //}
    }

    #region Helper Methods

    /// <summary>
    /// 델리게이트 생성
    /// </summary>
    void Init_Delegate()
    {
        Del_DoorCountUp = () => onDoorCount++;
        Del_HiddenCountUp = () => onHiddenCout++;
    }
    #endregion Helper Methods
}
