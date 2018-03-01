' Registrar y modifca la información de los embarques, al modificar un embarque no se activan varios registros
' debido a que estos registros afecta directamente los inventarios, estos registros no se pueden modificar para
' esto es neecsario la cancelación del movimiento

Public Class frmEmbarqueTraspaso
    Inherits System.Windows.Forms.Form
    Private Producto As Integer
    Public Operacion As String
    Public Embarque As Integer
    Private FactorDensidad As String
    Private Titulo As String
    Private DatosSalvados As Boolean
    Private NumEnter As Short

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpbEmbarque As System.Windows.Forms.GroupBox
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtKilosPemex As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtLitros100 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtPorcentaje As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtLitrosPemex As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboOrigen As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboTransportadora As PortatilClasses.Combo.ComboBase
    Friend WithEvents txtPG As System.Windows.Forms.TextBox
    Friend WithEvents dtpFEmbarque As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumeroEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents cboCorporativoDestino As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboCorporativoFacturar As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCelulaDestino As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGarza As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEmbarqueTraspaso))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbEmbarque = New System.Windows.Forms.GroupBox()
        Me.cboCelulaDestino = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtKilosPemex = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtLitros100 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtPorcentaje = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtLitrosPemex = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.cboOrigen = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboTransportadora = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.txtPG = New System.Windows.Forms.TextBox()
        Me.dtpFEmbarque = New System.Windows.Forms.DateTimePicker()
        Me.txtNumeroEmbarque = New System.Windows.Forms.TextBox()
        Me.cboCorporativoDestino = New PortatilClasses.Combo.ComboCorporativo()
        Me.cboCorporativoFacturar = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGarza = New System.Windows.Forms.TextBox()
        Me.gpbEmbarque.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(470, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(470, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpbEmbarque
        '
        Me.gpbEmbarque.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.txtGarza, Me.cboCelulaDestino, Me.Label4, Me.cboAlmacen, Me.Label22, Me.txtKilosPemex, Me.Label43, Me.Label3, Me.Label2, Me.Label1, Me.Label45, Me.Label44, Me.Label12, Me.Label14, Me.Label15, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.txtLitros100, Me.txtPorcentaje, Me.txtLitrosPemex, Me.cboCelula, Me.dtpFMovimiento, Me.cboOrigen, Me.cboTransportadora, Me.txtPG, Me.dtpFEmbarque, Me.txtNumeroEmbarque, Me.cboCorporativoDestino, Me.cboCorporativoFacturar})
        Me.gpbEmbarque.Location = New System.Drawing.Point(16, 6)
        Me.gpbEmbarque.Name = "gpbEmbarque"
        Me.gpbEmbarque.Size = New System.Drawing.Size(408, 474)
        Me.gpbEmbarque.TabIndex = 1
        Me.gpbEmbarque.TabStop = False
        '
        'cboCelulaDestino
        '
        Me.cboCelulaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaDestino.Location = New System.Drawing.Point(168, 156)
        Me.cboCelulaDestino.Name = "cboCelulaDestino"
        Me.cboCelulaDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCelulaDestino.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(24, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Celula destino:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.ItemHeight = 13
        Me.cboAlmacen.Location = New System.Drawing.Point(168, 100)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(24, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 13)
        Me.Label22.TabIndex = 153
        Me.Label22.Text = "Almacén origen:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtKilosPemex
        '
        Me.txtKilosPemex.AutoSize = False
        Me.txtKilosPemex.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtKilosPemex.Location = New System.Drawing.Point(168, 380)
        Me.txtKilosPemex.MaxLength = 12
        Me.txtKilosPemex.Name = "txtKilosPemex"
        Me.txtKilosPemex.Size = New System.Drawing.Size(216, 21)
        Me.txtKilosPemex.TabIndex = 15
        Me.txtKilosPemex.Text = "txtKilosPemex"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(24, 384)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(104, 13)
        Me.Label43.TabIndex = 152
        Me.Label43.Text = "Kilos Guía Pemex:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(24, 412)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 151
        Me.Label3.Text = "Porcentaje Guía Pemex:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(24, 356)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Litros Guía Pemex:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(24, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Litros al 100%:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label45.Location = New System.Drawing.Point(24, 76)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(114, 13)
        Me.Label45.TabIndex = 148
        Me.Label45.Text = "Destino según guía:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(24, 188)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(109, 13)
        Me.Label44.TabIndex = 147
        Me.Label44.Text = "Fecha movimiento:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(24, 300)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 13)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "Número de P.G.:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(24, 272)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 145
        Me.Label14.Text = "Procedencia:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(24, 244)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 144
        Me.Label15.Text = "Transportadora:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(24, 216)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 143
        Me.Label18.Text = "Fecha de guía:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(24, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 13)
        Me.Label19.TabIndex = 142
        Me.Label19.Text = "Número de guía:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(24, 132)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 13)
        Me.Label20.TabIndex = 141
        Me.Label20.Text = "Empresa destino :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(24, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 13)
        Me.Label21.TabIndex = 140
        Me.Label21.Text = "Empresa facturada:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLitros100
        '
        Me.txtLitros100.AutoSize = False
        Me.txtLitros100.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtLitros100.Location = New System.Drawing.Point(168, 324)
        Me.txtLitros100.MaxLength = 12
        Me.txtLitros100.Name = "txtLitros100"
        Me.txtLitros100.Size = New System.Drawing.Size(216, 21)
        Me.txtLitros100.TabIndex = 13
        Me.txtLitros100.Text = "TxtNumeroEntero1"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.AutoSize = False
        Me.txtPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentaje.Location = New System.Drawing.Point(168, 406)
        Me.txtPorcentaje.MaxLength = 2
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(216, 21)
        Me.txtPorcentaje.TabIndex = 16
        Me.txtPorcentaje.Text = "TxtNumeroEntero3"
        '
        'txtLitrosPemex
        '
        Me.txtLitrosPemex.AutoSize = False
        Me.txtLitrosPemex.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtLitrosPemex.Location = New System.Drawing.Point(168, 352)
        Me.txtLitrosPemex.MaxLength = 12
        Me.txtLitrosPemex.Name = "txtLitrosPemex"
        Me.txtLitrosPemex.Size = New System.Drawing.Size(216, 21)
        Me.txtLitrosPemex.TabIndex = 14
        Me.txtLitrosPemex.Text = "TxtNumeroEntero2"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(168, 72)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 4
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(168, 184)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 8
        Me.dtpFMovimiento.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.Location = New System.Drawing.Point(168, 268)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboOrigen.TabIndex = 11
        '
        'cboTransportadora
        '
        Me.cboTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransportadora.Location = New System.Drawing.Point(168, 240)
        Me.cboTransportadora.Name = "cboTransportadora"
        Me.cboTransportadora.Size = New System.Drawing.Size(216, 21)
        Me.cboTransportadora.TabIndex = 10
        '
        'txtPG
        '
        Me.txtPG.AutoSize = False
        Me.txtPG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPG.Location = New System.Drawing.Point(168, 296)
        Me.txtPG.MaxLength = 25
        Me.txtPG.Name = "txtPG"
        Me.txtPG.Size = New System.Drawing.Size(216, 21)
        Me.txtPG.TabIndex = 12
        Me.txtPG.Text = "TEXTBOX6"
        '
        'dtpFEmbarque
        '
        Me.dtpFEmbarque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFEmbarque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFEmbarque.Location = New System.Drawing.Point(168, 212)
        Me.dtpFEmbarque.Name = "dtpFEmbarque"
        Me.dtpFEmbarque.Size = New System.Drawing.Size(216, 21)
        Me.dtpFEmbarque.TabIndex = 9
        Me.dtpFEmbarque.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'txtNumeroEmbarque
        '
        Me.txtNumeroEmbarque.AutoSize = False
        Me.txtNumeroEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroEmbarque.Location = New System.Drawing.Point(168, 16)
        Me.txtNumeroEmbarque.MaxLength = 10
        Me.txtNumeroEmbarque.Name = "txtNumeroEmbarque"
        Me.txtNumeroEmbarque.Size = New System.Drawing.Size(216, 21)
        Me.txtNumeroEmbarque.TabIndex = 2
        Me.txtNumeroEmbarque.Text = "TEXTBOX8"
        '
        'cboCorporativoDestino
        '
        Me.cboCorporativoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoDestino.ItemHeight = 13
        Me.cboCorporativoDestino.Location = New System.Drawing.Point(168, 128)
        Me.cboCorporativoDestino.Name = "cboCorporativoDestino"
        Me.cboCorporativoDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoDestino.TabIndex = 6
        '
        'cboCorporativoFacturar
        '
        Me.cboCorporativoFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoFacturar.ItemHeight = 13
        Me.cboCorporativoFacturar.Location = New System.Drawing.Point(168, 44)
        Me.cboCorporativoFacturar.Name = "cboCorporativoFacturar"
        Me.cboCorporativoFacturar.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoFacturar.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 436)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "Número de Garza:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGarza
        '
        Me.txtGarza.AutoSize = False
        Me.txtGarza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGarza.Location = New System.Drawing.Point(168, 432)
        Me.txtGarza.MaxLength = 3
        Me.txtGarza.Name = "txtGarza"
        Me.txtGarza.Size = New System.Drawing.Size(216, 21)
        Me.txtGarza.TabIndex = 17
        Me.txtGarza.Text = "TEXTBOX1"
        '
        'frmEmbarqueTraspaso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(562, 518)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpbEmbarque, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmEmbarqueTraspaso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarque"
        Me.gpbEmbarque.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        If cboCorporativoFacturar.Items.Count > 1 Then
            cboCorporativoFacturar.SelectedIndex = -1
            cboCorporativoFacturar.SelectedIndex = -1
        End If
        If cboCorporativoDestino.Items.Count > 1 Then
            cboCorporativoDestino.SelectedIndex = -1
            cboCorporativoDestino.SelectedIndex = -1
        End If
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.SelectedIndex = -1
            cboAlmacen.SelectedIndex = -1
        End If
        If cboCelulaDestino.Items.Count > 1 Then
            cboCelulaDestino.SelectedIndex = -1
            cboCelulaDestino.SelectedIndex = -1
        End If
        If cboTransportadora.Items.Count > 1 Then
            cboTransportadora.SelectedIndex = -1
            cboTransportadora.SelectedIndex = -1
        End If
        If cboOrigen.Items.Count > 1 Then
            cboOrigen.SelectedIndex = -1
            cboOrigen.SelectedIndex = -1
        End If
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
        txtNumeroEmbarque.Clear()
        txtPG.Clear()
        txtLitros100.Clear()
        txtLitrosPemex.Clear()
        txtPorcentaje.Clear()
        txtKilosPemex.Clear()
        txtGarza.Clear()
        DatosSalvados = False
    End Sub


    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboCorporativoFacturar.Text <> "" And cboCorporativoDestino.Text <> "" And cboAlmacen.Text <> "" And _
        txtNumeroEmbarque.Text <> "" And cboTransportadora.Text <> "" And cboOrigen.Text <> "" And txtPG.Text <> "" And _
          txtLitros100.Text <> "" And txtLitrosPemex.Text <> "" And txtPorcentaje.Text <> "" And _
        txtKilosPemex.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub ExisteEmbarque()
        If cboAlmacen.Text <> "" And txtPG.Text <> "" And txtNumeroEmbarque.Text <> "" Then
            Dim oExisteEmbarque As New PortatilClasses.Consulta.cExisteEmbarque(0)
            oExisteEmbarque.CargarDatos(cboAlmacen.Identificador, txtPG.Text, txtNumeroEmbarque.Text, Embarque)
            If oExisteEmbarque.Identificador > 0 Then
                Dim Mensajes As New PortatilClasses.Mensaje(73)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ActiveControl = txtNumeroEmbarque
                txtNumeroEmbarque.SelectAll()
            End If
        End If
    End Sub

    ' Carga el producto del almacen destino
    Private Sub CargarProducto(ByVal AlmacenGas As Integer)
        If AlmacenGas > 0 Then
            Dim oProducto As New PortatilClasses.Consulta.cProductoContenedor(0, AlmacenGas)
            oProducto.CargaDatos()
            Producto = oProducto.Identificador
            oProducto = Nothing
        End If
    End Sub

    ''TEMPORALMENTE NO ME SIRVE YA QUE NO VOY A VALIDAR LA ENTRADA
    '' Checa si las existencia del almacen destino no rebasan el stock minimo que tiene asignado
    'Private Function StockMinimo(ByVal AlmacenGas As Integer, ByVal Cantidad As Decimal) As Boolean
    '    Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(1, AlmacenGas)
    '    Dim Litros As Decimal
    '    Litros = Cantidad / CType(FactorDensidad, Decimal)
    '    If oAlmacenGasStock.drReader.Read() Then
    '        If Litros > CType(oAlmacenGasStock.drReader(1), Decimal) Then
    '            oAlmacenGasStock.drReader.Close()
    '            oAlmacenGasStock.CerrarConexion()
    '            Return False
    '        End If
    '    Else
    '        oAlmacenGasStock.drReader.Close()
    '        oAlmacenGasStock.CerrarConexion()
    '        Return False
    '    End If
    '    oAlmacenGasStock.drReader.Close()
    '    oAlmacenGasStock.CerrarConexion()
    '    Return True
    'End Function

    ' Registra el producto en la tabla de MovimientoAlmacenproducto
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
        Dim Kilos As Decimal
        Kilos = CType(txtKilosPemex.Text, Decimal)
        Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
        oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(3, Almacen, Producto, _
                                        MovimientoAlmacen, Kilos, Kilos, 1)
        oMovimientoAProducto.CargaDatos()
    End Sub

    ' Registra la información del embarque
    Private Sub RegistrarEmbarque(ByVal MovimientoAlmacenE As Integer, ByVal AlmacenGas As Integer, _
    ByVal LitrosPemex As Decimal, ByVal FRecepcion As DateTime)
        Dim oEmbarque As PortatilClasses.Consulta.cEmbarque

        oEmbarque = New PortatilClasses.Consulta.cEmbarque(0)
        Embarque = 0

        Dim PesoLleno As Integer
        Dim PesoVacio As Integer
        Dim TotInicial As Decimal
        Dim TotFinal As Decimal



        oEmbarque.Registrar(Embarque, txtNumeroEmbarque.Text, CType(txtLitros100.Text, Decimal), LitrosPemex, _
        CType(txtKilosPemex.Text, Decimal), CType(txtPorcentaje.Text, Integer), dtpFEmbarque.Value, FRecepcion, 0, 0, _
        "", "", cboCorporativoFacturar.Identificador, PesoLleno, PesoVacio, _
        cboTransportadora.Identificador, Producto, cboOrigen.Identificador, MovimientoAlmacenE, _
        txtPG.Text, "", Now, Now, AlmacenGas, cboCelula.Identificador, TotInicial, _
        TotFinal, txtGarza.Text, GLOBAL_Usuario)

        oEmbarque = Nothing
    End Sub

    ' Modifica la iformacion del embarque
    Private Sub ModificarEmbarque(ByVal FRecepcion As Date)
        Dim oEmbarque As New PortatilClasses.Consulta.cEmbarque(2)

        Dim PesoLleno As Integer
        Dim PesoVacio As Integer
        Dim TotInicial As Decimal
        Dim TotFinal As Decimal


        oEmbarque.Registrar(Embarque, txtNumeroEmbarque.Text, CType(txtLitros100.Text, Decimal), _
        CType(txtLitrosPemex.Text, Decimal), 0, CType(txtPorcentaje.Text, Integer), dtpFEmbarque.Value.Date, FRecepcion, 0, 0, _
        "", "", cboCorporativoFacturar.Identificador, PesoLleno, PesoVacio, _
        cboTransportadora.Identificador, Producto, cboOrigen.Identificador, 0, txtPG.Text, "", _
        Now, Now, 0, cboCelula.Identificador, TotInicial, TotFinal, txtGarza.Text, GLOBAL_Usuario)

        oEmbarque = Nothing
    End Sub

    ' Realiza los movimientos del embarque
    Private Sub RealizarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()

            Dim Litros As Decimal
            Dim Kilos As Decimal
            Dim FechaMov As DateTime
            Dim CelulaDestino As Integer = 0
            If cboCelulaDestino.Text <> "" Then
                CelulaDestino = cboCelulaDestino.Identificador
            End If

            FechaMov = dtpFMovimiento.Value

            Kilos = CType(txtKilosPemex.Text, Decimal)
            Litros = Kilos / CType(FactorDensidad, Decimal)

            'SE GENERA EL NUMERO DE FOLIO PARA EL MOVIMIENTO DE SALIDA
            'CON EL TIPO DE MOVIMIENTO 13
            Dim oFolioMovimientoAlmacenS As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacenS.Registrar(0, cboAlmacen.Identificador, 0, 13, 0)

            'SE REGISTRA EL MOVIMIENTO DE TRASPASO VENTA FILIAL
            Dim oMovimientoAlmacenS As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, cboAlmacen.Identificador, _
                                           FechaMov, Kilos, Litros, 13, FechaMov, oFolioMovimientoAlmacenS.NDocumento, _
                                           oFolioMovimientoAlmacenS.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacenS.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()


            'SE GENERA EL NUMERO DE FOLIO PARA EL MOVIMIENTO DE ENTRADA AL ALMACEN 0
            'CON EL TIPO DE MOVIMIENTO 10
            Dim oFolioMovimientoAlmacenE As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacenE.Registrar(3, 0, oFolioMovimientoAlmacenS.NDocumento, 10, cboCorporativoDestino.Identificador)


            'SE REGITRA EL MOVIMIENTO DE ENTRADA DEL EMBARQUE PARA LA EMPRESA QUE LE VENDIMOS
            Dim oMovimientoAlmacenE As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, 0, _
                                           FechaMov, Kilos, Litros, 10, dtpFMovimiento.Value, oFolioMovimientoAlmacenE.NDocumento, _
                                           oFolioMovimientoAlmacenE.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacenE.IdCorporativo, GLOBAL_Usuario, CelulaDestino)
            oMovimientoAlmacenE.CargaDatos()

            RegistrarEmbarque(oMovimientoAlmacenE.Identificador, 0, CType(txtLitrosPemex.Text, Decimal), _
                  dtpFMovimiento.Value)


            Dim oMovimientoEntreAlmacenes As New PortatilClasses.Consulta.cMovimientoEntreAlmacenes(0, 0, oMovimientoAlmacenE.Identificador, _
                                                                     cboAlmacen.Identificador, oMovimientoAlmacenS.Identificador)

            oMovimientoEntreAlmacenes.CargaDatos()

            oMovimientoAlmacenE = Nothing
            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacenS = Nothing
            oMovimientoEntreAlmacenes = Nothing

            Limpiar()
            DatosSalvados = True
            Close()
        End If
    End Sub

    'TEMPORALMENTE NO MODIFICO
    ' Verfica la información para poder modificarla
    Private Sub ModificarMovimientos()
        'Dim Result As DialogResult
        'Dim Mensajes As New PortatilClasses.Mensaje(4)
        'Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If Result = DialogResult.Yes Then
        '    Refresh()

        '    ModificarEmbarque(dtpFRecepcion.Value.Date)
        '    Limpiar()
        '    Embarque = 0
        '    DatosSalvados = True
        '    Close()
        'End If
    End Sub

    ' Verifica la información para poder registrar el embarque
    Private Sub ValidarMovimientos()
        RealizarMovimientos()
    End Sub

    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As DateTime
        Dim Fecha As DateTime
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub InicializarFechas()
        dtpFMovimiento.Value = FechaActual()
        dtpFEmbarque.Value = dtpFMovimiento.Value
    End Sub

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = FechaActual()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value
        End If

        dtpFEmbarque.Value = dtpFMovimiento.Value

        dtpFEmbarque.MaxDate = dtpFMovimiento.Value
    End Sub

    ' Habilita o Deshabilita los controles que no se pueden modificar
    Private Sub HabilitarControles(ByVal Habilitar As Boolean)
        cboCorporativoDestino.Enabled = Habilitar
        cboAlmacen.Enabled = Habilitar
        dtpFMovimiento.Enabled = Habilitar
        txtKilosPemex.ReadOnly = Not Habilitar
    End Sub

    'TEMPORALMENTE NO MODIFICO
    ' Carga los datos del embarque a los controles correspondientes
    Private Sub CargarDatos(ByVal Embarque As Integer)
        'Dim oEmbarque As New PortatilClasses.Consulta.cEmbarque(1)
        'oEmbarque.Consultar(Embarque)
        'If oEmbarque.drAlmacen.Read() Then
        '    cboCorporativoFacturar.PosicionaCombo(CType(oEmbarque.drAlmacen(0), Integer))
        '    cboCorporativoDestino.PosicionaCombo(CType(oEmbarque.drAlmacen(1), Integer))
        '    cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
        '    cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoFacturar.Identificador, GLOBAL_Usuario)
        '    cboAlmacen.PosicionaCombo(CType(oEmbarque.drAlmacen(2), Integer))
        '    Try

        '        txtPG.Text = CType(oEmbarque.drAlmacen(9), String)


        '        dtpFMovimiento.Value = CType(oEmbarque.drAlmacen(4), DateTime)

        '        txtNumeroEmbarque.Text = CType(oEmbarque.drAlmacen(3), String)
        '        cboTransportadora.PosicionaCombo(CType(oEmbarque.drAlmacen(7), Integer))
        '        cboOrigen.PosicionaCombo(CType(oEmbarque.drAlmacen(8), Integer))

        '        txtLitros100.Text = CType(oEmbarque.drAlmacen(12), String)
        '        txtLitrosPemex.Text = CType(oEmbarque.drAlmacen(13), String)
        '        txtKilosPemex.Text = CType(oEmbarque.drAlmacen(14), String)
        '        txtPorcentaje.Text = CType(oEmbarque.drAlmacen(15), String)

        '        If Not IsDBNull(oEmbarque.drAlmacen(23)) Then
        '            If CType(oEmbarque.drAlmacen(23), Short) > 0 Then
        '                cboCelula.PosicionaCombo(CType(oEmbarque.drAlmacen(23), Short))
        '            End If
        '        End If

        '        Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(3, 0, txtPG.Text, "", 0, 0, _
        '                     CType(cboTransportadora.Identificador, Short))
        '        oTanque.VerificarCapacidad()
        '        If oTanque.NumeroTanque <> "" Then
        '            txtCapacidadPG.Text = CType(oTanque.Capacidad, String)
        '        End If
        '    Catch
        '        cboTransportadora.PosicionarInicio()
        '        cboOrigen.PosicionarInicio()
        '    End Try
        'End If
        'oEmbarque.drAlmacen.Close()
        'oEmbarque.CerrarConexion()
        'oEmbarque = Nothing
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter y las fechas de arriba y abajo
    Private Sub txtNumeroEmbarque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtNumeroEmbarque.KeyDown, txtLitros100.KeyDown, txtLitrosPemex.KeyDown, _
    txtPorcentaje.KeyDown, txtKilosPemex.KeyDown, txtPG.KeyDown, txtGarza.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Inicialización de la forma
    Private Sub frmEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor


        Limpiar()

        InicializarFechas()
        cboCorporativoFacturar.CargaDatos(0)

        cboCorporativoDestino.CargaDatos(0)
        'cboCorporativoDestino.PosicionaCombo(GLOBAL_Empresa)
        cboCorporativoFacturar.PosicionaCombo(GLOBAL_Empresa)

        cboCorporativoFacturar.Enabled = False

        If cboCorporativoFacturar.Text <> "" Then
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoFacturar.Identificador, Short), 0, 0)
        End If

        If cboCorporativoDestino.Text <> "" Then
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoDestino.Identificador, Short), 0, 0)
        End If

        If cboCelula.Text <> "" Then
            'If GLOBAL_EmbarqueEstacionario Or Operacion = "Modificar" Then
            '    cboAlmacen.CargaDatos(14, GLOBAL_Usuario, cboCelula.Identificador)
            'Else
            cboAlmacen.CargaDatos(13, GLOBAL_Usuario, cboCelula.Identificador)
            'End If
            CargarProducto(cboAlmacen.Identificador)
        End If


        cboTransportadora.CargaDatosBase("spPTLCargaComboTransportadora", 0, GLOBAL_Usuario)
        cboOrigen.CargaDatosBase("spPTLCargaComboDestinoTransporte", 0, GLOBAL_Usuario)
        Me.ActiveControl = txtNumeroEmbarque

        If Operacion = "Modificar" Then
            CargarDatos(Embarque)
            HabilitarControles(False)
        Else
            ValidarRangoFechas()
        End If

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim
        Titulo = Me.Text
        Cursor = Cursors.Default
    End Sub

    ' Evento del control cboCorporativoDestino, carga los almacenes d ela empresa seleccionada
    Private Sub cboCorporativoDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativoDestino.SelectedIndexChanged
        If cboCorporativoDestino.Focused And cboCorporativoDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoDestino.Identificador, Short), 0, 0)

            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub



    ' Evento del control Cancelar, cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    ' Evento que se activa cuando hay algún cambio en los controles
    Private Sub cboCorporativoFacturar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboOrigen.SelectedIndexChanged, txtLitros100.TextChanged, _
    txtLitrosPemex.TextChanged, txtPorcentaje.TextChanged, txtKilosPemex.TextChanged, _
    txtNumeroEmbarque.TextChanged
        ExisteEmbarque()
        HabilitarAceptar()
    End Sub

    ' Evento del botón btnAceptar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        If Operacion = "Agregar" Then
            ValidarMovimientos()
        End If
        If Operacion = "Modificar" Then
            ModificarMovimientos()
        End If
        Cursor = Cursors.Default
    End Sub

    ' Evento del botón cboAlmacen, se activa cuando hay un cambio, carga el producto del Almacen Destino
    Private Sub cboAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboAlmacen.SelectedIndexChanged
        If cboAlmacen.Focused Then
            Cursor = Cursors.WaitCursor
            ExisteEmbarque()
            HabilitarAceptar()
            CargarProducto(cboAlmacen.Identificador)
            'HabilitarCelula()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Valida que la fecha de embarque sea menor o igual a la fecha de recepcion
    Private Sub dtpFEmbarque_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFEmbarque.TextChanged
        HabilitarAceptar()
    End Sub



    ' Valida los controles txtLitros100 y txtLitrosPemex
    Private Sub txtLitros100_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLitros100.Leave, _
    txtLitrosPemex.Leave
        If txtLitros100.Text <> "" And txtLitrosPemex.Text <> "" Then
            If CType(txtLitros100.Text, Integer) < CType(txtLitrosPemex.Text, Integer) Then
                Dim Mensajes As New PortatilClasses.Mensaje(6)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = CType(sender, Control)
                CType(sender, Control).Select()
            End If
        End If
    End Sub


    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboCorporativoFacturar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCorporativoFacturar.KeyDown, cboCorporativoDestino.KeyDown, cboAlmacen.KeyDown, dtpFEmbarque.KeyDown, cboOrigen.KeyDown, dtpFMovimiento.KeyDown, cboCelula.KeyDown, cboTransportadora.KeyDown, cboCelulaDestino.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Valida que la fecha de recepcion sea menor o igual a la fecha de movimiennto y que la hora de inicio y fin
    ' de descarga sea menor o igual a la fecha de movimiento y mayor e igual a la fecha de recepcion del embarque
    Private Sub dtpFMovimiento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFMovimiento.TextChanged
        If dtpFMovimiento.Focused Then
            dtpFEmbarque.MaxDate = dtpFMovimiento.Value
        End If
        HabilitarAceptar()
    End Sub



    Private Sub frmEmbarque_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cboCorporativoFacturar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativoFacturar.SelectedIndexChanged
        HabilitarAceptar()
        If cboCorporativoFacturar.Focused Then
            'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoFacturar.Identificador, GLOBAL_Usuario)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoFacturar.Identificador, Short), 0, 0)
        End If
        'HabilitarCelula()
    End Sub

    Private Sub txtPG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtPG.TextChanged, cboTransportadora.SelectedIndexChanged
        ExisteEmbarque()
        HabilitarAceptar()
        NumEnter = 1
    End Sub



    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        HabilitarAceptar()
        If cboCelula.Text <> "" And cboCelula.Focused Then
            cboAlmacen.CargaDatos(13, GLOBAL_Usuario, cboCelula.Identificador)
            CargarProducto(cboAlmacen.Identificador)
        End If
    End Sub
End Class
