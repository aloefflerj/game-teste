using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class APIController : MonoBehaviour
{

    public RawImage rawImage;
    public Text text;

    private readonly string BASE_URL = "https://avatars.dicebear.com/api/male/";

    // Start is called before the first frame update
    void Start()
    {
        rawImage.texture = Texture2D.blackTexture;
        text.text = "";
    }

    public void OnbuttonResult()
    {
        int randomSeed = Random.Range(1, 1000);

        text.text = "Loading...";


        StartCoroutine(GetSprite(randomSeed));
    }

    IEnumerator GetSprite(int seed)
    {
        string spriteUrl = BASE_URL + seed.ToString() + ".svg?mood[]=happy";

        UnityWebRequest infoRequest = UnityWebRequestTexture.GetTexture("https://picsum.photos/200");

        UnityWebRequest insultRequest = UnityWebRequest.Get("https://evilinsult.com/generate_insult.php?lang=en&type=json");
        


        yield return infoRequest.SendWebRequest();
        yield return insultRequest.SendWebRequest();

        if(infoRequest.isNetworkError || infoRequest.isHttpError)
        {
            Debug.Log(infoRequest.error);
            yield break;
        }

        if (insultRequest.isNetworkError || insultRequest.isHttpError)
        {
            Debug.Log(insultRequest.error);
            yield break;
        }

        JSONNode insult = JSON.Parse(insultRequest.downloadHandler.text);
        

        rawImage.texture = DownloadHandlerTexture.GetContent(infoRequest);
        rawImage.texture.filterMode = FilterMode.Point;
        text.text = insult["insult"];

        
    }
}
