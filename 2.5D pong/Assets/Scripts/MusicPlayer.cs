using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        /*
            called while the script instance is being loaded
        */

        // tells unity to not destroy this object when the scene is changed
        DontDestroyOnLoad(this.gameObject);
    }
}
