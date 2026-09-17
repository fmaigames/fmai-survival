# FMAI Survival — Player Movement Task

## Status
PENDING — specification only. No Unity build or device verification is claimed.

## Goal
Implement the first playable movement slice for the Android-first survival prototype:

`Spawn → Move → Explore`

## Unity target
- Unity 6 + URP
- Third-person camera
- Android-first input
- Small test terrain

## Required behavior
1. Player spawns at a valid start position.
2. Player can move forward/back/left/right.
3. Camera follows the player without exposing the player outside the intended test area.
4. Mobile input supports touch/virtual joystick or the selected licensed input system.
5. Movement remains functional without combat, loot, crafting, or multiplayer dependencies.

## Safety / quality gates
- No copied proprietary assets, characters, maps, story, UI, or branding.
- Avoid null-reference-prone singleton assumptions.
- Keep movement and camera logic separated enough to test independently.
- Do not mark this task VERIFIED until a Unity build is successfully produced and movement is observed on an emulator or real Android device.

## Agent handoff
- Game Lead: own scope and integration.
- Android: validate mobile input/performance constraints.
- QA: define and execute movement test cases when a build exists.
- Safety: check IP/licensing and excluded adult/sexual mechanics.

## Evidence required for VERIFIED
- Unity project files committed.
- Successful build evidence.
- Emulator or real-device movement test evidence.
- Any critical failures recorded rather than hidden.
