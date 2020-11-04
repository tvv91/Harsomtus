using System.Windows;

namespace Harsomtus.UI
{
    public static class SizeObserver
    {
        public static readonly DependencyProperty ObserveProperty = DependencyProperty.RegisterAttached(
            "Observe",
            typeof(bool),
            typeof(SizeObserver),
            new FrameworkPropertyMetadata(OnObserveChanged));

        public static readonly DependencyProperty ObservedWidthProperty = DependencyProperty.RegisterAttached(
            "ObservedWidth",
            typeof(double),
            typeof(SizeObserver));

        public static readonly DependencyProperty ObservedHeightProperty = DependencyProperty.RegisterAttached(
            "ObservedHeight",
            typeof(double),
            typeof(SizeObserver));

        public static bool GetObserve(FrameworkElement fe)
        {
            return (bool)fe.GetValue(ObserveProperty);
        }

        public static void SetObserve(FrameworkElement fe, bool observe)
        {
            fe.SetValue(ObserveProperty, observe);
        }

        public static double GetObservedWidth(FrameworkElement fe)
        {
            return (double)fe.GetValue(ObservedWidthProperty);
        }

        public static void SetObservedWidth(FrameworkElement fe, double observedWidth)
        {
            fe.SetValue(ObservedWidthProperty, observedWidth);
        }

        public static double GetObservedHeight(FrameworkElement fe)
        {
            return (double)fe.GetValue(ObservedHeightProperty);
        }

        public static void SetObservedHeight(FrameworkElement fe, double observedHeight)
        {
            fe.SetValue(ObservedHeightProperty, observedHeight);
        }

        private static void OnObserveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)dependencyObject;

            if ((bool)e.NewValue)
            {
                fe.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(fe);
            }
            else
            {
                fe.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }

        private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        }

        private static void UpdateObservedSizesForFrameworkElement(FrameworkElement fe)
        {
            fe.SetCurrentValue(ObservedWidthProperty, fe.ActualWidth);
            fe.SetCurrentValue(ObservedHeightProperty, fe.ActualHeight);
        }
    }
}
