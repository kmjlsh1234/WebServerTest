using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ServerManager : MonoBehaviour
{
    private const string endpointURL = "http://localhost:7777/";
    public TMP_InputField _inputField_A;
    public TMP_InputField _inputField_B;
    public TMP_Text _resultText;
    public Button _sendButton;
    public void Start()
    {
        _sendButton.onClick.AddListener(() => StartCoroutine(Send()));
    }

    IEnumerator Send()
    {
        var num1 = _inputField_A.text;
        var num2 = _inputField_B.text;
        var reqest = endpointURL + "?var1=" + num1 + "&var2=" + num2;
        using (UnityWebRequest req = UnityWebRequest.Get(reqest))
        {
            yield return req.SendWebRequest();
            if(req.isNetworkError || req.isHttpError)
            {
                Debug.LogError(req.error);
            }
            else
            {
                _resultText.text = req.downloadHandler.text;
            }
        }
    }

}
