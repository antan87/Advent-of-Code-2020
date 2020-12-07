using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Models.Commands;
using AdventOfCode2020.Trajectory.Structs;
using AdventOfCode2020.Trajectory.Structs.Interfaces;

namespace AdventOfCode2020.Calender.Day3
{
    public class Day3TobogganManager : IManager
    {
        private IPoint? CurrentPosition { get; set; }
        private IEnumerable<(TobogganMovmentKind movmentKind, int steps)> Trajectory { get; }

        private event EventHandler<IEnumerable<IStep>>? TrajectoryIterationCompletedEvent;

        public Day3TobogganManager(IEnumerable<(TobogganMovmentKind movmentKind, int steps)> trajectory)
        {
            this.Trajectory = trajectory;
        }

        public ICommand? GetNextCommand(IMap map, IEnumerable<IStep> steps)
        {
            if (map.Vectors == null || map.CurrentPosition == null)
                throw new NullReferenceException();

            if (this.CurrentPosition == null)
                this.CurrentPosition = new Point2D(map.CurrentPosition.Point.X, map.CurrentPosition.Point.Y);

            if (!map.Vectors.Any(vector => vector.Point.Y == this.CurrentPosition?.Y))
                return null;

            if (this.CurrentPosition == null || map.Vectors == null)
                throw new NullReferenceException();

            foreach (var moveAction in this.Trajectory)
            {
                for (int index = 0; index < moveAction.steps; index++)
                {
                    this.Move(moveAction.movmentKind);
                    if (!map.Vectors.Any(vector => vector.Point.X == this.CurrentPosition?.X))
                        this.CurrentPosition = new Point2D(0, this.CurrentPosition.Y);
                    else if (!map.Vectors.Any(vector => vector.Point.Y == this.CurrentPosition?.Y))
                        return index == 0 ? null : new MoveCommand(new Point2D(this.CurrentPosition.X, this.CurrentPosition.Y + 1));
                }
            }

            return new MoveCommand(this.CurrentPosition);
        }

        private void UpdatePosition(int x, int y)
        {
            if (this.CurrentPosition == null)
                throw new Exception("Cant move position is null");

            this.CurrentPosition = new Point2D(x, y);
        }

        private void Move(TobogganMovmentKind kind)
        {
            if (this.CurrentPosition == null)
                throw new Exception("Cant move position is null");

            switch (kind)
            {
                case TobogganMovmentKind.Up:
                    this.UpdatePosition(this.CurrentPosition.X, this.CurrentPosition.Y + 1);
                    break;

                case TobogganMovmentKind.Down:
                    this.UpdatePosition(this.CurrentPosition.X, this.CurrentPosition.Y - 1);
                    break;

                case TobogganMovmentKind.Left:
                    this.UpdatePosition(this.CurrentPosition.X - 1, this.CurrentPosition.Y);
                    break;

                case TobogganMovmentKind.Right:
                    this.UpdatePosition(this.CurrentPosition.X + 1, this.CurrentPosition.Y);
                    break;
            }
        }

        private void OnTrajectoryIterationCompleted(IEnumerable<IStep> steps)
        {
            this.TrajectoryIterationCompletedEvent?.Invoke(this, steps);
        }

        public enum TobogganMovmentKind
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}