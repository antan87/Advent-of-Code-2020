using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Models;
using AdventOfCode2020.Trajectory.Models.Commands;

namespace AdventOfCode2020.Trajectory
{
    public class MapController
    {
        private event EventHandler<IStep> MoveCommandEvent;

        public MapController(TrajectoryConfiguration configuration)
        {
            Configuration = configuration;
            Map = CreateMap(configuration.Vectors, configuration.StartingPosition);
        }

        public List<IStep> Init()
        {
            this.ProcessCommands();
            return Steps;
        }

        private void ProcessCommands()
        {
            if (this.Configuration == null || this.Configuration?.Manager == null)
                return;

            ICommand? command = this.Configuration.Manager.GetNextCommand(this.Map, this.Steps);
            while (command != null)
            {
                this.InvokeCommand(command);
                command = this.Configuration.Manager.GetNextCommand(this.Map, this.Steps);
            }
        }

        private void InvokeCommand(ICommand command)
        {
            switch (command)
            {
                case IncreaseMap increaseMapCommand:
                    {
                        if (this.Map.Vectors == null)
                            return;

                        this.Map.Vectors.AddRange(increaseMapCommand.NewNectors);
                    }
                    break;

                case MoveCommand moveCommand:
                    {
                        if (this.Map.Vectors == null)
                            return;

                        var newPosition = this.Map.Vectors.First(vector => vector.Point.X == moveCommand.Point.X && vector.Point.Y == moveCommand.Point.Y);
                        this.Map = this.Map with { CurrentPosition = newPosition };
                        var step = new Step(moveCommand, this.Map.CurrentPosition);
                        this.Steps.Add(step);
                        this.OnMoveCommandCompleted(step);
                    }
                    break;
            }
        }

        private void OnMoveCommandCompleted(Step newPosition)
        {
            this.MoveCommandEvent?.Invoke(this, newPosition);
        }

        private TrajectoryConfiguration Configuration { get; }
        private Map Map { get; set; }
        private List<IStep> Steps { get; } = new List<IStep>();

        private Map CreateMap(List<IVector>? vectors, IVector? startingPosition)
        {
            if (vectors == null || startingPosition == null)
                return new Map();

            return new Map { Vectors = vectors, CurrentPosition = startingPosition };
        }
    }
}