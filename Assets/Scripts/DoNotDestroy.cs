using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {


	public static DoNotDestroy instance = null;

	void Awake() {
		//If there is no instance of this class....
		if(instance == null)
		{
			//....Then set the instance to this
			instance = this;
		}
		//Otherwise if an instance does not equal to this....
		else if(instance != this)
		{
			//....Then destroy this gameobject
			Destroy(gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}
	

}
