    using System;
    using System.Windows;
    using System.Windows.Controls;
    using BusinessObjects;
    using Services;

    namespace WPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private readonly IProductService iProductService;
            private readonly ICategoryService iCategoryService;

            public MainWindow()
            {
                InitializeComponent();
                iProductService = new ProductService();
                iCategoryService = new CategoryService();
            }

            public void LoadCategoryList()
            {
                try
                {
                    var catList = iCategoryService.GetCategories();
                    cboCategory.ItemsSource = catList;
                    cboCategory.DisplayMemberPath = "CategoryName";
                    cboCategory.SelectedValuePath = "CategoryId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on load list of categories");
                }
            }

            public void LoadProductList()
            {
                try
                {
                    var productList = iProductService.GetProducts();
                    dgData.ItemsSource = productList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on load list of products");
                }
                finally
                {
                    resetInput();
                }
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                LoadCategoryList();
                LoadProductList();
            }

            private void btnCreate_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Product product = new Product();
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryID = int.Parse(cboCategory.SelectedValue.ToString());
                    iProductService.SaveProduct(product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadProductList();
                }
            }

            private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow dgr = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell cell = (DataGridCell)dataGrid.Columns[0].GetCellContent(dgr).Parent as DataGridCell;
                txtProductID.Text = ((Product)dgr.Item).ProductID.ToString();
                txtProductName.Text = ((Product)dgr.Item).ProductName;
                txtPrice.Text = ((Product)dgr.Item).UnitPrice.ToString();
                txtUnitsInStock.Text = ((Product)dgr.Item).UnitsInStock.ToString();
                cboCategory.SelectedValue = ((Product)dgr.Item).CategoryID;
            }

            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void btnUpdate_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (txtProductID.Text.Length > 0)
                    {
                        Product product = new Product();
                        product.ProductID = int.Parse(txtProductID.Text);
                        product.ProductName = txtProductName.Text;
                        product.UnitPrice = decimal.Parse(txtPrice.Text);
                        product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                        product.CategoryID = int.Parse(cboCategory.SelectedValue.ToString());
                        iProductService.UpdateProduct(product);
                    }
                    else
                    {
                        MessageBox.Show("You must select a Product !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadProductList();
                }
            }

            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (txtProductID.Text.Length > 0)
                    {
                        Product product = new Product();
                        product.ProductID = int.Parse(txtProductID.Text);
                        product.ProductName = txtProductName.Text;
                        product.UnitPrice = decimal.Parse(txtPrice.Text);
                        product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                        product.CategoryID = int.Parse(cboCategory.SelectedValue.ToString());
                        iProductService.DeleteProduct(product);
                    }
                    else
                    {
                        MessageBox.Show("You must select a Product !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadProductList();
                }
            }

            private void resetInput()
            {
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtPrice.Text = "";
                txtUnitsInStock.Text = "";
                cboCategory.SelectedIndex = 0;
            }
        }
    }