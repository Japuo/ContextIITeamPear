using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UnityEvent deathEvents, winEvents;
    public GameObject fadeImage;

    [Header("Collectibles")]
    public GameObject[] collectibleUIElements;    
    public bool[] collectibles;

    private void Awake()
    {
        Instance = this;
    }

    public void PickupCollectible(int index)
    {
        collectibles[index] = true;
        collectibleUIElements[index].SetActive(true);
    }

    public void DropCollectible(int index)
    {

        collectibles[index] = false;
        collectibleUIElements[index].SetActive(false);
    }

    public Coroutine FadeCycle(Color start, Color end)
    {
        return StartCoroutine(FadeCycleC(start, end));
    }

    public Coroutine FadeIn(Color start, Color end)
    {
        return StartCoroutine(FadeInC(start,end));
    }

    public Coroutine FadeOut(Color start, Color end)
    {
        return StartCoroutine(FadeOutC(start,end));
    }

    IEnumerator FadeCycleC(Color start, Color end)
    {
        yield return StartCoroutine(FadeInC(start, end));
        yield return StartCoroutine(FadeOutC(end, start));
    }

    IEnumerator FadeInC(Color start, Color end)
    {
        fadeImage.SetActive(true);
        float t = 0;
        while(t<=1.0f)
        {
            fadeImage.GetComponent<Image>().color = Color.Lerp(start, end, t);
            t += Time.unscaledDeltaTime * 4;
            yield return null;
        }
        fadeImage.GetComponent<Image>().color = end;
    }

    IEnumerator FadeOutC(Color start, Color end)
    {
        fadeImage.SetActive(true);
        float t = 0;
        while (t <= 1.0f)
        {
            fadeImage.GetComponent<Image>().color = Color.Lerp(start, end, t);
            t += Time.unscaledDeltaTime * 4;

            yield return null;
        }
        fadeImage.GetComponent<Image>().color = end;

        fadeImage.SetActive(false);
    }


    #region ManaBasic Functionality
    public void Die()
    {
        deathEvents.Invoke();
    }

    public void Win()
    {
        winEvents.Invoke();
    }
    #endregion

    #region debug

    #endregion
}
