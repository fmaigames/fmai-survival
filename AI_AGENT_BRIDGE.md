# FMAI Survival — FM Home AI Agent Bridge

## Purpose

FMAI Survival uses the FM Home AI-Bridge architecture as its control-plane contract while keeping Survival's game code and repository isolated.

## Source of agent architecture

- Source repository: `fmmustaqeem/fm-home`
- Bridge area: `ai-bridge/`
- Contracts include task state, execution, adapters, providers, and output contracts.
- Available provider adapters in FM Home: DeepSeek, Gemini, and Qwen.

## Survival agent roles

1. **Game Lead Agent** — gameplay loop and implementation planning.
2. **Survival Systems Agent** — enemies, loot, food, crafting, shelter.
3. **World/Mission Agent** — exploration, map flow, helicopter and missions.
4. **Android Agent** — mobile controls, performance and build readiness.
5. **QA Agent** — tests, regression checks and evidence-based PASS/FAIL.
6. **Safety Agent** — enforces project exclusions and rejects sexual/adult content or marriage/child mechanics.

## Execution policy

- FM Home is the control-plane/reference architecture.
- FMAI Survival remains the execution repository.
- No automatic provider is considered active until a real successful run is verified.
- No paid provider/billing is enabled by this bridge.
- Failed provider runs must be reported as failed; never marked PASS by assumption.
- Production/release claims require verifiable GitHub evidence.

## Current provider status

- DeepSeek: configured/reference provider; successful Survival execution not yet verified.
- Gemini: configured/reference provider; successful Survival execution not yet verified.
- Qwen: available in FM Home architecture; Survival execution not yet verified.

## Next execution target

Start with one low-risk Survival task through the FM Home-style task contract, verify the result, then expand to the specialist agents.
