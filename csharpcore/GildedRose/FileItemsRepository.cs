using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace GildedRoseKata
{
    
    public class FileItemsRepository : ItemsRepository
    {
        public IList<Item> getInventory()
        {
            IList<Item> items = new List<Item>();
            using (TextFieldParser textFieldParser = new TextFieldParser(@"data.csv"))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(",");
                while (!textFieldParser.EndOfData)
                {
                    string[] rows = textFieldParser.ReadFields();
                    switch (rows[0])
                    {
                        case"ConjuredItem":
                            items.Add(new ConjuredItem(rows[1], int.Parse(rows[2]), int.Parse(rows[3])));
                            break;
                        case"AgingItem":
                            items.Add(new AgingItem(rows[1], int.Parse(rows[2]), int.Parse(rows[3])));
                            break;
                        case"LegendaryItem":
                            items.Add(new LegendaryItem(rows[1], int.Parse(rows[2]), int.Parse(rows[3])));
                            break;
                        case"EventItem":
                            items.Add(new EventItem(rows[1], int.Parse(rows[2]), int.Parse(rows[3])));
                            break;
                        case"GenericItem":
                            items.Add(new GenericItem(rows[1], int.Parse(rows[2]), int.Parse(rows[3])));
                            break;
                    }
                }
            }

            return items;
        }

        public void saveInventory(IList<Item> items)
        {
            File.WriteAllLines(@"data.csv", items.Select(item => String.Join(item.GetType().Name, ',', item, ",")));
        }
    }
}
