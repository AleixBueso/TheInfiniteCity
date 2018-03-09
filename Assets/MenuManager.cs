using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject mainCube;

    public void PressRight()
    {
        float startTime = Time.time;
        StartCoroutine(RightAnimation(startTime));
    }

    public void PressLeft()
    {
        float startTime = Time.time;
        StartCoroutine(LeftAnimation(startTime));
    }

    public void GenerateButton()
    {
        SceneManager.LoadScene("City");
    }

    IEnumerator RightAnimation(float startTime)
    {
        float t = 0;

        while (t < 1)
        {
            t = (Time.time - startTime) / 0.5f;
            mainCube.transform.rotation = Quaternion.Euler(0, Mathf.SmoothStep(mainCube.transform.rotation.y, mainCube.transform.rotation.y + 90, t), 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator LeftAnimation(float startTime)
    {
        float t = 0;

        while (t < 1)
        {
            t = (Time.time - startTime) / 0.5f;
            mainCube.transform.rotation = Quaternion.Euler(0, Mathf.SmoothStep(mainCube.transform.rotation.y, mainCube.transform.rotation.y - 90, t), 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
