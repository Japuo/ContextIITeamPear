using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float fps;

    SpriteRenderer sr;
    public bool startPlaying;
    
    bool isPlaying;
    public bool IsPlaying
    {
        get { return isPlaying; }
        set 
        {
            if (!isPlaying && value) { StartCoroutine(PlayAnimation()); }
            isPlaying = value;
        }
    }

    private void Start()
    {
        IsPlaying = startPlaying;
    }

    IEnumerator PlayAnimation()
    {
        yield return null; //Lets the getter/setter finish. This is ugly. Oh well.
        sr = GetComponentInParent<SpriteRenderer>();
        int i = 0;

        while(isPlaying)
        {
            sr.sprite = sprites[i];
            i++; i %= sprites.Length;
            yield return new WaitForSeconds(1.0f / fps);
        }
    }
    
}
