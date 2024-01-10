using System;

namespace ResourceSystem
{
    public interface IResource
    {
        event Action<float> OnChangeResource;
        float ResourceValue { get; set; }
        void ResourceUpdate(float value);
    }
}