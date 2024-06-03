using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
    
        public MainWindow()
        {
            InitializeComponent();
            MyTreeView.ItemsSource = GetFolderTree(@"C:\ProgramData\Autodesk");
        }

        public List<TreeNodeClass> GetFolderTree(string path)
        {
            List<TreeNodeClass> nodes = new List<TreeNodeClass>();

            try
            {
                // 获取指定目录下的所有文件和文件夹  
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                
                // 遍历所有文件夹  
                foreach (DirectoryInfo dir in dirs)
                {
                    if(Directory.GetFiles(dir.FullName).Length > 0)
                    {
                        TreeNodeClass node = new TreeNodeClass(dir.Name,dir.FullName);

                        // 递归获取子文件夹  
                        node.Children = GetFolderTree(dir.FullName);

                        nodes.Add(node);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // 处理异常，例如记录日志或显示错误消息  
                Console.WriteLine(ex.Message);
            }

            return nodes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("123");
        }

        private void MyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeNodeClass item = MyTreeView.SelectedItem as TreeNodeClass;
            if (item != null)
            {
                
            }
            
        }

        private void TreeViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item != null)
            {
                item.IsExpanded = true;
                //MessageBox.Show("123");
            }
        }
    }
}