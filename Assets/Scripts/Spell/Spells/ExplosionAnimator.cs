using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    private int currentFrame;
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= .01f)
        {
            ++currentFrame;
            gameObject.GetComponent<SpriteRenderer>().sprite = frames[currentFrame];
        }
    }
}
