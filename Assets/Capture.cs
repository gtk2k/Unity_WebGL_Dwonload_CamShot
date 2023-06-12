using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CaptureDownload(string fileName, byte[] jpg, int length);

    [SerializeField] private Button CaptureButton;
    [SerializeField] private Camera Cam;

    private void Start()
    {
        CaptureButton.onClick.AddListener(CaptureButtonOnClick);
    }

    private void CaptureButtonOnClick()
    {
        Debug.Log($"1, {Cam.aspect}");
        var width = 1920;
        var height = (int)(1920 / Cam.aspect);
        var rt = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, 0);
        Debug.Log($"2");
        var tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Debug.Log($"3");
        var prev = Cam.targetTexture;
        Debug.Log($"4");
        Cam.targetTexture = rt;
        Debug.Log($"5");
        Cam.Render();
        Debug.Log($"6");
        Cam.targetTexture = prev;
        Debug.Log($"7");
        RenderTexture.active = rt;
        Debug.Log($"8");
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        Debug.Log($"9");
        var jpg = tex.EncodeToJPG();
        Debug.Log($"10");
        var fileName = "capture.jpg";
        Debug.Log($"11");
        CaptureDownload(fileName, jpg, jpg.Length);
        Debug.Log($"12");
    }
}
