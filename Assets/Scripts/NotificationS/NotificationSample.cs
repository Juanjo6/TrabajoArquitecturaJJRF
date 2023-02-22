using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //var notification = new AndroidNotification();
        //notification.Title = "HEY, HACE TIEMPO QUE NO JUEGAS";
        //notification.Text = "Los m�dicos recomiendan que pegues tu cara al m�vil el m�ximo tiempo al d�a que respirar te permita";
        //notification.FireTime = System.DateTime.Now.AddSeconds(15);
        //AndroidNotificationCenter.SendNotification(notification, "channel_id");

        /////////Ejemplo de notificacion simple/////////
        var notification = new AndroidNotification();
        notification.Title = "Your Title";
        notification.Text = "Your Text";

        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";


        //Se activar� una notificacion cada x tiempo
        notification.FireTime = System.DateTime.Now.AddSeconds(15);

        //Finalmente enviamos la notificacion al m�vil
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        //Hemos recogido la notificaci�n en una variable llamada id para comprobar si el mensaje esta mostrado para no acumular mensajes
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
