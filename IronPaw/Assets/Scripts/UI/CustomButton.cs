using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private float _longPressTime;
    private float _mouseDownTime;
    private Coroutine _runningCoroutine;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShortPress();
    }

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
        if (_runningCoroutine != null)
        {
            StopCoroutine(_runningCoroutine);

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

    protected virtual void LongPress() { }

    protected virtual void ShortPress() { }
}
