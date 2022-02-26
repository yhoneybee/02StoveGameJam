using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IngameMap : MonoBehaviour
{
    public SpriteRenderer sr;
    [SerializeField] public PolygonCollider2D polygonCollider2D;
    [SerializeField] private bool trigger;

    public Door[] doors;
    public IHideable[] Hideables;
    public BasicObstacle[] obstacles;
    public Transform[] DangerZone;

    public void Setting()
    {
        K.curMap = this;
        K.CinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
    }

    private void Awake()
    {
        //���� ã��
        var doors = transform.GetComponentsInChildren<Door>();
        this.doors = doors;

        //���� �� �ִ� �� ã��
        var hiddens = transform.GetComponentsInChildren<IHideable>();
        Hideables = hiddens;

        //��� ��ֹ� ã��
        var obstacles = transform.GetComponentsInChildren<BasicObstacle>();
        this.obstacles = obstacles;

    }

    private void Start()
    {
        Test();
    }

    private void Update()
    {
        Test();
    }

    private void Test()
    {
        if (trigger)
        {
            trigger = false;
            Setting();
        }
    }
}
