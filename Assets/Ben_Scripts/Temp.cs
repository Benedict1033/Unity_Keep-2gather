using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Firebase.Database;


public class Temp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject btn;
    public static string date;
    DatabaseReference reference;
    string month, name;
    public static int delete; 
    

    private void Start()
    {
        btn = this.gameObject;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        name = PlayerPrefs.GetString("username");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("Money");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetString("Money", btn.gameObject.transform.GetChild(0).GetComponent<Text>().text);

        if (PlayerPrefs.GetString("Money") != "")
        {
            date = btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = btn.gameObject.transform.GetChild(0).gameObject.name;
        }
    }

    void checkMonth()
    {
        switch (month)
        {
            case "01":
                month = "January";
                break;

            case "02":
                month = "February";
                break;

            case "03":
                month = "March";
                break;

            case "04":
                month = "April";
                break;

            case "05":
                month = "May";
                break;

            case "06":
                month = "June";
                break;

            case "07":
                month = "July";
                break;

            case "08":
                month = "August";
                break;

            case "09":
                month = "September";
                break;

            case "10":
                month = "October";
                break;

            case "11":
                month = "November";
                break;

            case "12":
                month = "December";
                break;
        }
    }

    public void Delete_Data()
    {
        date = btn.gameObject.transform.GetChild(0).GetComponent<Text>().text = btn.gameObject.transform.GetChild(0).gameObject.name;

        month = date.Remove(2);
        checkMonth();

        string index = btn.gameObject.transform.GetChild(1).name;

        reference.Child("User").Child(name).Child(month).Child(index).RemoveValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                //Debug.Log("Successfull");
               
                delete = 1;
                //Debug.Log(123);

            }
            else
            {
                Debug.Log("Not Successfull");
            }
        });

        Destroy(btn);
    }
}
