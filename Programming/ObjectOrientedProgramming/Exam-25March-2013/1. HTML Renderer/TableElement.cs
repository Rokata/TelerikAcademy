using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class TableElement : HTMLElement, ITable
    {
        private int rows;
        private int cols;
        private IElement[,] childElements;

        public int Rows
        {
            get { return rows; }
        }

        public int Cols
        {
            get { return cols; }
        }

        public TableElement(int rows, int cols)
            : base("table")
        {
            this.rows = rows;
            this.cols = cols;
            this.childElements = new IElement[rows, cols];
        }

        public override void Render(StringBuilder output)
        {
            if (output == null) throw new ArgumentNullException();

            output.Append("<table>");
            string currentName = String.Empty, currentContent = String.Empty;

            for (int i = 0; i < Rows; i++)
            {
                output.Append("<tr>");
                for (int j = 0; j < Cols; j++)
                {
                    currentName = this[i, j].Name;
                    currentContent = this[i, j].TextContent;

                    output.Append("<td>");

                    if (currentName != null) output.Append("<" + currentName + ">");

                    if (currentContent != null)
                    {
                        if (ContainsSpecialChars(currentContent)) output.Append(GetEscapedContent(currentContent));
                        else output.Append(currentContent);
                    }

                    if (currentName != null) output.Append("</" + this[i, j].Name + ">");

                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public IElement this[int row, int col]
        {
            get { return this.childElements[row, col]; }
            set { this.childElements[row, col] = value; }
        }

        public new void AddElement(IElement element)
        {
            throw new ArgumentNullException();
        }

        public override string ToString()
        {
            StringBuilder element = new StringBuilder();
            this.Render(element);
            return element.ToString();
        }
    }
}
