// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="ArcTouch, Inc.">
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the MainPage.xaml type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;

using Xamarin.Forms;
using CocosSharp;

namespace FruityFalls.Pages
{
    public partial class GamePage : ContentPage
    {
        GameScene gameScene;

        public GamePage()
        {
            InitializeComponent();

            var ccSharpView = new CocosSharpView 
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    ViewCreated = HandleViewCreated
                };
            AbsoluteLayout.SetLayoutBounds(ccSharpView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(ccSharpView, AbsoluteLayoutFlags.All);

            outerLayout.Children.Add(ccSharpView);
        }

        private void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            if (gameView != null)
            {
                gameView.DesignResolution = new CCSizeI(100, 100);
                gameScene = new GameScene(gameView);
                gameView.RunWithScene(gameScene);
            }
        }

        private void MoveLeftClicked(object sender, EventArgs e)
        {
            gameScene.MoveCircleLeft();
        }

        private void MoveRightClicked(object sender, EventArgs e)
        {
            gameScene.MoveCircleRight();
        }
    }
}