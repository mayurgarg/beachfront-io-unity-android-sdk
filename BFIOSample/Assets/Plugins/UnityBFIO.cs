using UnityEngine;
using System;
using System.Collections;



public class UnityBFIO : MonoBehaviour {
	
private AndroidJavaObject session;
	
private static UnityBFIO instance;
	
private AdListener listener;
	
public static UnityBFIO getInstance(string appId,  string addUnitID, AdListener listener)
  {
    if(instance == null)
    {
  	  instance = FindObjectOfType( typeof(UnityBFIO) ) as UnityBFIO;
  	  if(instance == null)
  		{
        instance = new GameObject("UnityBFIO").AddComponent<UnityBFIO>();
      }
    }
	instance.listener = listener;
	AndroidJavaClass bfioClass = new AndroidJavaClass("com.bfio.unitysdk.UnityBFIO");
	instance.session = bfioClass.CallStatic<AndroidJavaObject>("configure",UnityBFIO.getActivity(),appId, addUnitID);	
	return instance;
  }		
				
public void requestAD(string appId, string addUnitID){	
	this.session.Call("requestAD",UnityBFIO.getActivity(),appId, addUnitID);	
	}
	
public void showAD(){	
	this.session.Call("showAD");	
	}
	
public static AndroidJavaObject getActivity() {
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");		
	}

public void onInterstitialFailed(string args){  
	listener.onInterstitialFailed(args);
	}
		
public void onInterstitialStarted(string args){
		listener.onInterstitialStarted(args);
	}


public void onInterstitialClicked(string args){
		listener.onInterstitialClicked(args);
	}

public void onInterstitialDismissed(string args){
		listener.onInterstitialDismissed(args);
	}

public void onInterstitialCompleted(string args){
		listener.onInterstitialCompleted(args);
	}

public void onReceiveInterstitial(string args){		
		listener.onReceiveInterstitial(args);
	}

}