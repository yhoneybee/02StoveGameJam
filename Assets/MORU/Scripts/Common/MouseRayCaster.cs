using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCaster
{
    /// <summary>
    /// 마우스방향으로부터 레이캐스팅된 RaycastHit 오브젝트가 존재하는지 여부를 판단, 반환합니다.
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    public static bool RayResult_Mouse(out RaycastHit hit)
    {
        var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        if (Physics.Raycast(currentMousePos, out hit, Mathf.Infinity))
        {
            return true;
        }
        else return false;
    }

    /// <summary>
    /// 마우스방향으로부터 레이캐스팅된 Collider 오브젝트가 존재하는지 여부를 판단, 반환합니다.
    /// </summary>
    /// <param name="collider"></param>
    /// <returns></returns>
    public static bool RayResult_Mouse(out Collider collider)
    {
        var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(currentMousePos, out hit, Mathf.Infinity))
        {
            collider = hit.collider;
            return true;
        }
        else
        {
            collider = null;
            return false;
        }
    }

    /// <summary>
    /// 마우스방향으로부터 레이캐스팅된 오브젝트들을 반환합니다.
    /// </summary>
    /// <returns></returns>
    public static RaycastHit[] RayResult_Mouse()
    {
        var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        var hits = Physics.RaycastAll(currentMousePos, Mathf.Infinity);
        return hits;
    }

    /// <summary>
    /// from으로부터 마우스좌표까지의 0 ~ 최대 Distance사이의 값을 반환합니다.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="Distance"></param>
    /// <returns></returns>
    public static Vector3 GetVector_From_To_Distance(Transform from, float maxDistance = float.PositiveInfinity)
    {
        var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(currentMousePos, out hit, Mathf.Infinity, 1 << 8))
        {
        }
        var currentDistance = Vector3.Distance(from.position, hit.point);
        Vector3 result_Vector = hit.point;
        if (currentDistance > maxDistance)
        {
            result_Vector = Vector3.Lerp(from.position, hit.point, maxDistance / currentDistance);
        }
        return result_Vector;
    }

    /// <summary>
    /// from으로부터 target간의 quaternion값을 반환합니다. target이 null일 경우 마우스위치로 대체됩니다.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Quaternion GetQuaternion_From_To_Target(Transform from, bool isY_On = true, Transform target = null)
    {
        var fromVec = new Vector3(from.position.x,
            isY_On ? from.position.y : 0,
            from.position.z);
        if (target != null)
        {
            var targetVector = new Vector3(target.position.x,
                isY_On ? target.position.y : 0,
                target.position.z);
            var result = targetVector - fromVec;
            var value = Quaternion.LookRotation(result);
            return value;
        }
        else
        {
            var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(currentMousePos, out hit, Mathf.Infinity, 1 << 8))
            {
            }
            var targetVector = new Vector3(hit.point.x,
                  isY_On ? hit.point.y : 0,
                hit.point.z);
            var result = targetVector - fromVec;
            var value = Quaternion.LookRotation(result);
            return value;
        }
    }

    public static Quaternion GetQuaternion_From_To_Target(Vector3 from, Vector3 target, bool isY_On = true)
    {
        var fromVec = new Vector3(from.x,
            isY_On ? from.y : 0,
            from.z);
        if (target != Vector3.zero)
        {
            var targetVector = new Vector3(target.x,
                isY_On ? target.y : 0,
                target.z);
            var result = targetVector - fromVec;
            var value = Quaternion.LookRotation(result);
            return value;
        }
        else
        {
            var currentMousePos = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(currentMousePos, out hit, Mathf.Infinity, 1 << 8))
            {
            }
            var targetVector = new Vector3(hit.point.x,
                  isY_On ? hit.point.y : 0,
                hit.point.z);
            var result = targetVector - fromVec;
            var value = Quaternion.LookRotation(result);
            return value;
        }
    }
}
