# AlgoVizz

## Overview
AlgoVizz is a desktop application built with **WinForms** that visualizes sorting and pathfinding algorithms in real-time. Watch how algorithms work step-by-step with animated visualizations to better understand their behavior and performance.

### Features
- **Sorting Algorithms**: Insertion Sort, Merge Sort
- **Pathfinding Algorithm**: Breadth-First Search (BFS)
- **Adjustable Speed**: Slow, Normal, or Fast animation speeds
- **Interactive Grid**: Draw walls, set start/end points, and visualize paths
- **Color-Coded Visualization**: Different colors represent different states (comparing, visited, sorted, path)

## Setup & Run

### Requirements
- **.NET 10** or higher
- **Visual Studio 2022/2026** (Community or higher)

### Steps
1. **Clone the repository**

2. **Open in Visual Studio**
- Open `AlgoVizz.sln` in Visual Studio

3. **Build & Run**
- Press `Ctrl + F5` to build and run
- Or go to __Debug > Start Without Debugging__

### Usage
- **Sorting Tab**: Generate random arrays or input custom values, select algorithm and speed, then click "Start Animation"
- **Pathfinding Tab**: Click "Pathfinding (BFS)" button → Select draw mode (Wall/Start/End/Erase) → Click grid cells to draw → Set speed → Click "Start BFS"

## Technologies
- C# / WinForms (GDI+)
- .NET 10
- Git