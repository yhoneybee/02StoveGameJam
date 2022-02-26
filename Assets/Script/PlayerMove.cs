using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMove : MonoBehaviour, IDoorable
{
    [SerializeField] private float moveSpeed = 5;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!K.moveable) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (!K.moveableX) h = 0;
        if (!K.moveableY) v = 0;

        transform.Translate(new Vector2(h, v) * moveSpeed * Time.fixedDeltaTime);

        var position = Vector3.zero;
        if (K.curMap)
            position = K.curMap.transform.position;

        var halfMapScale = K.curMap.sr.sprite.bounds.size / 2 - sr.sprite.bounds.size / 2;

        var clampX = Mathf.Clamp(transform.position.x, position.x - halfMapScale.x, position.x + halfMapScale.x);

        var halfUnderX = (position.y - halfMapScale.y) / 5 * 9;
        var halfUpperX = (position.y + halfMapScale.y) / 5 * 1;

        var clampY = Mathf.Clamp(transform.position.y, halfUnderX, halfUpperX);

        var viewport = Camera.main.WorldToViewportPoint(transform.localPosition);

        if (K.PostProcessVolume.profile.TryGetSettings<Vignette>(out var vignette))
        {
            vignette.center.Override(viewport);
        }

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
