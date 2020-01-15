using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    private Image fade;

    private void Start()
    {
        fade = GameObject.Find("轉場畫面").GetComponent<Image>();

        StartCoroutine(FadeOut());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送門")
        {
            StartCoroutine(FadeInAndLoad());
        }
    }

    /// <summary>
    /// 淡入並載入下一關
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeInAndLoad()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("第二關");
        ao.allowSceneActivation = false;

        while (fade.color.a < 1)
        {
            fade.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        ao.allowSceneActivation = true;
    }

    /// <summary>
    /// 淡出
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeOut()
    {
        fade.color = new Color32(37, 37, 37, 255);

        while (fade.color.a > 0)
        {
            fade.color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
