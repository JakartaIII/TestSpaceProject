using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasScript : MonoBehaviour {
	public bool QualityPanel, menuPanel;
	[SerializeField] GameObject PanelSettingObj,panelMenuObj,panelLog,settingShowButton,menuShowButton,logShowButton,logHideButton;
	// Use this for initialization
	void Start () {
		if(FindObjectOfType<savedSceneData>().LogPanelShowed)
		{
			panelLog.SetActive(true);
			logShowButton.SetActive(false);
			logHideButton.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))showOrHideMenu();
		
	}
	public void exitFromApp() //выйти из приложения
	{
		Application.Quit();
	}
	public void restartLevel() //перезапустить уровень
	{
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}
	public void showOrHideMenu() //показать/спрятать меню
	{
		if (panelMenuObj.activeSelf == true)
        {
            panelMenuObj.SetActive(false); 
			menuShowButton.SetActive(true);
			settingShowButton.SetActive(true);
			Time.timeScale = 1;
        }
        else
        {
            panelMenuObj.SetActive(true); 
			menuShowButton.SetActive(false);
			PanelSettingObj.SetActive(false);
			settingShowButton.SetActive(false);
			Time.timeScale = 0;
        }
	}

	public void showOrHideLogPanel()
	{
		if (panelLog.activeSelf == true)
        {
            panelLog.SetActive(false);
			logShowButton.SetActive(true);
			logHideButton.SetActive(false); 
			FindObjectOfType<savedSceneData>().LogPanelShowed = false;
        }
        else
        {
			FindObjectOfType<savedSceneData>().LogPanelShowed = true;
			panelLog.SetActive(true);
			logShowButton.SetActive(false);
			logHideButton.SetActive(true);
		}
	}
	public void showOrHideSettingPanel() // показать/скрыть панель настроек
	{
		if (PanelSettingObj.activeSelf == true)
        {
            PanelSettingObj.SetActive(false);
			settingShowButton.SetActive(true);
			menuShowButton.SetActive(true); 
			Time.timeScale = 1;
        }
        else
        {
            PanelSettingObj.SetActive(true);
			settingShowButton.SetActive(false);
			panelMenuObj.SetActive(false); 
			menuShowButton.SetActive(false);
			Time.timeScale = 0;
        }

    }
	public void setQuality(int i) //установить настройки графики
	{
		QualitySettings.SetQualityLevel(i,true);
	}
}
