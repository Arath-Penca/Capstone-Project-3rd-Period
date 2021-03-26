using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScreen : MonoBehaviour
{
    public float sec = 17f;
    public GameObject returnButton;
    public GameObject quitButton;

    void Start()
    {
        if (returnButton.activeInHierarchy)
        {
            returnButton.SetActive(false);
        }

        if (quitButton.activeInHierarchy)
        {
            quitButton.SetActive(false);
        }

        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(sec);

        returnButton.SetActive(true);
        quitButton.SetActive(true);

    }

}
