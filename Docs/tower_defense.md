# Tower Defense Practice Project – Actionable Roadmap （ChatGPT）

**Target duration:** ~10–15 focused hours
**Engine assumption:** Unity (MonoBehaviour-based)
**Goal:** Internalize TD fundamentals and produce a reusable jam skeleton

---

## Phase 0 — Constraints (Lock These First)

Before writing any code:

* [ ] Single path only
* [ ] Fixed build nodes (no free placement)
* [ ] One enemy type
* [ ] One tower type
* [ ] No upgrades
* [ ] No status effects
* [ ] No fancy UI

If you violate these early, you are over-scoping.

---

## Phase 1 — Enemy Pathing Core (Mandatory, Do Not Skip)

**Objective:** Enemies reliably move from start to end.

### Implementation

* [ ] Create a `Path` object containing ordered waypoints
* [ ] Enemy has:

  * [ ] `speed`
  * [ ] `hp`
  * [ ] `currentWaypointIndex`
* [ ] Move enemy toward current waypoint
* [ ] On reach → increment index
* [ ] On final waypoint → damage base & destroy enemy

### Debug Requirements

* [ ] Path visible via Gizmos
* [ ] Waypoints labeled or drawn
* [ ] Enemy HP bar visible

**Success criteria:**
You can spawn 100 enemies and all reach the base correctly.

---

## Phase 2 — Tower Targeting & Damage Loop (Mandatory)

**Objective:** Towers can consistently kill enemies.

### Implementation

* [ ] Tower has:

  * [ ] `range`
  * [ ] `fireRate`
  * [ ] `damage`
* [ ] Cooldown timer logic
* [ ] Target selection:

  * [ ] First enemy in range (by path progress)
* [ ] Damage application
* [ ] Enemy death → cleanup + reward currency

### Debug Requirements

* [ ] Range shown via Gizmos
* [ ] Visual indication of targeting (line / flash)
* [ ] Log or counter of kills

**Success criteria:**
A single tower can stop a small wave but fails on larger ones.

---

## Phase 3 — Placement & Economy (Minimal Viable)

**Objective:** Player decisions matter.

### Implementation

* [ ] Predefined build nodes
* [ ] Click node → place tower
* [ ] Currency system:

  * [ ] Starting gold
  * [ ] Cost per tower
  * [ ] Gold on enemy death
* [ ] Placement fails if insufficient gold

### Debug Requirements

* [ ] Build nodes visibly highlighted
* [ ] Gold displayed (text is fine)

**Success criteria:**
Placing a tower early vs late changes outcome.

---

## Phase 4 — Waves & Game Flow (Mandatory)

**Objective:** The game has structure.

### Implementation

* [ ] Wave config structure:

  * [ ] Enemy count
  * [ ] Spawn interval
* [ ] Sequential wave execution
* [ ] Base HP
* [ ] Lose condition

Optional (but recommended):

* [ ] Manual “Start Wave” button

### Debug Requirements

* [ ] Current wave displayed
* [ ] Remaining enemies counter

**Success criteria:**
Game reliably ends in win or loss.

---

## Phase 5 — Data-Driven Refactor (Critical Learning Step)

**Objective:** Separate data from behavior.

### Refactor Checklist

* [ ] Tower stats moved to ScriptableObject
* [ ] Enemy stats moved to ScriptableObject
* [ ] Wave definitions data-driven
* [ ] No hardcoded numbers in logic

**Success criteria:**
You can create a new enemy or tower without writing new code.

---

## Phase 6 — One Controlled Variant (Choose ONE)

Only do this **after everything above is stable**.

### Option A: Arknights-Style Blocking (Recommended)

* [ ] Enemies stop when blocked
* [ ] Tower has block count
* [ ] Multiple enemies queue behind blocker

### Option B: Path Split (Lower Risk Alternative)

* [ ] One fork in path
* [ ] Enemies choose randomly
* [ ] Forces coverage decisions

**Do NOT combine variants.**

---

## Phase 7 — Jam Stress Test

**Objective:** Prove jam readiness.

* [ ] Remove half your UI
* [ ] Add a new enemy in 10 minutes
* [ ] Add a new tower in 10 minutes
* [ ] Break balance intentionally, then fix it

If you cannot do this quickly, you are not jam-ready.

---

## Phase 8 — Template Freeze

* [ ] Stop adding features
* [ ] Comment core systems
* [ ] Save as “TD_Jam_Template”
* [ ] Write a 1-page README:

  * Controls
  * Extension points
  * Known limitations

---

# Final Success Definition

You are **ready for TD in game jams** when:

* You are bored implementing baseline TD
* Bugs are predictable, not mysterious
* New mechanics feel like *variations*, not rewrites
* You can explain your TD in one sentence
