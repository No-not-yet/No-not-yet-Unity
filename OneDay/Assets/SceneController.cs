using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Instance public in order to be used by any script
	public static SceneController instance = null;

	string scene1 = "SceneTest";
	string scene2 = "CasaPobres";
	string targetScene;
	CanvasGroup canvasGroup;

	Coroutine transitionAlpha;
	public float transitionSmoothTime = 0.1f;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	// Use this for initialization
	void Start () {
		//TransitionToScene(scene1);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Pressed Click For Transition");
			transitionToScene(scene1);
		}*/

		if (Input.touchCount > 0) {
			if(SceneManager.GetActiveScene ().name == scene2)
				transitionToScene(scene1);

			if(SceneManager.GetActiveScene ().name == scene1)
				transitionToScene(scene2);
		}
	}

	void transitionToScene(string sceneName){
		if (SceneManager.GetActiveScene ().name == sceneName)
			return;
		targetScene = sceneName;

		if (transitionAlpha == null) {
			this.transitionAlpha = StartCoroutine (fadeToAlpha(1));
		}
	}

	IEnumerator fadeToAlpha(float targetAlpha){
		float diff = Mathf.Abs (canvasGroup.alpha - targetAlpha);
		float transitionRate = 0;

		while (diff > 0.025f) {
			canvasGroup.alpha = Mathf.SmoothDamp (canvasGroup.alpha, targetAlpha, ref transitionRate, transitionSmoothTime);
			diff = Mathf.Abs (canvasGroup.alpha - targetAlpha);
			yield return new WaitForSeconds (Time.deltaTime);
		}

		canvasGroup.alpha = targetAlpha;

		if (targetAlpha == 1) {
			StartCoroutine (loadingScene());
			//SceneManager.LoadScene (targetScene, LoadSceneMode.Single);
		}else{
			this.transitionAlpha = null;
		}
	}

	IEnumerator loadingScene(){
		SceneManager.LoadScene (targetScene);
		string activeScene = SceneManager.GetActiveScene ().name;

		while(activeScene != targetScene){
			Debug.Log ("Loading ... ");
			activeScene = SceneManager.GetActiveScene ().name;
			yield return new WaitForSeconds(Time.deltaTime);
		}

		StartCoroutine (fadeToAlpha(0));
	}

}
