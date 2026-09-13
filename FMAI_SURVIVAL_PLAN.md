# FMAI Survival — Build Plan

## Project
Original Android-first online survival game inspired by the survival genre and feature set of games such as LifeAfter, without copying proprietary assets, maps, story, characters, UI, or other copyrighted material.

## Product Goal
Create a rapid playable vertical slice first, then expand toward a larger online survival experience.

## Core Systems
- Character / third-person movement
- Costumes / outfits
- Vehicles and helicopter interaction
- Weapons and combat
- Food / cooking
- Health and hunger
- Inventory and loot
- Crafting
- Base / shelter
- Enemies / zombies or other original enemies
- Open-world exploration
- Missions / story
- Online multiplayer / co-op
- Save / load
- Android build

## Rapid Prototype Target
`Spawn → Explore → Loot → Weapon → Enemy → Food → Craft → Shelter → Helicopter → Mission`

## Rapid Prototype Scope
- 3D player movement
- Character + costume
- One weapon
- One enemy type
- Health / hunger
- Food use
- Inventory + loot
- Basic crafting
- Small shelter
- Helicopter interaction
- Small playable map
- Save / load
- Basic online connection where technically practical
- Android build

## Engine Direction
Preferred prototype stack: Unity 6 + URP.

Use ready-made, properly licensed/free-to-use assets and systems where practical. Do not extract or reuse proprietary LifeAfter assets.

## Proposed Unity Structure
```text
FMAI_Survival/
├── Assets/
│   ├── Scripts/
│   │   ├── Player/
│   │   │   ├── PlayerController.cs
│   │   │   ├── PlayerStats.cs
│   │   │   └── ThirdPersonCamera.cs
│   │   ├── Inventory/
│   │   │   ├── InventorySystem.cs
│   │   │   └── ItemData.cs
│   │   ├── Enemies/
│   │   │   ├── EnemyAI.cs
│   │   │   └── EnemySpawner.cs
│   │   ├── Crafting/
│   │   │   └── CraftingSystem.cs
│   │   ├── World/
│   │   │   ├── LootSpawner.cs
│   │   │   ├── HelicopterInteraction.cs
│   │   │   └── ShelterZone.cs
│   │   └── Mission/
│   │       └── MissionManager.cs
│   ├── Prefabs/
│   ├── Scenes/
│   │   └── Prototype_01.unity
│   └── Models/
```

## Starter Systems / Asset Direction
Potential components to evaluate:
1. Unity Starter Assets Third Person Controller — free
2. Invector Third Person Shooter or Opsive UCC — commercial options
3. Emerald AI or NodeCanvas — enemy AI options
4. Survival Engine — survival-system option
5. Joystick Pack / Easy Touch — mobile controls
6. POLYGON Survival-style environment assets or other properly licensed alternatives

Selection must be based on current licensing, Android compatibility, performance, and whether the asset can be used legally in the project.

## Initial Script Concepts
Starter systems to implement and validate:
- `PlayerStats.cs`: health/hunger decay, eating, damage
- `PlayerController.cs`: mobile third-person movement
- `InventorySystem.cs`: item storage, add/remove/has
- `EnemyAI.cs`: detection, pursuit, attack and cooldown
- `LootSpawner.cs`: randomized loot spawning
- `Pickup.cs`: pickup interaction

These are prototypes only and must be hardened before production use: cooldowns, null checks, NavMesh setup, serialization, mobile input, camera handling, duplicate-item behavior, and performance all require validation.

## 3-Day Prototype Direction
### Day 1
- Unity project setup
- Player movement
- Mobile joystick/input
- Terrain / small map
- Loot + pickup
- First enemy

### Day 2
- Weapon system
- Combat
- Crafting UI
- Helicopter trigger
- Basic gameplay objective

### Day 3
- Android build configuration
- Build APK
- Install on phone
- Real-device test
- Fix critical issues

## Android Direction
Initial target: Android-first. Proposed settings from the planning draft (must be checked against the selected Unity version before final build):
- Minimum API around Android 8 / API 26
- IL2CPP
- ARM64
- Vulkan / OpenGLES3 as supported by the selected Unity version/device
- Mobile quality profile

## Online Multiplayer Strategy
Do not let multiplayer block the first playable prototype. Build the core loop offline/local first, then integrate a suitable networking stack for co-op and synchronize player state, inventory, combat, enemies, and mission state incrementally.

## Build Philosophy
- Rapid prototype over premature AAA scope
- Reuse licensed/free systems instead of rebuilding commodity systems
- Original FMAI branding, story, UI and game identity
- Android playable build is the first concrete milestone
- Real-device verification required before calling an APK release-ready
- No false PASS: each milestone is marked VERIFIED, PENDING, or FOUNDATION based on evidence

## First Milestones
1. Repository / plan — FOUNDATION
2. Unity project skeleton — PENDING
3. Player movement — PENDING
4. Loot + inventory — PENDING
5. Enemy + combat — PENDING
6. Food / hunger — PENDING
7. Crafting — PENDING
8. Shelter — PENDING
9. Helicopter interaction — PENDING
10. Android APK prototype — PENDING
11. Real-device test — PENDING
12. Online co-op — PENDING

## IP / Licensing Rule
The project may be inspired by survival-game mechanics, but must use original or properly licensed assets and content. Do not copy LifeAfter proprietary files, maps, characters, story text, UI, branding, or extracted assets.
