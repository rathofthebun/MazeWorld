using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClick : MonoBehaviour {
	[SerializeField] bool controllerClick = false;
	[SerializeField] int collected = 0;
	[SerializeField] bool coolingDown = false;
	private Renderer mRenderer;
	// Use this for initialization
	void Start () {
		mRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other) {
		if (controllerClick){
		mRenderer.material.SetColor("_Color", Color.red);
			if (Input.GetMouseButtonDown(0)){
				if (!coolingDown){
					collected += 1;
					coolingDown = true;
					StartCoroutine(resetCD(5.0f));
					//need to reset cooling down
				}
			}
		}
	}
	private void OnTriggerExit(Collider other) {
		mRenderer.material.SetColor("_Color", Color.white);
	}
	private IEnumerator resetCD(float waitTime){
		yield return new WaitForSeconds(waitTime);
		coolingDown = false;
	}
}
