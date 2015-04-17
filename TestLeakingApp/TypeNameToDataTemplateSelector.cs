using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TestLeakingAppExternalLibrary;

namespace TestLeakingApp
{
    public class TypeNameToDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PointTemplate { get; set; }
        public DataTemplate LineTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item,
          DependencyObject container)
        {
            IPositionnable element = (IPositionnable)item;
            if (element.TypeName == "Line")
                return LineTemplate;
            return PointTemplate;
        }
    }
}
