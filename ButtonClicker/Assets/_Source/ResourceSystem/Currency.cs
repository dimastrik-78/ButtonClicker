using System;
using UnityEngine;

namespace ResourceSystem
{
    public class Currency : IResource
    {
        public event Action<float> OnChangeResource;

        private float _resourceValue;

        public float ResourceValue
        {
            get => _resourceValue;
            set
            {
                _resourceValue = value;
                OnChangeResource?.Invoke(_resourceValue);
            }
        }

        public void ResourceUpdate(float value)
        {
            ResourceValue += value;
        }
    }
}