using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Character : MonoBehaviour
{
   



    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(LoadScene());
    }
    
    private IEnumerator LoadScene()
    {
        for (int i = 0; i < 10; i +=(int)Time.deltaTime)
        {
            SceneManager.LoadScene(1);
        }
        
        yield return new WaitForSeconds(0.5f);
    }

}
