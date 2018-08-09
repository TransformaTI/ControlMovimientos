'Forma para el control de fugas portatil se creo el 03 de diciembre

'Modificó: Claudia Aurora García Patiño
'Fecha: 17/02/2006
'Descripción: Se modifico la forma d ecarga el combo celula
'Identificador de cambios: 20060217CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$003

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReposicionFugasPortatil
    Inherits System.Windows.Forms.Form

#Region "Variables"
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private Titulo As String
    Private NumEnter As Short

    Private dvDetalle As DataView
    Private dtDetalle As DataTable = New DataTable()
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cboAlmacenOrigen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents dgtcCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgtcDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgtbCantidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgtcProducto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReposicionFugasPortatil))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFVenta = New System.Windows.Forms.DateTimePicker()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboAlmacenOrigen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.dgtcCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgtcDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgtbCantidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgtcProducto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.grpDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(660, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label3, Me.cboCorporativo, Me.Label2, Me.dtpFVenta, Me.lblCamion, Me.lblRuta, Me.cboAlmacenOrigen, Me.Label13, Me.Label6, Me.Label4, Me.Label5, Me.Label1, Me.dtpFMovimiento})
        Me.grpDatos.Location = New System.Drawing.Point(10, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(630, 230)
        Me.grpDatos.TabIndex = 12
        Me.grpDatos.TabStop = False
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(128, 52)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Célula:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Location = New System.Drawing.Point(128, 24)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Fecha reposición:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFVenta
        '
        Me.dtpFVenta.CustomFormat = ""
        Me.dtpFVenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFVenta.Location = New System.Drawing.Point(128, 191)
        Me.dtpFVenta.Name = "dtpFVenta"
        Me.dtpFVenta.Size = New System.Drawing.Size(216, 21)
        Me.dtpFVenta.TabIndex = 5
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Location = New System.Drawing.Point(128, 135)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(216, 21)
        Me.lblCamion.TabIndex = 29
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(128, 107)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(216, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenOrigen
        '
        Me.cboAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenOrigen.Location = New System.Drawing.Point(128, 79)
        Me.cboAlmacenOrigen.Name = "cboAlmacenOrigen"
        Me.cboAlmacenOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenOrigen.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén origen:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Camión:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(128, 163)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 4
        '
        'txtCliente
        '
        Me.txtCliente.AutoSize = False
        Me.txtCliente.Location = New System.Drawing.Point(136, 18)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 21)
        Me.txtCliente.TabIndex = 66
        Me.txtCliente.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Ingrese el número de cliente")
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(660, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.dgDetalle, Me.txtCliente, Me.Label12, Me.lblCliente, Me.Label7, Me.ProductoPanel, Me.Label10, Me.lblKilos})
        Me.GroupBox1.Location = New System.Drawing.Point(10, 239)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 264)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.ImageList = Me.ielImagenes
        Me.btnBuscar.Location = New System.Drawing.Point(548, 22)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 74
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgDetalle
        '
        Me.dgDetalle.CaptionText = "Productos"
        Me.dgDetalle.DataMember = ""
        Me.dgDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDetalle.Location = New System.Drawing.Point(422, 79)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.RowHeadersVisible = False
        Me.dgDetalle.RowHeaderWidth = 0
        Me.dgDetalle.Size = New System.Drawing.Size(295, 177)
        Me.dgDetalle.TabIndex = 73
        Me.dgDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgDetalle.TabStop = False
        Me.dgDetalle.Visible = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dgtcCliente, Me.dgtcDescripcion, Me.dgtbCantidad, Me.dgtcProducto})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'dgtcCliente
        '
        Me.dgtcCliente.Format = ""
        Me.dgtcCliente.FormatInfo = Nothing
        Me.dgtcCliente.HeaderText = "Cliente"
        Me.dgtcCliente.MappingName = "Cliente"
        Me.dgtcCliente.ReadOnly = True
        Me.dgtcCliente.Width = 70
        '
        'dgtcDescripcion
        '
        Me.dgtcDescripcion.Format = ""
        Me.dgtcDescripcion.FormatInfo = Nothing
        Me.dgtcDescripcion.HeaderText = "Descripción"
        Me.dgtcDescripcion.MappingName = "Producto"
        Me.dgtcDescripcion.ReadOnly = True
        Me.dgtcDescripcion.Width = 150
        '
        'dgtbCantidad
        '
        Me.dgtbCantidad.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.dgtbCantidad.Format = ""
        Me.dgtbCantidad.FormatInfo = Nothing
        Me.dgtbCantidad.HeaderText = "Cantidad"
        Me.dgtbCantidad.MappingName = "Cantidad"
        Me.dgtbCantidad.Width = 50
        '
        'dgtcProducto
        '
        Me.dgtcProducto.Format = ""
        Me.dgtcProducto.FormatInfo = Nothing
        Me.dgtcProducto.MappingName = "IdenProducto"
        Me.dgtcProducto.ReadOnly = True
        Me.dgtcProducto.Width = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 14)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(136, 45)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(492, 21)
        Me.lblCliente.TabIndex = 72
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 14)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Cliente:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(9, 74)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(412, 152)
        Me.ProductoPanel.TabIndex = 67
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(249, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Kilos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(297, 231)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 68
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Bitmap)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.ImageIndex = 1
        Me.btnQuitar.ImageList = Me.ielImagenes
        Me.btnQuitar.Location = New System.Drawing.Point(660, 214)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.TabIndex = 16
        Me.btnQuitar.TabStop = False
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.ImageList = Me.ielImagenes
        Me.btnAgregar.Location = New System.Drawing.Point(660, 184)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "A&gregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmReposicionFugasPortatil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(744, 512)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnQuitar, Me.btnAgregar, Me.GroupBox1, Me.btnAceptar, Me.grpDatos, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReposicionFugasPortatil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reposición de fugas a rutas portátiles"
        Me.grpDatos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos Impresion de Reporte"

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora()
        Dim Impresoras As New Printing.PrinterSettings()
        rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
    End Sub

    ' Establece la conexion de los subreportes que esten contenidos en el reporte
    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer

        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)

                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = GLOBAL_Servidor
                        .DatabaseName = GLOBAL_BaseDatos
                        .UserID = GLOBAL_Usuario
                        .Password = GLOBAL_Password
                    End With
                    _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                Next
            End If
        Next
    End Sub

    ' Establece y realiza la conexión para cargar la información al reporte
    Public Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = GLOBAL_Servidor
                .DatabaseName = GLOBAL_BaseDatos
                .UserID = GLOBAL_Usuario
                .Password = GLOBAL_Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
        OpenSubreport()
    End Sub

    ' Manda al procedimientos los valores de los parametros e imprime el ticket de carga
    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketReposicionFuga.rpt")

            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Configuracion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@MovimientoAlmacen")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            AplicaInfoConexion()

            Try
                EstablecerImpresora()
                rptReporte.PrintToPrinter(1, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Metodos y Funciones"

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        btnAgregar.Enabled = False
        lblKilos.Text = "0"
        lblRuta.Text = ""
        lblCamion.Text = ""
        txtCliente.Text = ""
        lblCliente.Text = ""
        If cboAlmacenOrigen.Items.Count > 1 Then
            cboAlmacenOrigen.SelectedIndex = -1
            cboAlmacenOrigen.SelectedIndex = -1
        End If
    End Sub

    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblRuta.Text = ""
        txtCliente.Clear()
        lblCliente.Text = ""
        lblKilos.Text = "0"
    End Sub

    Private Sub BorrarDatos()
        Cursor = Cursors.WaitCursor
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()

        Dim i As Integer
        For i = 0 To ProductoPanel.txtLista.Count() - 1
            textBox1 = CType(ProductoPanel.txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
            textBox1.Text = ""
        Next
        Cursor = Cursors.Default
    End Sub

    'Funcion que registra la medicion fisica "CODIGO PACO"
    Private Sub MedicionFisica(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboAlmacenOrigen.Text <> "" And lblCliente.Text <> "" And dtDetalle.Rows.Count > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
        If cboAlmacenOrigen.Text <> "" And lblCliente.Text <> "" Then
            btnAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
        End If
    End Sub

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function ValidarRangoFechaVenta() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(0, cboAlmacenOrigen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
            dtpFVenta.Value = Fecha
            dtpFVenta.MinDate = CType(oConsultaFechas.drReader(1), Date)
            dtpFVenta.MaxDate = dtpFVenta.Value.AddDays(3)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = ValidarRangoFechaVenta()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Si el usuario tiene privilegios de realizar cargas de diferentes empresas, habilita el combo de las empresas 
    ' para que el usuario pueda relizar cargas de todas las empresas
    Private Sub HabilitarEmpresa()
        cboCorporativo.CargaDatos(0)
        cboCorporativo.PosicionaCombo(GLOBAL_Empresa)
        ' 20060217CAGP$001 /I
        cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
        ' 20060217CAGP$001 /F
        cboCelula.PosicionaCombo(GLOBAL_Celula)
        ' Carga almaceens de tipo Ruta Portatil y andenes por CELULA
        cboAlmacenOrigen.CargaDatos(18, GLOBAL_Usuario, cboCelula.Identificador)
        ProductoPanel.BorrarDatos()
        CargarDatosAlmacen()

        If GLOBAL_VerEmpresas = False Then
            cboCorporativo.Enabled = False
            ActiveControl = cboAlmacenOrigen
        End If
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Cursor = Cursors.WaitCursor
        Dim oCliente As PortatilClasses.Consulta.cCliente

        Try
            Dim corporativo As Integer = CInt(cboCorporativo.SelectedValue)

            oCliente = New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer), corporativo)
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim strURLGateway As String = CType(oConfig.Parametros("URLGateway"), String).Trim

            If String.IsNullOrEmpty(strURLGateway) Then
                oCliente.CargaDatos()
            Else
                ' Se requiere el corporativo para consultar al web service
                If corporativo <= 0 Then
                    Dim Mensajes As New PortatilClasses.Mensaje(12)
                    Throw New Exception(Mensajes.Mensaje)
                End If

                oCliente.CargaDatos(strURLGateway, CByte(GLOBAL_Modulo))
            End If

            If oCliente.Cliente <> "" Then
                lblCliente.Text = oCliente.Cliente
                HabilitarAceptar()
            Else
                LimpiarCliente()
                Dim Mensajes As New PortatilClasses.Mensaje(3)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = txtCliente
                txtCliente.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reposición de fugas a rutas portátiles", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCliente = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarDatosAlmacen()
        If cboAlmacenOrigen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenOrigen.Identificador)
            ValidarRangoFechaVenta()

            Dim cRuta As New nombreRuta(0, cboAlmacenOrigen.Identificador)
            Dim cCamion As New nombreCamion(0, cboAlmacenOrigen.Identificador)
            cRuta.CargaDatos()
            lblRuta.Text = cRuta.Descripcion
            lblRuta.Tag = cRuta.Identificador
            cCamion.CargaDatos()
            lblCamion.Text = cCamion.Descripcion
            lblCamion.Tag = cCamion.Identificador
            dgDetalle.Visible = True
        End If
    End Sub

    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
        Dim i As Integer
        Dim ii As Integer
        Dim Cantidad As Integer
        Dim Kilos As Decimal
        Dim lblProducto As New Windows.Forms.Label()
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()

        For i = 0 To ProductoPanel.pdtoLista.Count() - 1
            lblProducto = CType(ProductoPanel.lblLista.Item(i), Windows.Forms.Label)
            textBox1 = CType(ProductoPanel.txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
            Cantidad = 0

            For ii = 0 To dtDetalle.Rows.Count - 1
                If CType(dgDetalle.Item(ii, 3), Integer) = CType(ProductoPanel.pdtoLista(i), Integer) Then
                    Cantidad = Cantidad + CType(dgDetalle.Item(ii, 2), Integer)
                End If
            Next

            If Cantidad > 0 Then
                Kilos = Cantidad * CType(textBox1.Tag, Decimal)
                Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
                oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(0, Almacen, _
                                                CType(ProductoPanel.pdtoLista(i), Integer), _
                                                MovimientoAlmacen, Kilos, Kilos, Cantidad)
                oMovimientoAProducto.CargaDatos()
            End If
        Next
    End Sub

    Private Function Capacidad(ByVal Producto As Integer) As Decimal
        Dim i As Integer
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()

        For i = 0 To ProductoPanel.pdtoLista.Count() - 1
            If CType(ProductoPanel.pdtoLista(i), Integer) = Producto Then
                textBox1 = CType(ProductoPanel.txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                Return CType(textBox1.Tag, Decimal)
            End If
        Next
    End Function

    Private Sub RegistraPedido(ByVal Att As Short, ByVal FolioAtt As Integer, ByVal MovimientoAlmacen As Integer)
        Dim i As Integer
        Dim ii As Integer
        Dim Kilos As Decimal
        Dim Cliente As Integer
        Dim oPedido As PortatilClasses.cLiquidacion

        For i = 0 To dtDetalle.Rows.Count - 1
            Cliente = CType(dgDetalle.Item(i, 0), Integer)
            For ii = 0 To dtDetalle.Rows.Count - 1
                If Cliente = CType(dgDetalle.Item(ii, 0), Integer) Then
                    Kilos = CType(dgDetalle.Item(ii, 2), Integer) * Capacidad(CType(dgDetalle.Item(ii, 3), Integer))
                    oPedido = New PortatilClasses.cLiquidacion(0, CType(cboCelula.Identificador, Short), 0, 0)
                    oPedido.LiquidacionPedidoyCobroPedido(CType(dgDetalle.Item(ii, 3), Integer), dtpFMovimiento.Value, _
                            0, 0, 0, 0, 0, "ACTIVO", Cliente, Now, 0, "", 1, 1, _
                            CType(lblRuta.Tag, Short), 0, 0, GLOBAL_Usuario, CType(lblRuta.Tag, Short), 1, _
                            Att, FolioAtt, "PENDIENTE", 0, Now, Now, 0, MovimientoAlmacen, cboAlmacenOrigen.Identificador, _
                            0, -1, 0, 1, Kilos)
                End If
            Next
        Next
    End Sub

    ' Registra la información en la base de datos
    Public Function RealizarMovimientos() As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            Cursor = Cursors.WaitCursor
            Dim Kilos As Decimal
            Dim Litros As Decimal

            Dim Ano As Integer

            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            Ano = dtpFMovimiento.Value.Year
            Kilos = CType(lblKilos.Text, Decimal)
            Litros = Kilos / CType(FactorDensidad, Decimal)
            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacenOrigen.Identificador, 0, 28, 0)

            'Registra el movimiento de salida
            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrigen.Identificador, dtpFMovimiento.Value, _
                                       Kilos, Litros, 28, dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            'Registra el detalle de los productos salida
            RegistraMovimientoProducto(cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador)

            ' Registra la información en la tabla de AutoTanqueTurno
            Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
            oAutotanqueTurno.CargaDatos(Ano, CType(lblRuta.Tag, Integer), dtpFVenta.Value.Date, 0, cboCelula.Identificador, 1, _
                    CType(lblCamion.Tag, Short), 1, 0, oMovimientoAlmacenS.Identificador, cboAlmacenOrigen.Identificador, False)

            'Registra en la tabla de pedido
            RegistraPedido(CType(oAutotanqueTurno.AnoAtt, Short), oAutotanqueTurno.FolioMov, _
                           oMovimientoAlmacenS.Identificador)

            'Registro de las mediciones físicas del almacen origen 
            If GLOBAL_MedicionFisica Then
                MedicionFisica(oMovimientoAlmacenS.Identificador)
            End If

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
            End If

            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            LimpiarDetalle()
            ProductoPanel.BorrarDatos()
            Cursor = Cursors.Default
        End If
    End Function

    Private Sub DesplegarTitulos()
        Dim dcoDetalle As DataColumn

        dcoDetalle = New DataColumn()
        dcoDetalle.DataType = Type.GetType("System.String")
        dcoDetalle.ColumnName = "Cliente"
        dtDetalle.Columns.Add(dcoDetalle)

        dcoDetalle = New DataColumn()
        dcoDetalle.DataType = System.Type.GetType("System.String")
        dcoDetalle.ColumnName = "Producto"
        dtDetalle.Columns.Add(dcoDetalle)

        dcoDetalle = New DataColumn()
        dcoDetalle.DataType = Type.GetType("System.Decimal")
        dcoDetalle.ColumnName = "Cantidad"
        dtDetalle.Columns.Add(dcoDetalle)

        dcoDetalle = New DataColumn()
        dcoDetalle.DataType = Type.GetType("System.Decimal")
        dcoDetalle.ColumnName = "IdenProducto"
        dtDetalle.Columns.Add(dcoDetalle)

        dvDetalle = New DataView(dtDetalle)
        dgDetalle.DataSource = dvDetalle
    End Sub

    Private Sub DesplegarDatos(ByVal Cliente As Integer, ByVal Producto As String, ByVal Cantidad As Integer, _
    ByVal IdenProducto As Integer)
        Dim droDetalle As DataRow

        droDetalle = dtDetalle.NewRow()
        droDetalle("Cliente") = Cliente  '0
        droDetalle("Producto") = Producto  '1 
        droDetalle("Cantidad") = Cantidad  '2
        droDetalle("IdenProducto") = IdenProducto  '3

        dtDetalle.Rows.Add(droDetalle)
    End Sub

    Private Function ExisteDetalle(ByVal Cliente As Integer, ByVal IdenProducto As Integer, _
    ByVal Cantidad As Integer) As Boolean
        Dim i As Integer
        Dim Existe As Boolean = False
        For i = 0 To dtDetalle.Rows.Count - 1
            If CType(dgDetalle.Item(i, 0), Integer) = Cliente And CType(dgDetalle.Item(i, 3), Integer) = IdenProducto Then
                Cantidad = Cantidad + CType(dgDetalle.Item(i, 2), Integer)
                dgDetalle.Item(i, 2) = Cantidad
                Existe = True
            End If
        Next
        Return Existe
    End Function

    Private Sub AgregarDetalle()
        Cursor = Cursors.WaitCursor
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
        Dim Descripcion As String

        Dim i As Integer
        For i = 0 To ProductoPanel.txtLista.Count() - 1
            textBox1 = CType(ProductoPanel.txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
            Descripcion = CType(ProductoPanel.ListaDescripcion.Item(i), String)

            If textBox1.Text <> "" Then
                If ExisteDetalle(CType(txtCliente.Text, Integer), CType(ProductoPanel.pdtoLista(i), Integer), CType(textBox1.Text, Integer)) = False Then
                    DesplegarDatos(CType(txtCliente.Text, Integer), Descripcion, CType(textBox1.Text, Integer), CType(ProductoPanel.pdtoLista(i), Integer))
                End If
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub LimpiarDetalle()
        While dtDetalle.Rows.Count > 0
            QuitarDetalle()
        End While
    End Sub

    Private Sub QuitarDetalle()
        If dtDetalle.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            Dim droDetalle As DataRow
            droDetalle = dtDetalle.Rows(dgDetalle.CurrentRowIndex)
            dtDetalle.Rows.Remove(droDetalle)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Function VerificarExistencias() As Boolean
        Dim i As Integer
        Dim ii As Integer
        Dim Cantidad As Integer
        Dim lblProducto As New Windows.Forms.Label()

        For i = 0 To ProductoPanel.pdtoLista.Count() - 1
            lblProducto = CType(ProductoPanel.lblLista.Item(i), Windows.Forms.Label)
            Cantidad = 0

            For ii = 0 To dtDetalle.Rows.Count - 1
                If CType(dgDetalle.Item(ii, 3), Integer) = CType(ProductoPanel.pdtoLista(i), Integer) Then
                    Cantidad = Cantidad + CType(dgDetalle.Item(ii, 2), Integer)
                End If
            Next
            If lblProducto.Text <> "" Then
                If CType(lblProducto.Text, Integer) < Cantidad Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function SumarKilos() As Decimal
        Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
        Dim i As Integer
        Dim ii As Integer
        Dim Kilos As Decimal = 0
        For i = 0 To ProductoPanel.txtLista.Count() - 1
            textBox1 = CType(ProductoPanel.txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
            For ii = 0 To dtDetalle.Rows.Count - 1
                If CType(dgDetalle.Item(ii, 3), Integer) = CType(ProductoPanel.pdtoLista(i), Integer) Then
                    Kilos = Kilos + CType(textBox1.Tag, Decimal) * CType(dgDetalle.Item(ii, 2), Integer)
                End If
            Next
        Next
        Return Kilos
    End Function

#End Region

    Private Sub frmReposicionFugasPortatil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = cboCorporativo
        DesplegarTitulos()
        ValidarRangoFechas()
        Limpiar()
        HabilitarEmpresa()
        Titulo = "Reposición de fugas a rutas portátiles"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboAlmacenOrigen.KeyDown, dtpFMovimiento.KeyDown, dtpFVenta.KeyDown, _
    cboCorporativo.KeyDown, cboCelula.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        HabilitarAceptar()
        NumEnter = 1
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        If NumEnter = 1 And txtCliente.Text <> "" Then
            BuscarCliente()
            NumEnter = 2
        End If
        If NumEnter = 1 Then
            LimpiarCliente()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                BuscarCliente()
                ActiveControl = dtpFMovimiento
            Else
                ActiveControl = txtCliente
            End If
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        'lblKilos.Text = Format(ProductoPanel.SumarKilos(), "n")
        HabilitarAceptar()
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento del control cboCorporativo en donde carga los almacenes correspondientes a la empresa seleccionada
    Private Sub cboCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativo.SelectedIndexChanged
        If cboCorporativo.Focused And cboCorporativo.Text <> "" Then
            Refresh()
            Cursor = Cursors.WaitCursor
            ' 20060217CAGP$001 /I
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativo.Identificador, Short), 0, 0)
            ' 20060217CAGP$001 /F
            ' Carga almaceens de tipo Ruta Portatil y andenes por CELULA
            cboAlmacenOrigen.CargaDatos(18, GLOBAL_Usuario, cboCelula.Identificador)

            ProductoPanel.BorrarDatos()
            CargarDatosAlmacen()
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If cboCelula.Focused And cboCelula.Text <> "" Then
            Cursor = Cursors.WaitCursor
            ' Carga almaceens de tipo Ruta Portatil y andenes por CELULA
            cboAlmacenOrigen.CargaDatos(18, GLOBAL_Usuario, cboCelula.Identificador)
            ProductoPanel.BorrarDatos()
            CargarDatosAlmacen()
            Cursor = Cursors.Default
        End If
        HabilitarAceptar()
    End Sub

    Private Sub cboAlmacenOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenOrigen.SelectedIndexChanged
        If cboAlmacenOrigen.Focused Then
            Cursor = Cursors.WaitCursor
            CargarDatosAlmacen()
            Cursor = Cursors.Default
        End If
        HabilitarAceptar()
    End Sub

    Private Sub frmMovimientoAlmacen_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    ' Evento del botón cboAlmacenOrigen, llama a la que habilitará el boton de Aceptar
    Private Sub lblKilos_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles lblKilos.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ' 20060617CAGP$003 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
           cboAlmacenOrigen.Identificador, 0) ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            If VerificarExistencias() Then
                RealizarMovimientos()
                ActiveControl = cboAlmacenOrigen
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(1)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = ProductoPanel.txtCantidad1
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
        ' 20060617CAGP$003 /F
    End Sub

    Private Sub dgDetalle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalle.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarDetalle()
        HabilitarAceptar()
        BorrarDatos()
        lblKilos.Text = Format(SumarKilos(), "n")
        btnAgregar.Enabled = False
        ActiveControl = txtCliente
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        QuitarDetalle()
        HabilitarAceptar()
        lblKilos.Text = Format(SumarKilos(), "n")
    End Sub
End Class
