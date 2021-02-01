using UnityEngine;

public class SubViewControl : MonoBehaviour
{
    [Header("左右角度 : マウスのスクロール")]
    [Header("上下移動 : QEキー")]
    [Header("前後左右移動 : WASDキー or 矢印キー")]
    [Header("VR内のWebカメラの設定")]

    [Range(-90.0f, 90.0f)]
    [SerializeField] private float 上下角度 = 0.0f;

    [Range(30.0f, 90.0f)]
    [SerializeField] private float 画角 = 40.0f;

    private Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            targetCamera.transform.position += transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            targetCamera.transform.position += -transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            targetCamera.transform.position += transform.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            targetCamera.transform.position += -transform.right * 0.1f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            targetCamera.transform.position += transform.up * 0.1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            targetCamera.transform.position += -transform.up * 0.1f;
        }

        var rot = targetCamera.transform.rotation.eulerAngles;

        var scroll = Input.mouseScrollDelta;
        if (scroll.y > 0)
        {
            rot.y += 10.0f;
        }
        if (scroll.y < 0)
        {
            rot.y -= 10.0f;
        }

        rot.x = 上下角度;
        targetCamera.transform.rotation = Quaternion.Euler(rot);

        targetCamera.fieldOfView = 画角;
    }
}
