using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class SaveAndOpen
    {
        public Form ActiveMdiChild;
        public Form MdiParent;
        public bool newFormCreated;
        public SaveAndOpen(Form activeMdiChild, Form mdiParent)
        {
            this.ActiveMdiChild = activeMdiChild;
            this.MdiParent = mdiParent;
        }
        public bool saveHowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Файлы формы (*.frm)|*.frm";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SerializeFormPosition((Form2)ActiveMdiChild, saveFileDialog.FileName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool saveToolStripMenuItem_Click(object sender, EventArgs e, string Text)
        {
            if (ActiveMdiChild != null)
            {
              SerializeFormPosition((Form2)ActiveMdiChild, ActiveMdiChild.Text);
            }
            return true;
        }

        public bool openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы формы (*.frm)|*.frm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try { 
                    DeserializeFormPosition(openFileDialog.FileName);
                    return true;
                } catch { return false; }
            }
            else
            {
                return false;
            }
        }

        // Метод сериализации позиции и размеров формы
        private void SerializeFormPosition(Form2 form, string filename)
        {
            try
            {
                FormPositionData formData = new FormPositionData
                {
                    Left = form.Left,
                    Top = form.Top,
                    Width = form.Width,
                    Height = form.Height,
                    savedRectangles = form.savedRectangles
                };

                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Create))
                {
                    formatter.Serialize(stream, formData);
                }
                MessageBox.Show("Позиция и размеры формы успешно сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении формы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод обратной сериализации позиции и размеров формы
        private void DeserializeFormPosition(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    FormPositionData formData = (FormPositionData)formatter.Deserialize(stream);
                    newFormCreated = false;
                    Form2 newForm = new Form2(newFormCreated);
                    newForm.Left = formData.Left;
                    newForm.Text = filename;
                    newForm.Top = formData.Top;
                    newForm.Width = formData.Width;
                    newForm.Height = formData.Height;
                    newForm.MdiParent = MdiParent;
                    newForm.savedRectangles = formData.savedRectangles;
                    newForm.Show();
                }
                MessageBox.Show("Форма успешно восстановлена.", "Открытие", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии формы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательный класс для хранения данных о позиции и размерах формы
        [Serializable]
        private class FormPositionData
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public List<Rectangle> savedRectangles { get; set; }
        }
       
    }
}
