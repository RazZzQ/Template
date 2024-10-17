using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class NotificationSystem : MonoBehaviour
{
    private const string ChannelId = "default_channel";

    private void Start()
    {
        CreateNotificationChannel();
    }

    public void CreateNotificationChannel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            var channel = new AndroidJavaObject("android.app.NotificationChannel", ChannelId, "Default Channel", 3);
            var manager = new AndroidJavaObject("android.app.NotificationManager");
            manager.Call("createNotificationChannel", channel);
        }
    }

    public void SendNotification(string title, string message)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaObject notificationBuilder = new AndroidJavaObject("android.app.Notification$Builder", currentActivity, "default_channel");
            notificationBuilder.Call<AndroidJavaObject>("setContentTitle", title);
            notificationBuilder.Call<AndroidJavaObject>("setContentText", message);

            int iconId = currentActivity.Call<AndroidJavaObject>("getResources").Call<int>("getIdentifier", "ic_launcher", "mipmap", currentActivity.Call<string>("getPackageName"));
            notificationBuilder.Call<AndroidJavaObject>("setSmallIcon", iconId);

            AndroidJavaObject notificationManager = currentActivity.Call<AndroidJavaObject>("getSystemService", "notification");
            notificationManager.Call("notify", 1, notificationBuilder.Call<AndroidJavaObject>("build"));
        }
    }
}
