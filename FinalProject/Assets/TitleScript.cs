using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene("GameScene");
		}
	}

    private GUIStyle guiStyle = new GUIStyle();

    void OnGUI() {
        guiStyle.fontSize = 80; //change the font size
        guiStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 40, 128, 32), "Plattach", guiStyle);
	}
}
