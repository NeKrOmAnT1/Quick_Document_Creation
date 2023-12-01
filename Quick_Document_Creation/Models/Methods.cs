using System;
using System.Windows;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Windows.Input;
using System.Windows.Controls;

namespace Quick_Document_Creation.Models
{
    internal class Methods
    {
        public static void SelectDoc(ComboBoxItem selectItem, string Сourse, string Fio, string Groupe, ComboBoxItem Forma, string Date)
        {
            try
            {
                if (selectItem == null)
                {
                    MessageBox.Show("Не был выбран тип документа");
                    return;
                }

                string select = selectItem.Tag.ToString();

                switch (select)
                {

                case "Справка №1": GenerateDocMesto(Сourse, Fio, Groupe, Forma, Date); break;

                }
            }
            catch(Exception) 
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
        public static void GenerateDocMesto(string Сourse, string Fio, string Groupe, ComboBoxItem Forma, string Date)
        {
            try
            {
                string FormaLessons = Forma.Tag.ToString();
                using (var doc = DocX.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\GeneratedDocument.docx"))
                {
                    var title = doc.InsertParagraph("СПРАВКА");
                    title.Font("Times New Roman").FontSize(18).Bold().Alignment = Alignment.center;

                    title.SpacingAfter(10); 

                    var paragraph1 = doc.InsertParagraph($"Выдана {Fio}, {Date} числа," +
                        $" в том, что он (она) действительно учится в ГАПОУ «СГК», на {Сourse} курсе в 2023-2024 учебном году. Специальность (код, наименование)" +
                        $" {Groupe}, форма обучения: {FormaLessons}.");
                    paragraph1.Font("Times New Roman").FontSize(14).SpacingAfter(10).Alignment = Alignment.both;

                    var paragraph4 = doc.InsertParagraph($"Дата начала обучения: «_____» _____________ _____ г.");
                    paragraph4.Font("Times New Roman").FontSize(14).SpacingAfter(10).Alignment = Alignment.both;

                    var paragraph5 = doc.InsertParagraph($"Дата окончания обучения: «_____» _____________ _____ г.");
                    paragraph5.Font("Times New Roman").FontSize(14).SpacingAfter(10).Alignment = Alignment.both;

                    var paragraph6 = doc.InsertParagraph("Справка выдана по месту требования.");
                    paragraph6.Font("Times New Roman").FontSize(14).SpacingAfter(10).Alignment = Alignment.both;

                    var paragraph7 = doc.InsertParagraph("Директор __________________/ _____________________");
                    paragraph7.Font("Times New Roman").FontSize(14).SpacingAfter(10).Alignment = Alignment.both;

                    doc.Save();
                }

                MessageBox.Show("Документ успешно создан и сохранен.", "Готово");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
        }
    }
}
