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

    private int DiagramHeight;
    private int DiagramHeightPadding;
    private int DiagramWidth;
    private int DiagramWidthPadding;

    private int AxisHeight() {
      return DiagramHeight - 2 * DiagramHeightPadding;
    }

    private int AxisWidth() {
      return DiagramWidth - 2 * DiagramWidthPadding;
    }

    public Gui() {
      this.DiagramHeight = 150;
      this.DiagramHeightPadding = 20;
      this.DiagramWidth = 700;
      this.DiagramWidthPadding = 50;

      this.Height = DiagramHeight * 3 + DiagramHeightPadding;
      this.Width = 1000;
      this.ResizeMode = System.Windows.ResizeMode.NoResize;
      this.Title = "Beams";
      this.Content = DrawAll();
      this.Show();
    }

    private Canvas DrawAll() {
      Canvas c = new Canvas {
        Height = this.Height,
        Width = this.Width
      };

      c.Children.Add(DrawDiagrams());
      c.Children.Add(DrawSidebar());
      return c;
    }

    private Canvas DrawDiagrams() {
      Canvas c = new Canvas {
        Height = this.Height,
        Width = DiagramWidth
      };

      c.Children.Add(BeamDiagram());
      c.Children.Add(ForceDiagram());
      c.Children.Add(MomentDiagram());
      return c;
    }

    private Canvas BeamDiagram() {
      Canvas c = DiagramCanvas(Brushes.WhiteSmoke);
      Canvas.SetTop(c, 0);

      Rectangle beam = new Rectangle {
        Fill = Brushes.Purple,
        Height = 10,
        Width = AxisWidth()
      };
      Canvas.SetBottom(beam, DiagramHeightPadding);
      Canvas.SetLeft(beam, DiagramWidthPadding);
      c.Children.Add(beam);

      return c;
    }

    private Canvas ForceDiagram() {
      Canvas c = DiagramCanvas(Brushes.WhiteSmoke);
      Canvas.SetTop(c, DiagramHeight); // Place beneath beam diagram.

      Rectangle xaxis = Xaxis();
      Canvas.SetBottom(xaxis, DiagramHeightPadding);
      Canvas.SetLeft(xaxis, DiagramWidthPadding);
      c.Children.Add(xaxis);

      Rectangle yaxis = Yaxis();
      Canvas.SetBottom(yaxis, DiagramHeightPadding);
      Canvas.SetLeft(yaxis, DiagramWidthPadding);
      c.Children.Add(yaxis);

      return c;
    }

    private Canvas MomentDiagram() {
      Canvas c = DiagramCanvas(Brushes.WhiteSmoke);
      Canvas.SetTop(c, 2*DiagramHeight); // Place beneath force plot.

      Rectangle xaxis = Xaxis();
      Canvas.SetTop(xaxis, DiagramHeight/2);
      Canvas.SetLeft(xaxis, DiagramWidthPadding);
      c.Children.Add(xaxis);

      Rectangle yaxis = Yaxis();
      Canvas.SetBottom(yaxis, DiagramHeightPadding);
      Canvas.SetLeft(yaxis, DiagramWidthPadding);
      c.Children.Add(yaxis);

      return c;
    }

    private Canvas DiagramCanvas(Brush color) {
      return new Canvas {
        Background = color,
        Height = DiagramHeight,
        Width = DiagramWidth
      };
    }

    private Canvas DrawSidebar() {
      Canvas c = new Canvas {
        Background = Brushes.LightGray,
        Height = this.Height,
        Width = this.Width - DiagramWidth
      };
      Canvas.SetRight(c, 0);
      return c;
    }

    private Rectangle Xaxis() {
      return new Rectangle {
        Fill = Brushes.Black,
        Height = 1,
        Width = AxisWidth()
      };
    }

    private Rectangle Yaxis() {
      return new Rectangle {
        Fill = Brushes.Black,
        Height = AxisHeight(),
        Width = 1
      };
    }

  }
}
