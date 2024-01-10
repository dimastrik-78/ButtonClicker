using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace ResourceSystem
{
    public class MiningButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public event Action<float> OnUpButton;

        [SerializeField] private TextMeshProUGUI _holdTimeText;

        private IResource _resource;

        private float _basePoint;
        private float _power;
        private bool _isPressed;

        [Inject]
        private void Construct(IResource resource)
        {
            _resource = resource;
        }

        private void Awake()
        {
            BindEvent();
        }

        private void OnDestroy()
        {
            ExposeEvent();
        }

        private void Update()
        {
            if (_isPressed)
            {
                _power += Time.deltaTime;
                _holdTimeText.text = $"Hold time: {Math.Round(_power, 2)}";
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            
            OnUpButton?.Invoke(_basePoint * _power);
            _holdTimeText.text = "Hold time: 0";
            _power = 0;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        private void BindEvent()
        {
            OnUpButton += _resource.ResourceUpdate;
        }
        
        private void ExposeEvent()
        {
            OnUpButton -= _resource.ResourceUpdate;
        }

        public void SetParameters(float givePoint)
        {
            _basePoint = givePoint;
        }
    }
}