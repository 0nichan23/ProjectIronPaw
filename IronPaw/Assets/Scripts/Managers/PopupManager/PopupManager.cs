using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private ObjectPooler _objectPooler;

    public List<TextPopup> textQueue = new List<TextPopup>();

    private bool _isCurrentlyDisplayingPopup;

    private void Update()
    {
        if(!_isCurrentlyDisplayingPopup && textQueue.Count > 0)
        {
            StartCoroutine(DisplayPopup(textQueue[0]));
        }
    }

    private IEnumerator DisplayPopup(TextPopup textPopup)
    {
        
        _isCurrentlyDisplayingPopup = true;
        textPopup.gameObject.SetActive(true);
        textQueue.Remove(textPopup);
        yield return new WaitUntil(() => !textPopup.gameObject.activeSelf);
        _isCurrentlyDisplayingPopup = false;
    }

    public void ClearPopupQueue()
    {

    }

    public void AddMessage(Vector3 position, string text /*Material _givenFontMaterial*/)
    {
        Debug.Log("Display");
        Vector3 pos = new Vector3(position.x, position.y + 1, position.z - 4);
        GameObject popupRef = _objectPooler.GetPooledObjects();
        TextPopup textPopup = popupRef.GetComponent<TextPopup>();

        textPopup.Setup(text);
        popupRef.transform.position = pos;

        textQueue.Add(textPopup);
    }
}
