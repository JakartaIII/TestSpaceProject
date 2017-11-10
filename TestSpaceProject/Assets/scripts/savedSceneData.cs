using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class savedSceneData : MonoBehaviour {
	public float health,meteorCount;
	public string LogTextStr;
	[SerializeField] Text LogText;
	public bool LogPanelShowed;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(LogText==null&&LogPanelShowed) 
		{
			LogText = GameObject.Find("LogText").gameObject.GetComponent<Text>();
		}
		if(LogPanelShowed)
		{
			LogText.text = LogTextStr;
		}
	}
	public void AddLogText(string addText)
	{
		LogTextStr += "\n"+addText;
	}
}
