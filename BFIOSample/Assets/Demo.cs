using UnityEngine;
using System;
using System.Collections;


public class Demo : MonoBehaviour, AdListener {

 private GUIStyle labelStyle = new GUIStyle();
    private float centerX = Screen.width / 2;
	UnityBFIO unityBFIO;
	String appID = "e04fd6b0-4eb2-4dc8-b8d3-accfb7cf8043";
	String adUnitID = "622834c9-3b52-4114-a531-a4bf494230ba";
    // Use this for initialization
    void Start ()
    {   
        labelStyle.fontSize = 24;
        labelStyle.normal.textColor = Color.black;
        labelStyle.alignment = TextAnchor.MiddleCenter;
		unityBFIO = UnityBFIO.getInstance (appID,adUnitID, this); 
    }

    void OnGUI ()
    {
        GUI.Label(new Rect(centerX - 200, 20, 400, 35), "BFIOSDK Demo", labelStyle);
        if (GUI.Button(new Rect(centerX - 75, 80, 150, 35), "Request Ad"))
        {	
            unityBFIO.requestAD(appID,adUnitID);
        }
		
		
		if (GUI.Button(new Rect(centerX - 75, 180, 150, 35), "Show Ad"))
        {	
            unityBFIO.showAD();
        }
    }
	
	public void onInterstitialFailed(string args){  
	
	}
		
public void onInterstitialStarted(string args){
	
	}


public void onInterstitialClicked(string args){
	
	}

public void onInterstitialDismissed(string args){
	
	}

public void onInterstitialCompleted(string args){
		
	}

public void onReceiveInterstitial(string args){		
		unityBFIO.showAD();
	}
}
