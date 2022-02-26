using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public float Alpha_speed;
    public Image GuideImage;
    public Image Synop_Image;
    bool isActive;
    private void Update()
    {
        if(Input.anyKeyDown && !GuideImage.gameObject.activeInHierarchy && !Synop_Image.gameObject.activeInHierarchy)
        {
            GuideImage.gameObject.SetActive(true);
            StartCoroutine(FadeIn(GuideImage));
        }

        else if (Input.anyKeyDown && GuideImage.gameObject.activeInHierarchy)
        {
            
            GuideImage.gameObject.SetActive(false);
            Synop_Image.gameObject.SetActive(true);
            StartCoroutine(FadeIn(Synop_Image));
        }
        else if (Input.anyKeyDown && Synop_Image.gameObject.activeInHierarchy)
        {
            Synop_Image.gameObject.SetActive(true);
            StartCoroutine(FadeOut(Synop_Image, true));
        }
    }

    public IEnumerator FadeIn(Image image)
    {
        Color _color = new Color(0, 0, 0, Alpha_speed);
        yield return null;

        while (image.color.a < 0.99f)
        {
            image.color += _color;
            yield return null;
        }

    }

    public IEnumerator FadeOut(Image image, bool isSceneLoad = false)
    {
        Color _color = new Color(0, 0, 0, Alpha_speed);
        yield return null;
        while(image.color.a >= 0.01f)
        {
            image.color -= _color;
            yield return null;
        }
        if(isSceneLoad)
        {
            SceneManager.LoadScene(1);
        }
    }
}
