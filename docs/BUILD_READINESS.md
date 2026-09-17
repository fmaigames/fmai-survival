# FMAI Survival — Build Readiness Gate

Status: PENDING — evidence gate only. No Unity build or APK PASS is claimed.

## Verified code foundation

- `PrototypeBootstrap` now creates `MobileInputBridge` and uses `ThirdPersonCamera`.
- `PlayerController` consumes `MobileInputBridge.Move` with desktop fallback.
- `ThirdPersonCamera` consumes `MobileInputBridge.Look` with desktop fallback.
- Prototype runtime spawns a test ground, shelter, player, light, enemies, loot and prototype combat systems.

## Current blockers

1. `ProjectSettings/ProjectVersion.txt` is not present on `main`.
2. `Assets/Scenes/Prototype_01.unity` is not present on `main`.
3. Therefore a complete Unity project/scene cannot yet be verified from repository evidence.
4. No successful Unity Android build has been verified.
5. No APK installation or real-device test has been verified.

## Important architecture note

`PrototypeFollowCamera` and `PrototypeWorldSpawner` remain in the repository as prototype code, but the current `PrototypeBootstrap` path uses `ThirdPersonCamera` and `PrototypeSpawner`. These older/alternate prototype components should not be treated as active scene wiring unless a future scene explicitly references them.

## Release gate

Do not mark VERIFIED until evidence exists for:

- Unity project opens without compile errors.
- `Prototype_01` loads.
- Android touch movement works.
- Android touch camera look works.
- Android build succeeds.
- APK installs and launches on a real Android device.
- Movement/camera QA cases pass on-device.

This document intentionally records blockers rather than fabricating build success.