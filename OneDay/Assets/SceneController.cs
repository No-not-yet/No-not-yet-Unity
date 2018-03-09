using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Instance public in order to be used by any script
	public static SceneController instance = null;

	string scene0 = "CasaRicos";
	string scene1 = "CasaPobres";
	string scene2 = "Scene_03";
	string targetScene;
	CanvasGroup canvasGroup;

	Coroutine transitionAlpha;
	public float transitionSmoothTime = 0.1f;

	GameObject camera;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		canvasGroup = GetComponent<CanvasGroup> ();

		camera = GameObject.Find ("Main Camera");
	}

	// Use this for initialization
	void Start () {
		//TransitionToScene(scene1);
		this.transform.position = camera.transform.position + camera.transform.forward * 1f;
		this.transform.parent = camera.transform;
		//this.transform.SetSiblingIndex (0);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Pressed Click For Transition");
			transitionToScene(scene1);
		}*/


		/*if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Entrando a scene");
			if(SceneManager.GetActiveScene ().name == scene0)
				transitionToScene(scene1);

			if(SceneManager.GetActiveScene ().name == scene2)
				transitionToScene(scene1);

			if(SceneManager.GetActiveScene ().name == scene1)
				transitionToScene(scene2);
		}*/
	}

	public void loadScene(int i){
		switch (i) {
		case 2:
			transitionToScene (scene1);
			break;
		case 3:
			transitionToScene (scene2);
			break;
		default:
			transitionToScene (scene0);
			break;
		}
	}

	public void transitionToScene(string sceneName){
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

		if (activeScene == targetScene) {
			camera = GameObject.Find ("Main Camera");
			this.transform.position = camera.transform.position + camera.transform.forward * 1.5f;
			this.transform.parent = camera.transform;
			//this.transform.SetSiblingIndex (0);
		}
			

		while(activeScene != targetScene){
			Debug.Log ("Loading ... ");
			activeScene = SceneManager.GetActiveScene ().name;
			yield return new WaitForSeconds(Time.deltaTime);
		}

		StartCoroutine (fadeToAlpha(0));
	}

}
