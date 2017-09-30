namespace HoundMazePathFinder.Tests
{
    using HoundMazePathFinder.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    [TestClass]
    public class HoundMazePathFinderTests
    {
        private List<bool[]> map;
        private SearchParameters findingParameters;

        [TestInitialize]
        public void Initialize()
        {
            this.map = new List<bool[]>();
            for (int y = 0; y < 5; y++)
            {
                this.map.Add(new bool[7]);
                for (int x = 0; x < 7; x++)
                    map[y][x] = true;
            }

            var startLocation = new Point(1, 2);
            var endLocation = new Point(5, 2);
            this.findingParameters = new SearchParameters(startLocation, endLocation, map);
        }

        private void AddWallWithGap()
        {

            this.map[4][3] = false;
            this.map[3][3] = false;
            this.map[2][3] = false;
            this.map[1][3] = false;
            this.map[1][4] = false;
        }


        private void AddWallWithNoGap()
        {
            this.map[4][3] = false;
            this.map[3][3] = false;
            this.map[2][3] = false;
            this.map[1][3] = false;
            this.map[0][3] = false;
        }

        [TestMethod]
        public void Test_WithoutWalls_CanFindPath()
        {
            PathFinder pathFinder = new PathFinder(findingParameters);

            List<Point> path = pathFinder.FindPath();

            Assert.IsNotNull(path);
            Assert.IsTrue(path.Any());
            Assert.AreEqual(4, path.Count);
        }

        [TestMethod]
        public void Test_OpenWall_FindPathAroundWall()
        {
            AddWallWithGap();
            PathFinder pathFinder = new PathFinder(findingParameters);

            List<Point> path = pathFinder.FindPath();

            Assert.IsNotNull(path);
            Assert.IsTrue(path.Any());
        }

        [TestMethod]
        public void Test_ClosedWall_DontFindPath()
        {
            AddWallWithNoGap();
            PathFinder pathFinder = new PathFinder(findingParameters);

            List<Point> path = pathFinder.FindPath();

            Assert.IsNotNull(path);
            Assert.IsFalse(path.Any());
        }
        private void InitializeHoundMazeMap()
        {

            StringBuilder mazeBuilder = new StringBuilder();
            mazeBuilder.Append("FFFFFFFFFFFFFFFFFFFFFFFFFFFXFXFFFXXXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("FXXXXXXXXXXXXXXXXXFFFXFXXXFXFXFFFXXXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("FFFXXXFFFFFXFFFFFXFFFXFXXXFXFXFFFXFFFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXXXXXFXXXFXFXXXFXFFFXFXXXFXFXFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFFFFFXFXFXFXXXFXFFFXFXXXFXFFFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFXXXXXFXFXFXXXFXFFFXFXXXFXXXFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFXXXFFFFFXFXXXFFFFFXFXXXFFFFFFFXFXFFFFFFFFFFFFFFFFFFF,");
            mazeBuilder.Append("XXFXXXFXXXXXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFXXXXXXXXXXXF,");
            mazeBuilder.Append("XXFXXXFXFFFXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFFFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXXXFXFXFXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFXFXFXFXFXFFFXFFFXFXXXFFFXXXXXFXFFFFFXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFXFXXXFXFXXXFXXXXXFXXXFFFXXXXXFXXXFXXXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFFFFFFFXFXXXFFFFFFFFFXFFFXXXXXFXFFFFFXFXFFFXFFFFFFF,");
            mazeBuilder.Append("XXFXXXXXXXXXFXXXFXXXFFFFFXXXXXXXXXFXFFFFFXFXFFFXFXXXXXF,");
            mazeBuilder.Append("XXFFFFFFFFFFFXXXFFFXFFFFFXXXFFFXXXFXFFFFFXFXFFFXFXFFFFF,");
            mazeBuilder.Append("XXFXXXXXXXXXXXXXXXFXXXXXXXXXFFFXXXFXXXXXXXFXFFFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFFFFFFFFFFFFFFFFFFFFFXFFFFFFFXFFFFFFFXFFFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXXXXXFXFXFFFXXXFXXXXXFXXXXXFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFFFFFFFXFXFFFXFFFFFFFFFFFXFXFXFFFFFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXXXXXXXFXXXXXFFFFFFFFFFFXFXFXXXXXXXF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFFFFFFFXXXXXFFFFFFFFFFFXFXFXFFFXFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXXXXXXXXXXXFFFFFFFFFFFXFXFXFFFXFXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFFFXFFFFFFFFFFFFFFFFFFFFFXFXFFFFFXFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXFFFFFFFXXXFFFFFFFFFFFXFXFXXXXXXXF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXFFFFFFFXFXFFFFFFFFFFFXFFFFFFFXFFF,");
            mazeBuilder.Append("XXXXFXFXFXXXXXXXXXXXFXFFFFFFFXFXXXFXFXXXXXXXFXXXXXXXFXF,");
            mazeBuilder.Append("FFFFFXFXFXFFFFFFFFFXFXFFFFFFFXFFFXFXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("XXXXFXFXFXFXXXXXXXFXXXFXXXXXFXXXFXFXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFXFXFXXXXXXXFFFFFXFFFFFFFXFFFXFFFFFFFXFXFFFFFFFXF,");
            mazeBuilder.Append("FFFXFXFXXXFXXXXXXXXXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXXXF,");
            mazeBuilder.Append("FFFXFXFFFFFXXXXXXXXXXXFXFFFFFFFFFFFFFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFXXXXXXXXXXXXXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFFFFFFFXFFFFFXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXFFF,");
            mazeBuilder.Append("FFFXFXXXXXFFFXFXXXFXXXFXFXFXXXFXXXXXXXXXFXFXXXFFFFFXFXX,");
            mazeBuilder.Append("FFFXFXXXXXFFFXFXFFFFFFFXFXFFFXFXXXXXXXXXFXFFFFFFFFFXFFF,");
            mazeBuilder.Append("FXFXFXXXXXFFFXFXXXXXXXXXFXFFFXFXXXXXXXXXFXXXXXXXXXXXXXF,");
            mazeBuilder.Append("FXFXFFFFFXFFFXFFFFFFFFFFFXFFFXFFFFFFFFFXFFFFFFFFFXFFFXF,");
            mazeBuilder.Append("FXFXXXXXFXXXXXFXXXXXXXXXXXFFFXXXXXXXXXFXFFFFFFFFFXFXXXF,");
            mazeBuilder.Append("FXFXXXXXFXFFFFFFFFFFFFFXFXFFFFFFFFFFFXFXFFFFFFFFFXFFFFF,");
            mazeBuilder.Append("XXFXXXXXFXFXFFFFFFFFFFFXFXFXXXFFFFFFFXFXXXFXFXXXXXFXXXX,");
            mazeBuilder.Append("FFFXXXXXFXFXFFFFFFFFFFFFFXFXXXFFFFFFFFFXXXFXFFFFFFFXXXX,");
            mazeBuilder.Append("FXXXXXXXFXFXFFFFFFFFFFFXXXFXXXXXXXFXXXFXXXFXXXXXXXXXXXX,");
            mazeBuilder.Append("FFFXFFFFFXFXFFFFFFFFFFFXXXFXXXXXXXFXFFFXXXFFFFFFFFFFFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXXXFXXXXXXXFXFXFXXXXXXXXXXXXXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFFFXFFFFFFFXFXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXFXXXXXXXFXFXXXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXFFFFFFFXFXFFFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXXXXXXXXXXXXXFXXXFXFXFXXXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFFFFFFFXXXXXFFFXXXFXFXFXXXFFFFFFFFFFFFFFFXFXX,");
            mazeBuilder.Append("FXFXXXFXXXXXXXXXFXXXXXFXXXXXFXXXFXXXXXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFFFFFXFFFFFXXXFXXXXXFXFFFFFFFFFXXXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXXXXXXXFXXXFXXXFXXXXXFXFFFXFXXXXXXXFXXXXXXXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFXXXXXFXFFFXFFFXFFFFFFFXFFFXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFXXXXXXXFFFXXXFXFFFFFFFXFXFXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFFFFFFFFFFFXFFFFFFFFFFFXFXFFFFFFFFFXFFF,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXXXXXXXXXFFFXXXXXFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFFFXXXFFFFFFFXXXXXFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXXXXXXXFXXXFXXXFFFXXXXXXXXXXXXXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFFFFFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFXXXXXXXXXFXFXXXXXXXFXXXXXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFXFFFFFFFFFFFXFFFFFXFXXXFFF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXXXXXFXFXXXXXXXXXXXFFFFFXFXXXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFFFFFFFXFXFXXXXXXXXXXXFFFFFXFXXXFXX,");
            mazeBuilder.Append("XXFXXXXXFXFFFFFXFXXXXXXXXXFXFXFXXXXXXXXXXXFXXXFXFXXXFXX,");
            mazeBuilder.Append("FFFFFFFXFXFFFFFXFFFFFFFFFXFXFFFFFFFXXXXXXXFXFFFXFFFXFFF,");
            mazeBuilder.Append("FXXXXXFXFXFFFFFXXXXXXXXXFXFXFFFFFFFXXXXXXXXXFXFXXXXXXXF,");
            mazeBuilder.Append("FXXXXXFXFFFFFFFXXXXXXXXXFXFXFFFFFFFXFFFFFFFFFXFFFFFFFFF,");
            mazeBuilder.Append("FXXXXXFXXXXXFXXXXXXXXXXXFXFXFFFFFFFXFXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("FXXXXXFFFXFFFXXXXXXXXXXXFXFXFFFFFFFXFXFFFFFXFFFFFFFFFXF,");
            mazeBuilder.Append("FXXXXXXXFXXXXXXXXXXXXXXXFXFXFXXXXXXXFXFXXXFXFFFFFFFFFXF,");
            mazeBuilder.Append("FXFFFFFXFFFFFFFXXXXXXXXXFXFFFXXXXXXXFXFXFFFXFFFFFFFFFFF,");
            mazeBuilder.Append("FXXXFXFXXXXXXXFXXXXXXXXXFXXXXXXXXXXXFXFXXXXXXXXXFXXXXXF,");
            mazeBuilder.Append("FFFFFXFFFFFFFXFFFFFFFFFFFFFFFFFFFFFFFXFFFFFFFFFFFXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");

            string[] strArray = mazeBuilder.ToString().Split(',');
            /*this.map = new bool[55, strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                char[] strBoolean = strArray[i].ToCharArray();
                for (int j = 0; j < strBoolean.Length; j++)
                {
                    this.map[j, i] = strBoolean[j] == 'F';
                }
            }

            var startCoordinates = new Point(54, 77);
            var finishCoordinates = new Point(12, 20);
            this.findingParameters = new SearchParameters(startCoordinates, finishCoordinates, map);*/
        }
    }
}
