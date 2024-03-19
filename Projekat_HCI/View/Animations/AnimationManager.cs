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
        private readonly Canvas _transitionContainer;
        private readonly Duration _animationDuration = new Duration(TimeSpan.FromSeconds(0.3));

        public AnimationManager(Canvas transitionContainer)
        {
            _transitionContainer = transitionContainer;
        }

        public enum AnimationType
        {
            SlideLeft,
            SlideDown,
            SlideUp,
            SlideRight
        }

        private DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventHandler)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, _animationDuration);
            if (completedEventHandler != null)
                doubleAnimation.Completed += completedEventHandler;
            return doubleAnimation;
        }

        private void AnimateContent(UIElement newContent, UIElement oldContent, EventHandler completedEventHandler, AnimationType animationType)
        {
            DependencyProperty property = Canvas.LeftProperty;
            double startValue = 0;

            switch (animationType)
            {
                case AnimationType.SlideLeft:
                    startValue = Canvas.GetLeft(oldContent);
                    break;
                case AnimationType.SlideDown:
                    startValue = Canvas.GetBottom(oldContent);
                    property = Canvas.TopProperty;
                    break;
                case AnimationType.SlideUp:
                    startValue = Canvas.GetTop(oldContent);
                    property = Canvas.BottomProperty;
                    break;
                case AnimationType.SlideRight:
                    startValue = Canvas.GetRight(oldContent);
                    property = Canvas.LeftProperty;
                    break;
            }

            if (double.IsNaN(startValue))
            {
                startValue = 0;
            }

            _transitionContainer.Children.Add(newContent);
            DoubleAnimation outAnimation = CreateDoubleAnimation(startValue, startValue + (animationType == AnimationType.SlideLeft ? _transitionContainer.ActualWidth : _transitionContainer.ActualHeight), null);
            DoubleAnimation inAnimation = CreateDoubleAnimation(startValue - (animationType == AnimationType.SlideLeft ? _transitionContainer.ActualWidth : _transitionContainer.ActualHeight), startValue, completedEventHandler);
            oldContent.BeginAnimation(property, outAnimation);
            newContent.BeginAnimation(property, inAnimation);
        }

        public void ChangeContent(UIElement newContent, AnimationType animationType)
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
                    if (oldContent is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                };
                AnimateContent(newContent, oldContent, onAnimationCompletedHandler, animationType);
            }
        }
    }

}

