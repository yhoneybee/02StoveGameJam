using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private void FixedUpdate()
    {
        if (!K.moveable) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(h, v) * moveSpeed * Time.fixedDeltaTime);

        var halfMapScale = K.curMap.transform.localScale / 2 - transform.localScale / 2;

        var clampX = Mathf.Clamp(transform.position.x, -halfMapScale.x, halfMapScale.x);
        var clampY = Mathf.Clamp(transform.position.y, -halfMapScale.y, halfMapScale.y);

        var viewport = Camera.main.WorldToViewportPoint(transform.localPosition);

        if (K.PostProcessVolume.profile.TryGetSettings<Vignette>(out var vignette))
        {
            vignette.center.Override(viewport);
        }

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
