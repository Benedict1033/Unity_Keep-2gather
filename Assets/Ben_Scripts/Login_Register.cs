using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_Register : MonoBehaviour
{
    DatabaseReference reference;
    DataSnapshot snapshot;
    public InputField username;
    public GameObject checkSymbol;

    bool loginState = false;
    public static bool remember = false;
    string user;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        if (PlayerPrefs.GetString("remember") == "Yes")
        {
            user = PlayerPrefs.GetString("username");
            loginRemember();
        }
    }
    private void Update()
    {
        if (loginState)
        {
            loginState = false;
            loginSuccessful();
        }
    }

    public void loginUser()
    {
        if (username.text != "")
        {
            reference.Child("User").Child(username.text).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    snapshot = task.Result;

                    if (snapshot.Value != null)
                    {
                        loginState = true;
                        Debug.Log("User Login");
                    }
                    else
                    {
                        Debug.Log("User Not Exist , pls register");
                    }
                }
            });
        }
        else
            Debug.Log("Pls enter username");

    }

    public void registerUser()
    {
        if (username.text != "")
        {
            reference.Child("User").Child(username.text).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    snapshot = task.Result;
                    if (snapshot.Value != null)
                    {
                        Debug.Log("Username Exist,change other name");
                    }
                    else
                    {
                        User user = new User();
                        user.name = username.text;
                        string json = JsonUtility.ToJson(user);

                        reference.Child("User").Child(user.name).SetRawJsonValueAsync(json).ContinueWith(task =>
                        {
                            username.text = "";
                        });
                        Debug.Log("Register successful, go Login");
                    }
                }
            });
        }
        else
            Debug.Log("Pls enter usernaem");
    }

    void loginSuccessful()
    {
        PlayerPrefs.SetString("username", username.text);
        SceneManager.LoadScene("Home");
    }

    void loginRemember()
    {
        PlayerPrefs.SetString("username",user );
        SceneManager.LoadScene("Home");
    }

    public void rememberMe()
    {
        remember = !remember;

        if (remember)
        {
            checkSymbol.SetActive(true);
            PlayerPrefs.SetString("remember", "Yes");
        }
        else
        {
            checkSymbol.SetActive(false);
            PlayerPrefs.SetString("remember", "No");
        }
    }
}
