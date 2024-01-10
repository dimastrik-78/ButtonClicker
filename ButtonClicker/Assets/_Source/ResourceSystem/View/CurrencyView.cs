using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace ResourceSystem.View
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;

        private IResource _resource;

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
        
        private void BindEvent()
        {
            _resource.OnChangeResource += UpdateCurrency;
        }
        
        private void ExposeEvent()
        {
            _resource.OnChangeResource -= UpdateCurrency;
        }

        private void UpdateCurrency(float value)
        {
            _currencyText.text = $"Currency: {Math.Round(value, 2)}";
        }
    }
}