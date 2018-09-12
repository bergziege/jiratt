using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Jiratt.UI.Modules.TaskDetails.Controls {
    public class CircularTimeProgress : Control {
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
                "Angle",
                typeof(double),
                typeof(CircularTimeProgress),
                new PropertyMetadata(default(double), AngleChanged));
        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register(
                "Percentage",
                typeof(double),
                typeof(CircularTimeProgress),
                new PropertyMetadata(default(double), PercentageChanged));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
                "Radius",
                typeof(double),
                typeof(CircularTimeProgress),
                new PropertyMetadata(default(double), RadiusChanged));
        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
                "Stroke",
                typeof(Brush),
                typeof(CircularTimeProgress),
                new PropertyMetadata(default(Brush)));
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
                "StrokeThickness",
                typeof(double),
                typeof(CircularTimeProgress),
                new PropertyMetadata(default(double)));

        private ArcSegment _partArcSegment;
        private PathFigure _partPathFigure;
        private Path _partPathRoot;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Windows.Controls.Control"/>-Klasse.
        /// </summary>
        public CircularTimeProgress() {
            DefaultStyleKey = GetType();
        }

        static CircularTimeProgress() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularTimeProgress),
                    new FrameworkPropertyMetadata(typeof(CircularTimeProgress)));
        }

        public double Angle {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public double Percentage {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }
        public double Radius {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }
        public Brush Stroke {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }
        public double StrokeThickness {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        /// <summary>
        /// Wird aufgerufen, um den Inhalt eines <see cref="T:System.Windows.Controls.Control"/>-Objekts anzuordnen und zu skalieren.
        /// </summary>
        /// <returns>
        /// Die Größe des Steuerelements.
        /// </returns>
        /// <param name="arrangeBounds">Die berechnete Größe, mit der der Inhalt angeordnet wird.</param>
        protected override Size ArrangeOverride(Size arrangeBounds) {
            double min = Math.Min(arrangeBounds.Width, arrangeBounds.Height);
            Radius = (min / 2) - StrokeThickness;
            return base.ArrangeOverride(arrangeBounds);
        }

        /// <summary>
        /// Wird aufgerufen, um ein Steuerelement erneut zu messen.
        /// </summary>
        /// <returns>
        /// Die Größe des Steuerelements, bis zu dem durch <paramref name="constraint"/> angegebenen Maximum.
        /// </returns>
        /// <param name="constraint">Die maximale Größe, die die Methode zurückgeben kann.</param>
        protected override Size MeasureOverride(Size constraint) {
            return base.MeasureOverride(constraint);
        }

        /// <summary>
        ///     Wird bei einer Überschreibung in einer abgeleiteten Klasse stets aufgerufen, wenn
        ///     <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" /> von Anwendungscode oder internem Prozesscode
        ///     aufgerufen wird.
        /// </summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            _partPathFigure = GetTemplateChild("PART_PathFigure") as PathFigure;
            _partPathRoot = GetTemplateChild("PART_PathRoot") as Path;
            _partArcSegment = GetTemplateChild("PART_ArcSegment") as ArcSegment;

            RenderArc();
        }

        public void RenderArc() {
            if (_partArcSegment == null || _partPathFigure == null || _partPathRoot == null) {
                return;
            }
            Point startPoint = new Point(Radius, 0);
            Point endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;

            _partPathRoot.Width = Radius * 2 + StrokeThickness;
            _partPathRoot.Height = Radius * 2 + StrokeThickness;
            _partPathRoot.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            bool largeArc = Angle > 180.0;

            Size outerArcSize = new Size(Radius, Radius);

            _partPathFigure.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y)) {
                endPoint.X -= 0.01;
            }

            _partArcSegment.Point = endPoint;
            _partArcSegment.Size = outerArcSize;
            _partArcSegment.IsLargeArc = largeArc;
        }

        private static void AngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            CircularTimeProgress sender = (CircularTimeProgress)d;
            sender.RenderArc();
        }

        private static void PercentageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            CircularTimeProgress sender = (CircularTimeProgress)d;
            sender.Angle = (sender.Percentage * 360) / 100;
        }

        private static void RadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            CircularTimeProgress sender = (CircularTimeProgress)d;
            sender.RenderArc();
        }

        private Point ComputeCartesianCoordinate(double angle, double radius) {
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}