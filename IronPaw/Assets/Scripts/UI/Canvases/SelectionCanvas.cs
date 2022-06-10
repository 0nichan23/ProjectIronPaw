using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;

    public TextMeshProUGUI Title { get => _title; set => _title = value; }
}
