' Forma en donde se realiza la carga de las rutas portatiles, se muestran los productos a cargar
' y la cantidad de ellos, si se requiere realizar una carga independiente del stock maximo se debe
' de modificar el parametro STOCKCARGA a 0 al habilitar el SOTOCKCARGA se habailita los edit para
' que se puedan modificar sus valores, si se requiere que se realize la carga sin haber liquidado
' la ruta se debe de modificar el parametro CARGASINLIQUIDAR a 1

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$004

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCargaCliente
    Inherits System.Windows.Forms.Form

    Private rptReporte As New ReportDocument()

    Private Producto As Integer
    Private CelulaCliente As Integer
    Private InicialEmpresa As String
    Private PorcentajeImpuesto As Decimal
    Private TipoCobro As Short = 1
    Private _ClienteResguardo As Boolean = False
    Private _ResguardoPorTanque As Boolean = False

    Public NumEnter As Short

    Private ListaDescuentos2 As New ArrayList()
    Private ListaDetalle As New ArrayList()

    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private _FolioPrestamo As Integer
    Private _AñoPrestamo As Integer
    Private _RegistroAbonos As Integer

    Private ofrmAbono As New ClienteZonaEconomica.frmAbonoComisionista()

    Private Factor As Decimal

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
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cboAlmacenOrigen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblZonaEconomica As System.Windows.Forms.Label
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescuentoTotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxPrecio As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Protected WithEvents dgDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents lblSellos As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnResguardo As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAbono As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblGranTotal As System.Windows.Forms.Label
    Friend WithEvents btnAbonos As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCargaCliente))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblZonaEconomica = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboAlmacenOrigen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFVenta = New System.Windows.Forms.DateTimePicker()
        Me.cBoxPrecio = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnResguardo = New System.Windows.Forms.Button()
        Me.lblSellos = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.lblDescuentoTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAbono = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblGranTotal = New System.Windows.Forms.Label()
        Me.btnAbonos = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grpDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.lblZonaEconomica, Me.Label11, Me.cboProducto, Me.Label8, Me.lblDescuento, Me.Label4, Me.txtCliente, Me.lblRuta, Me.cboAlmacenOrigen, Me.Label12, Me.Label13, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblPrecio, Me.lblCliente, Me.Label3, Me.Label7, Me.dtpFVenta, Me.cBoxPrecio})
        Me.grpDatos.Location = New System.Drawing.Point(8, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 308)
        Me.grpDatos.TabIndex = 7
        Me.grpDatos.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(406, 52)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 62
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZonaEconomica.Location = New System.Drawing.Point(127, 192)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(352, 21)
        Me.lblZonaEconomica.TabIndex = 36
        Me.lblZonaEconomica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Zona económica:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(128, 220)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(216, 21)
        Me.cboProducto.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(16, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Producto:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescuento
        '
        Me.lblDescuento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescuento.Location = New System.Drawing.Point(128, 164)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(352, 21)
        Me.lblDescuento.TabIndex = 32
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Descuento:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(128, 52)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 20)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Ingrese el número de cliente")
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(128, 108)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenOrigen
        '
        Me.cboAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenOrigen.Location = New System.Drawing.Point(128, 24)
        Me.cboAlmacenOrigen.Name = "cboAlmacenOrigen"
        Me.cboAlmacenOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenOrigen.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 28)
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
        Me.Label6.Location = New System.Drawing.Point(16, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(128, 136)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 4
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Enabled = False
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(128, 248)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 20)
        Me.dtpFMovimiento.TabIndex = 3
        '
        'lblPrecio
        '
        Me.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrecio.Location = New System.Drawing.Point(358, 220)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(122, 21)
        Me.lblPrecio.TabIndex = 37
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblPrecio, "Precio del producto seleccionado")
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(128, 80)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 32
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(16, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Fecha venta:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFVenta
        '
        Me.dtpFVenta.CustomFormat = ""
        Me.dtpFVenta.Enabled = False
        Me.dtpFVenta.Location = New System.Drawing.Point(128, 276)
        Me.dtpFVenta.Name = "dtpFVenta"
        Me.dtpFVenta.Size = New System.Drawing.Size(216, 20)
        Me.dtpFVenta.TabIndex = 4
        '
        'cBoxPrecio
        '
        Me.cBoxPrecio.Location = New System.Drawing.Point(394, 21)
        Me.cBoxPrecio.Name = "cBoxPrecio"
        Me.cBoxPrecio.Size = New System.Drawing.Size(92, 24)
        Me.cBoxPrecio.TabIndex = 10
        Me.cBoxPrecio.Text = "Precio por kilo"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(935, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(935, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResguardo, Me.lblSellos, Me.Label16, Me.ProductoPanel, Me.lblDescuentoTotal, Me.Label9, Me.Label2, Me.lblTotal, Me.Label10, Me.lblKilos})
        Me.GroupBox1.Location = New System.Drawing.Point(500, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 234)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'btnResguardo
        '
        Me.btnResguardo.Location = New System.Drawing.Point(432, 200)
        Me.btnResguardo.Name = "btnResguardo"
        Me.btnResguardo.TabIndex = 63
        Me.btnResguardo.Text = "Resguardos"
        '
        'lblSellos
        '
        Me.lblSellos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSellos.Location = New System.Drawing.Point(428, 169)
        Me.lblSellos.Name = "lblSellos"
        Me.lblSellos.Size = New System.Drawing.Size(84, 21)
        Me.lblSellos.TabIndex = 62
        Me.lblSellos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(428, 153)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 13)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Total sellos"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(7, 16)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(413, 208)
        Me.ProductoPanel.TabIndex = 60
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'lblDescuentoTotal
        '
        Me.lblDescuentoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescuentoTotal.Location = New System.Drawing.Point(428, 128)
        Me.lblDescuentoTotal.Name = "lblDescuentoTotal"
        Me.lblDescuentoTotal.Size = New System.Drawing.Size(84, 21)
        Me.lblDescuentoTotal.TabIndex = 59
        Me.lblDescuentoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(428, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Descuento $"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(428, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Total          $"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Location = New System.Drawing.Point(428, 88)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(84, 21)
        Me.lblTotal.TabIndex = 56
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(428, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Kilos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(428, 40)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(84, 21)
        Me.lblKilos.TabIndex = 54
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtObservacion, Me.Label14, Me.dgDetalle})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 232)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(112, 208)
        Me.txtObservacion.MaxLength = 150
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(888, 20)
        Me.txtObservacion.TabIndex = 35
        Me.txtObservacion.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(16, 212)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Observaciones:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgDetalle
        '
        Me.dgDetalle.DataMember = ""
        Me.dgDetalle.Enabled = False
        Me.dgDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDetalle.Location = New System.Drawing.Point(8, 16)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.ReadOnly = True
        Me.dgDetalle.Size = New System.Drawing.Size(992, 192)
        Me.dgDetalle.TabIndex = 0
        Me.dgDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgDetalle.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ArrayList"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn1.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 50
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.MappingName = "Producto"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 0
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Producto"
        Me.DataGridTextBoxColumn3.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 120
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = "n2"
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Precio"
        Me.DataGridTextBoxColumn4.MappingName = "Precio"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = "n2"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Costo"
        Me.DataGridTextBoxColumn5.MappingName = "Costo"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Descuento1xKg"
        Me.DataGridTextBoxColumn6.MappingName = "Descuento1"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 90
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = "n2"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Descuento1 total x Kg"
        Me.DataGridTextBoxColumn7.MappingName = "Descuento1Total"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 90
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Descuento2 x tanque"
        Me.DataGridTextBoxColumn8.MappingName = "Descuento2"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 90
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = "n2"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Descuento2 total x tanque"
        Me.DataGridTextBoxColumn9.MappingName = "Descuento2Total"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 90
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = "n2"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Total descuentos"
        Me.DataGridTextBoxColumn10.MappingName = "TotalDescuentos"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 90
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = "n2"
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "IVA"
        Me.DataGridTextBoxColumn11.MappingName = "IVA"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = "n2"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Total"
        Me.DataGridTextBoxColumn12.MappingName = "Total"
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(510, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Abono préstamo $:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(621, 36)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.ReadOnly = True
        Me.txtAbono.Size = New System.Drawing.Size(59, 20)
        Me.txtAbono.TabIndex = 25
        Me.txtAbono.TabStop = False
        Me.txtAbono.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(716, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Total a pagar $:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGranTotal
        '
        Me.lblGranTotal.AutoSize = True
        Me.lblGranTotal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblGranTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblGranTotal.Location = New System.Drawing.Point(812, 40)
        Me.lblGranTotal.Name = "lblGranTotal"
        Me.lblGranTotal.Size = New System.Drawing.Size(28, 13)
        Me.lblGranTotal.TabIndex = 27
        Me.lblGranTotal.Text = "0.00"
        Me.lblGranTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAbonos
        '
        Me.btnAbonos.Location = New System.Drawing.Point(681, 34)
        Me.btnAbonos.Name = "btnAbonos"
        Me.btnAbonos.Size = New System.Drawing.Size(32, 23)
        Me.btnAbonos.TabIndex = 28
        Me.btnAbonos.Text = "..."
        Me.btnAbonos.Visible = False
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = "n2"
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Incentivos"
        Me.DataGridTextBoxColumn13.MappingName = "Incentivos"
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'frmCargaCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1026, 568)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAbonos, Me.GroupBox2, Me.GroupBox1, Me.grpDatos, Me.btnCancelar, Me.btnAceptar, Me.Label15, Me.txtAbono, Me.Label17, Me.lblGranTotal})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCargaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpDatos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Realiza la medicion fisica "CODIGO PACO"
    Private Sub MedicionFisica(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(1, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()
        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub
    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblRuta.Text = ""
        lblEmpresa.Text = ""
        txtCliente.Clear()
        lblDescuento.Text = "0.00"
        lblZonaEconomica.Text = ""
        lblCliente.Text = ""
        lblPrecio.Text = "0.00"
        txtObservacion.Text = ""
        Factor = 0
    End Sub

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        lblKilos.Text = "0"
        lblTotal.Text = "0.00"
        lblDescuentoTotal.Text = "0.00"
        lblSellos.Text = "0"
        If cboAlmacenOrigen.Items.Count > 1 Then
            cboAlmacenOrigen.PosicionarInicio()
        End If
        lblGranTotal.Text = "0.00"
        LimpiarCliente()
    End Sub

    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()
        If cboAlmacenOrigen.Text <> "" And txtCliente.Text <> "" And cboProducto.Text <> "" And _
           CType(lblKilos.Text, Decimal) > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Registra la infortmación en la base de datos
    Public Function RealizarMovimientos() As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            Cursor = Cursors.WaitCursor
            Dim Kilos As Decimal
            Dim Ano As Integer
            Ano = dtpFMovimiento.Value.Year
            Kilos = CType(lblKilos.Text, Decimal)
            ' REgistra el folio del movimiento
            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacenOrigen.Identificador, 0, 11, 0)
            ' Registra los datos en la tabla MovimientoAlmacen
            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrigen.Identificador, dtpFMovimiento.Value, _
                                           Kilos, Kilos, 11, dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            ' Registra la informacion de los productos en la tabla de MovimientoAlmacenProducto
            ProductoPanel.RegistraMovimientoProducto(cboAlmacenOrigen.Identificador, _
                                                     oMovimientoAlmacenS.Identificador, Producto, Kilos)

            Dim oMovimientoAlmacenE As New cMovimientoAlmacen(0, 0, 0, dtpFMovimiento.Value, Kilos, Kilos, 2, _
                                           dtpFVenta.Value.Date, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            ProductoPanel.RegistraMovimientoProducto(0, oMovimientoAlmacenE.Identificador)

            Dim oMovimientoEntreAlmacenes As New cMovimientoEntreAlmacenes(0, 0, oMovimientoAlmacenE.Identificador, cboAlmacenOrigen.Identificador, _
                                                         oMovimientoAlmacenS.Identificador)
            oMovimientoEntreAlmacenes.CargaDatos()

            If txtAbono.Text <> "" Then
                If _RegistroAbonos = 1 Then
                    Dim Abono As Decimal
                    Abono = CType(txtAbono.Text, Decimal)
                    Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
                    oAbono.Actualizar(1, 0, dtpFMovimiento.Value.Year, CType(txtCliente.Text, Integer), Abono, cboAlmacenOrigen.Identificador, _
                           oMovimientoAlmacenS.Identificador, dtpFVenta.Value, GLOBAL_Usuario, 0, "", _FolioPrestamo, _AñoPrestamo, 0, Now)
                End If
                If _RegistroAbonos > 1 Then
                    ofrmAbono.RegistrarAbonos(dtpFMovimiento.Value.Year, cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador, dtpFVenta.Value, GLOBAL_Usuario)
                End If

            End If

        ' Registra la información en la tabla de AutoTanqueTurno
        Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
        oAutotanqueTurno.CargaDatos(Ano, CType(lblRuta.Tag, Integer), dtpFVenta.Value.Date, 0, CelulaCliente, 1, _
                                    0, 1, 0, oMovimientoAlmacenE.Identificador, 0, True)

        'Registra la informacion en MovimientoAlmacenProductoZOna
        Dim oMovimientoAlmacenZona As New cMovimientoAProductoZona(1, 0, oMovimientoAlmacenE.Identificador, 0, _
                                          0, CType(lblZonaEconomica.Tag, Short), 0, 0, 0)
        oMovimientoAlmacenZona.RegistrarModificarEliminar()

        Dim Impuesto As Decimal
        Dim Total As Decimal
        Dim Saldo As Decimal
        Dim Descuento As Decimal
        Descuento = CType(lblDescuentoTotal.Text, Decimal)
        Total = CType(lblTotal.Text, Decimal)
        Impuesto = CType(Total - Total / (1 + PorcentajeImpuesto * 0.01), Decimal)
        Saldo = Total

        Dim oPedido As New PortatilClasses.cLiquidacion(0, CType(CelulaCliente, Short), 0, 0)
        'oPedido.LiquidacionPedidoyCobroPedido(cboProducto.Identificador, dtpFMovimiento.Value, _
        '        CType(lblPrecio.Tag, Decimal), 0, (Total - Impuesto), Impuesto, Total, "ACTIVO", _
        '        CType(txtCliente.Text, Integer), Now, Saldo, "", 1, 1, CType(lblRuta.Tag, Short), 0, 0, _
        '        GLOBAL_Usuario, CType(lblRuta.Tag, Short), 1, CType(Ano, Short), _
        '        oFolioMovimientoAlmacen.NDocumento, "PENDIENTE", 0, Now, Now, 0, oMovimientoAlmacenE.Identificador, _
        '        0, CType(lblDescuentoTotal.Text, Decimal), CType(lblZonaEconomica.Tag, Short), 0, 1, Kilos)
        oPedido.LiquidacionPedidoyCobroPedido(cboProducto.Identificador, dtpFMovimiento.Value, _
                            CType(lblPrecio.Tag, Decimal), 0, (Total - Impuesto), Impuesto, Total, "ACTIVO", _
                            CType(txtCliente.Text, Integer), Now, Saldo, "", 1, 8, CType(lblRuta.Tag, Short), 0, 0, _
                            GLOBAL_Usuario, CType(lblRuta.Tag, Short), TipoCobro, CType(Ano, Short), _
                            oAutotanqueTurno.FolioMov, "PENDIENTE", 0, Now, Now, 0, oMovimientoAlmacenS.Identificador, _
                            cboAlmacenOrigen.Identificador, Descuento, CType(lblZonaEconomica.Tag, Short), 0, CType(Kilos, Integer), Kilos, Descuento, txtObservacion.Text)

        Dim oPedidoComision As New PortatilClasses.Consulta.cPedidoComision(0)
        Dim i As Integer
        For i = 0 To ListaDetalle.Count - 1
            Dim oDetalle As PortatilClasses.Lista.ListaComisionista
            oDetalle = CType(ListaDetalle.Item(i), PortatilClasses.Lista.ListaComisionista)
            If CType(oDetalle.Cantidad, Decimal) > 0 Then
                    oPedidoComision.Registrar(oPedido.Celula, oPedido.AnoPedido, oPedido.Pedido, CType(oDetalle.Producto, Integer), CType(oDetalle.Cantidad, Decimal), CType(oDetalle.Precio, Decimal), CType(oDetalle.Costo, Decimal), CType(oDetalle.Descuento1, Decimal), CType(oDetalle.Descuento1Total, Decimal), CType(oDetalle.Descuento2, Decimal), CType(oDetalle.Descuento2Total, Decimal), CType(oDetalle.TotalDescuentos, Decimal), CType(oDetalle.Iva, Decimal), CType(oDetalle.Total, Decimal), _ClienteResguardo, _ResguardoPorTanque, CType(oDetalle.Incentivos, Decimal))
            End If
        Next
        oPedidoComision.CerrarConexion()

        'Llama a la funcio para realizar la medicion fisica "CODIGO PACO"
        If GLOBAL_MedicionFisica Then
            MedicionFisica(oMovimientoAlmacenS.Identificador)
        End If
        If GLOBAL_Imprimir = "1" Then
            ImprimirReporte(3, oMovimientoAlmacenE.Identificador)
                'ImprimirReporte(8, oMovimientoAlmacenE.Identificador)
        End If
        oMovimientoEntreAlmacenes = Nothing
        oMovimientoAlmacenS = Nothing
        oMovimientoAlmacenE = Nothing
        oFolioMovimientoAlmacen = Nothing
        oMovimientoAlmacenZona = Nothing
        Limpiar()
        ProductoPanel.BorrarDatos()
        Cursor = Cursors.Default


        End If

        ActiveControl = cboAlmacenOrigen
    End Function

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

    ' Carga el producto del almacén, debido a que la carga se realiza directamente del contenedor
    Private Sub ProductoContenedor()
        Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacenOrigen.Identificador)
        oProductoContenedor.CargaDatos()
        Producto = oProductoContenedor.Identificador
        oProductoContenedor = Nothing
    End Sub

    Private Sub ActualizarCantidades()


    End Sub

    Private Sub AceptaPago()
        Dim oPago As New PortatilClasses.Consulta.cCobroComisionista()
        oPago.Consulta(CType(0, Short), CType(txtCliente.Text, Integer))
        _RegistroAbonos = 0
        If oPago._Pago > 0 Then
            txtAbono.Text = CType(oPago._Pago, String)
            _FolioPrestamo = oPago._Folio
            _AñoPrestamo = oPago._AñoPrestamo
            _RegistroAbonos = oPago._Registros
            If _RegistroAbonos = 1 Then
                txtAbono.ReadOnly = False
                btnAbonos.Visible = False
            Else
                txtAbono.ReadOnly = True
                btnAbonos.Visible = True
            End If

            If _RegistroAbonos > 1 Then
                ofrmAbono.CargarDatos(CType(txtCliente.Text, Integer), _RegistroAbonos, lblCliente.Text)
            End If

        Else
            txtAbono.ReadOnly = True
        End If
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer), 0)
        oCliente.CargaDatos()

        Cursor = Cursors.WaitCursor
        _ClienteResguardo = False
        _ResguardoPorTanque = False
        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo
            InicialEmpresa = oCliente.Inicial
            lblZonaEconomica.Text = oCliente.ZonaEconomica
            lblZonaEconomica.Tag = oCliente.IdZonaEconomica
            TipoCobro = CType(oCliente.TipoCobro, Short)
            If TipoCobro = 0 Then
                TipoCobro = 5
            End If
            _ClienteResguardo = oCliente.Resguardo
            _ResguardoPorTanque = oCliente.ResguardoPorTanque
            CelulaCliente = oCliente.Celula
            CargarPrecio()
            lblDescuento.Text = ""
            Dim oClienteDescuento As New PortatilClasses.Consulta.cClienteDescuento(0, CType(txtCliente.Text, Integer))
            oClienteDescuento.CargaDatos()
            lblDescuento.Text = CType(oClienteDescuento.ValorDescuento, String)
            oClienteDescuento = Nothing

            Dim oClienteDescuento2 As New PortatilClasses.Consulta.cClienteDescuento(3, CType(txtCliente.Text, Integer))
            oClienteDescuento2.ConsultaDatos()
            Do While oClienteDescuento2.drAlmacen.Read()
                Dim oDescuento2 As New PortatilClasses.Lista.ListaPrecios(CType(oClienteDescuento2.drAlmacen(0), Integer), CType(oClienteDescuento2.drAlmacen(1), Integer), CType(oClienteDescuento2.drAlmacen(2), Decimal), CType(oClienteDescuento2.drAlmacen(3), Decimal))
                ListaDescuentos2.Add(oDescuento2)
            Loop

            Dim oFactor As New ClienteZonaEconomica.ClienteFactor.cConsultaClienteIncentivo(0)
            Factor = oFactor.FactorActual(CType(txtCliente.Text, Integer), dtpFMovimiento.Value.Date)

            AceptaPago()
            'ActualizarDetalle()
            ProductoPanel.BorrarDatos()
        Else
            LimpiarCliente()
            Factor = 0
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MyBase.ActiveControl = txtCliente
            txtCliente.Clear()
        End If
        oCliente = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Carga el precio dependiendo del producto seleccionado y de la zona economica a la que
    ' pertenece el cliente
    Private Sub CargarPrecio()
        If cboProducto.Text <> "" And lblZonaEconomica.Text <> "" Then
            Dim oPrecio As New PortatilClasses.Consulta.cPrecio(0, cboProducto.Identificador, _
                                                                CType(lblZonaEconomica.Tag, Integer))
            oPrecio.CargaDatos()
            lblPrecio.Text = CType(oPrecio.Precio, String)
            lblPrecio.Tag = CType(oPrecio.Impuesto, Decimal)
            PorcentajeImpuesto = CType(oPrecio.Impuesto, Decimal)
            oPrecio = Nothing
        End If
    End Sub

    ' Carga el total en pesos dependiendo del precio y del total de kilos
    Private Sub CargarTotal()        
        If lblPrecio.Text <> "" And lblKilos.Text <> "" Then
            Dim Total As Decimal = 0
            Dim Descuento As Decimal = 0
            Dim i As Integer
            Dim CantidadSellos As Integer = 0
            For i = 0 To ListaDetalle.Count - 1
                Dim oDetalle As PortatilClasses.Lista.ListaComisionista
                oDetalle = CType(ListaDetalle.Item(i), PortatilClasses.Lista.ListaComisionista)
                Total = Total + CType(oDetalle.Total, Decimal)
                Descuento = Descuento + CType(oDetalle.TotalDescuentos, Decimal) + CType(oDetalle.Incentivos, Decimal)
                CantidadSellos = CantidadSellos + CType(oDetalle.Cantidad, Integer)
            Next

            lblTotal.Text = Format(Total, "n")
            lblDescuentoTotal.Text = Format(Descuento, "n")
            lblSellos.Text = Format(CantidadSellos, "n0")
            ActualizarTotalGral()
        End If
    End Sub

    Private Sub ActualizarDetalle()
        Dim i As Integer
        Dim Precio As Decimal
        Dim PrecioProducto As Decimal
        Dim Descuento2 As Decimal
        Dim ii As Integer

        For ii = 0 To ListaDescuentos2.Count - 1
            Dim oDescuento As PortatilClasses.Lista.ListaPrecios
            oDescuento = CType(ListaDescuentos2.Item(ii), PortatilClasses.Lista.ListaPrecios)
            If oDescuento.Producto = Producto Then
                Descuento2 = oDescuento.Descuento
                PrecioProducto = oDescuento.Precio
            End If
        Next
        For i = 0 To ListaDetalle.Count - 1
            Dim oDetalle As PortatilClasses.Lista.ListaComisionista
            oDetalle = CType(ListaDetalle.Item(i), PortatilClasses.Lista.ListaComisionista)

            Dim Valor As Decimal
            If CType(oDetalle.Cantidad, Integer) > 0 Then
                Valor = CType(oDetalle.Kilos, Decimal) / CType(oDetalle.Cantidad, Decimal)
            End If


            If CType(oDetalle.Producto, Integer) = Producto Then
                If cBoxPrecio.Checked Then
                    Precio = CType(lblPrecio.Text, Decimal) * CType(oDetalle.Kilos, Decimal) / CType(oDetalle.Cantidad, Decimal)
                Else
                    Precio = PrecioProducto
                End If
                oDetalle.Precio = CType(Precio, String)
                oDetalle.Costo = CType(CType(oDetalle.Cantidad, Decimal) * Precio, String)
                oDetalle.Descuento1 = lblDescuento.Text
                oDetalle.Descuento1Total = CType(CType(oDetalle.Descuento1, Decimal) * CType(oDetalle.Kilos, Decimal), String)
                oDetalle.Descuento2 = CType(Descuento2, String)
                'If Valor > 9 Then
                oDetalle.Descuento2Total = CType(Descuento2 * CType(oDetalle.Cantidad, Decimal), String)
                'Else
                '    'If Valor = 10 Then
                '    '    Dim CantidadConsiderar As Decimal = CType(oDetalle.Cantidad, Long) \ 2
                '    '    oDetalle.Descuento2Total = CType(Descuento2 * CantidadConsiderar, String)
                '    'Else
                '    '    oDetalle.Descuento2Total = "0"
                '    'End If
                '    oDetalle.Descuento2Total = "0"
                'End If

                oDetalle.Incentivos = CType(Factor * CType(oDetalle.Kilos, Decimal), String)
                oDetalle.TotalDescuentos = CType(CType(oDetalle.Descuento1Total, Decimal) + CType(oDetalle.Descuento2Total, Decimal), String)
                oDetalle.Total = CType(CType(oDetalle.Costo, Decimal) - CType(oDetalle.TotalDescuentos, Decimal) - CType(oDetalle.Incentivos, Decimal), String)
                oDetalle.Iva = CType(CType(oDetalle.Total, Decimal) - CType(oDetalle.Total, Decimal) / (1 + PorcentajeImpuesto * 0.01), String)
            End If
        Next

        dgDetalle.DataSource = Nothing
        dgDetalle.DataSource = ListaDetalle
    End Sub

    Private Sub AgregarDetalle(ByVal Producto As Integer, ByVal Cantidad As Decimal, ByVal Kilos As Decimal, ByVal Des As String)
        Dim i As Integer
        Dim Existe As Boolean = False
        Dim Precio As Decimal
        Dim PrecioProducto As Decimal
        Dim Descuento2 As Decimal
        Dim ii As Integer

        Dim Valor As Decimal
        If Cantidad > 0 Then
            Valor = Kilos / Cantidad
        End If

        For ii = 0 To ListaDescuentos2.Count - 1
            Dim oDescuento As PortatilClasses.Lista.ListaPrecios
            oDescuento = CType(ListaDescuentos2.Item(ii), PortatilClasses.Lista.ListaPrecios)
            If oDescuento.Producto = Producto Then
                Descuento2 = oDescuento.Descuento
                PrecioProducto = oDescuento.Precio
            End If
        Next

        If cBoxPrecio.Checked Then
            If Cantidad = 0 Then
                Precio = 0
            Else
                Precio = CType(lblPrecio.Text, Decimal) * Kilos / Cantidad
            End If

        Else
            Precio = PrecioProducto
        End If
        For i = 0 To ListaDetalle.Count - 1
            Dim oDetalle As PortatilClasses.Lista.ListaComisionista
            oDetalle = CType(ListaDetalle.Item(i), PortatilClasses.Lista.ListaComisionista)
            If CType(oDetalle.Producto, Integer) = Producto Then
                Existe = True
                oDetalle.Cantidad = CType(Cantidad, String)
                oDetalle.Precio = CType(Precio, String)
                oDetalle.Costo = CType(Cantidad * Precio, String)
                oDetalle.Descuento1 = lblDescuento.Text
                oDetalle.Descuento1Total = CType(CType(oDetalle.Descuento1, Decimal) * Kilos, String)
                oDetalle.Descuento2 = CType(Descuento2, String)
                'If Valor > 9 Then
                    oDetalle.Descuento2Total = CType(Descuento2 * Cantidad, String)
                    'Else
                    '    'If Valor = 10 Then
                    '    '    Dim CantidadConsiderar As Decimal = CType(Cantidad, Long) \ 2
                    '    '    oDetalle.Descuento2Total = CType(Descuento2 * CantidadConsiderar, String)
                    '    'Else
                    '    '    oDetalle.Descuento2Total = "0"
                    '    'End If
                    '    oDetalle.Descuento2Total = "0"
                    'End If

                oDetalle.Incentivos = CType(Factor * CType(Kilos, Decimal), String)
                oDetalle.TotalDescuentos = CType(CType(oDetalle.Descuento1Total, Decimal) + CType(oDetalle.Descuento2Total, Decimal), String)
                oDetalle.Total = CType(CType(oDetalle.Costo, Decimal) - CType(oDetalle.TotalDescuentos, Decimal) - CType(oDetalle.Incentivos, Decimal), String)
                oDetalle.Kilos = CType(Kilos, String)
                oDetalle.Iva = CType(CType(oDetalle.Total, Decimal) - CType(oDetalle.Total, Decimal) / (1 + PorcentajeImpuesto * 0.01), String)
            End If
        Next
        If Existe = False Then
            Dim Descuento2Total As Decimal
            Dim Incentivos As Decimal

            'If Valor > 9 Then
                Descuento2Total = Descuento2 * Cantidad
                'Else
                '    'If Valor = 10 Then
                '    '    Dim CantidadConsiderar As Decimal = CType(Cantidad, Long) \ 2
                '    '    Descuento2Total = Descuento2 * CantidadConsiderar
                '    'Else
                '    '    Descuento2Total = 0
                '    'End If
                '    Descuento2Total = 0
                'End If

            Incentivos = Factor * Kilos
            Dim Tot As Decimal = Cantidad * Precio - ((CType(lblDescuento.Text, Decimal) * Kilos + Descuento2Total + Incentivos))
            Dim Iva As Decimal = Tot - CType(Tot / (1 + PorcentajeImpuesto * 0.01), Decimal)
            Dim oDetalle As New PortatilClasses.Lista.ListaComisionista(CType(Cantidad, Integer), Producto, Des, Precio, Cantidad * Precio, CType(lblDescuento.Text, Decimal), CType(lblDescuento.Text, Decimal) * Kilos, Descuento2, Descuento2Total, CType(lblDescuento.Text, Decimal) * Kilos + Descuento2Total, Iva, Tot, Kilos, Incentivos)
            ListaDetalle.Add(oDetalle)
        End If
        dgDetalle.DataSource = Nothing
        dgDetalle.DataSource = ListaDetalle
    End Sub

    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        'Dim crParameterValues As ParameterValues
        'Dim crParameterDiscreteValue As ParameterDiscreteValue
        'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        'Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            'rptReporte.Load(GLOBAL_RutaReportes & "\ReporteLiquidacionComision.rpt")

            ''Configuracion
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = Configuracion
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ''MovimientoAlmacen
            'crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterDiscreteValue = New ParameterDiscreteValue()
            'crParameterDiscreteValue.Value = MovimientoAlmacen
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'AplicaInfoConexion()
            Try

                'rptReporte.PrintToPrinter(1, False, 0, 0)
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionComision.rpt", GLOBAL_Servidor, _
                GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)

                oReporte.ShowDialog()
            Catch exc As Exception
                'Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show("No existe el formato de liquidación o no tiene acceso a la carpeta, intente imprimir más tarde, la información a sido guardada correctamente.", "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            'Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show("No existe el formato de liquidación o no tiene acceso a la carpeta, intente imprimir más tarde, la información a sido guardada correctamente.", "Modulo de liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub ActualizarTotalGral()
        Dim Total As Decimal = CType(lblTotal.Text, Decimal)
        If txtAbono.Text <> "" Then
            Total = Total + CType(txtAbono.Text, Decimal)
        End If
        lblGranTotal.Text = Format(Total, "n")

    End Sub


    ' Evento de la forma, en donde se inicializan los controles necesarios
    Private Sub frmCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = txtCliente
        ValidarRangoFechas()
        Limpiar()
        cboAlmacenOrigen.CargaDatos(4, GLOBAL_Usuario, GLOBAL_Empresa)
        If cboAlmacenOrigen.Items.Count = 1 Then
            cboAlmacenOrigen.Enabled = False
        End If
        cboProducto.CargaDatos(1, GLOBAL_Usuario)
        If cboProducto.Items.Count = 1 Then
            cboProducto.Enabled = False
        End If
        ProductoContenedor()
        If cboAlmacenOrigen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenOrigen.TipoProducto)
        End If
        cBoxPrecio.Checked = False
    End Sub

    ' Cierra la forma 
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    ' Finaliza el objeto
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ' Llena la información del cliente
    Private Sub txtCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtCliente.Leave
        If txtCliente.Text <> "" And NumEnter = 1 Then
            BuscarCliente()
            CargarTotal()
            NumEnter = 2
        End If
    End Sub

    ' Evento que se activa cuando hacemos clic sobre el botón aceptar, valida y registra la carga
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ' 20060617CAGP$004 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
        cboAlmacenOrigen.Identificador, 0)  ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            If ProductoPanel.VerificarExistenciasKilos(cboAlmacenOrigen.Identificador, CType(lblKilos.Text, Decimal), Producto) Then
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

        txtAbono.Text = "0"
        ActualizarTotalGral()
        ' 20060617CAGP$004 /I
    End Sub

    ' Habilita el botón aceptar si los controles cumplen con la condición
    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtCliente.TextChanged
        HabilitarAceptar()
        NumEnter = 1
    End Sub

    ' Cuando seleccionamos un almacen carga la información necesaria en los controles
    Private Sub cboAlmacenOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboAlmacenOrigen.SelectedIndexChanged
        If (cboAlmacenOrigen.Focused) And (cboAlmacenOrigen.Text <> "") Then
            ProductoContenedor()
            ProductoPanel.CargarProducto(cboAlmacenOrigen.TipoProducto)
            HabilitarAceptar()
        End If
    End Sub

    'Al seleccionar el producto se despliega el precio del producto seleccionado
    Private Sub cboProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboProducto.SelectedIndexChanged
        CargarPrecio()
        CargarTotal()
        HabilitarAceptar()
    End Sub

    ' Al desplegar el precio se actualiza el Total del cliente
    'Private Sub lblPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    'Handles lblPrecio.TextChanged
    '    CargarTotal()
    '    HabilitarAceptar()
    'End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        Dim Producto As Integer = ProductoPanel.IdenProducto(ProductoPanel.Indice)
        Dim Cantidad As Decimal = ProductoPanel.CantidadProductos
        Dim Kilos As Decimal = ProductoPanel.KilosProductos
        Dim Des As String = ProductoPanel.DescripcionProducto(ProductoPanel.Indice)
        If Producto > 0 Then
            AgregarDetalle(Producto, Cantidad, Kilos, Des)
        End If

        lblKilos.Text = Format(ProductoPanel.SumarKilos(), "n")
        HabilitarAceptar()
        CargarTotal()
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacenOrigen.KeyDown, txtCliente.KeyDown, cboProducto.KeyDown, dtpFMovimiento.KeyDown, dtpFVenta.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Valida si quiere cerrar la pantalla, le pregunta al usuario si esta seguro de cerrar la ventana
    Private Sub frmCargaCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                BuscarCliente()
                ActiveControl = cboProducto
            Else
                ActiveControl = txtCliente
            End If
        End If
    End Sub

    Private Sub dgDetalle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalle.Enter
        Try

        Catch

        End Try
    End Sub

    Private Sub btnResguardo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResguardo.Click
        If txtCliente.Text <> "" Then
            Dim oResguardos As New ClienteZonaEconomica.frmConsultarResguardos(CType(txtCliente.Text, Integer), lblCliente.Text)
            oResguardos.ShowDialog()
        End If

    End Sub

    Private Sub txtAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.TextChanged
        If txtAbono.Focused Then
            ActualizarTotalGral()
        End If
    End Sub

    Private Sub btnAbonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbonos.Click
        ofrmAbono.ShowDialog()
        Dim Abono As Decimal = ofrmAbono.AbonoTotal()
        txtAbono.Text = CType(Abono, String)
        ActualizarTotalGral()
    End Sub
End Class
