using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace elj.chtoeto
{
    public class TableCreate
    {
        //родительский флоу
        FlowDocument flowDocument = new FlowDocument();
        //создание таблицы
        Table table1 = new Table();
        public void Aa()
        {
            //добавление в коллекцию
            flowDocument.Blocks.Add(table1);
            //некоторые параметры
            table1.CellSpacing = 10;
            table1.Background = Brushes.White;

            //создать колонки
            int numOfColumns = 3;
            for (int i = 0; i < numOfColumns; i++)
            {
                table1.Columns.Add(new TableColumn());

                // Set alternating background colors for the middle colums.
                if (i % 2 == 0)
                    table1.Columns[i].Background = Brushes.Beige;
                else
                    table1.Columns[i].Background = Brushes.LightSteelBlue;
            }
        }
    }
}
