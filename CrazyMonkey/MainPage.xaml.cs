using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CrazyMonkey
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int MonkeysOnRope { get; set; }
        public bool FinishCrossing { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            HideMonkey("Left");
            HideMonkey("Center");
            HideMonkey("Right");
            HideArrow("Left");
            HideArrow("Right");
            StartCrossing();
            MonkeysOnRope = 0;
        }

        private void StartCrossing()
        {
            var _timer = new Timer(Callback, null, 1000, Timeout.Infinite);            
        }
        
        private async void Callback(Object state)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                CrossMonkeys(Convert.ToInt32(LeftCount.Text), Convert.ToInt32(RightCount.Text));
                StartCrossing();
            });
            
        }

        private void CrossMonkeys(int leftCount, int rightCount)
        {           
            if (rightCount > 0 && leftCount == 0 && MonkeysOnRope == 0)
            {
                ShowArrow("Left");
                ShowMonkey("Right");
                MonkeysOnRope++;
                RightCount.Text = (rightCount -1).ToString();
            }
            else if(leftCount > 0 && rightCount == 0 && MonkeysOnRope == 0)
            {
                ShowArrow("Right");
                ShowMonkey("Left");
                MonkeysOnRope++;
                LeftCount.Text = (leftCount - 1).ToString();
            }
            else if(RightArrow.Visibility.Equals(Visibility.Visible) && MonkeysOnRope == 0 )
            {
                ShowMonkey("Left");
                MonkeysOnRope++;
                LeftCount.Text = (leftCount - 1).ToString();
            }
            else if (LeftArrow.Visibility.Equals(Visibility.Visible) && MonkeysOnRope == 0)
            {
                ShowMonkey("Right");
                MonkeysOnRope++;
                RightCount.Text = (rightCount - 1).ToString();
            }
            else if(MonkeysOnRope > 0)
            {
                MoveMonkeyForward(Convert.ToInt32(LeftCount.Text), Convert.ToInt32(RightCount.Text));
            }
        }

        private void MoveMonkeyForward(int leftCount, int rightCount)
        {
            if (MonkeysOnRope < 3 && !FinishCrossing)
            {
                if (LeftArrow.Visibility.Equals(Visibility.Visible) && rightCount > 0)
                {
                    if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Right");
                        MonkeysOnRope++;
                        RightCount.Text = (rightCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Center");
                        MonkeysOnRope++;
                        RightCount.Text = (rightCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Left");
                        MonkeysOnRope ++;
                        RightCount.Text = (rightCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        ShowMonkey("Right");
                        MonkeysOnRope++;
                        RightCount.Text = (rightCount - 1).ToString();
                    }
                }
                else if (LeftArrow.Visibility.Equals(Visibility.Visible) && rightCount == 0)
                {
                    if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))//One monkey
                    {
                            ShowMonkey("Center");
                            HideMonkey("Right");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Left");
                        HideMonkey("Center");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        LeftCount.Text = (leftCount + 1).ToString();
                        MonkeysOnRope--;
                        HideMonkey("Left");
                        HideArrow("Left");
                        ShowArrow("Right");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Left");
                        HideMonkey("Right");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        LeftCount.Text = (leftCount + 1).ToString();
                        MonkeysOnRope--;
                        HideMonkey("Center");
                    }                
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        LeftCount.Text = (leftCount + 1).ToString();
                        MonkeysOnRope--;
                        HideMonkey("Right");
                    }                    

                }
                if (RightArrow.Visibility.Equals(Visibility.Visible) && leftCount > 0)
                {
                    if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) &&  RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Left");
                        MonkeysOnRope++;
                        LeftCount.Text = (leftCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        ShowMonkey("Center");
                        MonkeysOnRope++;
                        LeftCount.Text = (leftCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        ShowMonkey("Right");
                        MonkeysOnRope++;
                        LeftCount.Text = (leftCount - 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Left");
                        MonkeysOnRope++;
                        LeftCount.Text = (leftCount - 1).ToString();
                    }
                }
                else if (RightArrow.Visibility.Equals(Visibility.Visible) && leftCount == 0)
                {
                    if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        ShowMonkey("Center");
                        HideMonkey("Left");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        ShowMonkey("Right");
                        HideMonkey("Center");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        RightCount.Text = (rightCount + 1).ToString();
                        MonkeysOnRope--;
                        HideMonkey("Right");
                        HideArrow("Right");
                        ShowArrow("Left");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        ShowMonkey("Right");
                        HideMonkey("Left");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed))
                    {
                        RightCount.Text = (rightCount + 1).ToString();
                        MonkeysOnRope--;
                        HideMonkey("Center");
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Left");
                        RightCount.Text = (rightCount + 1).ToString();
                        MonkeysOnRope--;
                    }
                }
            }
            else if (MonkeysOnRope == 3 || FinishCrossing)
            {                
                if (LeftArrow.Visibility.Equals(Visibility.Visible))
                {
                    if(leftCount > 0)
                    {
                        FinishCrossing = true;
                    }
                    if (RopeRightMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Right");
                        MonkeysOnRope --;
                        LeftCount.Text = (leftCount + 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Center");
                        MonkeysOnRope--;
                        LeftCount.Text = (leftCount + 1).ToString();
                    }
                    else if (RopeRightMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeLeftMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Left");
                        MonkeysOnRope--;
                        LeftCount.Text = (leftCount + 1).ToString();
                        HideArrow("Left");
                        ShowArrow("Right");
                        FinishCrossing = false;
                    }
                }
                else if (RightArrow.Visibility.Equals(Visibility.Visible))
                {
                    if (rightCount > 0)
                    {
                        FinishCrossing = true;
                    }
                    if (RopeLeftMonkey.Visibility.Equals(Visibility.Visible) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeRightMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Left");
                        MonkeysOnRope--;
                        RightCount.Text = (rightCount + 1).ToString();
                    }
                    else if (RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Visible) && RopeRightMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Center");
                        MonkeysOnRope--;
                        RightCount.Text = (rightCount + 1).ToString();
                    }
                    else if (RopeLeftMonkey.Visibility.Equals(Visibility.Collapsed) && RopeCenterMonkey.Visibility.Equals(Visibility.Collapsed) && RopeRightMonkey.Visibility.Equals(Visibility.Visible))
                    {
                        HideMonkey("Right");
                        MonkeysOnRope--;
                        RightCount.Text = (rightCount + 1).ToString();
                        HideArrow("Right");
                        ShowArrow("Left");
                        FinishCrossing = false;
                    }
                }
            }
            
        }

        private void AddRightMonkeyButton_Click(object sender, RoutedEventArgs e)
        {
            AddMonkeyToOneSide("Right");
        }

        private void AddLeftMonkeyButton_Click(object sender, RoutedEventArgs e)
        {
            AddMonkeyToOneSide("Left");
        }

        private void AddMonkeyToOneSide(string side)
        {
            if(side.Equals("Left"))
            {
                var currentValue = Convert.ToInt32(LeftCount.Text);
                LeftCount.Text = (currentValue + 1).ToString();
            }
            if(side.Equals("Right"))
            {
                var currentValue = Convert.ToInt32(RightCount.Text);
                RightCount.Text = (currentValue + 1).ToString();
            }
        }

        private void HideMonkey(string monkeyId)
        {
            if(monkeyId.Equals("Left"))
            {
                RopeLeftMonkey.Visibility = Visibility.Collapsed;
            }
            if (monkeyId.Equals("Center"))
            {
                RopeCenterMonkey.Visibility = Visibility.Collapsed;
            }
            if (monkeyId.Equals("Right"))
            {
                RopeRightMonkey.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowMonkey(string monkeyId)
        {
            if (monkeyId.Equals("Left"))
            {
                RopeLeftMonkey.Visibility = Visibility.Visible;
            }
            if (monkeyId.Equals("Center"))
            {
                RopeCenterMonkey.Visibility = Visibility.Visible;
            }
            if (monkeyId.Equals("Right"))
            {
                RopeRightMonkey.Visibility = Visibility.Visible;
            }
        }

        private void ShowArrow(string arrowId)
        {
            if (arrowId.Equals("Left"))
            {
                LeftArrow.Visibility = Visibility.Visible;
            }
            if (arrowId.Equals("Right"))
            {
                RightArrow.Visibility = Visibility.Visible;
            }
        }

        private void HideArrow(string arrowId)
        {
            if (arrowId.Equals("Left"))
            {
                LeftArrow.Visibility = Visibility.Collapsed;
            }
            if (arrowId.Equals("Right"))
            {
                RightArrow.Visibility = Visibility.Collapsed;
            }
        }
    }
}
