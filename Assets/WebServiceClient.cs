using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;
using System;

// Used for accessing webservices
public class WebServiceClient : MonoBehaviour {

	private string getIPAdress = "http://ip.jsontest.com/";
	private string md5Adress = "http://md5.jsontest.com/?text={0}";
	private string jsonValidate = "http://validate.jsontest.com/?json={0}";

	// object used as json parameter
	class TestObject {
		public int id;
		public string name;
	}
		
	void Start () {
		// get data examples
		string ip = getJSON (getIPAdress);
		Debug.Log (ip);

		string md5 = getJSON (String.Format(md5Adress, "Hello World!"));
		Debug.Log (md5);

		// web request with json parameter
		string jsonData = produceExampleJSON ();
		string validate = getJSON (String.Format(jsonValidate, jsonData));
		Debug.Log ("jsonData: " + jsonData);
		Debug.Log ("validate: " + validate);
	}

	string produceExampleJSON() {
		TestObject obj = new TestObject ();
		obj.id = 1;
		obj.name = "test";
		return JsonUtility.ToJson (obj);
	}

	// Returns JSON string
	string GET(string url) 
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		try {
			WebResponse response = request.GetResponse();
			using (Stream responseStream = response.GetResponseStream()) {
				StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
				return reader.ReadToEnd();
			}
		}
		catch (WebException ex) {
			WebResponse errorResponse = ex.Response;
			using (Stream responseStream = errorResponse.GetResponseStream())
			{
				StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
				string errorText = reader.ReadToEnd();
				// log errorText
			}
			throw;
		}
	}

	// POST a JSON string
	void POST(string url, string jsonContent) 
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.Method = "POST";

		System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
		Byte[] byteArray = encoding.GetBytes(jsonContent);

		request.ContentLength = byteArray.Length;
		request.ContentType = @"application/json";

		using (Stream dataStream = request.GetRequestStream()) {
			dataStream.Write(byteArray, 0, byteArray.Length);
		}
		long length = 0;
		try {
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
				length = response.ContentLength;
			}
		}
		catch (WebException ex) {
			// Log exception and throw as for GET example above
		}
	}

	string getJSON(string url) {
		var client = new WebClient();
		var content = client.DownloadString(url);
		return content;
	}
}
