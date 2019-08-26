﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathKit;
using MathKit.Geometry;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Triangle2Test
    {
        private const int TRIANGLE_AMOUNT = 1;

        private struct TriangleInfo
        {
            public Triangle2 triangle;
            public double expectedSquare;
            public Vector2 expectedMedianCentre;

            public Vector2 expectedAB;
            public Vector2 expectedBC;
            public Vector2 expectedCA;

            public double angleA;
            public double angleB;
            public double angleC;
        }

        private TriangleInfo[] testData;

        public Triangle2Test()
        {
            testData = new TriangleInfo[TRIANGLE_AMOUNT];
            testData[0] = GetTestTriangle1();
        }

        private TriangleInfo GetTestTriangle1()
        {
            TriangleInfo info = new TriangleInfo();

            info.triangle = new Triangle2(new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0));
            info.expectedSquare = 0.5;

            info.expectedMedianCentre = new Vector2(1.0 / 3.0, 1.0 / 3.0);

            info.expectedAB = new Vector2(0, 1);
            info.expectedBC = new Vector2(1, -1);
            info.expectedCA = new Vector2(-1, 0);

            info.angleA = MathConst.PId2;
            info.angleB = MathConst.PI / 4.0;
            info.angleC = MathConst.PI / 4.0;

            return info;
        }

        [TestMethod]
        public void TestTriagles()
        {
            for (int i = 0; i < TRIANGLE_AMOUNT; i++)
            {
                CheckSquare(this.testData[i]);
                CheckMedianCentre(this.testData[i]);
                CheckSides(this.testData[i]);
                CheckAngles(this.testData[i]);
            }
        }

        private void CheckSquare(TriangleInfo info)
        {
            Assert.AreEqual(info.expectedSquare, info.triangle.Square(), MathConst.EPSYLON);
        }

        private void CheckMedianCentre(TriangleInfo info)
        {
            Vector2 median = info.triangle.MedianCentre();

            Assert.AreEqual(info.expectedMedianCentre.x, median.x, MathConst.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.y, median.y, MathConst.EPSYLON);
        }

        private void CheckSides(TriangleInfo info)
        {
            CheckSide(info.expectedAB, info.triangle.SideAB);
            CheckSide(info.expectedBC, info.triangle.SideBC);
            CheckSide(info.expectedCA, info.triangle.SideCA);
        }

        private void CheckSide(Vector2 expectedSide, Vector2 side)
        {
            Assert.AreEqual(expectedSide.x, side.x, MathConst.EPSYLON);
            Assert.AreEqual(expectedSide.y, side.y, MathConst.EPSYLON);
        }

        private void CheckAngles(TriangleInfo info)
        {
            Assert.AreEqual(info.angleA, info.triangle.AngleA(), MathConst.EPSYLON);
            Assert.AreEqual(info.angleB, info.triangle.AngleB(), MathConst.EPSYLON);
            Assert.AreEqual(info.angleC, info.triangle.AngleC(), MathConst.EPSYLON);
        }
    }
}
