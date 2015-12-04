using UnityEditor;
using System.Collections;
using FMG;
using UnityEngine;
using System.Collections.Generic;
[CanEditMultipleObjects]
[CustomEditor(typeof(SplashImages))] 
public class SplashEditor : Editor {
	
	
	public override void OnInspectorGUI() {
		SplashImages myTarget = (SplashImages) target;
		EditorGUILayout.Separator();
		serializedObject.Update();


		handleRounds(myTarget);
		

		serializedObject.ApplyModifiedProperties();		
		EditorUtility.SetDirty(target);
	}
	
	
	void handleSplash(BaseImage round)
	{
		SerializedObject so = new SerializedObject(round);
		EditorGUILayout.PropertyField(so.FindProperty("fadeType"), true);

		EditorGUILayout.PropertyField(so.FindProperty("go"), true);
		EditorGUILayout.PropertyField(so.FindProperty("onPlayAC"), true);
		EditorGUILayout.PropertyField(so.FindProperty("onHideAC"), true);
		EditorGUILayout.PropertyField(so.FindProperty("playWaitTime"), true);
		EditorGUILayout.PropertyField(so.FindProperty("hideWaitTime"), true);
		so.ApplyModifiedProperties();
	}
	void handleFade(BaseImage round)
	{
		SerializedObject so = new SerializedObject(round);
		EditorGUILayout.PropertyField(so.FindProperty("fadeType"), true);

		EditorGUILayout.PropertyField(so.FindProperty("playOnStart"), true);
		EditorGUILayout.PropertyField(so.FindProperty("startColor"), true);
		EditorGUILayout.PropertyField(so.FindProperty("endColor"), true);
		EditorGUILayout.PropertyField(so.FindProperty("fadeTime"), true);
		EditorGUILayout.PropertyField(so.FindProperty("fillStart"), true);
		EditorGUILayout.PropertyField(so.FindProperty("fillEnd"), true);
		EditorGUILayout.PropertyField(so.FindProperty("image"), true);
		EditorGUILayout.PropertyField(so.FindProperty("onPlayAC"), true);
		EditorGUILayout.PropertyField(so.FindProperty("onHideAC"), true);
		EditorGUILayout.PropertyField(so.FindProperty("playWaitTime"), true);
		EditorGUILayout.PropertyField(so.FindProperty("hideWaitTime"), true);
		so.ApplyModifiedProperties();
	}
	void handleRounds(SplashImages myTarget)
	{
		EditorGUILayout.LabelField("Splash Images");
		if(GUILayout.Button("New Splash"))
		{
			createNewSplash(myTarget);
		}
		if(GUILayout.Button("Delete current"))
		{
			deleteSplash(myTarget);
		}
		EditorGUILayout.IntSlider(serializedObject.FindProperty("splashIndex"),0,myTarget.splashImages.Length-1	);

		float fround = (float)myTarget.splashIndex;
		float nomRounds = (float)myTarget.splashImages.Length-1;
		float val = fround / nomRounds;
		
		ProgressBar (val, "Splash");
		
		
		if(myTarget.splashImages.Length>0 && 		myTarget.splashIndex>-1)
		{
			BaseImage round = myTarget.splashImages[myTarget.splashIndex];
			if(round)
			{
				if(round.fadeType==BaseImage.FadeType.FADE)
				{
					handleFade (round);
				}
				if(round.fadeType==BaseImage.FadeType.SPLASH)
				{
					handleSplash (round);
				}
			}
		}
		serializedObject.ApplyModifiedProperties();
		
		EditorUtility.SetDirty(target);
	}
	void deleteSplash(SplashImages myTarget)
	{
		if(myTarget.splashIndex>-1 && myTarget.splashIndex < myTarget.splashImages.Length	)
		{
			DestroyImmediate(myTarget.splashImages[myTarget.splashIndex].gameObject);
		}
		List<BaseImage> rounds = new List<BaseImage>();
		for(int i=0; i<myTarget.splashImages.Length; i++)
		{
			if(myTarget.splashImages[i])
			{
				rounds.Add(myTarget.splashImages[i]);
			}
		}
		myTarget.splashImages = rounds.ToArray();
		
		myTarget.splashIndex = myTarget.splashImages.Length-1;
		
		serializedObject.ApplyModifiedProperties();		
		EditorUtility.SetDirty(myTarget);
	}

	void createNewSplash(SplashImages myTarget)
	{
		BaseImage[] rz = myTarget.GetComponentsInChildren<BaseImage>(true);
		GameObject go = new GameObject();
		int count = rz.Length + 1;
		go.name = "Splash" + count;	
		
		go.transform.parent = myTarget.transform;
		

		
		BaseImage newRound = go.AddComponent<BaseImage>();
	
		List<BaseImage> rounds = new List<BaseImage>();
		for(int i=0; i<myTarget.splashImages.Length; i++)
		{
			rounds.Add(myTarget.splashImages[i]);
		}
		rounds.Add(newRound);
		myTarget.splashImages = rounds.ToArray();
		
		myTarget.splashIndex = myTarget.splashImages.Length-1;
		
		serializedObject.ApplyModifiedProperties();		
		EditorUtility.SetDirty(myTarget);
	}
	void ProgressBar (float value, string label) {
		Rect rect  = GUILayoutUtility.GetRect (18, 18, "TextField");
		EditorGUI.ProgressBar (rect, value, label);
		EditorGUILayout.Space ();
	}
	
}