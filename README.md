
# **Tetris Blaster**

Tetris Blaster is a fast-paced, browser-based action game where you pilot a Tetris-shaped spaceship and shoot other Tetris pieces at asteroids! The game combines the nostalgia of Tetris with the thrill of an asteroid shooter, creating a one-of-a-kind experience.

---

## **Gameplay**
- **Objective**: Pilot your Tetris-shaped ship through an asteroid field, destroy as many asteroids as you can, and avoid collisions.
- **Controls**:
  - **Arrow Keys or WASD**: Move your Tetris ship.
  - **Right Mouse Button**: Fire Tetris-shaped projectiles (e.g., `PieceL`, `PieceO`, etc.).
- **Unique Mechanic**:
  - Your ship itself is a **Tetris piece**!
  - Fire other **Tetris pieces** as projectiles to destroy asteroids.
- **Game Over**:
  - The game ends when your Tetris ship collides with an asteroid.
  - Your score (number of asteroids destroyed) is displayed on the game over screen.
  - A "Restart" button lets you play again.

---

## **Features**
- **Tetris-Themed Gameplay**:
  - Pilot a Tetris piece as your ship.
  - Shoot other randomly selected Tetris pieces at asteroids.
- **Dynamic Asteroid Field**:
  - Randomly generated asteroids keep the game challenging and fresh.
- **Explosions**:
  - Asteroids and Tetris pieces explode with satisfying animations.
- **Score Tracking**:
  - See how many asteroids you destroyed on the Game Over screen.
- **Web-Ready**:
  - Fully playable in modern browsers using WebGL.

---

## **Setup and Installation**
### **To Play Locally:**
1. Clone or download the repository.
2. Open a terminal and navigate to "tetris_hack\web_build" folder containing the WebGL build.
3. Start a local web server:
   - Python (for Python 3):
     ```bash
     python -m http.server
     ```
   - Node.js (if `http-server` is installed):
     ```bash
     http-server
     ```
4. Open the game in your browser:
   - Navigate to `http://localhost:8000`.

### **To Play Online:**
The game is hosted online. Visit the following link to play:  
[Play Tetris Blaster](http://tetris-aws-hack.s3-website-us-east-1.amazonaws.com/)

---

## **Development**
### **Technologies Used**
- **Unity**: Built with Unity 3D using WebGL for browser compatibility.
- **Amazon Q**: Used for development of all the gameplay logics
- **Amazon S3**: Game hosted on AWS S3 for public access.

### **How to Build**
1. Open the project in Unity.
2. Go to `File > Build Settings`.
3. Select **WebGL** as the platform and click **Build**.
4. Upload the generated files to a hosting platform (e.g., AWS S3).

---

## **Customization**
### **How to Change Game Elements**
- **Tetris Ship and Projectiles**:
  Modify the `ShipShooter` script to add new Tetris shapes as projectiles or even change the ship itself to other Tetris pieces.
  
- **Asteroid Speed/Spawn Rate**:
  Modify the `Asteroid Field` script in Unity to adjust the spawn frequency and speed of the asteroids.
  
- **Game Over Panel**:
  Customize the **GameOverPanel** UI in Unity's Canvas to match your desired style.

---




## **License**
This project is licensed under the [MIT License](LICENSE). Feel free to use and modify it for your own purposes.

