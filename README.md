# AI Final Project – Unity Game with AI Agent

This is the final project for the **CENG 3511: Artificial Intelligence** course. The goal was to design and implement an AI model capable of playing a Unity game environment using reinforcement learning techniques.

## 🎮 Game Description

The project features a Unity-based 2D side-scroller game where the player character must navigate an environment filled with pipes (similar to Flappy Bird). The AI agent learns to play the game by interacting with the environment and receiving feedback in the form of rewards based on its performance (e.g., number of pipes passed).

The AI acts as the **player**, learning how to survive longer and pass more obstacles.

## 🧠 AI Model

### Approach: Reinforcement Learning (RL)

The AI agent was trained using **Proximal Policy Optimization (PPO)** via Unity ML-Agents Toolkit. PPO is a policy-gradient method well-suited for continuous control tasks like our flappy-style game.

- **Training Method**: Unity ML-Agents Toolkit (3.0.0)
- **Max Step**: 10000
- **Steps of Training**:1.000.000 
- **Algorithm**: PPO (Proximal Policy Optimization)
- **Agent Design**: Bird-like character with upward movement controlled by learned actions

- You can find more info about the model in 5observation2period-V2 folder

## 🛠️ Tools & Frameworks

- **Game Engine**: Unity 6000.0.30f1
- **AI Toolkit**: Unity ML-Agents 3.0.0
- **Scripting**: C#
- **Training Backend**: Python 3.10.11 (ML-Agents 1.1.0 + PyTorch 2.2.1)
- **OS Tested**: Windows 11

## 📦 Installation

- Install Unity game engine
- Open package manager in Unity
- Install ML Agents package

## If you want to train your  own model

- Do the installation steps
- Install python 3.10.11 (it doesn't work with python 3.12 or after, see docs for more info https://unity-technologies.github.io/ml-agents/Installation/ )
- Go to your games folder
- Open CMD in your games project folder
- Create a virtual enviroment with python 3.10.11
```bash
py -3.10 -m venv mlagents-env
```
- Activate the virtual enviroment
```bash
.\mlagents-env\Scripts\activate
```
- Install mlagents library
```bash
pip install mlagents
```
- Install pytorch with this for gpu usage
```bash
pip install torch~=2.2.1 --index-url https://download.pytorch.org/whl/cu121
```
- In unity you should create a script that extends Agent class and attach that script to your player game object
- Your Agent script should be according to your own player's logic
- Use mlagents-learn to start training
```bash
mlagents-learn
```
- Click the play button on unity to start training your agent

## If you want just the build
[👉 Download the game here](https://xanthumr.itch.io/flappy-bird-ai)





