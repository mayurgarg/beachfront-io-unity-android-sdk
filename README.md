## Beachfront Android Unity SDK usage guide

## Overview
This document details the process of integrating the Beachfront AD SDK with your Unity Android application. 

## Requirements

* BeachFront IO app id & Ad Unit id - [Get it from here](http://beachfront.io/join)
* BeachFront SDK Jar - [Get it from here](https://github.com/beachfront/beachfront-io-unity-android-sdk/tree/master/SDK)
* Android 1.5 and above

## Installation
1. Access the beachfront.io Console and register your application to get your App ID & Ad unit Id;
2. Download the Beachfront Unity SDK & import the Beachfront Unity SDK to your Unity project as a custom package.
3. Add the BF activity in the application node of AndroidManifesh.xml:

```
	<activity
	android:name="com.bfio.ad.BFIOActivity"
	android:configChanges="keyboardHidden|orientation|screenSize" />
```

* Make sure to have android:targetSdkVersion should be equal or greater then 13 in the manifest

```
 <uses-sdk android:targetSdkVersion="13" />
```

   Add following required permession in your AndroidManifest.xml

```
  <uses-permission android:name="android.permission.READ_PHONE_STATE" />
  <uses-permission android:name="android.permission.INTERNET" />
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />  
```

Once you’ve completed the above steps, you can start displaying ads in your application by following the simple instructions for Interstitial Ad below: In your Game Object C# script (the one from which you want to show the ad), implement the AdListener interface. This will register the Ad events with your game object.

In your Activity class (the one from which you want to show the ad), declare a BFIOInterstitial instance variable, register your activity as the interstitial's BFIOInterstitial.InterstitialListener and instantiate it in the onCreate(Bundle savedInstanceState) method.

```
public class Demo : MonoBehaviour, AdListener

```
Declare an instance variable of UnityBFIO type.

```
UnityBFIO unityBFIO;

```
Instantiate the Unity BFIO variable in the start method with the APP ID & Add Unity ID

```
unityBFIO = UnityBFIO.getInstance (appID,adUnitID, this);
```

Request Ad:
```
	unityBFIO.requestAD(appID,adUnitID);
```

Show Ad:
```
	unityBFIO.showAD( );
```

Below is the sample Unity Game Object class integrated with Beachfront .iO:

```
using UnityEngine;
using System;
using System.Collections;

public class Demo : MonoBehaviour, AdListener { private GUIStyle labelStyle = new GUIStyle();
private float centerX = Screen.width / 2;
UnityBFIO unityBFIO;
String appID = “e04fd6b0-4eb2-4dc8-b8d3-accfb7cf8043”; String adUnitID = “622834c9-3b52-4114-a531-a4bf494230ba”;

// Use this for initialization
void Start () {
labelStyle.fontSize = 24;
labelStyle.normal.textColor = Color.black; labelStyle.alignment = TextAnchor.MiddleCenter; unityBFIO = UnityBFIO.getInstance (appID,adUnitID, this);
}

void OnGUI () {
GUI.Label(new Rect(centerX -200, 20, 400, 35), “BFIOSDK Demo”, labelStyle);
if (GUI.Button(new Rect(centerX - 75, 80, 150, 35), “Request Ad”))
{
unityBFIO.requestAD(appID,adUnitID);
}
if (GUI.Button(new Rect(centerX - 75, 180, 150, 35), “Show Ad”))
{
unityBFIO.showAD( );
} }

public void onInterstitialFailed(string args){ }
public void onInterstitialStarted(string args){ }
public void onInterstitialClicked(string args){ }
public void onInterstitialDismissed(string args){ }
public void onInterstitialCompleted(string args){ }
public void onReceiveInterstitial(string args){ unityBFIO.showAD( );
}
}

```

Instruction PDF can be found at - https://github.com/beachfront/beachfront-io-unity-android-sdk/raw/master/bfio-Unity-android-sdk.pdf

Have a bug? Please [create an issue on GitHub](https://github.com/beachfront/beachfront-io-unity-android-sdk/issues)!

