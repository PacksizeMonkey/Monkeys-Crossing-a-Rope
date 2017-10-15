
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrazyMonkey;
using System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MonkeyTests
{
    [TestClass]
    public class UnitTest1
    {
        public int MonkeysOnRope { get; set; }
        public bool FinishCrossing { get; set; }
        public int RightCount { get; set; }
        public int LeftCount { get; set; }
        public bool RightArrow { get; set; }
        public bool LeftArrow { get; set; }
        public bool RopeRightMonkey { get; set; }
        public bool RopeCenterMonkey { get; set; }
        public bool RopeLeftMonkey { get; set; }

        [TestMethod]
        public void StartCrossing()
        {
            LeftCount = 20;
            RightCount = 1;
            CrossMonkeys();
            //var _timer = new Timer(null, null, 1000, Timeout.Infinite);
            //Assert.IsInstanceOfType(_timer, typeof(Timer));
        }
        //[TestMethod]
        //public void Callback(Object state)
        //{
        //    Assert.AreEqual(null, state);
        //    CrossMonkeys(LeftCount,RightCount);
        //}
        [TestMethod]
        public void CrossMonkeys()
        {
            if (RightCount > 0 && LeftCount == 0 && MonkeysOnRope == 0)
            {
                ShowArrow();
                ShowMonkey();
                MonkeysOnRope++;
                Assert.AreEqual(1, MonkeysOnRope);
                RightCount= (RightCount - 1);
                Assert.AreEqual(RightCount - 1, RightCount);
            }
            else if (LeftCount > 0 && RightCount == 0 && MonkeysOnRope == 0)
            {
                ShowArrow();
                ShowMonkey();
                MonkeysOnRope++;
                Assert.AreEqual(1, MonkeysOnRope);
                LeftCount = (LeftCount - 1);
                Assert.AreEqual(LeftCount - 1, LeftCount);
            }
            else if (RightArrow.Equals(true) && MonkeysOnRope == 0)
            {
                ShowMonkey();
                MonkeysOnRope++;
                Assert.AreEqual(1, MonkeysOnRope);
                LeftCount = (LeftCount - 1);
                Assert.AreEqual(LeftCount - 1, LeftCount);
            }
            else if (LeftArrow.Equals(true) && MonkeysOnRope == 0)
            {
                ShowMonkey();
                MonkeysOnRope++;
                Assert.AreEqual(1, MonkeysOnRope);
                RightCount = (RightCount - 1);
                Assert.AreEqual(RightCount - 1, RightCount);
            }
            else if (MonkeysOnRope > 0)
            {
                MoveMonkeyForward();
            }
        }
        [TestMethod]
        public void MoveMonkeyForward()
        {
            if (MonkeysOnRope < 3 && !FinishCrossing)
            {
                if (LeftArrow.Equals(true) && RightCount > 0)
                {
                    if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(1, MonkeysOnRope);
                        RightCount= (RightCount - 1);
                        Assert.AreEqual(RightCount-1, RightCount);
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(2, MonkeysOnRope);
                        RightCount = (RightCount - 1);
                        Assert.AreEqual(RightCount - 1, RightCount);
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(3, MonkeysOnRope);
                        RightCount = (RightCount - 1);
                        Assert.AreEqual(RightCount - 1, RightCount);
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(3, MonkeysOnRope);
                        RightCount = (RightCount - 1);
                        Assert.AreEqual(RightCount - 1, RightCount);
                    }
                }
                else if (LeftArrow.Equals(true) && RightCount == 0)
                {
                    if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(false))//One monkey
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(true))
                    {
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(0, MonkeysOnRope);
                        HideMonkey();
                        HideArrow();
                        ShowArrow();
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(1, MonkeysOnRope);
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(2, MonkeysOnRope);
                        HideMonkey();
                    }

                }
                if (RightArrow.Equals(true) && LeftCount > 0)
                {
                    if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(1, MonkeysOnRope);
                        LeftCount = (LeftCount - 1);
                        Assert.AreEqual(LeftCount - 1, LeftCount);
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(true))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(2, MonkeysOnRope);
                        LeftCount = (LeftCount - 1);
                        Assert.AreEqual(LeftCount - 1, LeftCount);
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(3, MonkeysOnRope);
                        LeftCount = (LeftCount - 1);
                        Assert.AreEqual(LeftCount - 1, LeftCount);
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        MonkeysOnRope++;
                        Assert.AreEqual(3, MonkeysOnRope);
                        LeftCount = (LeftCount - 1);
                        Assert.AreEqual(LeftCount - 1, LeftCount);
                    }
                }
                else if (RightArrow.Equals(true) && LeftCount == 0)
                {
                    if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(true))
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(false))
                    {
                        RightCount= (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(0, MonkeysOnRope);
                        HideMonkey();
                        HideArrow();
                        ShowArrow();
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        ShowMonkey();
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(false))
                    {
                        RightCount= (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(1, MonkeysOnRope);
                        HideMonkey();
                    }
                    else if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        HideMonkey();
                        RightCount= (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                        MonkeysOnRope--;
                        Assert.AreEqual(2, MonkeysOnRope);
                    }
                }
            }
            else if (MonkeysOnRope == 3 || FinishCrossing)
            {
                if (LeftArrow.Equals(true))
                {
                    if (LeftCount > 0)
                    {
                        FinishCrossing = true;
                    }
                    if (RopeRightMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(2, MonkeysOnRope);
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeLeftMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(1, MonkeysOnRope);
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                    }
                    else if (RopeRightMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeLeftMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(0, MonkeysOnRope);
                        LeftCount = (LeftCount + 1);
                        Assert.AreEqual(LeftCount + 1, LeftCount);
                        HideArrow();
                        ShowArrow();
                        FinishCrossing = false;
                    }
                }
                else if (RightArrow.Equals(true))
                {
                    if (RightCount > 0)
                    {
                        FinishCrossing = true;
                        Assert.AreEqual(true, FinishCrossing);
                    }
                    if (RopeLeftMonkey.Equals(true) && RopeCenterMonkey.Equals(true) && RopeRightMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(2, MonkeysOnRope);
                        RightCount = (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                    }
                    else if (RopeLeftMonkey.Equals(false) && RopeCenterMonkey.Equals(true) && RopeRightMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(1, MonkeysOnRope);
                        RightCount = (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                    }
                    else if (RopeLeftMonkey.Equals(false) && RopeCenterMonkey.Equals(false) && RopeRightMonkey.Equals(true))
                    {
                        HideMonkey();
                        MonkeysOnRope--;
                        Assert.AreEqual(0, MonkeysOnRope);
                        RightCount = (RightCount + 1);
                        Assert.AreEqual(RightCount + 1, RightCount);
                        HideArrow();
                        ShowArrow();
                        FinishCrossing = false;
                        Assert.AreEqual(false, FinishCrossing);
                    }
                }
            }

        }
        [TestMethod]
        public void AddRightMonkeyButton_Click()
        {
            AddMonkeyToOneSide();
        }
        [TestMethod]
        public void AddLeftMonkeyButton_Click()
        {
            AddMonkeyToOneSide();
        }
        [TestMethod]
        public void AddMonkeyToOneSide()
        {
            var side = "Left";
            if (side.Equals("Left"))
            {
                var currentValue = LeftCount;
                LeftCount = (currentValue + 1);
                Assert.AreEqual(currentValue + 1, LeftCount);
            }
            if (side.Equals("Right"))
            {
                var currentValue = RightCount;
                RightCount = (currentValue + 1);
                Assert.AreEqual(currentValue + 1, RightCount);
            }
        }
        [TestMethod]
        public void HideMonkey()
        {
            var monkeyId = "Right";
            if (monkeyId.Equals("Left"))
            {
                RopeLeftMonkey=false;
                Assert.AreEqual(false, RopeLeftMonkey);
            }
            if (monkeyId.Equals("Center"))
            {
                RopeCenterMonkey=false;
                Assert.AreEqual(false, RopeCenterMonkey);
            }
            if (monkeyId.Equals("Right"))
            {
                RopeRightMonkey=false;
                Assert.AreEqual(false, RopeRightMonkey);
            }
        }
        [TestMethod]
        public void ShowMonkey()
        {
            var monkeyId = "Right";
            if (monkeyId.Equals("Left"))
            {
                RopeLeftMonkey= true;
                Assert.AreEqual(true, RopeLeftMonkey);
            }
            if (monkeyId.Equals("Center"))
            {
                RopeCenterMonkey= true;
                Assert.AreEqual(true, RopeCenterMonkey);
            }
            if (monkeyId.Equals("Right"))
            {
                RopeRightMonkey= true;
                Assert.AreEqual(true, RopeRightMonkey);
            }
        }
        [TestMethod]
        public void ShowArrow()
        {
            var arrowId = "Right";
            if (arrowId.Equals("Left"))
            {
                LeftArrow= true;
                Assert.AreEqual(true, LeftArrow);
            }
            if (arrowId.Equals("Right"))
            {
                RightArrow= true;
                Assert.AreEqual(true, RightArrow);
            }
        }
        [TestMethod]
        public void HideArrow()
        {
            var arrowId = "Right";
            if (arrowId.Equals("Left"))
            {
                LeftArrow=false;
                Assert.AreEqual(false, LeftArrow);
            }
            if (arrowId.Equals("Right"))
            {
                RightArrow=false;
                Assert.AreEqual(false, RightArrow);
            }
        }
    }
}
