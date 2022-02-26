using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Spine.Unity;

public class PlayerMove : MonoBehaviour, IDoorable
{
    [SerializeField] private float moveSpeed = 5;

    private SpriteRenderer sr;
    public SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnim;

    private float time;

    private void Start()
    {
        K.playerMove = this;
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!K.moveable) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (!K.moveableX) h = 0;
        if (!K.moveableY) v = 0;

        if (h != 0 || v != 0)
        {
            time += Time.fixedDeltaTime;
            if (time >= 0.7f)
            {
                time = 0;
                SoundManager.Instance.Play("주인공 발소리", SoundType.EFFECT);
            }
        }

        transform.Translate(new Vector2(h, v) * moveSpeed * Time.fixedDeltaTime);
        SpineAnimControll(h, v);
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

        //transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    private void SpineAnimControll(float h, float v)
    {
        if (h > 0)
        {
            skeletonAnimation.AnimationName = "walk";
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (h < 0)
        {
            skeletonAnimation.AnimationName = "walk";
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h == 0 && v == 0)
        {
            skeletonAnimation.AnimationName = "idle";
        }
        else
        {
            skeletonAnimation.AnimationName = "walk";
        }
    }
}
