﻿using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowDragAndMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
