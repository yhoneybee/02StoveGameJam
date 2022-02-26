using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class DeskGhost : MonoBehaviour
{
    [SerializeField] private List<Transform> transforms;
    [SerializeField] private Transform curTransform;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;

    private void Start()
    {
        curTransform = transforms[0];
        InvokeRepeating(nameof(Move), 3, 3);
    }

    private void Move()
    {
        transforms.Sort((x, y) =>
        {
            var disX = Vector3.Distance(x.transform.position, transform.position);
            var disY = Vector3.Distance(y.transform.position, transform.position);

            if (disX < disY) return -1;
            else if (disX > disY) return 1;
            else return 0;
        });

        float minDis = 100000;
        Transform minTrn = transform;

        for (int i = 0; i < 9; i++)
        {
            if (transforms[i] == curTransform) continue;

            var dis = Vector3.Distance(transforms[i].position, K.playerMove.transform.position);

            if (dis < minDis && dis > 4.5f)
            {
                minDis = dis;
                minTrn = transforms[i];
            }
        }

        transform.position = minTrn.position + Vector3.up * 3;
        curTransform = minTrn;

        sr.sortingOrder = curTransform.GetComponent<SortingGroup>().sortingOrder + 1;
    }

    private void FixedUpdate()
    {
        var dis = Vector3.Distance(transform.position, K.playerMove.transform.position);
        if (dis < 4.8f)
        {
            animator.Play("Smile");
            CancelInvoke();
        }
    }

    public void EndOfFrame()
    {
        StartCoroutine(EEndOfFrame());
    }

    private IEnumerator EEndOfFrame()
    {
        PostProcessing.Instance.GradingEffect2(Color.red);

        yield return new WaitForSeconds(1);

        GameObject.Find("DeskGhostFace").GetComponent<SpriteRenderer>().color = Color.white;
        
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameOver");

        yield return null;
    }
}
