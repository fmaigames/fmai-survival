# Unity Scene Wiring Gate

Status: PENDING — wiring instructions only. This document is not evidence of a Unity build or device test.

## Prototype_01 scene

Create or use `Assets/Scenes/Prototype_01.unity` and configure:

1. Player GameObject
   - `CharacterController`
   - `PlayerController`
   - `PlayerStats`
   - `MobileInputBridge`
   - Assign the camera target when available.
2. Main Camera
   - `ThirdPersonCamera`
   - Target = Player transform.
   - MobileInputBridge is discoverable at runtime; explicit inspector reference is preferred.
3. MobileInputBridge
   - Movement uses the left half of the screen.
   - Look uses the right half.
   - Test touch release so movement/look return to zero.
4. Test terrain
   - Small bounded terrain.
   - Clear spawn point.
   - At least one visible obstacle for camera/movement testing.

## Gate

The scene remains PENDING until all of these are evidenced:

- Unity project opens without compile errors.
- `Prototype_01` loads successfully.
- Player can move with Android touch input.
- Camera can look with Android touch input.
- Desktop fallback still works where applicable.
- Android build succeeds.
- APK installs and launches on a real Android device.
- Movement and camera test cases pass on-device.

No APK or real-device PASS may be claimed from this document alone.
