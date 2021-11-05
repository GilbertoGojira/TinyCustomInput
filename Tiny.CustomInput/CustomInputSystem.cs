using Unity.Collections;
using Unity.Tiny.Input;
using Unity.Entities;
using System;

namespace GilCat.CustomInput {
  public class CustomInputSystem : _CustomInputSystem {

    protected override void OnCreate() {
      base.OnCreate();
      DisableDuplicateSystems(typeof(CustomInputSystem));
    }

    /// <summary>
    /// Disable any system in the inheritance hierarchy that is different from the current system
    /// </summary>
    /// <param name="type"></param>
    void DisableDuplicateSystems(Type type) {
      if (type == null || type == typeof(SystemBase))
        return;
      var sys = World.GetExistingSystem(type);
      if (sys != null && sys != this)
        sys.Enabled = false;
      DisableDuplicateSystems(type.BaseType);
    }

    /// <summary>
    /// Is any key or mouse button currently held down?
    /// </summary>
    /// <returns></returns>
    public bool AnyKey() =>
      !m_inputState.keysPressed.IsEmpty || m_inputState.mousePressed != 0;

    /// <summary>
    /// Get the keys that are held down
    /// </summary>
    /// <returns></returns>
    public NativeList<KeyCode> GetKeys() =>
      m_inputState.keysPressed;

    /// <summary>
    /// Get a copy array of the keys that are held down
    /// </summary>
    /// <param name="allocator"></param>
    /// <returns></returns>
    public NativeArray<KeyCode> GetKeys(Allocator allocator) =>
      new NativeArray<KeyCode>(m_inputState.keysPressed, allocator);

    /// <summary>
    /// Is any key or mouse button currently held down on this frame? 
    /// </summary>
    /// <returns></returns>
    public bool AnyKeyDown() =>
      !m_inputState.keysJustDown.IsEmpty || m_inputState.mouseJustDown != 0;

    /// <summary>
    /// Get the keys that are held down on this frame
    /// </summary>
    /// <returns></returns>
    public NativeList<KeyCode> GetKeysDown() =>
      m_inputState.keysJustDown;

    /// <summary>
    /// Get a copy of the keys that are held down on this frame
    /// </summary>
    /// <param name="allocator"></param>
    /// <returns></returns>
    public NativeArray<KeyCode> GetKeysDown(Allocator allocator) =>
      new NativeArray<KeyCode>(m_inputState.keysJustDown, allocator);

    /// <summary>
    /// Is any key or mouse button released on this frame? 
    /// </summary>
    /// <returns></returns>
    public bool AnyKeyUp() =>
      !m_inputState.keysJustUp.IsEmpty || m_inputState.mouseJustUp != 0;

    /// <summary>
    /// Get the keys that were released in this frame
    /// </summary>
    /// <returns></returns>
    public NativeList<KeyCode> GetKeysUp() =>
      m_inputState.keysJustUp;

    /// <summary>
    /// Get a copy of the keys that were released in this frame
    /// </summary>
    /// <param name="allocator"></param>
    /// <returns></returns>
    public NativeArray<KeyCode> GetKeysUp(Allocator allocator) =>
      new NativeArray<KeyCode>(m_inputState.keysJustUp, allocator);
  }
}
