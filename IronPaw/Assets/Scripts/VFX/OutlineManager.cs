using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : Singleton<OutlineManager>
{
    [SerializeField, Range(0f, 10f)] private float _outlineWidth = 2f;

    [SerializeField] private Color _red;
    [SerializeField] private Color _green;
    [SerializeField] private Color _blue;
    [SerializeField] private Color _white;
    [SerializeField] private Color _colorless;

    private Dictionary<ColorIdentity, Color> _colorDictionary;

    public Dictionary<ColorIdentity, Color> ColorDictionary { get => _colorDictionary; }
    public float OutlineWidth { get => _outlineWidth; }

    private void Start()
    {
        InitializeColorDictionary();
    }

    private void InitializeColorDictionary()
    {
        _colorDictionary = new Dictionary<ColorIdentity, Color>();
        _colorDictionary.Add(ColorIdentity.Red, _red);
        _colorDictionary.Add(ColorIdentity.Green, _green);
        _colorDictionary.Add(ColorIdentity.Blue, _blue);
        _colorDictionary.Add(ColorIdentity.White, _white);
        _colorDictionary.Add(ColorIdentity.Colorless, _colorless);
    }
}
