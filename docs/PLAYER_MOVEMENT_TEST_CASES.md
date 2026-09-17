# Player Movement QA — Test Cases

Status: PENDING — test plan only.

## Preconditions
- Unity 6 + URP prototype exists.
- Android build is available.
- Test device/emulator is available.

## Cases
1. Spawn: player appears at the configured spawn point.
2. Forward/back movement: touch input moves the player in both directions.
3. Strafe: left/right input moves the player correctly.
4. Camera: third-person camera follows smoothly without severe clipping.
5. Boundary: player cannot leave the intended test area unexpectedly.
6. Input recovery: releasing touch stops movement without runaway motion.
7. Scene reload: player can spawn and move after restarting the scene.
8. Performance: no obvious movement/input freeze during the short test.

## Evidence
Record build identifier, device/emulator, Android version, result per case, and any crash/log evidence.

## Gate
No VERIFIED status until the build is actually run and these cases have evidence. A documentation commit alone is not a gameplay PASS.
