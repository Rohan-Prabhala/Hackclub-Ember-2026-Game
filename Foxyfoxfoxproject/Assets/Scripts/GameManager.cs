using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton Pattern
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            //Create object if not in the scene
            if (_instance == null) {
                GameObject temp = new GameObject("GameManager");
                temp.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake() {

        //Remove scene duplicates
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject); //Keep scene across loads

        OnAwake();

    }
    #endregion

    //blah
    //blah
    //blah
    private void OnAwake() {
        //lalalalalala
        //okay so what now ahhh
    }

}
