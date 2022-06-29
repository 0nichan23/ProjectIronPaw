using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PopupManager : MonoBehaviour
{
    [SerializeField] private TextObjectPooler _objectPooler;

    public List<TextPopup> TextQueue = new List<TextPopup>();

    private bool _isCurrentlyDisplayingPopup;

    private void Update()
    {
        if(!_isCurrentlyDisplayingPopup && TextQueue.Count > 0)
        {
            StartCoroutine(DisplayPopup(TextQueue[0]));
        }
    }

    private IEnumerator DisplayPopup(TextPopup textPopup)
    {
        
        _isCurrentlyDisplayingPopup = true;
        textPopup.gameObject.SetActive(true);
        TextQueue.Remove(textPopup);
        yield return new WaitUntil(() => !textPopup.gameObject.activeSelf);
        _isCurrentlyDisplayingPopup = false;
    }

    public void AddMessage(string text, Material _givenFontMaterial)
    {
        TextPopup popupRef = _objectPooler.GetPooledObjects();

        popupRef.Setup(text, _givenFontMaterial);
        popupRef.transform.position = transform.position;

        TextQueue.Add(popupRef);
    }
}
