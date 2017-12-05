using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class SendMessage : MonoBehaviour {
	public InputField messageText;
	public ReceiveMessage receiveMessage;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SendToServer () {
		if (messageText.text != null) {
			receiveMessage.ws.Send ("{ \"message\": \" " + messageText.text + "\" }");
			Debug.Log ("WebSocket Send");
			messageText.text = "";
		}
	}
}
