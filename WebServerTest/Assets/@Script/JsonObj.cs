using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonObj : MonoBehaviour
{
    private const string endpointURL = "http://localhost:7777/";
    public TMP_InputField _inputField;
    public TMP_Text _resultText;
    public Button _sendButton;
    public void Start()
    {
        _sendButton.onClick.AddListener(() => StartCoroutine(Send()));
    }

    IEnumerator Send()
    {
        var reqest = endpointURL + "?Name=" + _inputField.text;
        using (UnityWebRequest req = UnityWebRequest.Get(reqest))
        {
            yield return req.SendWebRequest();
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.LogError(req.error);
            }
            else
            {
                var result = req.downloadHandler.text;
                Debug.Log(result);
                AccountModel model = JsonConvert.DeserializeObject<AccountModel>(result);   
                _resultText.text = $"DisplayName : {model.DisplayName}\n Age : {model.Age}\nProgrammingSkill : {model.ProgrammingSkill}";
            }

        }
    }
}
