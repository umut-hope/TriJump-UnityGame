# 🔺 Tri-Jump

> ⚠️ **This project is currently in a prototype / early development stage.** Features, mechanics, and visuals are subject to change.

**Tri-Jump** is a 2D vertical-climbing arcade game built in Unity where the player controls a triangle character that jumps between rotating circles to climb as high as possible. Tap to jump, stick to circles, and rack up your score — but don't fall behind the camera!

## 🎮 Gameplay

- **Tap / Click** to jump upward or launch off a circle.
- **Stick** to rotating circles on contact and use their momentum to aim your next jump.
- **Score** a point for each new circle you land on.
- **Survive** — if you fall below the camera's view, it's game over!

## ✨ Current Features (Prototype)

- Triangle player with physics-based jumping and sticking mechanics
- Procedurally spawned rotating circles with randomized speed and direction
- Upward-scrolling camera that follows the player
- Score tracking system (displayed via TextMeshPro UI)
- Main menu, pause menu, and game over screens
- Retry and back-to-menu functionality
- Fail detection when the player drops off-screen
- Custom game art assets (player triangle, circle ring, UI icons)

## 🛠️ Tech Stack

| Component | Details |
|-----------|---------|
| **Engine** | Unity 6 (`6000.2.11f1`) |
| **Language** | C# |
| **Rendering** | Universal Render Pipeline (URP) |
| **UI Text** | TextMesh Pro |
| **Input** | Unity Input System |
| **Physics** | Rigidbody2D / Collider2D |

## 📁 Project Structure

```
Assets/
├── Scenes/                  # Unity scene files
├── Tri-Jump Assets/         # Sprites & UI art (triangle, circle, icons)
├── Settings/                # URP render pipeline settings
├── TextMesh Pro/            # TMP essentials
├── GameManager.cs           # Game state, menus, pause/resume/retry
├── PlayerMovement.cs        # Jump input & physics
├── StickController.cs       # Stick-to-circle & launch mechanics
├── CircleSpawner.cs         # Procedural circle generation
├── CircleRotate.cs          # Random rotation per circle
├── CircleScore.cs           # Per-circle scored flag
├── ScoreManager.cs          # Score tracking & UI
├── FailDetector.cs          # Off-screen game over detection
└── Camera.cs                # Upward-only camera follow
```

## 🚀 Getting Started

### Prerequisites

- **Unity 6** (version `6000.2.11f1` or compatible)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/umut-hope/TriJump-UnityGame.git
   ```
2. Open the project in Unity Hub.
3. Open the main scene from `Assets/Scenes/`.
4. Press **Play** ▶️ in the Unity Editor.

## 🗺️ Roadmap (Planned)

Since the project is still in its prototype phase, here are potential areas for future development:

- [ ] Mobile touch input support
- [ ] Sound effects & background music
- [ ] High score persistence
- [ ] Difficulty scaling over time
- [ ] Visual polish (particles, animations, backgrounds)
- [ ] Additional obstacle types

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Okan Umut Özen**

---

*This README reflects the current prototype state of the project and will be updated as development progresses.*
