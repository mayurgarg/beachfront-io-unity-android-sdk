using UnityEngine;
using System;
using System.Collections;


public class Demo : MonoBehaviour, AdListener {

 private GUIStyle labelStyle = new GUIStyle();
    private float centerX = Screen.width / 2;
	UnityBFIO unityBFIO;
	String appID = "57d0480b-3784-4741-e240-fb9d67e4b131";
	String adUnitID = "43577eec-b857-4050-c716-7759958d1642";
    // Use this for initialization
    void Start ()
    {   
        labelStyle.fontSize = 35;

        labelStyle.normal.textColor = Color.black;
        labelStyle.alignment = TextAnchor.MiddleCenter;
		unityBFIO = UnityBFIO.getInstance (appID,adUnitID, this); 
    }

    void OnGUI ()
    {
        GUI.Label(new Rect(centerX - 200, 20, 400, 35), "BFIOSDK Demo", labelStyle);
		if (GUI.Button(new Rect(centerX - 75, 80, 180, 75), "Request Ad"))
        {	
            unityBFIO.requestAD(appID,adUnitID);
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
