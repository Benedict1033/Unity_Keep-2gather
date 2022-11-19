using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Database_Test : MonoBehaviour
{
    #region Variable
    DatabaseReference reference;
    DataSnapshot snapshot;

    User user;
    
    string month, day,name;

    public InputField money;
    public Text username;
    public Text dateToday;

    public Text yearContainer;
    public Text monthContainer;
    public Text dayContainer;
    
    public GameObject []monthButton;
    public GameObject[] dayButton;
    #endregion

    #region Month List
    public List<string> January = new List<string>();
    public List<string> February = new List<string>();
    public List<string> March = new List<string>();
    public List<string> April = new List<string>();
    public List<string> May = new List<string>();
    public List<string> June = new List<string>();
    public List<string> July = new List<string>();
    public List<string> August = new List<string>();
    public List<string> September = new List<string>();
    public List<string> October = new List<string>();
    public List<string> November = new List<string>();
    public List<string> December = new List<string>();
    #endregion

    void Start()
    {
        name= PlayerPrefs.GetString("username");
        username.text = name;

        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;

        string monthStr="";
        string dayStr="";

        if (month < 10)
            monthStr = "0" + month;
        else
            monthStr = month.ToString();
        if (day < 10)
            dayStr = "0" + day;
        else
            dayStr = day.ToString();

        dateToday.text =  year+ "/"+ monthStr+"/"+ dayStr;

     this.month= monthStr;
     this.day= dayStr;

        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void loadData()
    {
        clearAllList();

        reference.Child("User").Child(PlayerPrefs.GetString("username")).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                snapshot = task.Result;

                addOldLoadDataToList();

                saveData();

            }
        });
    }

    void saveData()
    {
        if ( money.text != "")
        {

            addNewDataToList();

            sortAllList();

            addUpdatedListToFirebase();
        }
    }

    void clearAllList()
    {
        January.Clear();
        February.Clear();
        March.Clear();
        April.Clear();
        May.Clear();
        June.Clear();
        July.Clear();
        August.Clear();
        September.Clear();
        October.Clear();
        November.Clear();
        December.Clear();
    }

    void addOldLoadDataToList()
    {
        // January
        for (int i = 0; i < snapshot.Child("January").ChildrenCount; i++)
        {
            try
            {
                January.Add(""); 
                January[i] = snapshot.Child("January").Child(i.ToString()).Value.ToString();
            }
            catch {
                continue;
            }
        }
        // February
        for (int i = 0; i < snapshot.Child("February").ChildrenCount; i++)
        {
            February.Add("");
            February[i] = snapshot.Child("February").Child(i.ToString()).Value.ToString();
        }
        // March
        for (int i = 0; i < snapshot.Child("March").ChildrenCount; i++)
        {
            March.Add("");
            March[i] = snapshot.Child("March").Child(i.ToString()).Value.ToString();
        }
        // April
        for (int i = 0; i < snapshot.Child("April").ChildrenCount; i++)
        {
            April.Add("");
            April[i] = snapshot.Child("April").Child(i.ToString()).Value.ToString();
        }
        // May
        for (int i = 0; i < snapshot.Child("May").ChildrenCount; i++)
        {
            May.Add("");
            May[i] = snapshot.Child("May").Child(i.ToString()).Value.ToString();
        }
        // June
        for (int i = 0; i < snapshot.Child("June").ChildrenCount; i++)
        {
            June.Add("");
            June[i] = snapshot.Child("June").Child(i.ToString()).Value.ToString();
        }
        // July
        for (int i = 0; i < snapshot.Child("July").ChildrenCount; i++)
        {
            July.Add("");
            July[i] = snapshot.Child("July").Child(i.ToString()).Value.ToString();
        }
        // August
        for (int i = 0; i < snapshot.Child("August").ChildrenCount; i++)
        {
            August.Add("");
            August[i] = snapshot.Child("August").Child(i.ToString()).Value.ToString();
        }
        // September
        for (int i = 0; i < snapshot.Child("September").ChildrenCount; i++)
        {
            September.Add("");
            September[i] = snapshot.Child("September").Child(i.ToString()).Value.ToString();
        }
        // October
        for (int i = 0; i < snapshot.Child("October").ChildrenCount; i++)
        {
            October.Add("");
            October[i] = snapshot.Child("October").Child(i.ToString()).Value.ToString();
        }
        // November
        for (int i = 0; i < snapshot.Child("November").ChildrenCount; i++)
        {
            November.Add("");
            November[i] = snapshot.Child("November").Child(i.ToString()).Value.ToString();
        }
        // December
        for (int i = 0; i < snapshot.Child("December").ChildrenCount; i++)
        {
            December.Add("");
            December[i] = snapshot.Child("December").Child(i.ToString()).Value.ToString();
        }
    }

    void addNewDataToList()
    {
        switch (month)
        {
            case "01":
                January.Add("");
                January[January.Count - 1] = "01/" + day + " , " + money.text;
                break;

            case "02":
                February.Add("");
                February[February.Count - 1] = "02/" + day + " , " + money.text;
                break;

            case "03":
                March.Add("");
                March[March.Count - 1] = "03/" + day + " , " + money.text;
                break;

            case "04":
                April.Add("");
                April[April.Count - 1] = "04/" + day + " , " + money.text;
                break;

            case "05":
                May.Add("");
                May[May.Count - 1] = "05/" + day + " , " + money.text;
                break;

            case "06":
                June.Add("");
                June[June.Count - 1] = "06/" + day + " , " + money.text;
                break;

            case "07":
                July.Add("");
                July[July.Count - 1] = "07/" + day + " , " + money.text;
                break;

            case "08":
                August.Add("");
                August[August.Count - 1] = "08/" + day + " , " + money.text;
                break;

            case "09":
                September.Add("");
                September[September.Count - 1] = "09/" + day + " , " + money.text;
                break;

            case "10":
                October.Add("");
                October[October.Count - 1] = "10/" + day + " , " + money.text;
                break;

            case "11":
                November.Add("");
                November[November.Count - 1] = "11/" + day + " , " + money.text;
                break;

            case "12":
                December.Add("");
                December[December.Count - 1] = "12/" + day + " , " + money.text;
                break;
        }
    }

    void sortAllList()
    {
        January.Sort();
        February.Sort();
        March.Sort();
        April.Sort();
        May.Sort();
        June.Sort();
        July.Sort();
        August.Sort();
        September.Sort();
        October.Sort();
        November.Sort();
        December.Sort();
    }

    void addUpdatedListToFirebase()
    {
        user = new User();
        user.name = name;

        user.January.AddRange(January);
        user.February.AddRange(February);
        user.March.AddRange(March);
        user.April.AddRange(April);
        user.May.AddRange(May);
        user.June.AddRange(June);
        user.July.AddRange(July);
        user.August.AddRange(August);
        user.September.AddRange(September);
        user.October.AddRange(October);
        user.November.AddRange(November);
        user.December.AddRange(December);

        string json = JsonUtility.ToJson(user);

        reference.Child("User").Child(name).SetRawJsonValueAsync(json).ContinueWith(task => {  });
      
    }

    public void goToHome() {
        SceneManager.LoadScene("Home");
    }

    public void goToLogin()
    {

        Login_Register.remember = false;
        PlayerPrefs.SetString("remember", "No");

        SceneManager.LoadScene("Login");
    }

    public void comfirm()
    {
        if (monthContainer.text.Length == 1) {
            monthContainer.text = "0" + monthContainer.text;
        }
        if (dayContainer.text.Length == 1)
        {
            dayContainer.text = "0" + dayContainer.text;
        }

        dateToday.text = dateToday.text = yearContainer.text + "/" + monthContainer.text + "/" + dayContainer.text;

        month = monthContainer.text;
        day = dayContainer.text;
    }
}


