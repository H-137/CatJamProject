using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Text;

public class SubmitScoreScript : MonoBehaviour
{
    public TMP_Text Scores, Names, warning;
    public TMP_InputField nameInput;

    private string nameText;

    private int highScore;

    public string[] nameArr;
    public int[] scoreArr;

    public bool isLeaderboard;

    public string calculateHmac(byte[] data) {
        HMACSHA256 hmac = new HMACSHA256(SecretKeys.leaderboard_hmac_key);
        return System.Convert.ToBase64String(hmac.ComputeHash(data));
    }

    [System.Serializable]
    public class LeaderboardEntry
    {
        public string initials;
        public int score;
    }

    [System.Serializable]
    public class LeaderboardResponse
    {
        public string status;
        public List<LeaderboardEntry> data;

    }

    public void sendScore()
    {
        if(nameInput.text.Length != 3)
        {
            warning.text = "Please enter initials with 3 characters";
            StartCoroutine(warningMessage());
            return;
        }
        if(PlayerPrefs.GetString("name") == "")
        {
            PlayerPrefs.SetString("name",nameInput.text.ToUpper());
        }
        highScore = PlayerPrefs.GetInt("highscore");
        for( int i = 0; i < Utilities.nameArr.Length; i++)
        {
            //Debug.Log(Utilities.nameArr[i]);
            //Debug.Log(nameText);
            if(PlayerPrefs.GetString("name") == Utilities.nameArr[i])
            {
                if(highScore <= Utilities.scoreArr[i])
                {
                    warning.text = "Higher or equal score with same initials already exists";
                    StartCoroutine(warningMessage());
                    return;
                }
                break;
            }
        }
        StartCoroutine(sendScore(new LeaderboardEntry() { initials = PlayerPrefs.GetString("name"), score = highScore }));
    }

    public IEnumerator warningMessage(){
        warning.enabled = true;
        yield return new WaitForSeconds(2);
        warning.enabled = false;
    }

    //Recieves the leaderboard from the server
    public void recieveLeaderboard()
    {
        StartCoroutine(updateLatestLeaderboard());
    }

    IEnumerator updateLatestLeaderboard()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://catjam-leaderboard.vercel.app/leaderboard");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            string responseText = www.downloadHandler.text;
            //Debug.Log(responseText);

            // decode response json

            LeaderboardResponse response = JsonUtility.FromJson<LeaderboardResponse>(responseText);
            //Debug.Log(response.data[0].initials);
            for (int i = 0; i < response.data.Count; i++)
            {
                nameArr[i] = response.data[i].initials;
                scoreArr[i] = response.data[i].score;
            }
            //Debug.Log(scoreArr[0]);
            for(int i = 0; i < scoreArr.Length; i++){
                //Debug.Log(nameArr[i] + " " + scoreArr[i]);
                Scores.text += scoreArr[i] + "\n";
                Names.text += nameArr[i] + "\n";
            }
            Utilities.scoreArr = scoreArr;
            Utilities.nameArr = nameArr;
        }
    }
    
    IEnumerator sendScore(LeaderboardEntry entry)
    {
        string json = JsonUtility.ToJson(entry);
        Debug.Log(json);
        byte[] rawBody = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www =UnityWebRequest.Put("https://catjam-leaderboard.vercel.app/reportScore", rawBody);
        www.SetRequestHeader("Content-Type", "application/json");
        Debug.Log(calculateHmac(rawBody));
        www.SetRequestHeader("Content-Authenticity-HMAC", calculateHmac(rawBody));

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            // Show results as text
            string responseText = www.downloadHandler.text;
            Debug.Log(responseText);
            Debug.Log("Success");
        }
        SceneManager.LoadScene("Leaderboard");
    
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if(isLeaderboard){
                
            recieveLeaderboard();
        }
    }
}