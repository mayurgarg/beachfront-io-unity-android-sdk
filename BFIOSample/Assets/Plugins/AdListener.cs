using UnityEngine;
using System.Collections;

public interface AdListener
{
    	
void onInterstitialFailed(string args);	
		
void onInterstitialStarted(string args);

void onInterstitialClicked(string args);
	
void onInterstitialDismissed(string args);	

void onInterstitialCompleted(string args);

void onReceiveInterstitial(string args);	

}

