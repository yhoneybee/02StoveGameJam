using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintUI : MonoBehaviour
{
    public RectTransform rtrnMask;
    public RectTransform rtrnLayoutGroup;
    public TextMeshProUGUI txtOrigin;

    public Vector2 openScale;
    public bool openX;

    private bool isOpen;

    private void Start()
    {
        K.hintUI = this;
    }

    public void GetHint(HintInfo hintInfo)
    {
        K.hintInfos.Add(hintInfo);
        var obj = Instantiate(txtOrigin, rtrnLayoutGroup);
        obj.text = $"{hintInfo.hintCommnet}";
    }

    public void OpenUI()
    {
        if (isOpen) return;
        StopAllCoroutines();
        StartCoroutine(EOpenUI());
    }

    private IEnumerator EOpenUI()
    {
        var wait = new WaitForSeconds(0.01f);

        if (openX)
        {
            while (Mathf.Abs(rtrnMask.sizeDelta.x - openScale.x) > 100)
            {
                rtrnMask.sizeDelta = new Vector2(Mathf.Lerp(rtrnMask.sizeDelta.x, openScale.x, Time.deltaTime * 5), rtrnMask.sizeDelta.y);
                yield return wait;
            }
            rtrnMask.sizeDelta = new Vector2(openScale.x, rtrnMask.sizeDelta.y);
        }
        else
        {
            while (Mathf.Abs(rtrnMask.sizeDelta.y - openScale.y) > 100)
            {
                rtrnMask.sizeDelta = new Vector2(rtrnMask.sizeDelta.x, Mathf.Lerp(rtrnMask.sizeDelta.y, openScale.y, Time.deltaTime * 5));
                yield return wait;
            }
            rtrnMask.sizeDelta = new Vector2(rtrnMask.sizeDelta.x, openScale.y);
        }

        isOpen = true;

        yield return null;
    }

    public void CloseUI()
    {
        if (!isOpen) return;
        StopAllCoroutines();
        StartCoroutine(ECloseUI());
    }

    private IEnumerator ECloseUI()
    {
        var wait = new WaitForSeconds(0.01f);

        if (openX)
        {
            while (Mathf.Abs(rtrnMask.sizeDelta.x - 0) > 100)
            {
                rtrnMask.sizeDelta = new Vector2(Mathf.Lerp(rtrnMask.sizeDelta.x, 0, Time.deltaTime * 5), rtrnMask.sizeDelta.y);
                yield return wait;
            }
            rtrnMask.sizeDelta = new Vector2(0, rtrnMask.sizeDelta.y);
        }
        else
        {
            while (Mathf.Abs(rtrnMask.sizeDelta.y - 0) > 100)
            {
                rtrnMask.sizeDelta = new Vector2(rtrnMask.sizeDelta.x, Mathf.Lerp(rtrnMask.sizeDelta.y, 0, Time.deltaTime * 5));
                yield return wait;
            }
            rtrnMask.sizeDelta = new Vector2(rtrnMask.sizeDelta.x, 0);
        }
        
        isOpen = false;

        yield return null;
    }
}
