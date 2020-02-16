using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Spell
{
    public const string tag = "explosion";

    [SerializeField] private float castingRange;
    [SerializeField] private float explosionRadius;

    bool casting = true;
    bool execute = false;

    private GameObject indicator;
    private Animator explosionAnimation;

    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        indicator = gameObject.transform.GetChild(0).gameObject;
        indicator.SetActive(false);
        explosionAnimation = gameObject.GetComponent<Animator>();
        explosionAnimation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }

        if(casting)
        {
            indicator.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            indicator.transform.position = mousePos;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && casting)
        {
            casting = false;
            explosionAnimation.enabled = true;
            explosionAnimation.transform.position = mousePos;
            explosionAnimation.Play(0);

            EndSpell();
        }
    }

    private void EndSpell()
    {
        indicator.SetActive(false);
    }

    public override void Cast()
    {
        casting = true;
    }
}
