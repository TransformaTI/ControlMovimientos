' Modifico: Claudia Aurora García Patiño
' Fecha: 03de Mayo del 2006
' Motivo: Noe staba cargando las sucursales de la empresa
' Identificador de cambios: 20060503CAGP$002

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmProgramaCompraVenta
    Inherits System.Windows.Forms.Form

#Region "Varables"
    Private _Operacion As String
    Private _TipoPrograma As Boolean
    Private _FInicio As DateTime
    Private _FFin As DateTime
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _Year As Short
    Private _Mes As Short
    Private _dtProgramaCV As DataTable
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'InicializaTablaResguardo()
        'Add any initialization after the InitializeComponent() call

    End Sub


    ''Public Sub New(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Servidor As String, ByVal BaseDatos As String, ByVal Usuario As String, ByVal Password As String)
    'Public Sub New(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Usuario As String, ByVal Password As String)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call

    '    _FolioAtt = FolioAtt
    '    _AnoAtt = AnoAtt
    '    _FechaMovimiento = FMovimiento

    '    GLOBAL_Usuario = Usuario
    '    GLOBAL_Password = Password

    '    If _dtClienteResguardo.Rows.Count = 0 Then
    '        BuscarCliente()
    '    End If
    'End Sub


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
    Friend WithEvents gpbDatosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents cboConCorporativo As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents dtpConFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpConFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCapKilos As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents dtpCapFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboConSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents grdProgramaCV As System.Windows.Forms.DataGrid
    Friend WithEvents style1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents style2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col001 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col002 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col003 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col004 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col005 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtCorporativo As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtSucursal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProgramaCompraVenta))
        Me.grdProgramaCV = New System.Windows.Forms.DataGrid()
        Me.style1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col001 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col002 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col003 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col004 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col005 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.style2 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gpbDatosBusqueda = New System.Windows.Forms.GroupBox()
        Me.cboConSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboConCorporativo = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpConFFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpConFInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSucursal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCorporativo = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtCapKilos = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpCapFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        CType(Me.grdProgramaCV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbDatosBusqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdProgramaCV
        '
        Me.grdProgramaCV.AccessibleName = ""
        Me.grdProgramaCV.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdProgramaCV.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdProgramaCV.CaptionBackColor = System.Drawing.Color.MidnightBlue
        Me.grdProgramaCV.CaptionText = "Detalle de programa de compras"
        Me.grdProgramaCV.DataMember = ""
        Me.grdProgramaCV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProgramaCV.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProgramaCV.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdProgramaCV.Location = New System.Drawing.Point(0, 173)
        Me.grdProgramaCV.Name = "grdProgramaCV"
        Me.grdProgramaCV.ReadOnly = True
        Me.grdProgramaCV.Size = New System.Drawing.Size(623, 395)
        Me.grdProgramaCV.TabIndex = 11
        Me.grdProgramaCV.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.style1, Me.style2})
        '
        'style1
        '
        Me.style1.AlternatingBackColor = System.Drawing.Color.LightSkyBlue
        Me.style1.DataGrid = Me.grdProgramaCV
        Me.style1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col001, Me.col002, Me.col003, Me.col004, Me.col005})
        Me.style1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.style1.MappingName = "ProgramaCompra"
        '
        'col001
        '
        Me.col001.Format = ""
        Me.col001.FormatInfo = Nothing
        Me.col001.HeaderText = "Empresa"
        Me.col001.MappingName = "CorporativoDescripcion"
        Me.col001.Width = 155
        '
        'col002
        '
        Me.col002.Format = ""
        Me.col002.FormatInfo = Nothing
        Me.col002.HeaderText = "Sucursal"
        Me.col002.MappingName = "SucursalDescripcion"
        Me.col002.Width = 155
        '
        'col003
        '
        Me.col003.Format = ""
        Me.col003.FormatInfo = Nothing
        Me.col003.HeaderText = "Fecha programa"
        Me.col003.MappingName = "Fecha"
        Me.col003.Width = 105
        '
        'col004
        '
        Me.col004.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col004.Format = "N2"
        Me.col004.FormatInfo = Nothing
        Me.col004.HeaderText = "Kilos prog."
        Me.col004.MappingName = "KilosPrograma"
        Me.col004.Width = 75
        '
        'col005
        '
        Me.col005.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col005.Format = "N2"
        Me.col005.FormatInfo = Nothing
        Me.col005.HeaderText = "Litros prog."
        Me.col005.MappingName = "LitrosPrograma"
        Me.col005.Width = 80
        '
        'style2
        '
        Me.style2.AlternatingBackColor = System.Drawing.Color.LemonChiffon
        Me.style2.DataGrid = Me.grdProgramaCV
        Me.style2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05})
        Me.style2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.style2.MappingName = "ProgramaVenta"
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Empresa"
        Me.col01.MappingName = "CorporativoDescripcion"
        Me.col01.Width = 155
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Sucursal"
        Me.col02.MappingName = "SucursalDescripcion"
        Me.col02.Width = 155
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Fecha programa"
        Me.col03.MappingName = "Fecha"
        Me.col03.Width = 105
        '
        'col04
        '
        Me.col04.Format = "N2"
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Kilos vta."
        Me.col04.MappingName = "KilosPrograma"
        Me.col04.Width = 75
        '
        'col05
        '
        Me.col05.Format = "N2"
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Litros vta."
        Me.col05.MappingName = "LitrosPrograma"
        Me.col05.Width = 80
        '
        'gpbDatosBusqueda
        '
        Me.gpbDatosBusqueda.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboConSucursal, Me.Label8, Me.cboConCorporativo, Me.Label20, Me.Label4, Me.dtpConFFin, Me.Label2, Me.dtpConFInicio, Me.btnBuscar})
        Me.gpbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbDatosBusqueda.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbDatosBusqueda.Name = "gpbDatosBusqueda"
        Me.gpbDatosBusqueda.Size = New System.Drawing.Size(312, 174)
        Me.gpbDatosBusqueda.TabIndex = 127
        Me.gpbDatosBusqueda.TabStop = False
        Me.gpbDatosBusqueda.Text = "Consulta"
        '
        'cboConSucursal
        '
        Me.cboConSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConSucursal.Location = New System.Drawing.Point(83, 106)
        Me.cboConSucursal.Name = "cboConSucursal"
        Me.cboConSucursal.Size = New System.Drawing.Size(216, 21)
        Me.cboConSucursal.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(14, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Sucursal:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboConCorporativo
        '
        Me.cboConCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConCorporativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConCorporativo.ItemHeight = 13
        Me.cboConCorporativo.Location = New System.Drawing.Point(83, 78)
        Me.cboConCorporativo.Name = "cboConCorporativo"
        Me.cboConCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.cboConCorporativo.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(14, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "Empresa:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(14, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Fecha final:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpConFFin
        '
        Me.dtpConFFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpConFFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpConFFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpConFFin.Location = New System.Drawing.Point(83, 50)
        Me.dtpConFFin.Name = "dtpConFFin"
        Me.dtpConFFin.Size = New System.Drawing.Size(216, 21)
        Me.dtpConFFin.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Fecha inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpConFInicio
        '
        Me.dtpConFInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpConFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpConFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpConFInicio.Location = New System.Drawing.Point(83, 22)
        Me.dtpConFInicio.Name = "dtpConFInicio"
        Me.dtpConFInicio.Size = New System.Drawing.Size(216, 21)
        Me.dtpConFInicio.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.ImageList = Me.ielImagenes
        Me.btnBuscar.Location = New System.Drawing.Point(116, 136)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSucursal, Me.txtCorporativo, Me.btnAgregar, Me.txtCapKilos, Me.lblKilos, Me.Label1, Me.Label3, Me.Label9, Me.dtpCapFecha})
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(310, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 174)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Captura"
        '
        'txtSucursal
        '
        Me.txtSucursal.AutoSize = False
        Me.txtSucursal.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtSucursal.Location = New System.Drawing.Point(83, 78)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(216, 21)
        Me.txtSucursal.TabIndex = 8
        Me.txtSucursal.Text = ""
        '
        'txtCorporativo
        '
        Me.txtCorporativo.AutoSize = False
        Me.txtCorporativo.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtCorporativo.Location = New System.Drawing.Point(83, 50)
        Me.txtCorporativo.Name = "txtCorporativo"
        Me.txtCorporativo.ReadOnly = True
        Me.txtCorporativo.Size = New System.Drawing.Size(216, 21)
        Me.txtCorporativo.TabIndex = 7
        Me.txtCorporativo.Text = ""
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.ImageList = Me.ielImagenes
        Me.btnAgregar.Location = New System.Drawing.Point(116, 136)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "A&gregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapKilos
        '
        Me.txtCapKilos.AutoSize = False
        Me.txtCapKilos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtCapKilos.Location = New System.Drawing.Point(83, 106)
        Me.txtCapKilos.MaxLength = 15
        Me.txtCapKilos.Name = "txtCapKilos"
        Me.txtCapKilos.Size = New System.Drawing.Size(216, 21)
        Me.txtCapKilos.TabIndex = 9
        Me.txtCapKilos.Text = ""
        '
        'lblKilos
        '
        Me.lblKilos.AutoSize = True
        Me.lblKilos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblKilos.Location = New System.Drawing.Point(14, 110)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(35, 13)
        Me.lblKilos.TabIndex = 137
        Me.lblKilos.Text = "Kilos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Sucursal:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(14, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Empresa:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(14, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Fecha:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpCapFecha
        '
        Me.dtpCapFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpCapFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCapFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCapFecha.Location = New System.Drawing.Point(83, 22)
        Me.dtpCapFecha.Name = "dtpCapFecha"
        Me.dtpCapFecha.Size = New System.Drawing.Size(216, 21)
        Me.dtpCapFecha.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(654, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBorrar
        '
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(654, 524)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 12
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmProgramaCompraVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 568)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBorrar, Me.gpbDatosBusqueda, Me.GroupBox1, Me.btnCancelar, Me.grdProgramaCV})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgramaCompraVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programa de compras"
        CType(Me.grdProgramaCV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbDatosBusqueda.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Funciones y metodos de la forma"
    Private Sub ConfiguraForma(ByVal Operacion As String)
        Select Case Operacion
            Case "COMPRA"
                Me.Text = "Programa de compras a PEMEX."
                Me.grdProgramaCV.CaptionText = "Detalle de programa de compras"
                Me._TipoPrograma = False
            Case "VENTA"
                Me.Text = "Programa de ventas."
                Me.grdProgramaCV.CaptionText = "Detalle de programa de ventas"
                Me._TipoPrograma = True
        End Select
    End Sub

    Public Sub InicializaFormaCompra(ByVal Operacion As String)
        _Operacion = Operacion
        txtCorporativo.Text = ""
        txtSucursal.Text = ""
        txtCorporativo.Tag = 0
        txtSucursal.Tag = 0
        ConfiguraForma(_Operacion)
        cboConCorporativo.Tag = 1
        cboConCorporativo.CargaDatos(0)
        cboConCorporativo.Tag = 0

        Dim Datos As New PortatilClasses.ProgramaCompraVenta.Programa()
        Datos.CargarDatos(1, GLOBAL_Usuario, GLOBAL_Celula)

        Me._FInicio = Datos.FInicio
        Me._FFin = Datos.FFin
        Me._Corporativo = Datos.Corporativo
        Me._Sucursal = Datos.Sucursal
        Me._Year = Datos.Year
        Me._Mes = Datos.Mes

        ConsultarDatos()
        InicializaCaptura()

        ActiveControl = txtCapKilos
    End Sub

    Private Sub ConsultarDatos()
        Dim ProgramaCV As New PortatilClasses.ProgramaCompraVenta.Programa()

        dtpConFInicio.Value = Me._FInicio
        dtpConFFin.Value = Me._FFin
        cboConCorporativo.PosicionaCombo(Me._Corporativo)
        ' 20060503CAGP$002 /I
        If cboConCorporativo.Text <> "" Then
            cboConSucursal.CargaDatosBase("spPTLCargaComboSucursal", 1, GLOBAL_Usuario, CShort(cboConCorporativo.Identificador), 0, 0)
            cboConSucursal.PosicionaCombo(Me._Sucursal)
        End If
        ' 20060503CAGP$002 /F

        ProgramaCV.CargaPrograma(Me._FInicio, Me._FFin, Me._Corporativo, Me._Sucursal, Me._TipoPrograma)
        If Me._TipoPrograma = False Then
            ProgramaCV.dtTable.TableName = "ProgramaCompra"
        Else
            ProgramaCV.dtTable.TableName = "ProgramaVenta"
        End If

        _dtProgramaCV = ProgramaCV.dtTable

        Dim Keys(3) As DataColumn
        Keys(0) = _dtProgramaCV.Columns("ProgramaCompraVenta")
        Keys(1) = _dtProgramaCV.Columns("Fecha")
        Keys(2) = _dtProgramaCV.Columns("Corporativo")
        Keys(3) = _dtProgramaCV.Columns("Sucursal")
        _dtProgramaCV.PrimaryKey = Keys

        grdProgramaCV.DataSource = _dtProgramaCV

        dtpCapFecha.MinDate = CDate("01/01/1753")
        dtpCapFecha.MaxDate = CDate("31/12/9998")

        dtpCapFecha.MinDate = Me._FInicio.AddHours(0)
        dtpCapFecha.MaxDate = Me._FFin.AddHours(23.99)

        If Me._TipoPrograma = True Then
            Me.grdProgramaCV.CaptionText = "Detalle de programa de ventas del " & dtpConFInicio.Value.Date.ToShortDateString & " al " & dtpConFFin.Value.Date.ToShortDateString
        Else
            Me.grdProgramaCV.CaptionText = "Detalle de programa de compras del " & dtpConFInicio.Value.Date.ToShortDateString & " al " & dtpConFFin.Value.Date.ToShortDateString
        End If

    End Sub

    Private Sub InicializaCaptura()
        dtpCapFecha.Value = Me._FInicio
        If cboConCorporativo.Identificador > 0 And cboConSucursal.Identificador > 0 Then
            txtCorporativo.Text = cboConCorporativo.Text
            txtCorporativo.Tag = Me._Corporativo
            txtSucursal.Text = cboConSucursal.Text
            txtSucursal.Tag = Me._Sucursal
            ActiveControl = txtCapKilos
        Else
            txtCorporativo.Text = ""
            txtCorporativo.Tag = 0
            txtSucursal.Text = ""
            txtSucursal.Tag = 0
            ActiveControl = dtpConFInicio
        End If
    End Sub

    Function ValidaDatosConsulta() As Boolean
        Dim FechaConsulta As DateTime = CDate("01/" + Me._Mes.ToString + "/+" + Me._Year.ToString)
        FechaConsulta = FechaConsulta.AddMonths(1)
        If dtpConFInicio.Value > dtpConFFin.Value Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(89)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = dtpConFInicio
            Return False
        ElseIf CShort(dtpConFFin.Value.Month) > CShort(FechaConsulta.Month) And CShort(dtpConFFin.Value.Year) > CShort(FechaConsulta.Year) Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(89)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = dtpConFInicio
            Return False
        ElseIf cboConCorporativo.Identificador = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(90)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = cboConCorporativo
            Return False
        ElseIf cboConSucursal.Identificador = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(91)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = cboConSucursal
            Return False
        Else
            Me._FInicio = dtpConFInicio.Value
            Me._FFin = dtpConFFin.Value
            Me._Corporativo = CShort(cboConCorporativo.Identificador)
            Me._Sucursal = CShort(cboConSucursal.Identificador)
            Return True
        End If
    End Function

    Function ValidaDatosCaptura() As Boolean
        If dtpCapFecha.Value.Date < Me._FInicio.Date And dtpCapFecha.Value.Date > Me._FFin.Date Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(89)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = dtpCapFecha
            Return False
        ElseIf txtCapKilos.Text.Length = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(92)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = txtCapKilos
            Return False
        ElseIf CDec(txtCapKilos.Text) = 0 Then
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(92)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = txtCapKilos
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Manejo de Eventos de cajas de texto y combos"
    Private Sub cboConCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConCorporativo.SelectedIndexChanged
        If cboConCorporativo.SelectedIndex > -1 And CInt(cboConCorporativo.Tag) = 0 Then
            cboConSucursal.CargaDatosBase("spPTLCargaComboSucursal", 1, GLOBAL_Usuario, CShort(cboConCorporativo.Identificador), 0, 0)
        End If
    End Sub

    Private Sub txtCapKilos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapKilos.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0) OrElse _
                     (e.KeyChar = CChar("-") AndAlso CType(sender, TextBox).Text.IndexOf("-") < 0 AndAlso CType(sender, TextBox).SelectionStart = 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub dtpConFInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpConFInicio.KeyDown, dtpConFFin.KeyDown, cboConCorporativo.KeyDown, _
            cboConSucursal.KeyDown, dtpCapFecha.KeyDown, txtCapKilos.KeyDown, _
            txtCorporativo.KeyDown, txtSucursal.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If TypeOf (sender) Is TextBox Then
            If e.KeyData = Keys.Down Then
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            End If
            If e.KeyData = Keys.Up Then
                Me.SelectNextControl(CType(sender, Control), False, True, True, True)
            End If
        End If
    End Sub
#End Region

#Region "Funcionalidad de botonos"
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If ValidaDatosConsulta() Then
            ConsultarDatos()
            InicializaCaptura()
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidaDatosCaptura() Then
            Dim ProgramaCV As New PortatilClasses.ProgramaCompraVenta.Programa()
            ProgramaCV.RegistrarPrograma(dtpCapFecha.Value, CShort(txtCorporativo.Tag), CShort(txtSucursal.Tag), CDec(txtCapKilos.Text), 0, GLOBAL_Usuario, Me._TipoPrograma)
            ConsultarDatos()
            If dtpCapFecha.Value.AddDays(1).Date <= dtpCapFecha.MaxDate.Date Then
                dtpCapFecha.Value = dtpCapFecha.Value.AddDays(1).Date
                txtCapKilos.SelectAll()
                ActiveControl = txtCapKilos
            End If
            Dim strExpr As String
            Dim FoundRows As DataRow()
            strExpr = "Corporativo = " & CStr(txtCorporativo.Tag) & " AND Sucursal = " & CStr(txtSucursal.Tag) & " And Fecha = '" & CStr(dtpCapFecha.Value.Date) & "'"
            FoundRows = _dtProgramaCV.Select(strExpr)
            If FoundRows.Length > 0 Then
                txtCapKilos.Clear()
                ActiveControl = dtpConFInicio
            End If
        End If
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If _dtProgramaCV.Rows.Count > 0 Then
            Dim EliminaProgramaCV As New PortatilClasses.ProgramaCompraVenta.Programa()
            EliminaProgramaCV.EliminarPrograma(CInt(_dtProgramaCV.DefaultView.Item(grdProgramaCV.CurrentRowIndex).Item("ProgramaCompraVenta")), _
                                            CDate(_dtProgramaCV.DefaultView.Item(grdProgramaCV.CurrentRowIndex).Item("Fecha")), _
                                            CShort(_dtProgramaCV.DefaultView.Item(grdProgramaCV.CurrentRowIndex).Item("Corporativo")), _
                                            CShort(_dtProgramaCV.DefaultView.Item(grdProgramaCV.CurrentRowIndex).Item("Sucursal")))
            _dtProgramaCV.DefaultView.Item(grdProgramaCV.CurrentRowIndex).Delete()
            _dtProgramaCV.AcceptChanges()
            grdProgramaCV.DataSource = Nothing
            grdProgramaCV.DataSource = _dtProgramaCV
        End If
    End Sub
#End Region

End Class
