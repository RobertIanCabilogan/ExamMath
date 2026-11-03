using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checker : MonoBehaviour
{
    public Transform enemy;
    public string levelName;
    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            StartCoroutine(Switch(1));
        }
    }

    private IEnumerator Switch(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelName);

    }
}
