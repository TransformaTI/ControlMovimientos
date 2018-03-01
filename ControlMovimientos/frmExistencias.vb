' Muestra las  existencias del almacecén seleccionado
Public Class frmExistencias
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal AlmacenGas As Integer, ByVal Descripcion As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CargarExistencias(AlmacenGas)
        lblAlmacen.Text = Descripcion
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgExistencia As System.Windows.Forms.DataGrid
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExistencias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.dgExistencia = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAlmacen, Me.dgExistencia})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 216)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'lblAlmacen
        '
        Me.lblAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlmacen.Location = New System.Drawing.Point(34, 18)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(352, 21)
        Me.lblAlmacen.TabIndex = 31
        Me.lblAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgExistencia
        '
        Me.dgExistencia.AllowNavigation = False
        Me.dgExistencia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dgExistencia.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgExistencia.CaptionText = "Existencias"
        Me.dgExistencia.DataMember = ""
        Me.dgExistencia.FlatMode = True
        Me.dgExistencia.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgExistencia.Location = New System.Drawing.Point(4, 55)
        Me.dgExistencia.Name = "dgExistencia"
        Me.dgExistencia.ReadOnly = True
        Me.dgExistencia.Size = New System.Drawing.Size(416, 159)
        Me.dgExistencia.TabIndex = 5
        Me.dgExistencia.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgExistencia
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = "n"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn1.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn1.Width = 50
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Producto"
        Me.DataGridTextBoxColumn2.MappingName = "Producto"
        Me.DataGridTextBoxColumn2.Width = 170
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "n"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Total kilos"
        Me.DataGridTextBoxColumn3.MappingName = "Kilos"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = "n"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Total litros"
        Me.DataGridTextBoxColumn4.MappingName = "Litros"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(455, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 33
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmExistencias
        '
        Me.AcceptButton = Me.btnCerrar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(538, 238)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExistencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Existencias"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Carga los datos de las existencias del almacén mandado en el constructor
    Private Sub CargarExistencias(ByVal AlmacenGas As Integer)
        Cursor = Cursors.WaitCursor
        dgExistencia.DataSource = Nothing
        Dim oExistencia As New PortatilClasses.Consulta.cExistencia(3, AlmacenGas, 0, 0)
        oExistencia.CargaDatos(3)
        dgExistencia.DataSource = oExistencia.dtTable
        oExistencia = Nothing
        ActiveControl = btnCerrar
        Cursor = Cursors.Default
    End Sub

    ' Cierra la forma
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class
