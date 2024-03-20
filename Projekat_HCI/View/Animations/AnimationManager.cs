using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using Projekat_HCI.View;

namespace Projekat_HCI.ViewModel
{
    public class AnimationManager
    {
        public enum SlideAnimationType
        {
            SlideUp,
            SlideDown,
            SlideLeft,
            SlideRight
        }

        private readonly Duration _animationDuration = new Duration(TimeSpan.FromSeconds(0.4));
        private readonly Canvas _transitionContainer;

        public AnimationManager(Canvas transitionContainer)
        {
            _transitionContainer = transitionContainer;
        }

        public DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventHandler)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, _animationDuration);
            if (completedEventHandler != null)
                doubleAnimation.Completed += completedEventHandler;
            return doubleAnimation;
        }

        public void SlideAnimation(UIElement newContent, UIElement oldContent, SlideAnimationType animationType, double width, double height, EventHandler completedEventHandler)
        {
            double startValue = 0;
            DependencyProperty property = null;

            switch (animationType)
            {
                case SlideAnimationType.SlideUp:
                    startValue = Canvas.GetTop(oldContent);
                    Canvas.SetTop(newContent, startValue + height);
                    property = Canvas.TopProperty;
                    break;
                case SlideAnimationType.SlideDown:
                    startValue = Canvas.GetTop(oldContent);
                    Canvas.SetTop(newContent, startValue - height);
                    property = Canvas.TopProperty;
                    break;
                case SlideAnimationType.SlideLeft:
                    startValue = Canvas.GetLeft(oldContent);
                    Canvas.SetLeft(newContent, startValue - width);
                    property = Canvas.LeftProperty;
                    break;
                case SlideAnimationType.SlideRight:
                    startValue = Canvas.GetLeft(oldContent);
                    Canvas.SetLeft(newContent, startValue + width);
                    property = Canvas.LeftProperty;
                    break;
            }

            _transitionContainer.Children.Add(newContent);
            if (double.IsNaN(startValue))
            {
                startValue = 0;
            }

            DoubleAnimation outAnimation = null;
            DoubleAnimation inAnimation = null;

            switch (animationType)
            {
                case SlideAnimationType.SlideUp:
                    outAnimation = CreateDoubleAnimation(startValue, startValue - height, null);
                    inAnimation = CreateDoubleAnimation(startValue + height, startValue, completedEventHandler);
                    break;
                case SlideAnimationType.SlideDown:
                    outAnimation = CreateDoubleAnimation(startValue, startValue + height, null);
                    inAnimation = CreateDoubleAnimation(startValue - height, startValue, completedEventHandler);
                    break;
                case SlideAnimationType.SlideLeft:
                    outAnimation = CreateDoubleAnimation(startValue, startValue - width, null);
                    inAnimation = CreateDoubleAnimation(startValue + width, startValue, completedEventHandler);
                    break;
                case SlideAnimationType.SlideRight:
                    outAnimation = CreateDoubleAnimation(startValue, startValue + width, null);
                    inAnimation = CreateDoubleAnimation(startValue - width, startValue, completedEventHandler);
                    break;
            }

            oldContent.BeginAnimation(property, outAnimation);
            newContent.BeginAnimation(property, inAnimation);
        }

        public void ChangeContent(UIElement newContent, SlideAnimationType animationType)
        {
            if (_transitionContainer.Children.Count == 0)
            {
                _transitionContainer.Children.Add(newContent);
                return;
            }

            if (_transitionContainer.Children.Count == 1)
            {
                _transitionContainer.IsHitTestVisible = false;
                UIElement oldContent = _transitionContainer.Children[0];
                EventHandler onAnimationCompletedHandler = (sender, e) =>
                {
                    _transitionContainer.IsHitTestVisible = true;
                    _transitionContainer.Children.Remove(oldContent);
                    if (oldContent is IDisposable)
                    {
                        (oldContent as IDisposable).Dispose();
                    }
                };

                SlideAnimation(newContent, oldContent, animationType, _transitionContainer.ActualWidth, _transitionContainer.ActualHeight, onAnimationCompletedHandler);
            }
        }

    }

}

