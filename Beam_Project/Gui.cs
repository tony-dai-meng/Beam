using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Beam_Project {
  class Gui : Window {
    public Gui() {
      this.Height = 600;
      this.Width = 800;
      this.Content = drawGuiShapes();
      this.Show();
    }

    private Canvas drawGuiShapes() {
      Canvas c = new Canvas();
      c.Height = 600;
      c.Width = 800;
      Canvas.SetTop(c, 0);
      Canvas.SetLeft(c, 0);

      // The beam.
      Rectangle rect = new Rectangle();
      rect.Fill = Brushes.Green;
      rect.Height = 10;
      rect.Width = 600;
      Canvas.SetTop(rect, 200);
      Canvas.SetLeft(rect, 100);
      c.Children.Add(rect);

      return c;
    }
  }
}
