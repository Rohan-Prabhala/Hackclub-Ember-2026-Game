using UnityEngine;

public class NextSceneWrapper : MonoBehaviour
{

    public void NextScene() {
        GameManager.Instance.NextScene();
    }

}
