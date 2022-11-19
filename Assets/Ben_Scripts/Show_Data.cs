using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Show_Data : MonoBehaviour
{
    #region Variable
    DatabaseReference reference;
    DataSnapshot snapshot;
    string name;

    public GameObject[] Container;
    public GameObject Text;
    public Image redMoney;
    public Text username;

    public int a, b, c, d, e, f, g, h, i, j, k, l = 0;


    public bool done;

    #endregion

    #region Show Month List
    public List<Text> showJanuary = new List<Text>();
    public List<Text> showFebruary = new List<Text>();
    public List<Text> showMarch = new List<Text>();
    public List<Text> showApril = new List<Text>();
    public List<Text> showMay = new List<Text>();
    public List<Text> showJune = new List<Text>();
    public List<Text> showJuly = new List<Text>();
    public List<Text> showAugust = new List<Text>();
    public List<Text> showSeptember = new List<Text>();
    public List<Text> showOctober = new List<Text>();
    public List<Text> showNovember = new List<Text>();
    public List<Text> showDecember = new List<Text>();
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
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        name = PlayerPrefs.GetString("username");
        username.text = name;
        loadData();
        //Invoke("saveToFirebase", 0.5f);


    }

    private void Update()
    {
        showDataTree();


        if (Temp.delete == 1)
        {
            loadData();
            //Invoke("loadData",1f);
            //Invoke("saveToFirebase", 1.5f);
        }

        if (done) {
            done = false;

            Invoke("saveToFirebase", 2f);
            //saveToFirebase();
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

    public void loadData()
    {
        reference.Child("User").Child(name).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                snapshot = task.Result;

                clearAllList();

                addOldLoadDataToList();

            }
        });
    }


    void addOldLoadDataToList()
    {
        // January
        for (int i = 0; i < snapshot.Child("January").ChildrenCount; i++)
        {
            if (snapshot.Child("January").Child(i.ToString()).Value == null)
            {
                a += 1;
            }
            January.Add("");
            January[i] = snapshot.Child("January").Child((i + a).ToString()).Value.ToString();
        }
        // February
        for (int i = 0; i < snapshot.Child("February").ChildrenCount; i++)
        {

            if (snapshot.Child("February").Child(i.ToString()).Value == null)
            {
                b += 1;
          
            }
            
            February.Add("");
            Debug.Log((i + b));
            February[i] = snapshot.Child("February").Child((i+b).ToString()).Value.ToString();

        }
        // March
        for (int i = 0; i < snapshot.Child("March").ChildrenCount; i++)
        {
            if (snapshot.Child("March").Child(i.ToString()).Value == null)
            {
                c += 1;
            }
            March.Add("");
            March[i] = snapshot.Child("March").Child((i + c).ToString()).Value.ToString();
        }
        // April
        for (int i = 0; i < snapshot.Child("April").ChildrenCount; i++)
        {
            if (snapshot.Child("April").Child(i.ToString()).Value == null)
            {
                d += 1;
            }
            April.Add("");
            April[i] = snapshot.Child("April").Child((i + d).ToString()).Value.ToString();
        }
        // May
        for (int i = 0; i < snapshot.Child("May").ChildrenCount; i++)
        {
            if (snapshot.Child("May").Child(i.ToString()).Value == null)
            {
                e += 1;
            }
            May.Add("");
            May[i] = snapshot.Child("May").Child((i + e).ToString()).Value.ToString();
        }
        // June
        for (int i = 0; i < snapshot.Child("June").ChildrenCount; i++)
        {
            if (snapshot.Child("June").Child(i.ToString()).Value == null)
            {
                f += 1;
            }
            June.Add("");
            June[i] = snapshot.Child("June").Child((i + f).ToString()).Value.ToString();
        }
        // July
        for (int i = 0; i < snapshot.Child("July").ChildrenCount; i++)
        {
            if (snapshot.Child("July").Child(i.ToString()).Value == null)
            {
                g += 1;
            }
            July.Add("");
            July[i] = snapshot.Child("July").Child((i + g).ToString()).Value.ToString();
        }
        // August
        for (int i = 0; i < snapshot.Child("August").ChildrenCount; i++)
        {
            if (snapshot.Child("August").Child(i.ToString()).Value == null)
            {
                h += 1;
            }
            August.Add("");
            August[i] = snapshot.Child("August").Child((i + h).ToString()).Value.ToString();
        }
        // September
        for (int i = 0; i < snapshot.Child("September").ChildrenCount; i++)
        {
            if (snapshot.Child("September").Child(i.ToString()).Value == null)
            {
                this.i += 1;
            }
            September.Add("");
            September[i] = snapshot.Child("September").Child(i + this.i.ToString()).Value.ToString();
        }
        // October
        for (int i = 0; i < snapshot.Child("October").ChildrenCount; i++)
        {
            if (snapshot.Child("October").Child(i.ToString()).Value == null)
            {
                j += 1;
            }
            October.Add("");
            October[i] = snapshot.Child("October").Child((i + j).ToString()).Value.ToString();
        }
        // November
        for (int i = 0; i < snapshot.Child("November").ChildrenCount; i++)
        {
            if (snapshot.Child("November").Child(i.ToString()).Value == null)
            {
                k += 1;
            }
            November.Add("");
            November[i] = snapshot.Child("November").Child((i + k).ToString()).Value.ToString();
        }
        // December
        for (int i = 0; i < snapshot.Child("December").ChildrenCount; i++)
        {
            if (snapshot.Child("December").Child(i.ToString()).Value == null)
            {
                l += 1;
            }
            December.Add("");
            December[i] = snapshot.Child("December").Child((i + l).ToString()).Value.ToString();
        }


        done = true;
    }


    void saveToFirebase()
    {
        User user = new User();
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

        reference.Child("User").Child(name).SetRawJsonValueAsync(json).ContinueWith(task => { });
        Temp.delete = 0;

    }


    void clearContainer()
    {
        if (Container[0].transform.childCount != 0)
        {

            for (int i = 1; i < Container[0].transform.childCount; i++)
            {
                Destroy(Container[0].transform.GetChild(i).gameObject);
            }
        }
        if (Container[1].transform.childCount != 0)
        {

            for (int i = 1; i < Container[1].transform.childCount; i++)
            {
                Destroy(Container[1].transform.GetChild(i).gameObject);
            }
        }
        if (Container[2].transform.childCount != 0)
        {

            for (int i = 1; i < Container[2].transform.childCount; i++)
            {
                Destroy(Container[2].transform.GetChild(i).gameObject);
            }
        }
        if (Container[3].transform.childCount != 0)
        {

            for (int i = 1; i < Container[3].transform.childCount; i++)
            {
                Destroy(Container[3].transform.GetChild(i).gameObject);
            }
        }
        if (Container[4].transform.childCount != 0)
        {

            for (int i = 1; i < Container[4].transform.childCount; i++)
            {
                Destroy(Container[4].transform.GetChild(i).gameObject);
            }
        }
        if (Container[5].transform.childCount != 0)
        {

            for (int i = 1; i < Container[5].transform.childCount; i++)
            {
                Destroy(Container[5].transform.GetChild(i).gameObject);
            }
        }
        if (Container[6].transform.childCount != 0)
        {

            for (int i = 1; i < Container[6].transform.childCount; i++)
            {
                Destroy(Container[6].transform.GetChild(i).gameObject);
            }
        }
        if (Container[7].transform.childCount != 0)
        {

            for (int i = 1; i < Container[7].transform.childCount; i++)
            {
                Destroy(Container[7].transform.GetChild(i).gameObject);
            }
        }
        if (Container[8].transform.childCount != 0)
        {

            for (int i = 1; i < Container[8].transform.childCount; i++)
            {
                Destroy(Container[8].transform.GetChild(i).gameObject);
            }
        }
        if (Container[9].transform.childCount != 0)
        {

            for (int i = 1; i < Container[9].transform.childCount; i++)
            {
                Destroy(Container[9].transform.GetChild(i).gameObject);
            }
        }
        if (Container[10].transform.childCount != 0)
        {

            for (int i = 1; i < Container[10].transform.childCount; i++)
            {
                Destroy(Container[10].transform.GetChild(i).gameObject);
            }
        }
        if (Container[11].transform.childCount != 0)
        {

            for (int i = 1; i < Container[11].transform.childCount; i++)
            {
                Destroy(Container[11].transform.GetChild(i).gameObject);
            }
        }
    }


    public void showData(string month)
    {
        clearContainer();

        switch (month)
        {
            case "01":
                for (int i = 0; i < January.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[0].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = January[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = January[i].Remove(6);

                }
                break;

            case "02":
                for (int i = 0; i < February.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[1].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = February[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = February[i].Remove(6);
                }
                break;


            case "03":
                for (int i = 0; i < March.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[2].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = March[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = March[i].Remove(6);
                }
                break;

            case "04":
                for (int i = 0; i < April.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[3].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = April[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = April[i].Remove(6);
                }
                break;

            case "05":
                for (int i = 0; i < May.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[4].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = May[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = May[i].Remove(6);
                }
                break;

            case "06":
                for (int i = 0; i < June.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[5].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = June[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = June[i].Remove(6);
                }
                break;

            case "07":
                for (int i = 0; i < July.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[6].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = July[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = July[i].Remove(6);
                }
                break;

            case "08":
                for (int i = 0; i < August.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[7].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = August[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = August[i].Remove(6);
                }
                break;

            case "09":
                for (int i = 0; i < September.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[8].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = September[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = September[i].Remove(6);
                }
                break;

            case "10":
                for (int i = 0; i < October.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[9].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = October[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = October[i].Remove(6);
                }
                break;

            case "11":
                for (int i = 0; i < November.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[10].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = November[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = November[i].Remove(6);
                }
                break;

            case "12":
                for (int i = 0; i < December.Count; i++)
                {
                    GameObject j = Instantiate(Text, transform.position, transform.rotation);
                    j.transform.SetParent(Container[11].transform);
                    j.transform.localScale = new Vector2(0.39f, 0.39f);
                    j.transform.GetChild(0).GetComponent<Text>().text = December[i].Substring(8);
                    j.transform.GetChild(1).gameObject.name = i.ToString();
                    j.transform.GetChild(0).gameObject.name = December[i].Remove(6);
                }
                break;
        }


    }


    public void showDataTree()
    {

        for (int i = 0; i < 3; i++)
        {
            showJanuary[i].text = "";
            showFebruary[i].text = "";
            showMarch[i].text = "";
            showApril[i].text = "";
            showMay[i].text = "";
            showJune[i].text = "";
            showJuly[i].text = "";
            showAugust[i].text = "";
            showSeptember[i].text = "";
            showOctober[i].text = "";
            showNovember[i].text = "";
            showDecember[i].text = "";
        }

        // January
        for (int i = 0; i < January.Count; i++)
        {
            try
            {
                showJanuary[i].text = January[i].Substring(8);
                if (January[i].Contains("-"))
                    showJanuary[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showJanuary[i].gameObject.name = January[i].Remove(5);
            }
            catch { }
        }
        // February
        for (int i = 0; i < February.Count; i++)
        {
            try
            {
                showFebruary[i].text = February[i].Substring(8);
                if (February[i].Contains("-"))
                    showFebruary[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showFebruary[i].gameObject.name = February[i].Remove(5);
            }
            catch { }
        }
        // March
        for (int i = 0; i < March.Count; i++)
        {
            try
            {
                showMarch[i].text = March[i].Substring(8);
                if (March[i].Contains("-"))
                    showMarch[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showMarch[i].gameObject.name = March[i].Remove(5);

            }
            catch { }
        }
        // April
        for (int i = 0; i < April.Count; i++)
        {
            try
            {
                showApril[i].text = April[i].Substring(8);
                if (April[i].Contains("-"))
                    showApril[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showApril[i].gameObject.name = April[i].Remove(5);

            }
            catch { }
        }
        // May
        for (int i = 0; i < May.Count; i++)
        {
            try
            {
                showMay[i].text = May[i].Substring(8);
                if (May[i].Contains("-"))
                    showMay[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showMay[i].gameObject.name = May[i].Remove(5);
            }
            catch { }
        }
        // June
        for (int i = 0; i < June.Count; i++)
        {
            try
            {
                showJune[i].text = June[i].Substring(8);
                if (June[i].Contains("-"))
                    showJune[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showJune[i].gameObject.name = June[i].Remove(5);
            }
            catch { }
        }
        // July
        for (int i = 0; i < July.Count; i++)
        {
            try
            {
                showJuly[i].text = July[i].Substring(8);
                if (July[i].Contains("-"))
                    showJuly[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showJuly[i].gameObject.name = July[i].Remove(5);
            }
            catch { }
        }
        // August
        for (int i = 0; i < August.Count; i++)
        {
            try
            {
                showAugust[i].text = August[i].Substring(8);
                if (August[i].Contains("-"))
                    showAugust[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showAugust[i].gameObject.name = August[i].Remove(5);
            }
            catch { }
        }
        //September
        for (int i = 0; i < September.Count; i++)
        {
            try
            {
                showSeptember[i].text = September[i].Substring(8);
                if (September[i].Contains("-"))
                    showSeptember[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showSeptember[i].gameObject.name = September[i].Remove(5);
            }
            catch { }
        }
        // October
        for (int i = 0; i < October.Count; i++)
        {
            try
            {
                showOctober[i].text = October[i].Substring(8);
                if (October[i].Contains("-"))
                    showOctober[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showOctober[i].gameObject.name = October[i].Remove(5);
            }
            catch { }
        }
        // November
        for (int i = 0; i < November.Count; i++)
        {
            try
            {
                showNovember[i].text = November[i].Substring(8);
                if (November[i].Contains("-"))
                    showNovember[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showNovember[i].gameObject.name = November[i].Remove(5);
            }
            catch { }
        }
        // December
        for (int i = 0; i < December.Count; i++)
        {
            try
            {
                showDecember[i].text = December[i].Substring(8);
                if (December[i].Contains("-"))
                    showDecember[i].gameObject.GetComponentInParent<Image>().sprite = redMoney.sprite;

                showDecember[i].gameObject.name = December[i].Remove(5);
            }
            catch { }
        }
    }

    public void goToLogin()
    {
        Login_Register.remember = false;
        PlayerPrefs.SetString("remember", "No");
        SceneManager.LoadScene("Login");
    }

    public void goToAdd()
    {
        SceneManager.LoadScene("AddMoney");
    }
}
