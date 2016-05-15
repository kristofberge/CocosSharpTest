// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameScene.cs" company="ArcTouch, Inc.">
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
//   Defines the GameScene type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using CocosSharp;

namespace CocosSharpTest
{
    public class GameScene : CCScene
    {
        private CCDrawNode circle;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            var layer = new CCLayer();

            circle = new CCDrawNode();
            circle.DrawCircle(new CCPoint(0, 0), 15, CCColor4B.White);
            circle.PositionX = 20;
            circle.PositionY = 50;

            layer.AddChild(circle);
            this.AddLayer(layer);
        }

        public void MoveCircleLeft(float pixels = 10)
        {
            circle.PositionX -= pixels;
        }

        public void MoveCircleRight(float pixels = 10)
        {
            circle.PositionX += pixels;
        }
    }
}

