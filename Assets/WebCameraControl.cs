using UnityEngine;

public class WebCameraControl : MonoBehaviour
{
    [SerializeField] private Renderer render;
    private WebCamTexture webcam = null;

    // Start is called before the first frame update
    void Start()
    {
        var devices = WebCamTexture.devices;
        webcam = new WebCamTexture(devices[1].name);
        render.material.mainTexture = webcam;
        webcam.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
