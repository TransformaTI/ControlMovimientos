'' Realiza los traslados de la misma empresa a la misma empresa

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 29/12/2005
'Motivo: Se corrijio los parametros de INICIALIZAFORMA
'Identificador de cambios: 20051229CAGP$004
'Motivo: La salida de un att a un anden se debe de afectar por los litros totalizador
'Identificador de cambios: 20051229CAGP$007

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 19/01/2006
'Motivo: Se modifico y valido varias lineas de la forma

'Modifico: Claudia Aurora García Patiño
'Fecha: 03/03/2006
'Motivo: SE configuro para que no incrementara el totalziador y se volviera aincrementar en el area de bascula
'Identificador de cambios: 20060303CAGP$002

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$011

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 20/09/2006
'Motivo: Se corrijio el llamado de las pantallas de MedicionFisica

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 11/01/2007
'Motivo: Se modifico el calculo del factor de densidad
'Identificador de cambios: 20070111CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/07/2007
'Motivo: Se aumento un parametro para la validación de litros porcentaje y totalizador
'Identificador de cambios: 20070706CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 01/08/2007
'Motivo: Se aumento un control a la forma

Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoTraslado
    Inherits System.Windows.Forms.Form

    Private Producto As Integer
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo


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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboCorporativoOrigen As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAlmacenDestino As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents cboAlmacenOrigen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFTraslado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCelulaOrigen As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboCelulaDestino As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTotFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents cboxPorcentaje As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoTraslado))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboxPorcentaje = New System.Windows.Forms.CheckBox()
        Me.txtTotFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTotInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCelulaDestino = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCelulaOrigen = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.cboCorporativoOrigen = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacenDestino = New PortatilClasses.Combo.ComboAlmacen()
        Me.cboAlmacenOrigen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpFTraslado = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(515, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(515, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboxPorcentaje, Me.txtTotFinal, Me.txtTotInicial, Me.Label5, Me.Label7, Me.cboCelulaDestino, Me.Label4, Me.cboCelulaOrigen, Me.Label3, Me.ProductoPanel, Me.cboCorporativoOrigen, Me.Label2, Me.cboAlmacenDestino, Me.cboAlmacenOrigen, Me.Label12, Me.Label13, Me.lblProducto, Me.lblKilos, Me.Label6, Me.dtpFMovimiento, Me.dtpFTraslado, Me.Label1})
        Me.grpDatos.Location = New System.Drawing.Point(11, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 478)
        Me.grpDatos.TabIndex = 11
        Me.grpDatos.TabStop = False
        '
        'cboxPorcentaje
        '
        Me.cboxPorcentaje.Location = New System.Drawing.Point(360, 136)
        Me.cboxPorcentaje.Name = "cboxPorcentaje"
        Me.cboxPorcentaje.TabIndex = 43
        Me.cboxPorcentaje.TabStop = False
        Me.cboxPorcentaje.Text = "Porcentaje %"
        Me.cboxPorcentaje.Visible = False
        '
        'txtTotFinal
        '
        Me.txtTotFinal.AutoSize = False
        Me.txtTotFinal.Location = New System.Drawing.Point(131, 249)
        Me.txtTotFinal.MaxLength = 12
        Me.txtTotFinal.Name = "txtTotFinal"
        Me.txtTotFinal.Size = New System.Drawing.Size(216, 21)
        Me.txtTotFinal.TabIndex = 8
        Me.txtTotFinal.Text = ""
        '
        'txtTotInicial
        '
        Me.txtTotInicial.AutoSize = False
        Me.txtTotInicial.Location = New System.Drawing.Point(131, 221)
        Me.txtTotInicial.MaxLength = 12
        Me.txtTotInicial.Name = "txtTotInicial"
        Me.txtTotInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtTotInicial.TabIndex = 7
        Me.txtTotInicial.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(18, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Totalizador inicial:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(19, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Totalizador final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelulaDestino
        '
        Me.cboCelulaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaDestino.Location = New System.Drawing.Point(131, 107)
        Me.cboCelulaDestino.Name = "cboCelulaDestino"
        Me.cboCelulaDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCelulaDestino.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Célula destino:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelulaOrigen
        '
        Me.cboCelulaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaOrigen.Location = New System.Drawing.Point(131, 52)
        Me.cboCelulaOrigen.Name = "cboCelulaOrigen"
        Me.cboCelulaOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboCelulaOrigen.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Célula origen:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(11, 285)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(463, 152)
        Me.ProductoPanel.TabIndex = 9
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'cboCorporativoOrigen
        '
        Me.cboCorporativoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoOrigen.Location = New System.Drawing.Point(131, 24)
        Me.cboCorporativoOrigen.Name = "cboCorporativoOrigen"
        Me.cboCorporativoOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoOrigen.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Empresa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenDestino
        '
        Me.cboAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenDestino.Location = New System.Drawing.Point(131, 137)
        Me.cboAlmacenDestino.Name = "cboAlmacenDestino"
        Me.cboAlmacenDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenDestino.TabIndex = 4
        '
        'cboAlmacenOrigen
        '
        Me.cboAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenOrigen.Location = New System.Drawing.Point(131, 79)
        Me.cboAlmacenOrigen.Name = "cboAlmacenOrigen"
        Me.cboAlmacenOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenOrigen.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Almacén destino:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(309, 451)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(32, 13)
        Me.lblProducto.TabIndex = 17
        Me.lblProducto.Text = "Kilos:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(357, 447)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 15
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(131, 165)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 5
        '
        'dtpFTraslado
        '
        Me.dtpFTraslado.CustomFormat = ""
        Me.dtpFTraslado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFTraslado.Location = New System.Drawing.Point(131, 193)
        Me.dtpFTraslado.Name = "dtpFTraslado"
        Me.dtpFTraslado.Size = New System.Drawing.Size(216, 21)
        Me.dtpFTraslado.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(17, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Fecha traslado:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(515, 82)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMovimientoTraslado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 504)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.grpDatos, Me.btnConsultar})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoTraslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslado"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Crea la forma de la Captura de la medicion "CODIGO PACO"
    Dim frmCapturaMedicionEstacionarioSH As New MedicionFisica.frmMedicionInicialFinalEst()
    '20051201CAGP $002 /I
    Dim frmCapturaMedicionEstacionario As New MedicionFisica.frmMedicionInicialFinalHdirometro()
    '20051201CAGP $002 /F
    Dim frmCapturaMedicionTanque As New MedicionFisica.frmMedicionTanqueAlmacen()

    'Valida que los litros según porcentaje concuerden con los litros totalizador
    '20070706CAGP$001 /I
    Function PermitirPorTotHd() As Boolean
        If cboxPorcentaje.Checked And lblKilos.Text = "0.00" Then
            ProductoPanel.txtCantidad1.Text = CType(frmCapturaMedicionEstacionario.LitrosPorcentaje(), String)
        End If
        If frmCapturaMedicionEstacionario.PermitirTotalizadorPorcentaje(CType(lblKilos.Text, Decimal), GLOBAL_PorcentajePermitido) = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(96)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        Else
            Return True
        End If
    End Function

    'Valida que los litros según porcentaje concuerden con los litros totalizador
    Function PermitirPorTot() As Boolean
        If cboxPorcentaje.Checked And lblKilos.Text = "0.00" Then
            ProductoPanel.txtCantidad1.Text = CType(frmCapturaMedicionEstacionarioSH.LitrosPorcentaje(), String)
        End If
        If frmCapturaMedicionEstacionarioSH.PermitirTotalizadorPorcentaje(CType(lblKilos.Text, Decimal), GLOBAL_PorcentajePermitido) = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(96)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        Else
            Return True
        End If
    End Function

    'Valida que los litros según porcentaje concuerden con los litros totalizador
    Function PermitirPorTotTanque() As Boolean
        If frmCapturaMedicionTanque.PermitirTotalizadorPorcentaje(CType(lblKilos.Text, Decimal), GLOBAL_PorcentajePermitido) = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(96)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        Else
            Return True
        End If
    End Function

    'Funcion para la medicion fisica
    Function MedicionFisica() As Boolean
        If cboAlmacenDestino.Identificador > 0 Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDestino.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 4 And oAlmacenOrigen.AlmacenGas > 0 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenDestino.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionarioSH.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDestino.Text + "]"
                    frmCapturaMedicionEstacionarioSH.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenDestino.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String))
                    If frmCapturaMedicionEstacionarioSH.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTot()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                Else
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenDestino.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDestino.Text + "]"
                    frmCapturaMedicionEstacionario.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenDestino.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String), False) '20051229CAGP$004
                    If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTotHd()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 1 And oAlmacenOrigen.AlmacenGas > 0 Then
                frmCapturaMedicionTanque.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenOrigen.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value)
                If frmCapturaMedicionTanque.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotTanque()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 1 And oAlmacenOrigen.AlmacenGas > 0 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrigen.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionarioSH.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                    '20060301CAGP$001
                    frmCapturaMedicionEstacionarioSH.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrigen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String))
                    If frmCapturaMedicionEstacionarioSH.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTot()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                Else
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrigen.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                    frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrigen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String), False) ' 20051229CAGP$004
                    If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTotHd()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 4 And oAlmacenOrigen.AlmacenGas > 0 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrigen.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionarioSH.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                    frmCapturaMedicionEstacionarioSH.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrigen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                    If frmCapturaMedicionEstacionarioSH.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTot()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                Else
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrigen.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                    frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrigen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String), False) ' 20051229CAGP$004
                    If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTotHd()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 2 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 2 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 3 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 2 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 3 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 2 And oAlmacenOrigen.AlmacenGas > 0 Then
                Return True
            ElseIf oAlmacenDestino.TipoAlmacengas = 4 And oAlmacenOrigen.AlmacenGas = 0 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenDestino.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionarioSH.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDestino.Text + "]"
                    frmCapturaMedicionEstacionarioSH.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenDestino.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String))
                    If frmCapturaMedicionEstacionarioSH.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTot()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                Else
                    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenDestino.Identificador, 0)
                    oTanque.VerificarCapacidad()
                    frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDestino.Text + "]"
                    frmCapturaMedicionEstacionario.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenDestino.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String), False) ' 20051229CAGP$004
                    If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                        Return PermitirPorTotHd()
                    Else
                        DestruyeMedicionFisicaEstacionario()
                        Return False
                    End If
                End If
            ElseIf oAlmacenDestino.TipoAlmacengas = 1 And oAlmacenOrigen.AlmacenGas = 0 Then
                ' 20070111CAGP$001 /I
                'If oAlmacenDestino.CalcularVapor Then
                frmCapturaMedicionTanque.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDestino.Text + "]"
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenDestino.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value)
                Else
                    frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenDestino.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value, True)
                End If
                If frmCapturaMedicionTanque.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotTanque()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenDestino.TipoAlmacengas = 2 And oAlmacenOrigen.AlmacenGas = 0 Then
                Return True
            ElseIf oAlmacenDestino.TipoAlmacengas = 3 And oAlmacenOrigen.AlmacenGas = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrigen.Identificador, 0)
                oTanque.VerificarCapacidad()
                frmCapturaMedicionEstacionarioSH.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                frmCapturaMedicionEstacionarioSH.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrigen.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String))
                If frmCapturaMedicionEstacionarioSH.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTot()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 Then
                frmCapturaMedicionTanque.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrigen.Text + "]"
                frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenOrigen.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value)
                If frmCapturaMedicionTanque.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotTanque()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    ' 20070706CAGP$001 /F

    'Funcion que destruye la forma de medicion fisica "CODIGO PACO"
    Private Sub DestruyeMedicionFisicaEstacionario()
        frmCapturaMedicionEstacionario = Nothing
        frmCapturaMedicionEstacionario = New MedicionFisica.frmMedicionInicialFinalHdirometro()
        frmCapturaMedicionTanque = Nothing
        frmCapturaMedicionTanque = New MedicionFisica.frmMedicionTanqueAlmacen()
        frmCapturaMedicionEstacionarioSH = Nothing
        frmCapturaMedicionEstacionarioSH = New MedicionFisica.frmMedicionInicialFinalEst()
    End Sub

    'Funcion que Realiza una medicion fisica portatil "CODIGO PACO"
    Private Sub MedicionFisicaPortatil(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    'Funcion que almacena las mediciones fisica "CODIGO PACO"
    Private Sub AlmacenarMedicionFisica(ByVal MovEntrada As Integer, ByVal AlmDestino As Integer, ByVal MovSalida As Integer, ByVal AlmOrigen As Integer)
        If cboAlmacenDestino.Identificador > 0 Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDestino.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 4 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    frmCapturaMedicionEstacionarioSH.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                Else
                    frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                End If
                DestruyeMedicionFisicaEstacionario()

            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 1 Then
                ' ' 20070111CAGP$001 /I
                'If oAlmacenDestino.CalcularVapor = False And oAlmacenOrigen.AlmacenGas = 0 Then
                'frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                'Else
                frmCapturaMedicionTanque.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                'End If
                DestruyeMedicionFisicaEstacionario()
                ' ' 20070111CAGP$001 /F
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 1 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    frmCapturaMedicionEstacionarioSH.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                Else
                    frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                End If
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 4 Then
                If cboCelulaOrigen.Identificador = cboCelulaDestino.Identificador Then
                    frmCapturaMedicionEstacionarioSH.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                Else
                    frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                End If
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            End If
        Else
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 Then
                frmCapturaMedicionEstacionarioSH.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 Then
                frmCapturaMedicionTanque.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            End If
        End If
    End Sub

    Private Sub ConsultaTotalizador()
        ' 20060303CAGP$002 /I
        If GLOBAL_IncrementaTotalizador = "1" Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 Then
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
                oAutotanqueTurno.ConsultarAutotanqueTurno(0, oAlmacenOrigen.AlmacenGas, 0, 0)
                If Trim(oAutotanqueTurno.StatusBascula) <> "ABIERTO" Then
                    txtTotInicial.Text = oAutotanqueTurno.TotalizadorFinal.ToString("N2")
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(88, cboAlmacenOrigen.Text)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboAlmacenOrigen.PosicionarInicio()
                    ActiveControl = cboAlmacenOrigen
                End If
            End If
        Else
            OperacionTotalizador(0)
        End If
        ' 20060303CAGP$002 /F
    End Sub

    Private Sub ActivaTotalizador()
        If cboAlmacenOrigen.Text <> "" And cboAlmacenDestino.Text <> "" Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDestino.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 And (oAlmacenDestino.TipoAlmacengas = 2 Or oAlmacenDestino.TipoAlmacengas = 3) Then
                OperacionTotalizador(2)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And (oAlmacenDestino.TipoAlmacengas = 1 Or oAlmacenDestino.TipoAlmacengas = 4) Then
                OperacionTotalizador(1)
            Else
                OperacionTotalizador(0)
            End If
        Else
            If cboAlmacenOrigen.Text <> "" Then
                Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrigen.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
                oAlmacenOrigen.CargarAlmacenGas()

                If oAlmacenOrigen.TipoAlmacengas = 4 Then
                    OperacionTotalizador(1)
                Else
                    OperacionTotalizador(0)
                End If
            End If
        End If
    End Sub

    Private Sub OperacionTotalizador(ByVal Operacion As Short)
        Select Case Operacion
            Case 0
                txtTotInicial.Clear()
                txtTotFinal.Clear()
                OperacionTotalizador(1)
            Case 1
                txtTotInicial.ReadOnly = True
                txtTotFinal.ReadOnly = True
            Case 2
                txtTotInicial.ReadOnly = True
                txtTotFinal.ReadOnly = False
        End Select
    End Sub

    Function ValidaTotalizador() As Boolean
        If txtTotInicial.ReadOnly And txtTotFinal.ReadOnly Then
            Return True
        ElseIf txtTotFinal.ReadOnly = False Then
            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                Dim TotInicial As Decimal = CType(txtTotInicial.Text, Decimal)
                Dim TotFinal As Decimal = CType(txtTotFinal.Text, Decimal)
                If TotInicial <= TotFinal Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        OperacionTotalizador(0)
        lblKilos.Text = "0.00"
        If cboAlmacenOrigen.Items.Count > 1 Then
            cboAlmacenOrigen.SelectedIndex = -1
            cboAlmacenOrigen.SelectedIndex = -1
        End If
        If cboAlmacenDestino.Items.Count > 1 Then
            cboAlmacenDestino.SelectedIndex = -1
            cboAlmacenDestino.SelectedIndex = -1
        End If
    End Sub

    Private Sub SinAlmacenDestino()
        If (cboAlmacenDestino.Items.Count = 0 Or GLOBAL_TrasladosSinAlmacen = True) And cboAlmacenOrigen.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.TipoProducto)
            lblKilos.Text = "0.00"
            If cboAlmacenOrigen.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
        End If
    End Sub

    Private Sub SinAlmacenOrigen()
        If (cboAlmacenDestino.Items.Count = 0 Or GLOBAL_TrasladosSinAlmacen = True) And cboCelulaOrigen.Text <> "" Then
            cboAlmacenDestino.CargaDatos(15, GLOBAL_Usuario, cboCelulaDestino.Identificador)
            If cboAlmacenDestino.Text <> "" Then
                ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
                If cboAlmacenDestino.TipoProducto = 5 Then
                    lblProducto.Text = "Kilos:"
                Else
                    lblProducto.Text = "Litros:"
                End If
            End If
            lblKilos.Text = "0.00"
        End If
    End Sub

    ' Verifica que el almacén origen y el almacén destino no sean el mismo
    Private Function AlmacenGasDiferente() As Boolean
        If cboAlmacenOrigen.Identificador = cboAlmacenDestino.Identificador Then
            Return False
        End If
        Return True
    End Function

    Private Function LitrosPorPorcentaje() As Boolean
        If cboxPorcentaje.Checked And lblKilos.Text = "0.00" Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If ValidaTotalizador() And (cboAlmacenOrigen.Text <> "" Or (cboCelulaOrigen.Text <> "" And (cboAlmacenOrigen.Items.Count = 0 Or GLOBAL_TrasladosSinAlmacen = True))) _
        And (cboAlmacenDestino.Text <> "" Or (cboCelulaDestino.Text <> "" And (cboAlmacenDestino.Items.Count = 0 Or GLOBAL_TrasladosSinAlmacen = True))) _
        And cboCorporativoOrigen.Text <> "" And (CType(lblKilos.Text, Decimal) > 0 Or LitrosPorPorcentaje()) And AlmacenGasDiferente() Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Habilita los posibles valores del alamcén destino dependiendo de la selección del almacén origen
    Private Sub HabilitarAlmacenDestino()
        cboAlmacenDestino.Limpiar()
        If cboAlmacenOrigen.Text <> "" Then
            If cboAlmacenOrigen.TipoProducto = 5 Then
                ' Muestra los almacenes de tipo portatil
                cboAlmacenDestino.CargaDatos(18, GLOBAL_Usuario, cboCelulaDestino.Identificador)
            Else
                If GLOBAL_TrasladoCompleto Then
                    ' Muestra los contenedores, andenes y rutas estacionaria
                    cboAlmacenDestino.CargaDatos(19, GLOBAL_Usuario, cboCelulaDestino.Identificador)
                Else
                    ' Muestra sólo los andenes
                    cboAlmacenDestino.CargaDatos(16, GLOBAL_Usuario, cboCelulaDestino.Identificador)
                End If
            End If
        End If
        If cboAlmacenDestino.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
            lblKilos.Text = "0.00"
        End If
        SinAlmacenDestino()
        SinAlmacenOrigen()
    End Sub

    ' Registra los productos del movimiento, dependiendo del almacén origen y destino
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal TipoMovimiento As Integer)
        If cboAlmacenDestino.Text <> "" And cboAlmacenOrigen.Text <> "" Then
            ' Salida de prodictos del almacen
            If TipoMovimiento = 3 Then
                ' Registra el producto enviado en kilos
                If cboAlmacenOrigen.TipoProducto <> 5 And cboAlmacenDestino.TipoProducto = 5 Then
                    ' 20051229CAGP$007 /I
                    If cboAlmacenOrigen.Movil Then
                        Dim Litros As Decimal = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Litros, Producto)
                    Else
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Producto, CType(lblKilos.Text, Decimal))
                    End If
                    ' 20051229CAGP$007
                End If
                ' Registra los productos contenidos en el panel en kilos
                If cboAlmacenOrigen.TipoProducto = 5 And cboAlmacenDestino.TipoProducto = 5 Then
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                End If
                ' Registra el producto enviado en litros
                If cboAlmacenOrigen.TipoProducto <> 5 And cboAlmacenDestino.TipoProducto <> 5 Then
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal), Producto)
                End If
            End If
            ' Entrada de productos del almacen
            If TipoMovimiento = 4 Then
                ' Registra los productos contenidos en el panel en kilos
                If cboAlmacenDestino.TipoProducto = 5 Then
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                End If
                ' Registra el producto enviado en litros
                If cboAlmacenOrigen.TipoProducto <> 5 And cboAlmacenDestino.TipoProducto <> 5 Then
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
                End If
            End If
        Else
            If cboAlmacenDestino.Text = "" Then
                ' Salida de prodictos del almacen
                If TipoMovimiento = 3 Then
                    ' Registra los productos contenidos en el panel en kilos
                    If cboAlmacenOrigen.TipoProducto = 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                    End If
                    ' Registra el producto enviado en litros
                    If cboAlmacenOrigen.TipoProducto <> 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal), Producto)
                    End If
                End If
                ' Entrada de productos del almacen
                If TipoMovimiento = 4 Then
                    ' Registra los productos contenidos en el panel en kilos
                    If cboAlmacenOrigen.TipoProducto = 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                    End If
                    ' Registra el producto enviado en litros
                    If cboAlmacenOrigen.TipoProducto <> 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
                    End If
                End If
            Else
                ' Salida de prodictos del almacen
                If TipoMovimiento = 3 Then
                    ' Registra los productos contenidos en el panel en kilos
                    If cboAlmacenDestino.TipoProducto = 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                    End If
                    ' Registra el producto enviado en litros
                    If cboAlmacenDestino.TipoProducto <> 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
                    End If
                End If
                ' Entrada de productos del almacen
                If TipoMovimiento = 4 Then
                    ' Registra los productos contenidos en el panel en kilos
                    If cboAlmacenDestino.TipoProducto = 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
                    End If
                    ' Registra el producto enviado en litros
                    If cboAlmacenDestino.TipoProducto <> 5 Then
                        ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
                    End If
                End If
            End If
        End If
    End Sub

    ' Realiza los movimientos originados por el traspaso
    Public Function RealizarMovimientos(ByVal Año As Short, ByVal Folio As Integer, ByVal PesoBascula As String) As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim KilosOrigen, KilosDestino As Decimal
            Dim LitrosOrigen, LitrosDestino As Decimal

            Dim FechaMov As DateTime
            Dim Ano As Integer

            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            Ano = dtpFMovimiento.Value.Year
            'CAGP /I
            If cboAlmacenDestino.Text <> "" Then
                If cboAlmacenDestino.TipoProducto = 5 Then
                    KilosDestino = CType(lblKilos.Text, Decimal)
                    LitrosDestino = KilosDestino / CType(FactorDensidad, Decimal)
                Else
                    LitrosDestino = CType(lblKilos.Text, Decimal)
                    KilosDestino = LitrosDestino * CType(FactorDensidad, Decimal)
                End If
            Else
                If cboAlmacenOrigen.TipoProducto = 5 Then
                    KilosDestino = CType(lblKilos.Text, Decimal)
                    LitrosDestino = KilosDestino / CType(FactorDensidad, Decimal)
                Else
                    LitrosDestino = CType(lblKilos.Text, Decimal)
                    KilosDestino = LitrosDestino * CType(FactorDensidad, Decimal)
                End If
            End If

            'CAGP /F
            FechaMov = dtpFMovimiento.Value

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            If cboAlmacenOrigen.Text <> "" Then
                oFolioMovimientoAlmacen.Registrar(0, cboAlmacenOrigen.Identificador, 0, 3, 0)
            Else
                oFolioMovimientoAlmacen.Registrar(0, cboAlmacenDestino.Identificador, 0, 3, 0)
            End If

            Dim AlmacenOrigen As Integer
            If cboAlmacenOrigen.Text <> "" Then
                AlmacenOrigen = cboAlmacenOrigen.Identificador
            Else
                AlmacenOrigen = 0
                Producto = 1
            End If
            LitrosOrigen = LitrosDestino
            KilosOrigen = KilosDestino

            If AlmacenOrigen > 0 And cboAlmacenDestino.Text <> "" Then
                If cboAlmacenOrigen.Movil And cboAlmacenOrigen.TipoProducto <> 5 Then
                    If cboAlmacenDestino.TipoProducto = 5 Then
                        LitrosOrigen = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                        KilosOrigen = LitrosOrigen * CType(FactorDensidad, Decimal)
                    End If
                End If
            End If

            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrigen.Identificador, _
                                       FechaMov, KilosOrigen, LitrosOrigen, 3, dtpFTraslado.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            oMovimientoAlmacenS.CargaDatos()
            RegistraMovimientoProducto(cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador, 3)

            Dim oMovimientoAlmacenE As New cMovimientoAlmacen(0, 0, cboAlmacenDestino.Identificador, _
                                       FechaMov, KilosDestino, LitrosDestino, 4, dtpFTraslado.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario, cboCelulaDestino.Identificador)
            oMovimientoAlmacenE.CargaDatos()
            RegistraMovimientoProducto(cboAlmacenDestino.Identificador, oMovimientoAlmacenE.Identificador, 4)
            Dim oMovimientoEntreAlmacenes As New cMovimientoEntreAlmacenes(0, cboAlmacenDestino.Identificador, oMovimientoAlmacenE.Identificador, _
                                                         cboAlmacenOrigen.Identificador, oMovimientoAlmacenS.Identificador)

            oMovimientoEntreAlmacenes.CargaDatos()


            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                ' Registra la carga en autotanque turno
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(2)
                oAutotanqueTurno.CargaDatos(Ano, 0, dtpFTraslado.Value.Date, 0, _
                                        cboAlmacenOrigen.Celula, 1, 0, 1, 0, _
                                        oMovimientoAlmacenS.Identificador, cboAlmacenOrigen.Identificador, True, , , , , , CType(txtTotInicial.Text, Decimal), CType(txtTotFinal.Text, Decimal))
            End If

            'Llama a la funcion para almacenar la medicion fisica "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                AlmacenarMedicionFisica(oMovimientoAlmacenE.Identificador, cboAlmacenDestino.Identificador, oMovimientoAlmacenS.Identificador, cboAlmacenOrigen.Identificador)
            End If

            If Folio > 0 Then
                If PesoBascula = "ORIGEN" Then
                    Dim oAutotanque As New PortatilClasses.Consulta.cAutoTanqueTurno(5)
                    oAutotanque.CargaDatos(Año, 0, Now, Folio, 0, 3, 0, 0, 0, oMovimientoAlmacenS.Identificador, cboAlmacenOrigen.Identificador, False)
                Else
                    If PesoBascula = "DESTINO" Then
                        Dim oAutotanque As New PortatilClasses.Consulta.cAutoTanqueTurno(5)
                        oAutotanque.CargaDatos(Año, 0, Now, Folio, 0, 4, 0, 0, 0, oMovimientoAlmacenE.Identificador, cboAlmacenDestino.Identificador, False)
                    End If
                End If
            End If

            If GLOBAL_ImprimirFisicoTraslado = "1" Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(0, oMovimientoAlmacenE.Identificador, "ReporteTicketTraslado.rpt", pdImprimir.PrinterSettings.PrinterName)
                    ImprimirReporte(2, oMovimientoAlmacenE.Identificador, "ReporteTicketTrasladoFisico.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            Else
                If GLOBAL_Imprimir = "1" Then
                    Dim Impresoras As New Printing.PrinterSettings()
                    pdImprimir.PrinterSettings = Impresoras
                    pdImprimir.UseEXDialog = True
                    If pdImprimir.ShowDialog = DialogResult.OK Then
                        ImprimirReporte(0, oMovimientoAlmacenE.Identificador, "ReporteTicketTraslado.rpt", pdImprimir.PrinterSettings.PrinterName)
                    End If
                End If
            End If

            oMovimientoEntreAlmacenes = Nothing
            oMovimientoAlmacenS = Nothing
            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing
            Limpiar()
            ProductoPanel.BorrarDatos()
            Refresh()
            ActiveControl = cboCorporativoOrigen
            Cursor = Cursors.Default
        End If
    End Function

    ' Validar existencia
    Public Function VerificarExistencias(ByVal AlmacenOrigen As Integer, ByVal Cantidad As Decimal, _
    ByVal Producto As Integer) As Boolean
        Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(1, AlmacenOrigen, Producto, _
                                      Cantidad)
        VerificaExistencia.CargaDatos()
        If VerificaExistencia.Existencia = 0 Then
            Return False
        End If
        Return True
    End Function

    ' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    Private Function VerificarExistencias(ByVal Almacen As Integer, ByVal Cantidad As Decimal) As Boolean
        If cboxPorcentaje.Checked Then
            Return True
        Else
            If cboAlmacenDestino.Text <> "" And cboAlmacenOrigen.Text <> "" Then
                If cboAlmacenOrigen.TipoProducto <> 5 And cboAlmacenDestino.TipoProducto = 5 Then
                    If cboAlmacenOrigen.Movil Then
                        Dim Litros As Decimal = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                        Return (VerificarExistencias(Almacen, Litros, Producto))
                    Else
                        Return (ProductoPanel.VerificarExistenciasKilos(Almacen, Cantidad, Producto))
                    End If
                Else
                    Return (ProductoPanel.VerificarExistencias(Almacen, Cantidad, Producto))
                End If
            Else
                If cboAlmacenDestino.Text = "" Then
                    Return (ProductoPanel.VerificarExistencias(Almacen, Cantidad, Producto))
                Else
                    Return True
                End If
            End If
        End If
    End Function

    Private Function StockMinimo() As Boolean
        If cboxPorcentaje.Checked Then
            Return True
        Else
            If cboAlmacenDestino.Text <> "" Then
                If ProductoPanel.StockMinimo(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
    End Function

    Private Function LigaPesoBascula() As String
        Dim Valor As String = ""
        Dim PipaOrigen As Boolean = False
        Dim PipaDestino As Boolean = False

        If cboCelulaOrigen.Text = cboCelulaDestino.Text Then
            Valor = ""
        Else
            Dim SucursalOrigen As Short = CType(cboCelulaOrigen.Campo1, Short)
            Dim SucursalDestino As Short = CType(cboCelulaDestino.Campo1, Short)

            If SucursalOrigen = SucursalDestino Then
                Valor = ""
            Else
                If cboAlmacenOrigen.Text <> "" Then
                    If cboAlmacenOrigen.TipoProducto <> 5 And cboAlmacenOrigen.Movil Then
                        PipaOrigen = True
                    End If
                End If
                If cboAlmacenDestino.Text <> "" Then
                    If cboAlmacenDestino.TipoProducto <> 5 And cboAlmacenDestino.Movil Then
                        PipaDestino = True
                    End If
                End If
                Dim oBascula As PortatilClasses.Catalogo.cParametros
                oBascula = New PortatilClasses.Catalogo.cParametros(GLOBAL_Modulo, SucursalOrigen, CType(cboCorporativoOrigen.Identificador, Short), "BasculaInstalada")
                If PipaOrigen And oBascula.Valor = "1" Then
                    Valor = "ORIGEN"
                End If
                oBascula = New PortatilClasses.Catalogo.cParametros(GLOBAL_Modulo, SucursalDestino, CType(cboCorporativoOrigen.Identificador, Short), "BasculaInstalada")
                If PipaDestino And oBascula.Valor = "1" Then
                    Valor = "DESTINO"
                End If
            End If            
        End If
        Return Valor
    End Function

    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos(ByVal Año As Short, ByVal Folio As Integer, ByVal PesoBascula As String)
        If VerificarExistencias(cboAlmacenOrigen.Identificador, CType(lblKilos.Text, Decimal)) Then
            If StockMinimo() Then
                'Llama a la funcion de MedicionFisica para validar que se realize "CODIGO PACO"
                If GLOBAL_MedicionFisica Then
                    If MedicionFisica() Then
                        RealizarMovimientos(Año, Folio, PesoBascula)
                    End If
                Else
                    RealizarMovimientos(Año, Folio, PesoBascula)
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(5)
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = ProductoPanel.txtCantidad1
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(1)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
        End If
    End Sub

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacenDestino.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
            dtpFTraslado.Value = Fecha
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = FechaActual()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Carga el producto del almacén
    Private Sub ProductoContenedor()
        If cboAlmacenOrigen.Text <> "" Then
            Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacenOrigen.Identificador)
            oProductoContenedor.CargaDatos()
            Producto = oProductoContenedor.Identificador
            oProductoContenedor = Nothing
        End If
    End Sub

    ' Habilita los privilegios del usuario, para ver si puede realizar transpasos entre empresas
    Private Sub HabilitarEmpresa()
        cboCorporativoOrigen.PosicionaCombo(GLOBAL_Empresa)
        If cboCorporativoOrigen.Text <> "" Then
            'cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoOrigen.Identificador, GLOBAL_Usuario)
            cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrigen.Identificador, Short), 0, 0, "")
            cboCelulaOrigen.PosicionaCombo(GLOBAL_Celula)
            'cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoOrigen.Identificador, GLOBAL_Usuario)
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrigen.Identificador, Short), 0, 0, "")
            cboCelulaDestino.PosicionaCombo(GLOBAL_Celula)
        End If
        'If cboCelulaOrigen.Text <> "" Then
        If GLOBAL_TrasladoCompleto Then
            cboAlmacenOrigen.CargaDatos(15, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
        Else
            cboAlmacenOrigen.CargaDatos(13, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
        End If
        'End If
        If cboAlmacenOrigen.Text <> "" Then
            ProductoContenedor()
        End If
        HabilitarAlmacenDestino()
        If GLOBAL_VerEmpresas = False Then
            cboCorporativoOrigen.Enabled = False
            ActiveControl = cboAlmacenOrigen
        End If
    End Sub

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora(ByVal Impresora As String)
        If Impresora = "" Then
            Dim Impresoras As New Printing.PrinterSettings()
            rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
        Else
            rptReporte.PrintOptions.PrinterName = Impresora
        End If
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
    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal NombreTicket As String, ByVal Impresora As String)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(GLOBAL_RutaReportes & "\" & NombreTicket)

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
                EstablecerImpresora(Impresora)
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

    ' verifica si al informacion ya ha sido verificada y/o aprobada
    ' 20060617CAGP$011
    Private Function InformacionVerificada() As Boolean
        Dim Res As Boolean = False
        If cboAlmacenOrigen.Text <> "" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                    cboAlmacenOrigen.Identificador, 0) ' 20060822CAGP$001
            If oMovimiento.RealizarMovimiento() = False Then
                Res = True
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFMovimiento
            End If
        End If
        If cboAlmacenDestino.Text <> "" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                    cboAlmacenDestino.Identificador, 0) ' 20060822CAGP$001
            If oMovimiento.RealizarMovimiento() = False Then
                Res = True
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFMovimiento
            End If
        End If
        Return Res
    End Function

    Private Sub ActivaPorcentaje()
        If cboAlmacenDestino.Text = "" Then
            cboxPorcentaje.Visible = False
        Else
            If cboAlmacenDestino.Movil And cboAlmacenDestino.TipoProducto <> 5 And cboAlmacenOrigen.Text = "" Then
                cboxPorcentaje.Visible = True
            ElseIf cboAlmacenOrigen.Text <> "" Then
                If cboAlmacenDestino.Movil And cboAlmacenDestino.TipoProducto <> 5 And cboAlmacenOrigen.Movil = False _
                And cboAlmacenOrigen.TipoProducto <> 5 Then
                    cboxPorcentaje.Visible = True
                Else
                    cboxPorcentaje.Visible = False
                End If
            Else
                cboxPorcentaje.Visible = False
            End If
        End If
    End Sub

    ' Inicialización de la forma
    Private Sub frmMovimientoTranspaso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativoOrigen
        ValidarRangoFechas()
        Limpiar()
        cboCorporativoOrigen.CargaDatos(0)
        HabilitarEmpresa()

        If cboAlmacenDestino.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
            If cboAlmacenDestino.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    ' Carga los datos del almacén origen dependiendo de la empresa origen seleccionada
    Private Sub cboCorporativoOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCorporativoOrigen.SelectedIndexChanged
        If cboCorporativoOrigen.Focused And cboCorporativoOrigen.Text <> "" Then
            Cursor = Cursors.WaitCursor
            'cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoOrigen.Identificador, GLOBAL_Usuario)
            cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrigen.Identificador, Short), 0, 0, "")
            'cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoOrigen.Identificador, GLOBAL_Usuario)
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrigen.Identificador, Short), 0, 0, "")
            'If cboCelulaOrigen.Text <> "" Then
            If GLOBAL_TrasladoCompleto Then
                cboAlmacenOrigen.CargaDatos(15, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            Else
                cboAlmacenOrigen.CargaDatos(13, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            End If
            'End If
            HabilitarAlmacenDestino()
            If cboAlmacenOrigen.Text <> "" Then
                ProductoContenedor()
            End If
            HabilitarAceptar()

            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los productos del almacén seleccionado
    Private Sub cboAlmacenDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenDestino.SelectedIndexChanged
        If cboAlmacenDestino.Focused And cboAlmacenDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ProductoPanel.CargarProducto(cboAlmacenDestino.Identificador, cboAlmacenDestino.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
            If cboAlmacenDestino.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
            HabilitarAceptar()
            lblKilos.Text = "0.00"
            ActivaTotalizador()
            ActivaPorcentaje()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los productos del almacén origen seleccionado
    Private Sub cboAlmacenOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenOrigen.SelectedIndexChanged
        If cboAlmacenOrigen.Focused And cboAlmacenOrigen.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ProductoContenedor()
            'cboAlmacenDestino.PosicionarInicio()
            HabilitarAlmacenDestino()
            HabilitarAceptar()
            OperacionTotalizador(0)
            ActivaPorcentaje()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Evento del control btnAceptar, registra la información pedida
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If InformacionVerificada() = False Then  ' 20060617CAGP$011
            Dim PesoBascula As String = LigaPesoBascula()
            If PesoBascula = "" Or GLOBAL_TrasladosBascula = "0" Then
                ValidarMovimientos(0, 0, "")
            Else
                Dim oFolio As New frmFolioBascula()
                oFolio.Año = CType(dtpFMovimiento.Value.Year, Short)

                oFolio.ShowDialog()
                If oFolio.Folio > 0 Then
                    ValidarMovimientos(oFolio.Año, oFolio.Folio, PesoBascula)
                Else
                    If oFolio.ExisteFolio = False Then
                        ValidarMovimientos(0, 0, "")
                    End If
                End If

            End If
        End If
    End Sub

    ' Evento del control lblKilos
    Private Sub lblKilos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblKilos.TextChanged
        HabilitarAceptar()
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboCorporativoOrigen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCorporativoOrigen.KeyDown, cboAlmacenOrigen.KeyDown, cboAlmacenDestino.KeyDown, dtpFMovimiento.KeyDown, dtpFTraslado.KeyDown, cboCelulaDestino.KeyDown, cboCelulaOrigen.KeyDown, ProductoPanel.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub txtTotalizador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotInicial.KeyDown, txtTotFinal.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If

    End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        lblKilos.Text = Format(ProductoPanel.SumarKilos(), "n")
        If cboxPorcentaje.Checked And lblKilos.Text <> "0.00" Then
            cboxPorcentaje.Checked = False
        End If
        If cboAlmacenDestino.Text <> "" And cboAlmacenOrigen.Text <> "" Then
            If cboAlmacenOrigen.TipoProducto = 1 And cboAlmacenDestino.TipoProducto = 1 Then
                If txtTotInicial.Text.Length > 0 Then
                    txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal) + ProductoPanel.SumarKilos).ToString("N2")
                End If
            End If
        Else
            If cboAlmacenOrigen.Text <> "" Then
                If cboAlmacenOrigen.TipoProducto = 1 And lblKilos.Text <> "" Then
                    If txtTotInicial.Text.Length > 0 Then
                        If cboAlmacenDestino.Text <> "" Then
                            txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal) + ProductoPanel.SumarKilos).ToString("N2")
                        Else
                            txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal)).ToString("N2")
                        End If
                        'txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal) + ProductoPanel.SumarKilos).ToString("N2")
                    End If
                End If
            End If
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmMovimientoTraspaso_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If cboAlmacenOrigen.Text <> "" Then
            Dim ofrmExistencias As New frmExistencias(cboAlmacenOrigen.Identificador, cboAlmacenOrigen.Text)
            ofrmExistencias.ShowDialog()
            ofrmExistencias = Nothing
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(69)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboCelulaOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelulaOrigen.SelectedIndexChanged
        If cboCelulaOrigen.Text <> "" And cboCelulaOrigen.Focused Then
            If GLOBAL_TrasladoCompleto Then
                cboAlmacenOrigen.CargaDatos(15, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            Else
                cboAlmacenOrigen.CargaDatos(13, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            End If
            If cboAlmacenOrigen.Text <> "" Then
                ProductoContenedor()
            End If
            HabilitarAlmacenDestino()
            HabilitarAceptar()
            OperacionTotalizador(0)
        End If
    End Sub

    Private Sub cboCelulaDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelulaDestino.SelectedIndexChanged
        If cboCelulaDestino.Text <> "" And cboCelulaDestino.Focused Then
            HabilitarAlmacenDestino()
            HabilitarAceptar()
            OperacionTotalizador(1)
        End If
    End Sub

    Private Sub cboAlmacenOrigen_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenOrigen.Leave
        If cboAlmacenOrigen.Text <> "" Then
            ConsultaTotalizador()
        End If
    End Sub

    Private Sub txtTotFinal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotFinal.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub cboxPorcentaje_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxPorcentaje.CheckedChanged
        If cboxPorcentaje.Checked And lblKilos.Text <> "0.00" Then
            ProductoPanel.BorrarDatos()
            ProductoPanel.CargarExistencias(cboAlmacenDestino.Identificador)
        End If
        HabilitarAceptar()
    End Sub
End Class
