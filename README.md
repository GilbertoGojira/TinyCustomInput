# Tiny Asset Loader

This package intends to extend Tiny Input so that methods available in Unity legacy are mimic here alongside with extra functionality that will increase performance

## Getting Started

### Dependencies

* Requires Unity 2020.1.17f1 and will automatically import Tiny package 0.32.0-preview.54

### Installing

* Go to package manager and use `Add package from git url` to add this package. Alternatively clone this repo and use `Add package from Disk`.

### Using this package

* Make CustomInputSystem member of your system
```csharp
  public class MySystem : SystemBase {
    CustomInputSystem _inputSystem;
    protected override void OnCreate() {
      base.OnCreate();
      _inputSystem = World.GetOrCreateSystem<CustomInputSystem>();
    }
    ...
```
* Example on getting if any key was pressed
```csharp
    protected override void OnUpdate() {
      if (_inputSystem.AnyKey()) {
        var keys = _inputSystem.GetKeys();
        // Use keys in your job to do combined actions
        ...
      }
```

## Authors

Contributors names and contact info

Gilberto Catarino 
[![Linkedin](https://i.stack.imgur.com/gVE0j.png) LinkedIn](https://www.linkedin.com/in/gilberto-catarino-4ab685a)

## Version History

* 0.1
    * Initial Release

## Notes

This was tested on Windows, Mac and WebGL. iOS and Android might work but can't confirm right now.