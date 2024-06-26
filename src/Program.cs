﻿using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BingoCardGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1000;

            if (args.Length > 0)
                int.TryParse(args[0], out count);
            if (count == 0)
                return;
            string filename = $@"c:\temp\BlueBingoCards{count}.pdf";


            Console.WriteLine($"Generating {count} bingo cards.");

            var cards = BingoCardGenerator.GenerateBatch(count);

            Console.WriteLine($"Numbers chosen for all of the cards.");


            Console.WriteLine($"Creating PDF documnent of the cards.");

            PdfDocument document = new PdfDocument();
            document.Info.Title = "BingoCards";

            XFont font = new XFont("Segoe UI Black", 36, XFontStyle.Bold);
            var pen = new XPen(XColors.Blue, 3);



            foreach (var card in cards)
            {
                PdfPage page = document.AddPage();
                int top = 100, left = 20, size = 110;

                var rect = new XRect(left, top, size, size);

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                DrawColumn(font, pen, "B", card.B, size, rect, gfx);
                rect.X += size;
                DrawColumn(font, pen, "I", card.I, size, rect, gfx);
                rect.X += size;
                DrawColumn(font, pen, "N", card.N, size, rect, gfx);
                rect.X += size;
                DrawColumn(font, pen, "G", card.G, size, rect, gfx);
                rect.X += size;
                DrawColumn(font, pen, "O", card.O, size, rect, gfx);
                rect.X += size;


                if(cards.IndexOf(card) % 50 == 0)
				{
                    Console.WriteLine($"{cards.IndexOf(card)} cards done.");
                }
            }

            Console.WriteLine($"All done generating PDF of {count} cards.");

            Console.WriteLine($"Saving PDF as {filename}.");
            // Save the document...
            document.Save(filename);
            // ...and start a viewer.

            Console.WriteLine("Done");

        }

        private static void DrawColumn(XFont font, XPen pen, string title, List<string> values, int size, XRect rect, XGraphics gfx)
        {
            DrawBox(font, pen, rect, gfx, title);
            rect.Y += size;

            foreach (string s in values)
            {
                DrawBox(font, pen, rect, gfx, s);
                rect.Y += size;
            }
        }

        private static void DrawBox(XFont font, XPen pen, XRect rect, XGraphics gfx, string text)
        {
            gfx.DrawRectangle(pen, rect);
            // Draw the text
            gfx.DrawString(text, font, XBrushes.Blue, rect, XStringFormats.Center);
        }
    }
}
