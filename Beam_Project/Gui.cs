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
    private TextBox lengthBox;

    private int AxisHeight() {
      return DiagramHeight - 2 * DiagramHeightPadding;
    }

    private int AxisWidth() {
      return DiagramWidth - 2 * DiagramWidthPadding;
    }

    private int SidebarWidth() {
      return (int)this.Width - DiagramWidth;
    }

    public Gui() {
      this.DiagramHeight = 150;
      this.DiagramHeightPadding = 20;
      this.DiagramWidth = 700;
      this.DiagramWidthPadding = 50;

      this.Height = DiagramHeight * 3 + DiagramHeightPadding;
      this.Width = 1000;
      this.ResizeMode = ResizeMode.NoResize;
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
      Canvas.SetTop(beam, AxisHeight());
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

      Rectangle yaxis = Yaxis();
      Canvas.SetBottom(yaxis, DiagramHeightPadding);
      Canvas.SetLeft(yaxis, DiagramWidthPadding);

      TextBlock ylabel = new TextBlock {
        Text = "Sheer force",
        RenderTransform = new RotateTransform(270)
      };
      Canvas.SetBottom(ylabel, DiagramHeightPadding);
      Canvas.SetLeft(ylabel, DiagramHeightPadding);

      c.Children.Add(xaxis);
      c.Children.Add(yaxis);
      c.Children.Add(ylabel);
      return c;
    }

    private Canvas MomentDiagram() {
      Canvas c = DiagramCanvas(Brushes.WhiteSmoke);
      Canvas.SetTop(c, 2*DiagramHeight); // Place beneath force plot.

      Rectangle xaxis = Xaxis();
      Canvas.SetTop(xaxis, DiagramHeight/2);
      Canvas.SetLeft(xaxis, DiagramWidthPadding);

      Rectangle yaxis = Yaxis();
      Canvas.SetBottom(yaxis, DiagramHeightPadding);
      Canvas.SetLeft(yaxis, DiagramWidthPadding);

      TextBlock ylabel = new TextBlock {
        Text = "Bending moment",
        RenderTransform = new RotateTransform(270)
      };
      Canvas.SetBottom(ylabel, DiagramHeightPadding);
      Canvas.SetLeft(ylabel, DiagramHeightPadding);

      c.Children.Add(xaxis);
      c.Children.Add(yaxis);
      c.Children.Add(ylabel);
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
        Width = SidebarWidth()
      };
      Canvas.SetRight(c, 0);

      TextBlock lengthLabel = new TextBlock {
        Text = "Beam length",
        FontSize = 10
      };
      Canvas.SetTop(lengthLabel, AxisHeight());
      Canvas.SetLeft(lengthLabel, SidebarWidth()/3.5);

      lengthBox = new TextBox {
        FontSize = 10,
        Width = 50
      };
      Canvas.SetTop(lengthBox, AxisHeight());
      Canvas.SetRight(lengthBox, SidebarWidth()/3.5);

      Button calcBtn = new Button {
        Content = "Calculate",
        Width = SidebarWidth() - 20
      };
      calcBtn.Click += Calculate;
      Canvas.SetBottom(calcBtn, 50);
      Canvas.SetLeft(calcBtn, 10);

      c.Children.Add(lengthLabel);
      c.Children.Add(lengthBox);
      c.Children.Add(calcBtn);
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

    private bool IsNonnegativeString(String num) {
      return num.All(x => char.IsDigit(x) || x == '.') &&
             num.Count(x => x == '.') < 2 &&
             num != "";
    }

    private void Calculate(Object sender, RoutedEventArgs e) {
      String length = lengthBox.Text;
      if(IsNonnegativeString(length)) {
        MessageBox.Show("To be implemented.");
      } else {
        MessageBox.Show($"The value '{length}' is not a valid length.", "Error");
      }
    }

  }
}
