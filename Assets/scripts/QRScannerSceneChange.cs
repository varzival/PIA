using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using BarcodeScanner;
using BarcodeScanner.Scanner;

public class QRScannerSceneChange : MonoBehaviour {
    private IScanner BarcodeScanner;
    //public Text TextHeader;
    public RawImage camImage;
    //public AudioSource Audio;
    private float RestartTime;

    public string endScene;

    public GameObject iOSInput;
    public InputField iOSInputField;

    // Use this for initialization
    void Start()
    {
        if (PersistantSaver.getCurrentStation() == -1)
        {
            SceneManager.LoadScene(endScene);
            return;
        }

#if UNITY_IOS
        iOSInput.SetActive(true);
#else
        iOSInput.SetActive(false);
        // Create a basic scanner
        BarcodeScanner = new Scanner();
        BarcodeScanner.Camera.Play();

        // Display the camera texture through a RawImage
        BarcodeScanner.OnReady += (sender, arg) => {
            // Set Orientation & Texture
            camImage.transform.localEulerAngles = BarcodeScanner.Camera.GetEulerAngles();
            camImage.transform.localScale = BarcodeScanner.Camera.GetScale();
            camImage.texture = BarcodeScanner.Camera.Texture;

            // Keep Image Aspect Ratio
            var rect = camImage.GetComponent<RectTransform>();
            var newHeight = rect.sizeDelta.x * BarcodeScanner.Camera.Height / BarcodeScanner.Camera.Width;
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, newHeight);

            RestartTime = Time.realtimeSinceStartup;
        };
#endif
    }

    public void checkStationInput()
    {
        string inputValue = iOSInputField.text;

        int currentStation = PersistantSaver.getCurrentStation();
        if (StationData.stations[currentStation].qrcodestring.Equals(inputValue.ToLower()))
        {
            changeToCurrentStation();
            return;
        }
        iOSInputField.text = "";
        #if UNITY_ANDROID || UNITY_IOS
            Handheld.Vibrate();
        #endif

    }

    public static void changeToCurrentStation()
    {
        int station = PersistantSaver.getCurrentStation();
        PersistantSaver.playerData.stationStats[station].discovered = true;
        SceneManager.LoadScene(StationData.stations[station].scene);
    }

    /// <summary>
	/// Start a scan and wait for the callback (wait 1s after a scan success to avoid scanning multiple time the same element)
	/// </summary>
	private void StartScanner()
    {
        BarcodeScanner.Scan((barCodeType, barCodeValue) => {
            BarcodeScanner.Stop();
            RestartTime += Time.realtimeSinceStartup + 1f;

            int currentStation = PersistantSaver.getCurrentStation();
            if (StationData.stations[currentStation].qrcodestring.Equals(barCodeValue))
            {
                changeToCurrentStation();
            }

            // Feedback
            //Audio.Play();


        });
    }

    /// <summary>
    /// The Update method from unity need to be propagated
    /// </summary>
    void Update()
    {
#if UNITY_IOS

#else
        if (BarcodeScanner != null)
        {
            BarcodeScanner.Update();
        }

        // Check if the Scanner need to be started or restarted
        if (RestartTime != 0 && RestartTime < Time.realtimeSinceStartup)
        {
            StartScanner();
            RestartTime = 0;
        }
#endif
    }


#region UI Buttons

    /*
    public void ClickBack()
    {
        // Try to stop the camera before loading another scene
        StartCoroutine(StopCamera(() => {
            SceneManager.LoadScene("Boot");
        }));
    }
    */

    /// <summary>
    /// This coroutine is used because of a bug with unity (http://forum.unity3d.com/threads/closing-scene-with-active-webcamtexture-crashes-on-android-solved.363566/)
    /// Trying to stop the camera in OnDestroy provoke random crash on Android
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator StopCamera(Action callback)
    {
        // Stop Scanning
        camImage = null;
        BarcodeScanner.Destroy();
        BarcodeScanner = null;

        // Wait a bit
        yield return new WaitForSeconds(0.1f);

        callback.Invoke();
    }

#endregion
}
