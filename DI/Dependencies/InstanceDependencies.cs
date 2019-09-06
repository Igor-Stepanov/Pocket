using FeaturesDI.Registered;

namespace FeaturesDI.Dependencies
{
  internal struct InstanceDependencies
  {
    private readonly object _instance;
    private readonly Field[] _fields;

    public InstanceDependencies(object instance, Field[] fields)
    {
      _instance = instance;
      _fields = fields;
    }
    
    public void InjectWith(IFeatures features)
    {
      foreach (var field in _fields)
        field.Of(_instance).InjectWith(features.Registered(field.Type));
    }

    public void Release()
    {
      foreach (var field in _fields)
        field.Of(_instance).Release();
    }
  }
}