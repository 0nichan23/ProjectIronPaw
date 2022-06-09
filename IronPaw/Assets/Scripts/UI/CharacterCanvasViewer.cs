using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCanvasViewer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _longPressTime = 1f;
    private float _mouseDownTime;
    private Coroutine _runningCoroutine;

    [SerializeField] private Character _character;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressStart();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPressRelease();
    }

    public void OnPressStart()
    {
        _runningCoroutine = StartCoroutine(CountTimeHeld());
    }

    public void OnPressRelease()
    {
        if (TurnManager.Instance.LockInputs)
        {
            return;
        }
        StopCoroutine(_runningCoroutine);
        if (_mouseDownTime < _longPressTime) // Longpress
        {
            ShortPress();
        }
        _mouseDownTime = 0;
    }

    private IEnumerator CountTimeHeld()
    {
        while (_mouseDownTime < _longPressTime)
        {
            _mouseDownTime += Time.deltaTime;
            yield return null;
        }

        LongPress();
    }

    private void LongPress()
    {
        UIManager.Instance.CharacterHighlightCanvas.InitInfo(_character);
        UIManager.Instance.ToggleCanvasas(false);
    }

    private void ShortPress()
    {

    }
}
