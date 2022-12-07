// Written by Turin Briggs 2022
namespace LinearAlgebraApplications;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		drawPanel.c = new Cube();
        graphicsView.Invalidate();
    }

	/// <summary>
	/// Perform a rotation of the cube around the specified axis
	/// </summary>
	private void OnRotateClicked(object sender, EventArgs e)
	{
		if(Double.TryParse(angleEntry.Text, out double angle))
		{
			if(axisEntry.Text == "X")
			{
                drawPanel.c.TransformCube(Matrix4x4.BuildRotationMatrix(angle, 1));
            }
			else if (axisEntry.Text == "Y")
			{
                drawPanel.c.TransformCube(Matrix4x4.BuildRotationMatrix(angle, 2));
            }
			else if(axisEntry.Text == "Z")
			{
                drawPanel.c.TransformCube(Matrix4x4.BuildRotationMatrix(angle, 3));
            }
		}
        graphicsView.Invalidate();
    }

    /// <summary>
    /// Perform a translation of the cube
    /// </summary>
    private void OnTranslateClicked(object sender, EventArgs e)
	{
		if (Double.TryParse(xEntry.Text, out double x) && Double.TryParse(yEntry.Text, out double y) && Double.TryParse(zEntry.Text, out double z))
		{
			drawPanel.c.TransformCube(Matrix4x4.BuildTranslationMatrix(x, -y, z));
		}
        graphicsView.Invalidate();
    }

    /// <summary>
    /// Reset the cube to default state
    /// </summary>
    private void OnResetClicked(object sender, EventArgs e)
	{
        drawPanel.c = new Cube();
        graphicsView.Invalidate();
    }
}

