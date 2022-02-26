using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : Singletone<PostProcessing>
{
    private WaitForSeconds wait = new WaitForSeconds(0.01f);

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    public void BloomEffect(float value)
    {
        if (K.PostProcessVolume.profile.TryGetSettings<Bloom>(out var effect))
        {
            StartCoroutine(EBloomEffect(effect, Mathf.Clamp(value, 0, 60)));
        }
    }

    private IEnumerator EBloomEffect(Bloom bloom, float value)
    {
        while (Mathf.Abs(bloom.intensity - value) >= 1)
        {
            bloom.intensity.Override(Mathf.MoveTowards(bloom.intensity, value, 1));
            yield return wait;
        }

        yield return null;
    }

    public void GrainEffect(float value)
    {
        if (K.PostProcessVolume.profile.TryGetSettings<Grain>(out var effect))
        {
            StartCoroutine(EGrainEffect(effect, Mathf.Clamp(value, 0, 1)));
        }
    }

    private IEnumerator EGrainEffect(Grain grain, float value)
    {
        while (Mathf.Abs(grain.intensity - value) >= 0.1f)
        {
            grain.intensity.Override(Mathf.MoveTowards(grain.intensity, value, Time.deltaTime));
            yield return wait;
        }

        yield return null;
    }

    public void LensEffect(float value)
    {
        if (K.PostProcessVolume.profile.TryGetSettings<LensDistortion>(out var effect))
        {
            StartCoroutine(ELensEffect(effect, Mathf.Clamp(value, 0, 100)));
        }
    }

    private IEnumerator ELensEffect(LensDistortion lens, float value)
    {
        while (Mathf.Abs(lens.intensity - value) >= 10)
        {
            lens.intensity.Override(Mathf.MoveTowards(lens.intensity, value, 10));
            yield return wait;
        }

        float time = 0;

        while (time < 5)
        {
            time += Time.deltaTime;

            lens.scale.Override(Mathf.Sin(time * Random.Range(3, 13)) * 2.5f + 2.5f);

            yield return wait;
        }

        lens.scale.Override(0.01f);

        yield return null;
    }

    public void ShakeEffect(float value)
    {
        if (K.PostProcessVolume.profile.TryGetSettings<DepthOfField>(out var effect))
        {
            StartCoroutine(EShakeEffect(effect, Mathf.Clamp(value, 0, 300)));
        }
    }

    private IEnumerator EShakeEffect(DepthOfField grain, float value)
    {
        while (Mathf.Abs(grain.focalLength - value) >= 10)
        {
            grain.focalLength.Override(Mathf.MoveTowards(grain.focalLength, value, 10));
            yield return wait;
        }

        yield return null;
    }

    public void GradingEffect(float value, bool restore)
    {
        if (K.PostProcessVolume.profile.TryGetSettings<ColorGrading>(out var effect))
        {
            StartCoroutine(EGradingEffect(effect, Mathf.Clamp(value, 0, 25), restore));
        }
    }

    private IEnumerator EGradingEffect(ColorGrading grading, float value, bool restore)
    {
        while (Mathf.Abs(grading.postExposure - value) >= 1)
        {
            grading.postExposure.Override(Mathf.MoveTowards(grading.postExposure, value, 2));
            yield return wait;
        }

        if (restore)
        {
            while (Mathf.Abs(grading.postExposure - 0) >= 1)
            {
                grading.postExposure.Override(Mathf.MoveTowards(grading.postExposure, 0, 3));
                yield return wait;
            }
        }

        yield return null;
    }
}
