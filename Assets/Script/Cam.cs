using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    // Zoom용 카메라를 하나더 만들고 UI에다가 카메라가 보고있는거 Texture로 받아서 랜더링하기
    [SerializeField] private float range = 4.5f;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private RawImage rawImgZoom;
    [SerializeField] private Camera cam;

    public void CameraToggle()
    {
        K.moveable = !K.moveable;

        if (!K.moveable)
        {
            cam.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
        // Zoom카메라 위치에서 Raycasting해서 뭘 찍었는지 확인
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraToggle();
        }
    }

    private void FixedUpdate()
    {
        if (!K.moveable)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            cam.transform.Translate(new Vector2(h, v) * moveSpeed * Time.fixedDeltaTime);

            var clampX = Mathf.Clamp(cam.transform.position.x, transform.position.x - range, transform.position.x + range);
            var clampY = Mathf.Clamp(cam.transform.position.y, transform.position.y - range, transform.position.y + range);

            cam.transform.position = new Vector3(clampX, clampY, cam.transform.position.z);
        }
    }
}
