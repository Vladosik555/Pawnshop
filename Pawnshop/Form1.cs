using Newtonsoft.Json;
using Pawnshop.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Drawing.Imaging;

namespace Pawnshop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string openFile;
        List<All__Network> networks;
        /// <summary>
        /// Загрузка файла xml и json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";
            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            openFile = open.FileName;
            string jsonFile = File.ReadAllText(openFile);
            FileStream opFile = new FileStream(openFile, FileMode.Open);
            try
            {
                if (Path.GetExtension(openFile) == ".xml")
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<All__Network>), new[] { typeof(Pawnshop_Network), typeof(Owner), typeof(Goods)});
                    networks = xml.Deserialize(opFile) as List<All__Network>;
                }
                else if (Path.GetExtension(openFile) == ".json")
                {
                    networks = System.Text.Json.JsonSerializer.Deserialize<List<All__Network>>(jsonFile);
                }
                
            }
            catch
            {
                MessageBox.Show("Невозможно загрузить файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Файл успешно загружен", "Загрузка файла", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Вывод информацию в дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show(object sender, EventArgs e)
        {
            if (networks == null)
            {
                return;
            }
            for (int i = 0; i < networks.Count; i++) 
            {
                TreeNode treeNode = new TreeNode();
                for (int j = 0; j < networks[i].List.Count; j++) 
                {
                    if (networks[i].List[j] is Pawnshop_Network) 
                    {
                        Pawnshop_Network pawnshop_Network = networks[i].List[j] as Pawnshop_Network;
                        treeNode.Nodes.Add(pawnshop_Network.Name);
                    }
                    if (networks[i].List[j] is Owner)
                    {
                        Owner owner = networks[i].List[j] as Owner;
                        treeNode.Nodes.Add(owner.Name);
                    }
                    if (networks[i].List[j] is Goods)
                    {
                        Goods goods = networks[i].List[j] as Goods;
                        treeNode.Nodes.Add(goods.Jewelry);
                    }
                }
                tree.Nodes.Add(treeNode);
            }
        }
        /// <summary>
        /// Вывод информации в таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = tree.SelectedNode.Text;
            for (int i = 0; i < networks.Count; i++) 
            {
                for (int j = 0; j < networks[i].List.Count; j++) 
                {
                    if (networks[i].List[j] is Pawnshop_Network)
                    {
                        Pawnshop_Network pawnshop_Network = networks[i].List[j] as Pawnshop_Network;
                        if (pawnshop_Network.Name == name)
                        {
                            table.Columns.Add("Id", $"{pawnshop_Network.Id}");
                            table.Columns.Add("Название", $"{pawnshop_Network.Name}");
                            table.Columns.Add("Дата основания", $"{pawnshop_Network.Opening_date}");
                            table.Columns.Add("Тип", $"{pawnshop_Network.Type}");
                            table.Columns.Add("Рейтинг", $"{pawnshop_Network.Rating}");
                            break;
                        }
                    }
                    else if (networks[i].List[j] is Owner)
                    {
                        Owner owner = networks[i].List[j] as Owner;
                        if (owner.Name == name)
                        {
                            table.Columns.Add("Имя", $"{owner.Name}");
                            table.Columns.Add("Фамилия", $"{owner.Surname}");
                            table.Columns.Add("Возраст", $"{owner.Age}");
                            table.Columns.Add("Адрес", $"{owner.Address}");
                            table.Columns.Add("Номер телефона", $"{owner.Number_phone}");
                            break;
                        }
                    }
                    else 
                    {
                        Goods goods = networks[i].List[j] as Goods;
                        if (goods.Jewelry == name) 
                        {
                            table.Columns.Add("Ювелирные", $"{goods.Jewelry}");
                            table.Columns.Add("Техника", $"{goods.Appliances}");
                            table.Columns.Add("Антиквариат", $"{goods.Antiques}");
                            table.Columns.Add("Меховые", $"{goods.Fur}");
                            table.Columns.Add("Автомобили", $"{goods.Car}");
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
