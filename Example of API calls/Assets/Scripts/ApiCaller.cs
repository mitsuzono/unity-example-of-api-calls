using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiCaller : MonoBehaviour
{
    private readonly string FUNCTION1_URL = "<YOUR_FUNCTION1_URL>";

    [SerializeField]
    Text serializedRequestResult;

    public void Get()
        => StartCoroutine(GetCoroutine());

    public void Post()
        => StartCoroutine(PostCoroutine());

    private IEnumerator GetCoroutine()
    {
        // GETリクエスト実行
        var name = "userA";
        var request = UnityWebRequest.Get($"{FUNCTION1_URL}&name={name}");
        yield return request.SendWebRequest();

        var responseMessage = request.downloadHandler.text;
        if (string.IsNullOrWhiteSpace(responseMessage) || responseMessage == "{}")
        {
            // レスポンスが空なら終了
            serializedRequestResult.text = "レスポンスが取得できませんでした";
            yield break;
        }

        // ログ出力
        serializedRequestResult.text = responseMessage;
    }

    private IEnumerator PostCoroutine()
    {
        // POSTリクエスト実行
        var requestJson = "{\"name\":\"userB\"}";
        var request = new UnityWebRequest(FUNCTION1_URL, UnityWebRequest.kHttpVerbPOST)
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(requestJson)),
            downloadHandler = new DownloadHandlerBuffer(),
        };
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        var responseMessage = request.downloadHandler.text;
        if (string.IsNullOrWhiteSpace(responseMessage) || responseMessage == "{}")
        {
            // レスポンスが空なら終了
            serializedRequestResult.text = "レスポンスが取得できませんでした";
            yield break;
        }

        // ログ出力
        serializedRequestResult.text = responseMessage;
    }
}
