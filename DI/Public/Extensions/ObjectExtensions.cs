using DIFeatures.Static;

namespace DIFeatures.Public.Extensions
{
  public static class ObjectExtensions
  {
    // TODO: throw exception?
    public static void InjectDependencies(this object self) =>
      DI.Features?.InjectInto(self); 
    
    public static void ReleaseDependencies(this object self) =>
      DI.Features?.Release(self);
  }
}