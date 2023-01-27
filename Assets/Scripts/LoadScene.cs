using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public string escena;
    public GameObject panel;

    public void CargarScene()
    {
        StartCoroutine(Transition());
        GameManager.Singleton.Nulify();
        Time.timeScale = 1;
    }

    public void TitleScreenToMenu()
    {
        StartCoroutine(Transition());
        GameManager.Singleton.Nulify();
        Time.timeScale = 1;
    }

    IEnumerator Transition()
    {

        yield return new WaitForSeconds(1.5f);
        panel.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(escena);
    }
}
