# FMAI Survival

An original Android-first survival game project by FM AI Games. The goal is to build a small, playable vertical slice first, then expand it into a larger survival experience only after the core loop is working on a real device.

The project may take broad inspiration from the survival genre, but all FM code, characters, story, UI, maps, branding, and assets must be original or properly licensed. Do not extract or reuse proprietary LifeAfter content.

## First playable loop

```text
Spawn → Explore → Loot → Equip → Encounter → Eat → Craft → Shelter → Helicopter → Mission
```

## Planned vertical slice

- Third-person player movement and mobile controls.
- Health and hunger.
- Inventory and loot pickup.
- One weapon and basic combat.
- One original enemy type.
- Food consumption.
- Basic crafting.
- Small shelter/base.
- Helicopter interaction and a simple objective.
- Small test map and save/load foundation.
- Android debug build and real-device test.

This is the target scope, not a statement that these systems or an APK are already complete.

## Engine direction

- **Target:** Android first.
- **Proposed engine:** Unity 6 with URP.
- **Input:** touch controls and mobile joystick.
- **Assets:** free/open-source or otherwise properly licensed assets, subject to license and Android compatibility review.
- **Networking:** defer online co-op until the offline/local core loop is playable and stable.

Use proven free starter systems where practical instead of spending time recreating standard movement, input, inventory, or UI foundations. Confirm each component's current license, compatibility, and redistribution terms before inclusion.

## Development roadmap

1. Create and validate the Unity project skeleton.
2. Implement player movement, camera, and mobile input.
3. Add a small environment, loot, and pickup interactions.
4. Add one enemy, one weapon, health, and combat.
5. Add food, hunger, inventory, and basic crafting.
6. Add a shelter and helicopter interaction.
7. Build an Android APK and test it on a physical device.
8. Expand progression, missions, vehicles, content, and co-op only after the prototype is stable.

See [FMAI_SURVIVAL_PLAN.md](FMAI_SURVIVAL_PLAN.md) for the detailed planning document.

## Current milestone status

| Milestone | Status |
|---|---|
| Repository and project plan | FOUNDATION |
| Unity project skeleton | PENDING |
| Player movement and mobile controls | PENDING |
| Loot and inventory | PENDING |
| Enemy and combat | PENDING |
| Food, hunger, and crafting | PENDING |
| Shelter and helicopter interaction | PENDING |
| Android APK prototype | PENDING |
| Physical-device testing | PENDING |
| Online co-op | PENDING |

Do not mark a milestone VERIFIED without build/test output or real-device evidence.

## Local-first development

- Prefer local development and offline-capable gameplay.
- Avoid paid services and unnecessary cloud dependencies during the first prototype.
- Do not make multiplayer a blocker for the first playable build.
- Keep generated builds and large media out of source control unless they are essential.
- Preserve third-party license files and attribution.

## Build status

A playable Unity build and Android APK are not claimed by this README. Build instructions will be added once the Unity project structure and exact editor/toolchain version are present and verified.

## Intellectual property

FMAI Survival is an independent project. Genre inspiration does not grant permission to reuse another game's source code, assets, maps, characters, narrative, branding, or UI. Use original work or assets with documented licenses and retain all required notices.