Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Drawing.Text
Imports System.Security.Cryptography

Public Class Main_Page
    Private defaultProductImage As Image
    Private defaultNewPicProductImage As Image
    Dim selectedSortOrder As String
    Dim selectedCouponName As String

    Private Sub Main_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetGroupBoxToReadOnly()
        HideAllPanels()
        GenerateProductID()
        GenerateNewCategoryID()
        GenerateNewBatchID()
        LoadProductID()
        defaultProductImage = My.Resources.picEmptyImage
        picProductImage.Image = defaultProductImage
        defaultNewPicProductImage = My.Resources.picEmptyImage
        picNewImg.Image = defaultNewPicProductImage


    End Sub

    Private Sub HideAllPanels()
        pnlAddProduct.Visible = False
        pnlViewProduct.Visible = False
        pnlUpdateProduct.Visible = False
        pnlRestockProduct.Visible = False
        pnlAddCategory.Visible = False
        pnlAddCoupon.Visible = False
        pnlViewCoupon.Visible = False
        pnlAddUser.Visible = False
        pnlViewUser.Visible = False
        pnlUpdateUser.Visible = False
        pnlViewOrder.Visible = False
        pnlCheckSale.Visible = False
        pnlUserProfile.Visible = False
    End Sub

    Private Sub menuOptAddProduct_Click(sender As Object, e As EventArgs) Handles menuOptAddProduct.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlAddProduct.Visible = True
    End Sub

    Private Sub menuOptViewProduct_Click(sender As Object, e As EventArgs) Handles menuOptViewProduct.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlViewProduct.Visible = True
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles menuOptRestockProduct.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlRestockProduct.Visible = True
    End Sub

    Private Sub menuOptUpdateProduct_Click(sender As Object, e As EventArgs) Handles menuOptUpdateProduct.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlUpdateProduct.Visible = True
    End Sub

    Private Sub menuOptAddCategory_Click(sender As Object, e As EventArgs) Handles menuOptAddCategory.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlAddCategory.Visible = True
    End Sub

    Private Sub menuOptAddCoupon_Click(sender As Object, e As EventArgs) Handles menuOptAddCoupon.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlAddCoupon.Visible = True
    End Sub

    Private Sub menuOptViewCoupon_Click(sender As Object, e As EventArgs) Handles menuOptViewCoupon.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlViewCoupon.Visible = True
    End Sub

    Private Sub menuOptAddUser_Click(sender As Object, e As EventArgs) Handles menuOptAddUser.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlAddUser.Visible = True
    End Sub

    Private Sub menuOptViewUser_Click(sender As Object, e As EventArgs) Handles menuOptViewUser.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlViewUser.Visible = True
    End Sub

    Private Sub menuOptUpdateUser_Click(sender As Object, e As EventArgs) Handles menuOptUpdateUser.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlUpdateUser.Visible = True
    End Sub

    Private Sub menuOptViewRecord_Click(sender As Object, e As EventArgs) Handles menuOptViewRecord.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlViewCoupon.Visible = True
    End Sub

    Private Sub menuOptCheckSale_Click(sender As Object, e As EventArgs) Handles menuOptCheckSale.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlCheckSale.Visible = True
    End Sub

    Private Sub btnShowProfilePic_Click(sender As Object, e As EventArgs) Handles btnShowProfilePic.Click
        HideAllPanels()
        pnlHomePage.Visible = False
        pnlUserProfile.Visible = True
    End Sub
    Private Sub GenerateProductID()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader
        Dim sql As String
        Dim lastNumber As Integer = 0

        Try
            con.Open()

            sql = "SELECT MAX(VAL(MID(ProductID, 2))) FROM Product"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read() AndAlso Not IsDBNull(reader(0)) Then
                lastNumber = CInt(reader(0))
            End If

            ' Increment and format the new ID
            Dim newIDNumber As Integer = lastNumber + 1
            Dim newID As String = "P" & newIDNumber.ToString("D3")
            txtProductID.Text = newID

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ShowRegisterData()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader
        Dim sql As String

        Try
            con.Open()

            sql = "SELECT TOP 1 [ProductID], [ProductName], [Validity] FROM [Product] ORDER BY [ProductID] DESC"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                txtAddEntryProductID.Text = reader("ProductID").ToString()
                txtAddEntryProductName.Text = reader("ProductName").ToString()
                txtAddEntryValidity.Text = reader("Validity").ToString()
            Else
                MessageBox.Show("No data found in Product table.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnLoadProductAdd_Click(sender As Object, e As EventArgs) Handles btnLoadProductAdd.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\CakeHouseDatabase.accdb")

        ' SQL query with subquery to get total quantity for each product
        Dim sql As String = "SELECT p.ProductID, p.ProductName, p.CategoryID, p.CategoryName, p.NetWeight, p.SupplierName, p.ProductImage, " &
                        "(SELECT Sum(b.Quantity) FROM Batch AS b WHERE b.ProductID = p.ProductID) AS TotalQuantity " &
                        "FROM Product AS p"

        Dim cmd As New OleDbCommand(sql, con)
        Dim reader As OleDbDataReader
        dgvAddProduct.Rows.Clear()
        dgvAddProduct.Columns.Clear()

        ' Add columns to dgvAddProduct
        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "ProductImage"
        imgCol.HeaderText = "Product Image"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvAddProduct.Columns.Add(imgCol)
        dgvAddProduct.Columns.Add("ProductID", "Product ID")
        dgvAddProduct.Columns.Add("ProductName", "Product Name")
        dgvAddProduct.Columns.Add("CategoryID", "Category ID")
        dgvAddProduct.Columns.Add("CategoryName", "Category Name")
        dgvAddProduct.Columns.Add("NetWeight", "Net Weight (gram)")
        dgvAddProduct.Columns.Add("TotalQuantity", "Total Quantity")
        dgvAddProduct.Columns.Add("SupplierName", "Supplier Name")

        Try
            con.Open()
            reader = cmd.ExecuteReader()
            While reader.Read()
                ' Get image
                Dim imgBytes As Byte() = If(Not IsDBNull(reader("ProductImage")), CType(reader("ProductImage"), Byte()), Nothing)
                Dim img As Image = Nothing
                If imgBytes IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgBytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                ' Handle null quantity
                Dim totalQuantity As String = "0"
                If Not IsDBNull(reader("TotalQuantity")) AndAlso reader("TotalQuantity") IsNot Nothing Then
                    totalQuantity = reader("TotalQuantity").ToString()
                End If

                dgvAddProduct.Rows.Add(
                img,
                reader("ProductID").ToString(),
                reader("ProductName").ToString(),
                reader("CategoryID").ToString(),
                reader("CategoryName").ToString(),
                reader("NetWeight").ToString(),
                totalQuantity,
                reader("SupplierName").ToString()
            )
            End While
            dgvAddProduct.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub

    Public Sub SetGroupBoxToReadOnly()
        txtAddEntryProductID.ReadOnly = True
        numAddEntryQuantity.ReadOnly = True
        dtpRegisterDate.Enabled = False
        txtAddEntryProductName.ReadOnly = True
        txtAddEntryValidity.ReadOnly = True
    End Sub


    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim sql As String
        Dim i As Integer


        If txtProductName.Text = "" Then
            MessageBox.Show("Please enter the product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
        ElseIf cmbCategoryID.SelectedIndex = -1 Then
            MessageBox.Show("Please select the category ID for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategoryID.Focus()
        ElseIf txtCategoryName.Text = "" Then
            MessageBox.Show("Please select the category ID for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
        ElseIf txtNetWeight.Text = "" Then
            MessageBox.Show("Please enter the net weight for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNetWeight.Focus()
        ElseIf txtValidity.Text = "" Then
            MessageBox.Show("Please enter the validity days for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtValidity.Focus()
        ElseIf txtPrice.Text = "" Then
            MessageBox.Show("Please enter the price(RM) for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
        ElseIf Not IsNumeric(txtPrice.Text) Then
            MessageBox.Show("Price must be in numeric number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
        ElseIf txtSupplierName.Text = "" Then
            MessageBox.Show("Please the supplier name for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
        ElseIf richTxtIngredient.Text = "" Then
            MessageBox.Show("Please enter the ingredients for the related product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            richTxtIngredient.Focus()
        ElseIf picProductImage.Image Is Nothing OrElse picProductImage.Image.Equals(defaultProductImage) Then
            MessageBox.Show("Please upload a valid product image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Try
                con.Open()

                ' Convert image to byte array
                Dim imageData() As Byte = Nothing
                If picProductImage.Image IsNot Nothing Then
                    Using ms As New IO.MemoryStream()
                        picProductImage.Image.Save(ms, picProductImage.Image.RawFormat)
                        imageData = ms.ToArray()
                    End Using
                End If

                sql = "INSERT INTO [Product] ([ProductID], [ProductName], [CategoryID], [CategoryName], [NetWeight], [Validity], [Price], [SupplierName], [Ingredient], [ProductImage]) " &
                  "VALUES ('" & txtProductID.Text & "','" & txtProductName.Text & "', '" & cmbCategoryID.Text & "', '" & txtCategoryName.Text & "', " &
                  txtNetWeight.Text & ", " & txtValidity.Text & ", " & txtPrice.Text & ", '" & txtSupplierName.Text & "', '" & richTxtIngredient.Text & "', ?)"

                cmd = New OleDbCommand(sql, con)
                cmd.Parameters.AddWithValue("@ProductImage", imageData) 'Parameterized form for image 

                i = cmd.ExecuteNonQuery()

                If i > 0 Then
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    txtProductName.Clear()
                    cmbCategoryID.SelectedIndex = -1
                    txtCategoryName.Clear()
                    txtNetWeight.Clear()
                    txtValidity.Clear()
                    txtPrice.Clear()
                    txtSupplierName.Clear()
                    richTxtIngredient.Clear()
                    picProductImage.Image = Nothing
                    picProductImage.BackgroundImage = My.Resources.picEmptyImage
                    picProductImage.BackgroundImageLayout = ImageLayout.Zoom
                    picProductImage.Refresh()
                    numAddEntryQuantity.Focus()
                    numAddEntryQuantity.ReadOnly = False
                    dtpRegisterDate.Enabled = True
                    txtAddEntryBatchID.Text = GenerateNewBatchID()

                    GenerateProductID()
                    ShowRegisterData()
                    ProductView()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If

    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtProductName.Clear()
        cmbCategoryID.SelectedItem = Nothing
        txtCategoryName.Clear()
        txtNetWeight.Clear()
        txtValidity.Clear()
        txtPrice.Clear()
        txtSupplierName.Clear()
        richTxtIngredient.Clear()

        picProductImage.Image = Nothing
        picProductImage.BackgroundImage = My.Resources.picEmptyImage
        picProductImage.BackgroundImageLayout = ImageLayout.Zoom
        picProductImage.Refresh()
    End Sub

    Private Sub btnAddEntryProduct_Click(sender As Object, e As EventArgs)
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As New OleDbCommand
        Dim registerDate As String = dtpRegisterDate.Value.ToString("MM/dd/yyyy")
        Dim i As Integer

        If numAddEntryQuantity.Value <= 0 Then
            MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numAddEntryQuantity.Focus()
            Exit Sub
        ElseIf txtAddEntryBatchID.Text.Trim() = "" Then
            MessageBox.Show("Batch ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddEntryBatchID.Focus()
            Exit Sub
        ElseIf txtAddEntryProductID.Text.Trim() = "" Then
            MessageBox.Show("Product ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddEntryProductID.Focus()
            Exit Sub
        ElseIf txtAddEntryProductName.Text.Trim() = "" Then
            MessageBox.Show("Product Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddEntryProductName.Focus()
            Exit Sub
        ElseIf txtAddEntryValidity.Text.Trim() = "" Then
            MessageBox.Show("Validity cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddEntryValidity.Focus()
            Exit Sub
        ElseIf Not IsNumeric(txtAddEntryValidity.Text) OrElse Convert.ToInt32(txtAddEntryValidity.Text) <= 0 Then
            MessageBox.Show("Validity must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddEntryValidity.Focus()
            Exit Sub
        End If

        Try
            con.Open()

            sql = "INSERT INTO [Batch] ([Quantity], [RestockDate], [BatchID], [ProductID], [Validity], [ProductName]) " &
              "VALUES (" & numAddEntryQuantity.Value & ", #" & registerDate & "#, '" & txtAddEntryBatchID.Text & "', '" & txtAddEntryProductID.Text & "', " & txtAddEntryValidity.Text & ", '" & txtAddEntryProductName.Text & "')"

            cmd = New OleDbCommand(sql, con)
            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                MessageBox.Show("Product entry inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                numAddEntryQuantity.Value = 0
                txtAddEntryProductID.Clear()
                txtAddEntryBatchID.Clear()
                txtAddEntryProductName.Clear()
                txtAddEntryValidity.Clear()
                SetGroupBoxToReadOnly()
            Else
                MessageBox.Show("No matching ProductID found. Insert failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbCategoryID_DropDown(sender As Object, e As EventArgs) Handles cmbCategoryID.DropDown
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader
        cmbCategoryID.Items.Clear()
        Try
            con.Open()
            sql = "SELECT CategoryID FROM Category"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                cmbCategoryID.Items.Add(reader("CategoryID").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub cmbCategoryID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryID.SelectedIndexChanged
        Dim selectedId As String = cmbCategoryID.Text.Trim()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader

        Try
            con.Open()
            sql = "SELECT CategoryName FROM Category WHERE CategoryID = '" & selectedId & "'"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                txtCategoryName.Text = reader("CategoryName").ToString()
            Else
                txtCategoryName.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub

    Private Sub btnBrowseProductImage_Click(sender As Object, e As EventArgs) Handles btnBrowseProductImage.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Title = "Select Product Image"
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            picProductImage.Image = Image.FromFile(openFileDialog.FileName)

            picProductImage.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub ProductView()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader

        dgvViewProduct.Rows.Clear()
        dgvViewProduct.Columns.Clear()

        dgvViewProduct.Columns.Add("ProductID", "Product ID")
        dgvViewProduct.Columns.Add("ProductName", "Product Name")
        dgvViewProduct.Columns.Add("CategoryName", "Category")
        dgvViewProduct.Columns.Add("SupplierName", "Supplier")
        dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
        dgvViewProduct.Columns.Add("Quantity", "Stock Level") ' now showing quantity
        dgvViewProduct.Columns.Add("Price", "Price (RM)")
        dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

        Try
            con.Open()
            ' SQL to group by ProductID, RestockDate and sum Quantity
            sql = "
            SELECT 
                p.ProductID, 
                p.ProductName, 
                p.CategoryName, 
                p.SupplierName, 
                p.NetWeight, 
                SUM(b.Quantity) AS TotalQuantity, 
                p.Price, 
                b.RestockDate, 
                b.Validity
            FROM Product AS p
            LEFT JOIN Batch AS b ON p.ProductID = b.ProductID
            GROUP BY 
                p.ProductID, 
                p.ProductName, 
                p.CategoryName, 
                p.SupplierName, 
                p.NetWeight, 
                p.Price, 
                b.RestockDate, 
                b.Validity
            ORDER BY p.ProductID, b.RestockDate
        "

            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim expiredDateStr As String = "-"
                If Not IsDBNull(reader("RestockDate")) AndAlso Not IsDBNull(reader("Validity")) Then
                    Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                    Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                    Dim expiredDate As Date = restockDate.AddDays(validityDays)
                    expiredDateStr = expiredDate.ToShortDateString()
                End If

                dgvViewProduct.Rows.Add(
                reader("ProductID").ToString(),
                reader("ProductName").ToString(),
                reader("CategoryName").ToString(),
                reader("SupplierName").ToString(),
                reader("NetWeight").ToString(),
                reader("TotalQuantity").ToString(),
                reader("Price").ToString(),
                expiredDateStr
            )
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub


    Private Sub btnLoadProductView_Click(sender As Object, e As EventArgs) Handles btnLoadProductView.Click
        ProductView()
    End Sub


    Private Sub btnSearchDescription_Click(sender As Object, e As EventArgs) Handles btnSearchDescription.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader
        Dim keyword As String = txtSearchDescription.Text.Trim().Replace("'", "''")

        dgvViewProduct.Rows.Clear()
        dgvViewProduct.Columns.Clear()

        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "ProductImage"
        imgCol.HeaderText = "Product Image"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvViewProduct.Columns.Add(imgCol)

        dgvViewProduct.Columns.Add("ProductID", "Product ID")
        dgvViewProduct.Columns.Add("ProductName", "Product Name")
        dgvViewProduct.Columns.Add("CategoryName", "Category")
        dgvViewProduct.Columns.Add("SupplierName", "Supplier")
        dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
        dgvViewProduct.Columns.Add("Price", "Price (RM)")
        dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

        Try
            con.Open()
            sql = "SELECT p.ProductID, p.ProductImage, p.ProductName, p.CategoryName, p.SupplierName, " &
      "p.NetWeight, p.Price, b.RestockDate, b.Validity " &
      "FROM Product AS p " &
      "LEFT JOIN Batch AS b ON p.ProductID = b.ProductID " &
      "WHERE p.ProductID LIKE '%" & keyword & "%' " &
      "OR p.ProductName LIKE '%" & keyword & "%' "


            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            While reader.Read()
                ' Load image safely
                Dim imgBytes As Byte() = If(Not IsDBNull(reader("ProductImage")), CType(reader("ProductImage"), Byte()), Nothing)
                Dim img As Image = Nothing
                If imgBytes IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgBytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                ' Calculate expired date only if both fields are NOT NULL
                Dim expiredDateStr As String = "N/A"
                If Not IsDBNull(reader("RestockDate")) AndAlso Not IsDBNull(reader("Validity")) Then
                    Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                    Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                    Dim expiredDate As Date = restockDate.AddDays(validityDays)
                    expiredDateStr = expiredDate.ToShortDateString()
                End If

                dgvViewProduct.Rows.Add(
                img,
                reader("ProductID").ToString(),
                reader("ProductName").ToString(),
                reader("CategoryName").ToString(),
                reader("SupplierName").ToString(),
                reader("NetWeight").ToString(),
                reader("Price").ToString(),
                expiredDateStr
            )

            End While

            txtSearchDescription.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub

    Private Sub cmbCategory_DropDown(sender As Object, e As EventArgs) Handles cmbCategory.DropDown
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader

        Try
            con.Open()
            sql = "SELECT CategoryName FROM Category"
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            cmbCategory.Items.Clear()

            While reader.Read()
                cmbCategory.Items.Add(reader("CategoryName").ToString())
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        If cmbCategory.SelectedItem Is Nothing Then Exit Sub

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader
        Dim selectedCategory As String = cmbCategory.SelectedItem.ToString().Trim().Replace("'", "''")

        dgvViewProduct.Rows.Clear()
        dgvViewProduct.Columns.Clear()

        sql = "
                SELECT p.ProductID, p.ProductName, p.CategoryName, p.SupplierName, 
                       p.NetWeight, p.Price, b.RestockDate, b.Validity, 
                       SUM(b.Quantity) AS TotalQuantity
                FROM Product AS p 
                INNER JOIN Batch AS b ON p.ProductID = b.ProductID 
                WHERE p.CategoryName = '" & selectedCategory & "' 
                GROUP BY p.ProductID, p.ProductName, p.CategoryName, p.SupplierName, 
                         p.NetWeight, p.Price, b.RestockDate, b.Validity
                ORDER BY p.ProductName"


        ' Add columns to DataGridView
        dgvViewProduct.Columns.Add("ProductName", "Product Name")
        dgvViewProduct.Columns.Add("CategoryName", "Category")
        dgvViewProduct.Columns.Add("SupplierName", "Supplier")
        dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
        dgvViewProduct.Columns.Add("Quantity", "Total Quantity")
        dgvViewProduct.Columns.Add("Price", "Price (RM)")
        dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

        Try
            con.Open()
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim expiredDateStr As String = "N/A"
                If Not IsDBNull(reader("RestockDate")) AndAlso Not IsDBNull(reader("Validity")) Then
                    Try
                        Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                        Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                        Dim expiredDate As Date = restockDate.AddDays(validityDays)
                        expiredDateStr = expiredDate.ToShortDateString()
                    Catch ex As Exception
                        expiredDateStr = "N/A"
                    End Try
                End If

                dgvViewProduct.Rows.Add(
                                        reader("ProductName").ToString(),
                                        reader("CategoryName").ToString(),
                                        reader("SupplierName").ToString(),
                                        reader("NetWeight").ToString(),
                                        reader("TotalQuantity").ToString(),
                                        reader("Price").ToString(),
                                        expiredDateStr
                                    )
                cmbCategory.SelectedIndex = -1

            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub cmbCakeStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\CakeHouseDatabase.accdb")
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader
        Dim selectedDate As Date = dtpExpiredDate.Value

        dgvViewProduct.Rows.Clear()
        dgvViewProduct.Columns.Clear()

        Dim sql As String = "SELECT p.ProductImage, p.ProductName, p.CategoryName, p.SupplierName, p.NetWeight, p.Price, b.RestockDate, b.Validity " &
        "FROM [Product] AS p INNER JOIN [Batch] AS b ON p.ProductID = b.ProductID " &
        "WHERE b.Quantity IS NOT NULL AND b.RestockDate IS NOT NULL AND b.Validity IS NOT NULL AND " &
        "DateAdd('d', b.Validity, b.RestockDate) >= ? " &
        "ORDER BY p.ProductName"

        cmd = New OleDbCommand(sql, con)
        cmd.Parameters.AddWithValue("?", selectedDate)

        ' Setup columns
        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "ProductImage"
        imgCol.HeaderText = "Product Image"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvViewProduct.Columns.Add(imgCol)

        dgvViewProduct.Columns.Add("ProductName", "Product Name")
        dgvViewProduct.Columns.Add("CategoryName", "Category")
        dgvViewProduct.Columns.Add("SupplierName", "Supplier")
        dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
        dgvViewProduct.Columns.Add("Price", "Price (RM)")
        dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

        Try
            con.Open()
            reader = cmd.ExecuteReader()

            If Not reader.HasRows Then
                MessageBox.Show("No products found with expiry on or after the selected date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            While reader.Read()
                If IsDBNull(reader("RestockDate")) OrElse IsDBNull(reader("Validity")) Then Continue While

                ' Load product image
                Dim imgBytes As Byte() = If(Not IsDBNull(reader("ProductImage")), CType(reader("ProductImage"), Byte()), Nothing)
                Dim img As Image = Nothing
                If imgBytes IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgBytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                ' Calculate expired date
                Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                Dim expiredDate As Date = restockDate.AddDays(validityDays)
                Dim expiredDateStr As String = expiredDate.ToShortDateString()

                ' Add row to DataGridView
                dgvViewProduct.Rows.Add(
                img,
                reader("ProductName").ToString(),
                reader("CategoryName").ToString(),
                reader("SupplierName").ToString(),
                reader("NetWeight").ToString(),
                reader("Price").ToString(),
                expiredDateStr
            )
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "SQL: " & sql)
        Finally
            If reader IsNot Nothing Then reader.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub




    Private Sub cmbSortingOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSortingOptions.SelectedIndexChanged
        If cmbSortingOptions.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a sorting option.")
            Exit Sub
        End If

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\CakeHouseDatabase.accdb")
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim keyword As String = cmbSortingOptions.SelectedItem.ToString().Trim()

        Select Case keyword
            Case "Stock Level (Low to High)"
                sql = "SELECT BatchID, ProductID, ProductName, Quantity, Validity, RestockDate, " &
                  "DateAdd('d', Validity, RestockDate) AS ExpiryDate " &
                  "FROM Batch ORDER BY Quantity ASC"
            Case "Stock Level (High to Low)"
                sql = "SELECT BatchID, ProductID, ProductName, Quantity, Validity, RestockDate, " &
                  "DateAdd('d', Validity, RestockDate) AS ExpiryDate " &
                  "FROM Batch ORDER BY Quantity DESC"
            Case "Expiry Date (Nearest First)"
                sql = "SELECT BatchID, ProductID, ProductName, Quantity, Validity, RestockDate, " &
                  "DateAdd('d', Validity, RestockDate) AS ExpiryDate " &
                  "FROM Batch ORDER BY DateAdd('d', Validity, RestockDate) ASC"
            Case "Expiry Date (Farthest First)"
                sql = "SELECT BatchID, ProductID, ProductName, Quantity, Validity, RestockDate, " &
                  "DateAdd('d', Validity, RestockDate) AS ExpiryDate " &
                  "FROM Batch ORDER BY DateAdd('d', Validity, RestockDate) DESC"
            Case Else
                MessageBox.Show("Invalid sort option selected.")
                Exit Sub
        End Select

        Try
            con.Open()
            da = New OleDbDataAdapter(sql, con)
            da.Fill(dt)
            dgvRestockProduct.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function GenerateNewBatchID() As String
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader
        Dim newBatchID As Integer = 1

        Try
            con.Open()
            Dim sqlBatch As String = "SELECT MAX(Val(Mid(BatchID, 2))) AS MaxBatchID FROM [Batch]"
            cmd = New OleDbCommand(sqlBatch, con)
            reader = cmd.ExecuteReader()

            If reader.Read() AndAlso Not IsDBNull(reader("MaxBatchID")) Then
                newBatchID = Convert.ToInt32(reader("MaxBatchID")) + 1
            End If

            Return "B" & newBatchID.ToString("D3")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Function

    Private Sub cmbRestockProductID_DropDown(sender As Object, e As EventArgs) Handles cmbRestockProductID.DropDown
        If cmbRestockProductID.Items.Count = 0 Then
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
            Dim cmd As New OleDbCommand
            Dim sql As String
            Dim reader As OleDbDataReader

            Try
                con.Open()
                sql = "SELECT [ProductID] FROM [Product]"
                cmd = New OleDbCommand(sql, con)
                reader = cmd.ExecuteReader()
                While reader.Read()
                    cmbRestockProductID.Items.Add(reader("ProductID").ToString())
                End While
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                reader.Close()
                con.Close()
            End Try
        End If
    End Sub
    Private Sub cmbRestockProductID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRestockProductID.SelectedIndexChanged
        If cmbRestockProductID.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader

        Try
            con.Open()

            Dim sqlProduct As String = "SELECT [ProductName], [Validity] FROM [Product] WHERE [ProductID] = @ProductID"
            cmd = New OleDbCommand(sqlProduct, con)
            cmd.Parameters.AddWithValue("@ProductID", cmbRestockProductID.SelectedItem.ToString())
            reader = cmd.ExecuteReader()
            If reader.Read() Then
                txtRestockProductName.Text = reader("ProductName").ToString()
                txtRestockValidity.Text = reader("Validity").ToString()
            End If
            reader.Close()

            txtRestockBatchID.Text = GenerateNewBatchID()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
            con.Close()
        End Try
    End Sub

    Private Sub btnRestockProduct_Click_1(sender As Object, e As EventArgs) Handles btnRestockProduct.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim sql As String
        Dim i As Integer
        Dim restockDate As String = dtpRestockDate.Value.ToString("MM/dd/yyyy")

        If txtRestockBatchID.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Batch ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestockBatchID.Focus()
            Exit Sub
        ElseIf cmbRestockProductID.SelectedIndex = -1 Then
            MessageBox.Show("Please select the Product ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRestockProductID.Focus()
            Exit Sub
        ElseIf txtRestockProductName.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Product Name.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestockProductName.Focus()
            Exit Sub
        ElseIf numRestockQuantity.Value <= 0 Then
            MessageBox.Show("Please enter a quantity greater than 0.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numRestockQuantity.Focus()
            Exit Sub
        ElseIf txtRestockValidity.Text.Trim() = "" OrElse Not IsNumeric(txtRestockValidity.Text) Then
            MessageBox.Show("Please enter a valid numeric value for Validity.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRestockValidity.Focus()
            Exit Sub
        End If

        Try
            con.Open()
            sql = "INSERT INTO [Batch] ([BatchID], [ProductID], [ProductName], [Quantity], [Validity], [RestockDate]) " &
              "VALUES ('" & txtRestockBatchID.Text & "', '" & cmbRestockProductID.SelectedItem.ToString() & "', '" &
              txtRestockProductName.Text & "', " & numRestockQuantity.Value & ", " &
              txtRestockValidity.Text & ", #" & restockDate & "#)"

            cmd = New OleDbCommand(sql, con)
            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                MessageBox.Show("Product restocked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtRestockBatchID.Clear()
                cmbRestockProductID.SelectedIndex = -1
                txtRestockProductName.Clear()
                numRestockQuantity.Value = 0
                txtRestockValidity.Clear()
                dtpRestockDate.Value = DateTime.Now
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub RestockView()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim sql As String

        Try
            con.Open()
            sql = "SELECT BatchID, ProductID, ProductName, Quantity, Validity, RestockDate, " &
                  "DateAdd('d', Validity, RestockDate) AS ExpiryDate " &
                  "FROM Batch"

            da = New OleDbDataAdapter(sql, con)
            da.Fill(dt)

            dgvRestockProduct.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnRestockLoad_Click(sender As Object, e As EventArgs) Handles btnRestockLoad.Click
        RestockView()
    End Sub
    Private Sub pnlUpdateProduct_Paint(sender As Object, e As PaintEventArgs) Handles pnlUpdateProduct.Paint
        LoadProductID()
    End Sub

    Private Sub UpdateProductView()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader

        dgvUpdateProductRecords.Rows.Clear()
        dgvUpdateProductRecords.Columns.Clear()

        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "ProductImage"
        imgCol.HeaderText = "Product Image"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvUpdateProductRecords.Columns.Add(imgCol)

        dgvUpdateProductRecords.Columns.Add("ProductID", "Product ID")
        dgvUpdateProductRecords.Columns.Add("ProductName", "Product Name")
        dgvUpdateProductRecords.Columns.Add("SupplierName", "Supplier")
        dgvUpdateProductRecords.Columns.Add("Price", "Price (RM)")
        dgvUpdateProductRecords.Columns.Add("Validity", "Validity (days)")

        Try
            con.Open()
            sql = "SELECT ProductID, ProductName, SupplierName, Price, ProductImage, Validity FROM Product "
            cmd = New OleDbCommand(sql, con)
            reader = cmd.ExecuteReader()

            If Not reader.HasRows Then
                MessageBox.Show("No products found.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            While reader.Read()
                Dim imgBytes As Byte() = If(Not IsDBNull(reader("ProductImage")), CType(reader("ProductImage"), Byte()), Nothing)
                Dim img As Image = Nothing
                If imgBytes IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgBytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                dgvUpdateProductRecords.Rows.Add(img,
                                                 reader("ProductID").ToString(),
                                                 reader("ProductName").ToString(),
                                                 reader("SupplierName").ToString(),
                                                 reader("Price").ToString(),
                                                 reader("Validity").ToString())
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            con.Close()
        End Try
    End Sub
    Private Sub btnUpdateProductLoad_Click(sender As Object, e As EventArgs) Handles btnUpdateProductLoad.Click
        UpdateProductView()
    End Sub

    Private Sub LoadProductID()
        If cmbUpdateProductID.Items.Count = 0 Then
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
            Dim cmd As New OleDbCommand
            Dim sql As String = "SELECT [ProductID] FROM [Product]"
            Dim reader As OleDbDataReader

            Try
                con.Open()
                cmd = New OleDbCommand(sql, con)
                reader = cmd.ExecuteReader()
                While reader.Read()
                    cmbUpdateProductID.Items.Add(reader("ProductID").ToString())
                End While
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
                con.Close()
            End Try
        End If
    End Sub

    Private Sub cmbUpdateProductID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUpdateProductID.SelectedIndexChanged
        If cmbUpdateProductID.SelectedItem Is Nothing Then
            ' Clear textboxes
            txtUpdateProductName.Clear()
            txtUpdateProductValidity.Clear()
            txtUpdateProductSupplier.Clear()
            txtUpdateProductPrice.Clear()

            picCurrentImg.Image = Nothing
            picCurrentImg.BackgroundImage = My.Resources.picEmptyImage
            picCurrentImg.BackgroundImageLayout = ImageLayout.Zoom
            picCurrentImg.Refresh()


            picNewImg.Image = Nothing
            picNewImg.BackgroundImage = My.Resources.picEmptyImage
            picNewImg.BackgroundImageLayout = ImageLayout.Zoom
            picNewImg.Refresh()

            Return
        End If

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim reader As OleDbDataReader = Nothing

        Try
            con.Open()

            Dim sqlProduct As String = "SELECT [ProductName], [Validity], [SupplierName], [Price], [ProductImage] FROM [Product] WHERE [ProductID] = @ProductID"
            cmd = New OleDbCommand(sqlProduct, con)
            cmd.Parameters.AddWithValue("@ProductID", cmbUpdateProductID.SelectedItem.ToString())
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                txtUpdateProductName.Text = reader("ProductName").ToString()
                txtUpdateProductValidity.Text = reader("Validity").ToString()
                txtUpdateProductSupplier.Text = reader("SupplierName").ToString()
                txtUpdateProductPrice.Text = reader("Price").ToString()

                If Not IsDBNull(reader("ProductImage")) Then
                    Dim imgBytes As Byte() = CType(reader("ProductImage"), Byte())
                    Using ms As New IO.MemoryStream(imgBytes)
                        picCurrentImg.Image = Image.FromStream(ms)
                    End Using
                Else
                    ' No image in DB — set to empty image placeholder
                    picCurrentImg.Image = Image.FromFile("picEmptyImage.png")
                End If


            Else
                ' No record found — clear text boxes and images
                txtUpdateProductName.Clear()
                txtUpdateProductValidity.Clear()
                txtUpdateProductSupplier.Clear()
                txtUpdateProductPrice.Clear()

                picCurrentImg.Image = Nothing
                picCurrentImg.BackgroundImage = My.Resources.picEmptyImage
                picCurrentImg.BackgroundImageLayout = ImageLayout.Zoom
                picCurrentImg.Refresh()


                picNewImg.Image = Nothing
                picNewImg.BackgroundImage = My.Resources.picEmptyImage
                picNewImg.BackgroundImageLayout = ImageLayout.Zoom
                picNewImg.Refresh()
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            con.Close()
        End Try
    End Sub

    Private Sub btnUpdateProductBrowse_Click(sender As Object, e As EventArgs) Handles btnUpdateProductBrowse.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Title = "Select Product Image"
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            picNewImg.Image = Image.FromFile(openFileDialog.FileName)

            picNewImg.Text = openFileDialog.FileName
        End If
    End Sub

    Private Sub btnUpdateProductRecords_Click(sender As Object, e As EventArgs) Handles btnUpdateProductRecords.Click
        If picNewImg.Image Is Nothing OrElse picNewImg.Image.Equals(defaultNewPicProductImage) Then
            MessageBox.Show("Please upload a valid product image.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            picNewImg.Focus()
            Exit Sub
        End If


        If txtUpdateProductName.Text = "" Then
            MessageBox.Show("Please enter the product name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductName.Focus()
            Exit Sub
        End If

        If txtUpdateProductValidity.Text = "" Then
            MessageBox.Show("Please enter the validity.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductValidity.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtUpdateProductValidity.Text) Then
            MessageBox.Show("Validity must be a numeric value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductValidity.Focus()
            Exit Sub
        End If

        If txtUpdateProductSupplier.Text = "" Then
            MessageBox.Show("Please enter the supplier name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductSupplier.Focus()
            Exit Sub
        End If

        If txtUpdateProductPrice.Text = "" Then
            MessageBox.Show("Please enter the price.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductPrice.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtUpdateProductPrice.Text) Then
            MessageBox.Show("Price must be a numeric value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProductPrice.Focus()
            Exit Sub
        End If

        If cmbUpdateProductID.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a product ID.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUpdateProductID.Focus()
            Exit Sub
        End If

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand

        Try
            con.Open()

            Dim imageData() As Byte = Nothing
            If picNewImg.Image IsNot Nothing Then
                Using ms As New IO.MemoryStream()
                    picNewImg.Image.Save(ms, picNewImg.Image.RawFormat)
                    imageData = ms.ToArray()
                End Using
            End If

            sql = "UPDATE [Product] SET [ProductName] = '" & txtUpdateProductName.Text & "', [Validity] = " & txtUpdateProductValidity.Text & ", 
          [SupplierName] = '" & txtUpdateProductSupplier.Text & "', [Price] = " & txtUpdateProductPrice.Text & ", 
          [ProductImage] = ? WHERE [ProductID] = '" & cmbUpdateProductID.SelectedItem.ToString().Trim() & "'"

            cmd = New OleDbCommand(sql, con)
            cmd.Parameters.AddWithValue("?", If(imageData, New Byte() {}))

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUpdateProductName.Clear()
                txtUpdateProductValidity.Clear()
                txtUpdateProductSupplier.Clear()
                txtUpdateProductPrice.Clear()
                cmbUpdateProductID.SelectedIndex = -1

                picCurrentImg.Image = Nothing
                picCurrentImg.BackgroundImage = My.Resources.picEmptyImage
                picCurrentImg.BackgroundImageLayout = ImageLayout.Zoom
                picCurrentImg.Refresh()


                picNewImg.Image = Nothing
                picNewImg.BackgroundImage = My.Resources.picEmptyImage
                picNewImg.BackgroundImageLayout = ImageLayout.Zoom
                picNewImg.Refresh()

                UpdateProductView()

            Else
                MessageBox.Show("No product was updated. Check the Product ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function GenerateNewCategoryID() As String
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String = "SELECT MAX(CategoryID) FROM Category"
        Dim cmd As New OleDbCommand(sql, con)
        Dim newID As String = ""

        Try
            con.Open()
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                Dim maxID As String = result.ToString()
                Dim numPart As Integer = Integer.Parse(maxID.Substring(1))
                numPart += 1
                newID = "C" & numPart.ToString("D2")
                txtAddCategoryID.Text = newID
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating new CategoryID: " & ex.Message)
        Finally
            con.Close()
        End Try

        Return newID
    End Function

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim cmd As OleDbCommand

        If txtAddCategoryID.Text.Trim() = "" Then
            MessageBox.Show("Please enter a Category ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCategoryID.Focus()
            Exit Sub
        ElseIf txtAddCategoryName.Text.Trim() = "" Then
            MessageBox.Show("Please enter a Category Name.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCategoryName.Focus()
            Exit Sub
        End If

        Try
            con.Open()
            sql = "INSERT INTO [Category] ([CategoryID], [CategoryName]) VALUES ('" & txtAddCategoryID.Text & "', '" & txtAddCategoryName.Text & "')"
            cmd = New OleDbCommand(sql, con)

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MessageBox.Show("New category inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtAddCategoryID.Clear()
                txtAddCategoryName.Clear()
                CategoryView()
            Else
                MessageBox.Show("Failed to insert new category.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CategoryView()
        Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String = "SELECT * FROM Category"
        Dim adapter As New OleDb.OleDbDataAdapter(sql, con)
        Dim dt As New DataTable()

        Try
            con.Open()
            sql =
            adapter.Fill(dt)
            dgvAddCategory.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnAddCategoryLoad_Click(sender As Object, e As EventArgs) Handles btnAddCategoryLoad.Click
        CategoryView()
    End Sub

    Private Sub btnAddCoupon_Click(sender As Object, e As EventArgs) Handles btnAddCoupon.Click

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim cmd As New OleDbCommand
        Dim sql As String
        Dim i As Integer

        If txtAddCouponCode.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Coupon Code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCouponCode.Focus()
            Exit Sub
        ElseIf txtAddCouponName.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Coupon Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCouponName.Focus()
            Exit Sub
        ElseIf txtAddCouponDiscount.Text.Trim() = "" Then

            MessageBox.Show("Please enter the Discount Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCouponDiscount.Focus()
            Exit Sub

        ElseIf Not IsNumeric(txtAddCouponDiscount.Text.Trim()) Then
            MessageBox.Show("Discount Rate must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCouponDiscount.Focus()
            Exit Sub

        ElseIf txtAddCouponDescription.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCouponDescription.Focus()
            Exit Sub
        Else
            Try
                con.Open()

                sql = "SELECT * FROM [Coupon] WHERE [CouponCode] = '" & txtAddCouponCode.Text & "'"
                cmd = New OleDbCommand(sql, con)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    MessageBox.Show("Coupon Code already exists. Please use a different code.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtAddCouponCode.Focus()
                    reader.Close()
                    Exit Sub
                End If
                reader.Close()

                sql = "INSERT INTO [Coupon] ([CouponCode], [CouponName], [DiscountRate], [Description]) " &
                  "VALUES ('" & txtAddCouponCode.Text & "', '" & txtAddCouponName.Text & "', " & txtAddCouponDiscount.Text & ", '" & txtAddCouponDescription.Text & "')"

                cmd = New OleDbCommand(sql, con)
                i = cmd.ExecuteNonQuery()

                If i > 0 Then
                    MessageBox.Show("Coupon record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtAddCouponCode.Clear()
                    txtAddCouponName.Clear()
                    txtAddCouponDiscount.Clear()
                    txtAddCouponDescription.Clear()
                    CouponView()
                Else
                    MessageBox.Show("Failed to insert coupon record.", "Insertion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub CouponView()
        Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable()

        Try
            con.Open()
            sql = "SELECT * FROM Coupon"
            da = New OleDb.OleDbDataAdapter(sql, con)
            da.Fill(dt)
            dgvAddCoupon.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnAddCouponLoad_Click(sender As Object, e As EventArgs) Handles btnAddCouponLoad.Click
        CouponView()
    End Sub

    Private Sub btnViewCouponClear_Click(sender As Object, e As EventArgs) Handles btnViewCouponClear.Click
        Dim con As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable()

        cmbViewCouponName.SelectedIndex = -1
        rbViewCouponHighest.Checked = False
        rbViewCouponLowest.Checked = False

        Try
            con.Open()
            sql = "SELECT * FROM Coupon"
            da = New OleDb.OleDbDataAdapter(sql, con)
            da.Fill(dt)
            dgvViewCouponDetails.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnViewCouponLoad_Click(sender As Object, e As EventArgs) Handles btnViewCouponLoad.Click
        CouponView()
    End Sub

    Private Sub cmbViewCouponName_DropDown(sender As Object, e As EventArgs) Handles cmbViewCouponName.DropDown
        cmbViewCouponName.Items.Clear()

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String = "SELECT DISTINCT CouponName FROM Coupon"
        Dim cmd As New OleDbCommand(sql, con)

        Try
            con.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbViewCouponName.Items.Add(reader("CouponName").ToString())
            End While
        Catch ex As Exception
            MessageBox.Show("Error loading coupon names: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbViewCouponName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbViewCouponName.SelectedIndexChanged

        If cmbViewCouponName.SelectedItem Is Nothing OrElse cmbViewCouponName.SelectedIndex = -1 Then
            dgvViewCouponDetails.DataSource = Nothing
            Return
        End If

        Dim selectedName As String = cmbViewCouponName.SelectedItem.ToString()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
        Dim sql As String = "SELECT * FROM Coupon WHERE CouponName = ?"
        Dim cmd As New OleDbCommand(sql, con)
        cmd.Parameters.AddWithValue("?", selectedName) ' Use parameterized query for safety

        Try
            con.Open()
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvViewCouponDetails.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error loading coupon details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub rbViewCouponHighest_CheckedChanged(sender As Object, e As EventArgs) Handles rbViewCouponHighest.CheckedChanged
        If rbViewCouponHighest.Checked Then
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
            Dim sql As String = "SELECT * FROM Coupon ORDER BY DiscountRate DESC"
            Dim cmd As New OleDbCommand(sql, con)

            Try
                con.Open()
                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvViewCouponDetails.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error sorting by highest discount: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub


    Private Sub rbViewCouponLowest_CheckedChanged(sender As Object, e As EventArgs) Handles rbViewCouponLowest.CheckedChanged
        If rbViewCouponLowest.Checked Then
            Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")
            Dim sql As String = "SELECT * FROM Coupon ORDER BY DiscountRate ASC"
            Dim cmd As New OleDbCommand(sql, con)

            Try
                con.Open()
                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvViewCouponDetails.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error sorting by lowest discount: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub dtpExpiredDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpExpiredDate.ValueChanged
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\CakeHouseDatabase.accdb")
        Dim cmd As OleDbCommand
        Dim reader As OleDbDataReader
        Dim selectedDate As Date = dtpExpiredDate.Value

        dgvViewProduct.Rows.Clear()
        dgvViewProduct.Columns.Clear()

        Dim sql As String = "
        SELECT p.ProductID, p.ProductImage, p.ProductName, p.CategoryName, 
               p.SupplierName, p.NetWeight, p.Price, b.Validity, b.RestockDate
        FROM Product AS p 
        INNER JOIN Batch AS b ON p.ProductID = b.ProductID
    "

        cmd = New OleDbCommand(sql, con)

        ' Setup columns
        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "ProductImage"
        imgCol.HeaderText = "Product Image"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        dgvViewProduct.Columns.Add(imgCol)

        dgvViewProduct.Columns.Add("ProductName", "Product Name")
        dgvViewProduct.Columns.Add("CategoryName", "Category")
        dgvViewProduct.Columns.Add("SupplierName", "Supplier")
        dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
        dgvViewProduct.Columns.Add("Price", "Price (RM)")
        dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

        Try
            con.Open()
            reader = cmd.ExecuteReader()
            Dim foundValidProduct As Boolean = False

            While reader.Read()
                If IsDBNull(reader("RestockDate")) OrElse IsDBNull(reader("Validity")) Then Continue While

                ' Calculate expired date
                Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                Dim expiredDate As Date = restockDate.AddDays(validityDays)

                ' Only show products that have NOT expired (expiredDate is today or later)
                If expiredDate < selectedDate Then Continue While

                foundValidProduct = True

                ' Load product image
                Dim imgBytes As Byte() = If(Not IsDBNull(reader("ProductImage")), CType(reader("ProductImage"), Byte()), Nothing)
                Dim img As Image = Nothing
                If imgBytes IsNot Nothing Then
                    Using ms As New IO.MemoryStream(imgBytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                ' Add row to DataGridView
                dgvViewProduct.Rows.Add(
                img,
                reader("ProductName").ToString(),
                reader("CategoryName").ToString(),
                reader("SupplierName").ToString(),
                reader("NetWeight").ToString(),
                reader("Price").ToString(),
                expiredDate.ToShortDateString()
            )
            End While

            If Not foundValidProduct Then
                MessageBox.Show("No expired products found before the selected date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & vbCrLf & "SQL: " & sql)
        Finally
            If reader IsNot Nothing Then reader.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        HideAllPanels()
        pnlHomePage.Visible = True
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim login As New Login_Page
        Me.Close()
        login.Show()
    End Sub

    Private Sub btnSerachExpiredDay_Click(sender As Object, e As EventArgs) Handles btnSerachExpiredDay.Click
        Dim userInputDays As Integer = Convert.ToInt32(numExpired.Value)
        Dim targetDate As Date = Date.Today.AddDays(userInputDays)

        ' Format date in MM/dd/yyyy with # for Access SQL
        Dim targetDateStr As String = "#" & targetDate.ToString("MM/dd/yyyy") & "#"

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\CakeHouseDatabase.accdb")

        Dim sql As String = "
        SELECT p.ProductName, p.CategoryName, p.SupplierName, p.NetWeight, b.Quantity, p.Price, 
               b.RestockDate, b.Validity
        FROM [Batch] AS b
        INNER JOIN [Product] AS p ON b.ProductID = p.ProductID
        WHERE b.Quantity IS NOT NULL AND b.RestockDate IS NOT NULL
          AND DateAdd('d', b.Validity, b.RestockDate) = " & targetDateStr

        Try
            con.Open()
            Dim cmd As New OleDbCommand(sql, con)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            dgvViewProduct.Rows.Clear()
            dgvViewProduct.Columns.Clear()

            dgvViewProduct.Columns.Add("ProductName", "Product Name")
            dgvViewProduct.Columns.Add("CategoryName", "Category")
            dgvViewProduct.Columns.Add("SupplierName", "Supplier")
            dgvViewProduct.Columns.Add("NetWeight", "Weight (gram)")
            dgvViewProduct.Columns.Add("Quantity", "Stock Level")
            dgvViewProduct.Columns.Add("Price", "Price (RM)")
            dgvViewProduct.Columns.Add("RegisterDate", "Restock Date")
            dgvViewProduct.Columns.Add("ExpiredDate", "Expired Date")

            Dim count As Integer = 0

            While reader.Read()
                Dim restockDate As Date = Convert.ToDateTime(reader("RestockDate"))
                Dim validityDays As Integer = Convert.ToInt32(reader("Validity"))
                Dim expiredDate As Date = restockDate.AddDays(validityDays)

                dgvViewProduct.Rows.Add(
                    reader("ProductName").ToString(),
                    reader("CategoryName").ToString(),
                    reader("SupplierName").ToString(),
                    reader("NetWeight").ToString(),
                    reader("Quantity").ToString(),
                    reader("Price").ToString(),
                    restockDate.ToShortDateString(),
                    expiredDate.ToShortDateString()
                )
                count += 1
            End While

            numExpired.Value = 0

            reader.Close()

            If count = 0 Then
                MessageBox.Show("No products found with expired date equal to " & targetDate.ToShortDateString())
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dgvUpdateProductRecords_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateProductRecords.CellClick
        ' Ensure the click is on a valid row, not the header
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvUpdateProductRecords.Rows(e.RowIndex)

        ' Populate controls with data from the clicked row
        cmbUpdateProductID.Text = row.Cells("ProductID").Value.ToString()
        txtUpdateProductName.Text = row.Cells("ProductName").Value.ToString()
        txtUpdateProductSupplier.Text = row.Cells("SupplierName").Value.ToString()
        txtUpdateProductPrice.Text = row.Cells("Price").Value.ToString()
        txtUpdateProductValidity.Text = row.Cells("Validity").Value.ToString()

        ' Load image from Ole Object in DataGridView
        If Not IsDBNull(row.Cells("ProductImage").Value) Then
            picCurrentImg.Image = DirectCast(row.Cells("ProductImage").Value, Image)
        Else
            picCurrentImg.Image = Nothing
        End If
    End Sub

End Class