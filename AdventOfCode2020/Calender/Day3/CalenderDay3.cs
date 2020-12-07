using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;
using AdventOfCode2020.Trajectory;
using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Models;
using Parser.Parsers;
using static AdventOfCode2020.Calender.Day3.Day3TobogganManager;

namespace AdventOfCode2020.Calender.Day3
{
    public class CalenderDay3 : ICalenderDay
    {
        public string GetName() => "Day 3: Toboggan Trajectory";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            var result2 = await GetSecondTask();
            return new List<IResultTask> {
                //result,
                result2
            };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day3.Input.txt";
            IEnumerable<IVector>? vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());

            var startingY = vectors.Select(point => point.Point).Max(point => point.Y);
            var startingVector = vectors.First(vector => vector.Point.X == 0 && vector.Point.Y == startingY);
            var trajectory = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 3),
                (TobogganMovmentKind.Down, 1),
            };

            TrajectoryConfiguration configuration = new TrajectoryConfiguration(new Day3TobogganManager(trajectory), vectors.ToList(), startingVector);
            var controller = new MapController(configuration);
            var steps = controller.Init();

            var count = steps.Count(step => step.Vector.GetType() == typeof(TreeObstacle));

            return new StringResultTask("Part 1", $"Answer: {count}");
        }

        private async Task<StringResultTask> GetSecondTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day3.Input.txt";
            var trajectory = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 1),
                (TobogganMovmentKind.Down, 1),
            };

            var trajectory2 = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 5),
                (TobogganMovmentKind.Down, 1),
            };

            var trajectory3 = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 7),
                (TobogganMovmentKind.Down, 1),
            };

            var trajectory4 = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 1),
                (TobogganMovmentKind.Down, 2),
            };

            var trajectory5 = new List<(TobogganMovmentKind movmentKind, int steps)>
            {
                (TobogganMovmentKind.Right, 3),
                (TobogganMovmentKind.Down, 1),
            };

            IEnumerable<IVector>? vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());
            var trajectoryCountObstacles = InitializeTrajectory(vectors.ToList(), trajectory).Count(step => step.Vector.GetType() == typeof(TreeObstacle));
            vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());
            var trajectory2CountObstacles = InitializeTrajectory(vectors.ToList(), trajectory2).Count(step => step.Vector.GetType() == typeof(TreeObstacle));
            vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());
            var trajectory3CountObstacles = InitializeTrajectory(vectors.ToList(), trajectory3).Count(step => step.Vector.GetType() == typeof(TreeObstacle));
            vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());
            var trajectory4CountObstacles = InitializeTrajectory(vectors.ToList(), trajectory4).Count(step => step.Vector.GetType() == typeof(TreeObstacle));
            vectors = await ParseHelper.GetInput(filePath, new Day3TobogganParser());
            var trajectory5CountObstacles = InitializeTrajectory(vectors.ToList(), trajectory5).Count(step => step.Vector.GetType() == typeof(TreeObstacle));

            var result = trajectoryCountObstacles * trajectory5CountObstacles * trajectory2CountObstacles * trajectory3CountObstacles * trajectory4CountObstacles;

            return new StringResultTask("Part 2", $"Answer: {result}");

            static List<IStep> InitializeTrajectory(List<IVector> vectors, List<(TobogganMovmentKind movmentKind, int steps)> trajectory)
            {
                var startingY = vectors.Select(point => point.Point).Max(point => point.Y);
                var startingVector = vectors.First(vector => vector.Point.X == 0 && vector.Point.Y == startingY);
                TrajectoryConfiguration configuration = new TrajectoryConfiguration(new Day3TobogganManager(trajectory), vectors, startingVector);
                var controller = new MapController(configuration);

                var steps = controller.Init();
                return steps;
            }
        }
    }
}