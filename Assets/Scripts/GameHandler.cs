using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public int deaths;
    void Start()
    {
        deaths = PlayerPrefs.GetInt("Deaths");
    }

    internal void Respawn()
    {
        StartCoroutine(WaitForSceneLoad());
        deaths++;
        PlayerPrefs.SetInt("Deaths", deaths);
        PlayerPrefs.GetInt("Deaths");
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 25, 100, 20), "Deaths: " + PlayerPrefs.GetInt("Deaths"));
    }
}
