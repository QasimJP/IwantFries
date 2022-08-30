using UnityEngine;
//using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{
    public static FacebookManager Instance;

    //void Awake()
    //{
    //    if ( Instance == null )
    //    {
    //        DontDestroyOnLoad ( this );
    //        Instance = this;

    //    }
    //    else
    //    {
    //        Destroy ( gameObject );
    //    }


    //    if (!FB.IsInitialized)
    //    {
    //        // Initialize the Facebook SDK
    //        FB.Init(InitCallback, OnHideUnity);
    //        GAEventManager.instance.SendDesignEvent("Facebook:Init");
    //    }
    //    else
    //    {
    //        // Already initialized, signal an app activation App Event
    //        FB.ActivateApp();
    //    }
    //}

    private void Start()
    {
        InitFBManually();
    }

    public void InitFBManually()
    {
        //if (!FB.IsInitialized)
        //{
        //    // Initialize the Facebook SDK
        //    FB.Init(InitCallback, OnHideUnity);

        //    //GAEventManager.instance.SendDesignEvent("Facebook:Init");
        //}
        //else
        //{
        //    // Already initialized, signal an app activation App Event
        //    FB.ActivateApp();
        //}
    }

    private void InitCallback()
    {
        //if (FB.IsInitialized)
        //{
        //    // Signal an app activation App Event
        //    FB.ActivateApp();
        //    Debug.Log("Facebook Sdk initialized");
        //    //GAEventManager.instance.SendDesignEvent("Facebook:Initialized");
        //    // Continue with Facebook SDK
        //    // ...
        //}
        //else
        //{
        //    Debug.Log("Failed to Initialize the Facebook SDK");
        //}
    }

    private void OnHideUnity(bool isGameShown)
    {
        //if (!isGameShown)
        //{
        //    // Pause the game - we will need to hide
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    // Resume the game - we're getting focus again
        //    Time.timeScale = 1;
        //}
    }
}