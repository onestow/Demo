using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfApp1.CustomAnimation
{
    public class GridLengthWidthAnimation : AnimationTimeline
    {
        public override Type TargetPropertyType => typeof(GridLength);

        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthWidthAnimation();
        }
        
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(double),
          typeof(GridLengthWidthAnimation));
        public double From
        {
            get { return (double)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(double),
          typeof(GridLengthWidthAnimation));
        public double To
        {
            get { return (double)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            return new GridLength(From + animationClock.CurrentProgress.Value * (To - From));
        }
    }
}
