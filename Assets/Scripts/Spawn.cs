using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Spawn : MonoBehaviour
{
    //public float waitAfterDiying = 3f;
    //public Text loseText;
    // Start is called before the first frame update
    [SerializeField] string levelToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method to manage the player when die
    public void PlayerDied()
    {
        //Call the coroutine
        StartCoroutine(PlayerDiedCo());
       
    }

    //Create the coroutine
    public IEnumerator PlayerDiedCo()
    {
        //yield return new WaitForSeconds(2f);                  
        //imageFade.gameObject.SetActive(true);
        //Wait an amount of time
        
        yield return new WaitForSeconds(0.5f);
        GameManager.Singleton.Nulify();
        //Load again the active Scene
        SceneManager.LoadScene(levelToLoad);
    }
}
