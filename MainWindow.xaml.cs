using Arm64.WinUIApp.Helpers;
using Microsoft.UI.Xaml;
using System;

namespace Arm64.WinUIApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the window size
            AppWindow.Resize(new Windows.Graphics.SizeInt32(800, 1200));            

            // Update ProcessorArchitecture Label
            TextBlockProcessorArchitecture.Text = $"{Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")}";

            // Update Window Title
            Title = "ARM";
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            int matrixSize = Convert.ToInt32(NumberBoxMatrixSize.Value);
            int executionCount = Convert.ToInt32(NumberBoxExecutionCount.Value);

            var executionTime = PerformanceHelper.MeasurePerformance(
                () => MatrixHelper.SquareMatrixMultiplication(matrixSize),
                executionCount);

            ListBoxResults.Items.Add($"Size: {matrixSize}, Count: {executionCount}, " +
                $"Time: {executionTime} ms");
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ListBoxResults.Items.Clear();
        }
    }
}
