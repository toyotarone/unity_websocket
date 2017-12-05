using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using WebSocketSharp;

public class ReceiveMessage : MonoBehaviour {
	public Text messageText;
	public WebSocket ws;
	string buf;

	// Use this for initialization
	void Start () {
		ws = new WebSocket("your domain name");

		ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
			ws.Send("Websocket Open");
		};

		ws.OnMessage += (sender, e) =>
		{
			Debug.Log("WebSocket Message Type: " + ", Data: " + e.Data);
			buf += e.Data;
		};

		ws.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		ws.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		ws.Connect();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (buf != null){
			messageText.text += buf + "\n";
			buf = null;
		}
	}

	void OnDestroy()
	{
		ws.Close();
		ws = null;
	}
}
