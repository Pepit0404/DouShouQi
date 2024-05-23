using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDouShouQi.MyLayouts
{
    public class MatrixLayoutManager : ILayoutManager
    {
        double LayoutWidth { get; set; }
        double LayoutHeight { get; set; }
        double MaxCellWidth { get; set; }
        double MaxCellHeight { get; set; }
        MatrixLayout? MatrixLayout { get; set; }

        public MatrixLayoutManager(MatrixLayout matrixLayout)
        {
            MatrixLayout = matrixLayout;
        }

        
        public Size Measure(double widthConstraint, double heightConstraint)
        {
            if (MatrixLayout == null)
                return new Size(widthConstraint, heightConstraint);

            int nbRows = MatrixLayout.NbRows;
            int nbColumns = MatrixLayout.NbColumns;

            var padding = MatrixLayout.Padding;
            var horizontalSpacing = MatrixLayout.HorizontalSpacing;
            var verticalSpacing = MatrixLayout.VerticalSpacing;

            MaxCellWidth = (widthConstraint - padding.HorizontalThickness - (nbColumns - 1) * horizontalSpacing) / nbColumns;
            MaxCellHeight = (heightConstraint - padding.VerticalThickness - (nbRows - 1) * verticalSpacing) / nbRows;

            double minDim = Math.Min(MaxCellWidth, MaxCellHeight);
            MaxCellWidth = minDim;
            MaxCellHeight = minDim;

            LayoutWidth = MaxCellWidth * nbColumns + (nbColumns - 1) * horizontalSpacing + padding.HorizontalThickness;
            LayoutHeight = MaxCellHeight * nbRows + (nbRows - 1) * verticalSpacing + padding.VerticalThickness;
            return new Size(LayoutWidth, LayoutHeight);
        }



        // Ajouter arrange child
    }
}
