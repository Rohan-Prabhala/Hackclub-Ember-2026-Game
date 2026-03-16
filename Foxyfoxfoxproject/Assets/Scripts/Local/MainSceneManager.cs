using System;
using TMPro;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    //i should rename this to like EarthHell/Game/HellishEmbers/wtv the name of the game is/foxyfoxfox scenemanager but im too lazy rn
    [SerializeField] TextMeshProUGUI counterText;

    int soulsCounted = 0;

    #region Singleton Pattern
    private static MainSceneManager _instance;

    public static MainSceneManager Instance {
        get {
            //Create object if not in the scene
            if (_instance == null) {
                GameObject temp = new GameObject("SceneManager");
                temp.AddComponent<MainSceneManager>();
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

        OnAwake();
    }

    #endregion

    private void OnAwake() {
        
    }

    public void incrementSoulsCounted() {
        soulsCounted++;
        counterText.text = "Souls Counted:" + soulsCounted;
    }

}
