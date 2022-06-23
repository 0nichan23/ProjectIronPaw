using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        Color newColor = new Color(_color.r, _color.g, _color.b, 200);
        _color = newColor;
        _sprite.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
