using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskListManager : MonoBehaviour
{
    public List<Desk> desks;
    [ContextMenu("리스트 참조")]
    public void GetDeskList()
    {
        desks = new List<Desk>();
        for(int i = 0; i < transform.childCount; i++)
        {
            desks.Add(transform.GetChild(i).GetComponent<Desk>());
        }
    }

    
}
