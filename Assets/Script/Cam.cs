using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    // Zoom용 카메라를 하나더 만들고 UI에다가 카메라가 보고있는거 Texture로 받아서 랜더링하기
    [SerializeField] private float range = 4.5f;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private RawImage rawImgZoom;
    [SerializeField] private Camera cam;
    [SerializeField] private Image imgPicture;
    [SerializeField] private RectTransform rtrnLayoutGroup;

    public void CameraToggle()
    {
        if (!K.camable) return;

        K.moveable = !K.moveable;

        Cursor.visible = K.moveable;

        if (!K.moveable)
        {
            cam.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            SoundManager.Instance.Play("카메라 초점음 1", SoundType.EFFECT);

            if (Vector2.Distance(transform.position, cam.transform.position) > range)
            {
                K.moveable = true;
            }
        }

        rawImgZoom.gameObject.SetActive(!K.moveable);
        cam.gameObject.SetActive(!K.moveable);
    }

    public void TakePicture()
    {
        if (!K.camable) return;

        // Zoom카메라 위치에서 Raycasting해서 뭘 찍었는지 확인
        var hit = Physics2D.Raycast(cam.transform.position, Vector3.forward, 2, LayerMask.GetMask("Filmable"));
        if (hit.transform)
        {
            SoundManager.Instance.Play("카메라 써터음 1회-3", SoundType.EFFECT);

            print(hit.transform.gameObject.name);

            var ghost = hit.transform.GetComponent<Ghost>();

            if (ghost)
            {
                hit.transform.gameObject.SetActive(false);
                imgPicture.sprite = ghost.spPicture;
            }

            PostProcessing.Instance.GradingEffect2(Color.white);

            PostProcessing.Instance.GradingEffect(100, true);


            for (int i = 0; i < 5; i++)
            {
                var img = rtrnLayoutGroup.GetChild(i).GetComponent<Image>();

                if (img.sprite == null)
                {
                    img.sprite = imgPicture.sprite;
                    img.gameObject.SetActive(true);

                    if (i == 4)
                    {
                        SceneManager.LoadScene(3);
                    }

                    break;
                }
            }

            StartCoroutine(EShowPicture());
        }
    }

    private IEnumerator EShowPicture()
    {
        var wait = new WaitForSeconds(0.01f);
        imgPicture.color = Color.white;
        imgPicture.gameObject.SetActive(true);

        while (Mathf.Abs(imgPicture.color.a - 0) > 0.01f)
        {
            imgPicture.color = Color.Lerp(imgPicture.color, new Color(1, 1, 1, 0), Time.deltaTime * 2);
            yield return wait;
        }

        imgPicture.gameObject.SetActive(false);

        yield return null;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CameraToggle();
            Player.instance.PM.skeletonAnimation.AnimationName = "idle";
        }
        if (Input.GetMouseButtonDown(0))
        {
            TakePicture();
        }
    }

    private void FixedUpdate()
    {
        if (!K.camable) return;

        if (!K.moveable)
        {
            //float h = Input.GetAxisRaw("Horizontal");
            //float v = Input.GetAxisRaw("Vertical");

            //cam.transform.Translate(new Vector2(h, v) * moveSpeed * Time.fixedDeltaTime);
            cam.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var clampX = Mathf.Clamp(cam.transform.position.x, transform.position.x - range, transform.position.x + range);
            var clampY = Mathf.Clamp(cam.transform.position.y, transform.position.y - range, transform.position.y + range);

            cam.transform.position = new Vector3(clampX, clampY, cam.transform.position.z);
        }
    }
}
