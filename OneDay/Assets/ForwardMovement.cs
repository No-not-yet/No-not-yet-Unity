using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(Status))]

public class ForwardMovement : MonoBehaviour {

	public float speed = 3;
	private Status playerStatus;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    private AudioSource m_AudioSource;

    private Coroutine corutinaDeSonido;
    bool playerMoving = true;






    void Start(){
		playerStatus = this.GetComponent<Status> ();
        m_AudioSource = this.GetComponent<AudioSource>();
		//Debug.Log ("Walking esta en: " + playerStatus.getWalking ());

	}

	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && !playerStatus.getBusy())
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            this.transform.position += forward * (Time.deltaTime) * speed;
            playerStatus.setWalking(true);
            if (playerMoving)
            {
               StartCoroutine(Delay());
            }
        }

        if (!(Input.touchCount > 0) && playerStatus.getWalking())
        {
            playerStatus.setWalking(false);
        }
    }

    void soundOfMadness() {

        if (playerStatus.isWalking == true)
        {       
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }
        else {
            return;
        }
    }

    IEnumerator Delay() {
        // Hacer 1 sonido
        soundOfMadness();
        playerMoving = false;
        yield return new WaitForSeconds(.7f);
        playerMoving = true;

    }
    


}
