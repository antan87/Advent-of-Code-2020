using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Calender.Day3;
using AdventOfCode2020.Trajectory;
using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Models;
using Parser.Parsers;
using Xunit;
using static AdventOfCode2020.Calender.Day3.Day3TobogganManager;

namespace Test.Day3
{
    public class Day3TobogganManagerTests
    {
        [Theory]
        [MemberData(nameof(TrajectoryTestData))]
        public async Task Day3TobogganManager_Count_TreeObstacle((TobogganMovmentKind movmentKind, int steps)[] trajectory, int startingPointX, int startingPointY, int expectedResult)
        {
            string input = "Test.Day3.Input.txt";
            var vectors = await ParseHelper.GetInput(input, new Day3TobogganParser());

            IVector? startingVector = vectors.ToList().First(vector => vector.Point.X == startingPointX && vector.Point.Y == startingPointY);
            List<IStep> trajectorySteps = InitializeTrajectory(vectors, startingVector, trajectory.ToList());
            var trajectoryCountObstacles = trajectorySteps.Count(step => step.Vector.GetType() == typeof(TreeObstacle));

            static List<IStep> InitializeTrajectory(IEnumerable<IVector> vectors, IVector startingVector, List<(TobogganMovmentKind movmentKind, int steps)> trajectory)
            {
                TrajectoryConfiguration configuration = new TrajectoryConfiguration(new Day3TobogganManager(trajectory), vectors.ToList(), startingVector);
                var controller = new MapController(configuration);

                var steps = controller.Init();
                return steps;
            }

            Assert.Equal(expectedResult, trajectoryCountObstacles);
        }

        public static IEnumerable<object[]> TrajectoryTestData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 1), (TobogganMovmentKind.Down, 1) }, 0, 10, 2 },
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 3), (TobogganMovmentKind.Down, 1) }, 0, 10, 7 },
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 5), (TobogganMovmentKind.Down, 1) }, 0, 10, 3 },
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 7), (TobogganMovmentKind.Down, 1) }, 0, 10, 4 },
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 1), (TobogganMovmentKind.Down, 2) }, 0, 10, 2 },
                    new object[] {new (TobogganMovmentKind movmentKind, int steps)[]{(TobogganMovmentKind.Right, 1), (TobogganMovmentKind.Down, 13) }, 0, 10, 1 },
                };
            }
        }
    }
}