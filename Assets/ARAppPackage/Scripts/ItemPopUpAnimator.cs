using System;
using UnityEngine;

public class ItemPopUpAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform startPos;
    [SerializeField] private RectTransform endPos;
    [SerializeField] private float minMovement;
    [SerializeField] private float minAnimVel;
    [SerializeField] private float maxAnimVel = 8f;
    [SerializeField] private AnimationCurve openCurve;
    [SerializeField] private AnimationCurve closeCurve;
    [SerializeField] private float animationLength = .8f;
    [SerializeField] private float velocitySmoothing = 10f;
    [SerializeField] private float referenceHeight = 1080f;


    private float _pixelMultipl;
    private Vector3 _offset;
    private float _currentYVel;
    private float _totalDistance;
    private float _lastMousePosY;

    private bool _isGrabbed;

    private void Awake()
    {
        _totalDistance = Vector2.Distance(startPos.localPosition, endPos.localPosition);
    }

    private void Update()
    {
        if (_isGrabbed) HandleGrab();
        _lastMousePosY = Input.mousePosition.y;
    }

    void HandleGrab()
    {
        float vel;
        
        #if UNITY_ANDROID && !UNITY_EDITOR
        var touch = Input.GetTouch(0);
        vel = Mathf.Abs(touch.deltaPosition.y);
        
        transform.position = new Vector3(transform.position.x, touch.position.y - _offset.y, 0f);
        #else
        vel = Mathf.Abs(_lastMousePosY - Input.mousePosition.y);

        transform.position = new Vector3(transform.position.x, Input.mousePosition.y - _offset.y, 0f);
#endif

        _currentYVel = Mathf.Lerp(vel, _currentYVel, Time.deltaTime * velocitySmoothing);
    }

    public void Open()
    {
        LeanTween.moveLocalY(gameObject, endPos.localPosition.y, animationLength).setEase(openCurve);
    }

    public void Close()
    {
        LeanTween.moveLocalY(gameObject, startPos.localPosition.y, animationLength).setEase(closeCurve);
    }
}
