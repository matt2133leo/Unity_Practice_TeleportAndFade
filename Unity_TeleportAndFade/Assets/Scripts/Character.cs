using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour
{
    [Header("透明數值"), Range(0, 255)]
    public float alpha = 255;
    [Header("淡入淡出速度"), Range(0f, 1f)]
    public float speed = 0.1f;

    private Image colorimage;

    private void Start()
    {
        colorimage = GetComponent<Image>();
        colorimage.color = new Color(255, 255, 255, alpha);
        enterscene();
    }

    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(LoadScene());
    }
    


    private void enterscene()
    {
        float t = 0;
        for (float i = 0; i < 5; i+=Time.deltaTime)
        {
            t += speed;
            alpha = Mathf.Lerp(255, 0, t*Time.deltaTime);
        }

    }


    private IEnumerator LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(0.01f);
    }

}
