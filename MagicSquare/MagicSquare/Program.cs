﻿using Magic;

Console.WriteLine("Hello, Magic square!");

UInt32[,] mySquare = { { 1, 2, 4 }, { 4, 5, 6 }, { 7, 8, 9 } };

MagicSquare.IsMagic(mySquare);